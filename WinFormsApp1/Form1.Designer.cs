namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            historyTxt = new TextBox();
            messageTxt = new TextBox();
            sendBtn = new Button();
            groupBox2 = new GroupBox();
            portTxt = new TextBox();
            IPTxt = new TextBox();
            portLabel = new Label();
            signInBtn = new Button();
            IPLabel = new Label();
            nickTxt = new TextBox();
            label1 = new Label();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // historyTxt
            // 
            historyTxt.BackColor = Color.Azure;
            historyTxt.Location = new Point(15, 135);
            historyTxt.Multiline = true;
            historyTxt.Name = "historyTxt";
            historyTxt.ReadOnly = true;
            historyTxt.Size = new Size(352, 374);
            historyTxt.TabIndex = 3;
            // 
            // messageTxt
            // 
            messageTxt.BackColor = Color.White;
            messageTxt.Enabled = false;
            messageTxt.Location = new Point(15, 531);
            messageTxt.Name = "messageTxt";
            messageTxt.Size = new Size(257, 23);
            messageTxt.TabIndex = 4;
            // 
            // sendBtn
            // 
            sendBtn.Enabled = false;
            sendBtn.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            sendBtn.Location = new Point(282, 527);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(85, 27);
            sendBtn.TabIndex = 5;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(portTxt);
            groupBox2.Controls.Add(IPTxt);
            groupBox2.Controls.Add(portLabel);
            groupBox2.Controls.Add(signInBtn);
            groupBox2.Controls.Add(IPLabel);
            groupBox2.Controls.Add(nickTxt);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(8, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(359, 116);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            // 
            // portTxt
            // 
            portTxt.BackColor = Color.White;
            portTxt.Location = new Point(53, 52);
            portTxt.Name = "portTxt";
            portTxt.Size = new Size(211, 23);
            portTxt.TabIndex = 9;
            // 
            // IPTxt
            // 
            IPTxt.BackColor = Color.White;
            IPTxt.Location = new Point(53, 19);
            IPTxt.Name = "IPTxt";
            IPTxt.Size = new Size(211, 23);
            IPTxt.TabIndex = 11;
            // 
            // portLabel
            // 
            portLabel.AutoSize = true;
            portLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            portLabel.Location = new Point(0, 52);
            portLabel.Name = "portLabel";
            portLabel.Size = new Size(43, 20);
            portLabel.TabIndex = 8;
            portLabel.Text = "Port:";
            // 
            // signInBtn
            // 
            signInBtn.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            signInBtn.Location = new Point(270, 86);
            signInBtn.Name = "signInBtn";
            signInBtn.Size = new Size(85, 27);
            signInBtn.TabIndex = 2;
            signInBtn.Text = "Sign In";
            signInBtn.UseVisualStyleBackColor = true;
            signInBtn.Click += signInBtn_Click;
            // 
            // IPLabel
            // 
            IPLabel.AutoSize = true;
            IPLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            IPLabel.Location = new Point(0, 19);
            IPLabel.Name = "IPLabel";
            IPLabel.Size = new Size(31, 20);
            IPLabel.TabIndex = 10;
            IPLabel.Text = "IP: ";
            // 
            // nickTxt
            // 
            nickTxt.BackColor = Color.White;
            nickTxt.Location = new Point(53, 86);
            nickTxt.Name = "nickTxt";
            nickTxt.Size = new Size(211, 23);
            nickTxt.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 89);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Nick: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FloralWhite;
            ClientSize = new Size(389, 580);
            Controls.Add(groupBox2);
            Controls.Add(sendBtn);
            Controls.Add(messageTxt);
            Controls.Add(historyTxt);
            ForeColor = Color.Black;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox historyTxt;
        private TextBox messageTxt;
        private Button sendBtn;
        private GroupBox groupBox2;
        private Button signInBtn;
        private TextBox nickTxt;
        private Label label1;
        private TextBox IPTxt;
        private Label IPLabel;
        private TextBox portTxt;
        private Label portLabel;
    }
}
