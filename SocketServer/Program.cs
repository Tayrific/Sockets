using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketServer
{
    class ChatClient
    {
        public static Hashtable AllClients = new Hashtable();

        //information about the client
        private Socket _client;
        private string _clientIP;
        private string _clientNick;
        private byte[] data = new byte[128];
        private bool ReceiveNick = true;

        public ChatClient(Socket client)
        {
            _client = client;
            _clientIP = client.RemoteEndPoint.ToString();
            AllClients.Add(_clientIP, this);
            _client.BeginReceive(data, 0, data.Length, SocketFlags.None, ReceiveMessage, null);
        }

        public void ReceiveMessage(IAsyncResult ar)
        {
            int bytesRead;
            try
            {
                bytesRead = _client.EndReceive(ar);
                if (bytesRead < 1)
                {
                    AllClients.Remove(_clientIP);
                    Broadcast($"{_clientNick} has left the chat.");
                    _client.Close();
                    return;
                }
                else
                {
                    string messageReceived = Encoding.ASCII.GetString(data, 0, bytesRead);
                    if (ReceiveNick)
                    {
                        _clientNick = messageReceived;
                        Broadcast($"{_clientNick} has joined the chat.");
                        ReceiveNick = false;
                    }
                    else
                    {
                        Broadcast($"{_clientNick}: {messageReceived}");
                    }
                }
                _client.BeginReceive(data, 0, data.Length, SocketFlags.None, ReceiveMessage, null);
            }
            catch (Exception ex)
            {
                AllClients.Remove(_clientIP);
                Broadcast($"{_clientNick} has left the chat.");
                _client.Close();
            }
        }

        public void Broadcast(string message)
        {
            Console.WriteLine(message);
            byte[] bytesToSend = Encoding.ASCII.GetBytes(message + Environment.NewLine);
            foreach (DictionaryEntry c in AllClients)
            {
                ChatClient chatClient = (ChatClient)c.Value;
                try
                {
                    chatClient._client.Send(bytesToSend);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //Create an object of socket class 
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Create an object of an IP Address.socket listning on any ip address.
            IPAddress ipaddr = IPAddress.Any;
            // Define IP ENDP POINT
            IPEndPoint ipep = new IPEndPoint(ipaddr, 25000);
            //Bind socket to ip end point.
            try
            {
                listenerSocket.Bind(ipep);
                // Call listen method on the Listener socket object, pass the a number to signify how many 
                //clients can wait for a connection while the system is busy handling another connection
                listenerSocket.Listen(5);
                // Call Accept method on the listener socket.
                //Print out client ip end point
                Console.WriteLine("Server is listening on port 25000...");
  
                while (true)
                {
                    // Accept a new client connection
                    Socket clientSocket = listenerSocket.Accept();
                    Console.WriteLine("Client connected: " + clientSocket.RemoteEndPoint.ToString());

                    // Create a new ChatClient instance to handle the new client
                    ChatClient user = new ChatClient(clientSocket);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
            finally
            {
                listenerSocket.Close();
            }
        }
    }
}
