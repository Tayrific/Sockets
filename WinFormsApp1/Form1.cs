using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Socket client;
        private byte[] buffer = new byte[128];
        private Thread receiveThread; //my application kept freezing and after some research i figured using threads will help as it can perform taks concurrently
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void signInBtn_Click(object sender, EventArgs e)
        {
            if (signInBtn.Text == "Sign In")
            {

                try
                {
                    client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPAddress ipaddr = null;

                    string strIPAddress = IPTxt.Text;
                    string strPortInput = portTxt.Text;
                    string nickName = nickTxt.Text;


                    int nPortInput = 0;

                    if (strIPAddress == "") strIPAddress = "127.0.0.1";
                    if (strPortInput == "") strPortInput = "25000";


                    if (!IPAddress.TryParse(strIPAddress, out ipaddr))
                    {
                        MessageBox.Show("Invalid server IP supplied.");
                        return;
                    }
                    if (!int.TryParse(strPortInput.Trim(), out nPortInput))
                    {
                        MessageBox.Show("Invalid port number supplied.");
                        return;
                    }
                    if (nickName.Length < 1)
                    {
                        MessageBox.Show("Please enter a nick name.");
                        return;
                    }

                    if (nPortInput <= 0 || nPortInput > 65535)
                    {
                        MessageBox.Show("Port number must be between 0 and 65535.");
                        return;
                    }
                    
                    signInBtn.Text = "Sign Out";
                    IPTxt.Enabled = false;
                    portTxt.Enabled = false;
                    sendBtn.Enabled = true;  
                    messageTxt.Enabled = true;
                    

                    //MessageBox.Show(string.Format("IPAddress: {0} - Port: {1} - Name: {2}", ipaddr.ToString(), nPortInput, nickName));
                    client.Connect(ipaddr, nPortInput);
                  
                    byte[] nickBytes = Encoding.ASCII.GetBytes(nickName);
                    client.Send(nickBytes);

                    //socket communication
                    receiveThread = new Thread(ReceiveMessages);
                    receiveThread.IsBackground = true;
                    receiveThread.Start();

                    UpdateHistory("Connected as " + nickName + Environment.NewLine);

                    SendMessage(messageTxt.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                //---disconnect from server---
                Disconnect();
                signInBtn.Text = "Sign In";
                sendBtn.Enabled = false;
                messageTxt.Enabled = false;
                IPTxt.Enabled = true;
                portTxt.Enabled = true;
                
            }
        }
        public void SendMessage(string message)
        {
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(message);
                client.Send(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            SendMessage(messageTxt.Text);
            messageTxt.Clear();
        }

        private void ReceiveMessages()
        {
            try
            {
                while (true)
                {
                    int bytesRead = client.Receive(buffer);
                    if (bytesRead > 0)
                    {
                        string receivedMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        UpdateHistory(receivedMessage + Environment.NewLine);
                    }
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Socket exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        public delegate void delUpdateHistory(string str);
        public void UpdateHistory(string str)
        {
            if (InvokeRequired)
            {
                Invoke(new delUpdateHistory(UpdateHistory), str);
            }
            else
            {
                historyTxt.AppendText(str);
            }
        }

        public void Disconnect()
        {
            if (client != null)
            {
                if (client.Connected)
                {
                    client.Shutdown(SocketShutdown.Both);
                }
                client.Close();
                client.Dispose();
            }
        }
    }
}
