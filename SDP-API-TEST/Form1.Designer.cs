namespace SDP_API_TEST
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
            richTextBox1 = new RichTextBox();
            sendRequest = new Button();
            progressBar1 = new ProgressBar();
            modifyUser = new Button();
            AddRequestBtn = new Button();
            CloseRequestBtn = new Button();
            GetUserRequestsBtn = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(4, 233);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(784, 205);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // sendRequest
            // 
            sendRequest.Location = new Point(12, 12);
            sendRequest.Name = "sendRequest";
            sendRequest.Size = new Size(141, 29);
            sendRequest.TabIndex = 3;
            sendRequest.Text = "Add New User";
            sendRequest.UseVisualStyleBackColor = true;
            sendRequest.Click += sendRequest_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(181, 12);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(607, 29);
            progressBar1.TabIndex = 6;
            // 
            // modifyUser
            // 
            modifyUser.Location = new Point(12, 47);
            modifyUser.Name = "modifyUser";
            modifyUser.Size = new Size(141, 29);
            modifyUser.TabIndex = 7;
            modifyUser.Text = "Remove  User";
            modifyUser.UseVisualStyleBackColor = true;
            modifyUser.Click += modifyUser_Click;
            // 
            // AddRequestBtn
            // 
            AddRequestBtn.Location = new Point(12, 82);
            AddRequestBtn.Name = "AddRequestBtn";
            AddRequestBtn.Size = new Size(141, 29);
            AddRequestBtn.TabIndex = 8;
            AddRequestBtn.Text = "Add Request";
            AddRequestBtn.UseVisualStyleBackColor = true;
            AddRequestBtn.Click += AddRequestBtn_Click;
            // 
            // CloseRequestBtn
            // 
            CloseRequestBtn.Location = new Point(12, 117);
            CloseRequestBtn.Name = "CloseRequestBtn";
            CloseRequestBtn.Size = new Size(141, 29);
            CloseRequestBtn.TabIndex = 9;
            CloseRequestBtn.Text = "Close Request";
            CloseRequestBtn.UseVisualStyleBackColor = true;
            CloseRequestBtn.Click += CloseRequestBtn_Click;
            // 
            // GetUserRequestsBtn
            // 
            GetUserRequestsBtn.Location = new Point(12, 152);
            GetUserRequestsBtn.Name = "GetUserRequestsBtn";
            GetUserRequestsBtn.Size = new Size(141, 29);
            GetUserRequestsBtn.TabIndex = 10;
            GetUserRequestsBtn.Text = "Get User Requests";
            GetUserRequestsBtn.UseVisualStyleBackColor = true;
            GetUserRequestsBtn.Click += GetUserRequestsBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(GetUserRequestsBtn);
            Controls.Add(CloseRequestBtn);
            Controls.Add(AddRequestBtn);
            Controls.Add(modifyUser);
            Controls.Add(progressBar1);
            Controls.Add(sendRequest);
            Controls.Add(richTextBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(818, 497);
            MinimizeBox = false;
            MinimumSize = new Size(818, 497);
            Name = "Form1";
            Text = "SDP API";
            ResumeLayout(false);
        }

        #endregion
        private RichTextBox richTextBox1;
        private Button sendRequest;
        private ProgressBar progressBar1;
        private Button modifyUser;
        private Button AddRequestBtn;
        private Button CloseRequestBtn;
        private Button GetUserRequestsBtn;
    }
}
