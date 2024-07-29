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
            apiKeyField = new TextBox();
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            sendRequest = new Button();
            urlField = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // apiKeyField
            // 
            apiKeyField.Location = new Point(181, 10);
            apiKeyField.Name = "apiKeyField";
            apiKeyField.Size = new Size(607, 27);
            apiKeyField.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 13);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 1;
            label1.Text = "Place API Key here";
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
            sendRequest.Location = new Point(12, 83);
            sendRequest.Name = "sendRequest";
            sendRequest.Size = new Size(141, 29);
            sendRequest.TabIndex = 3;
            sendRequest.Text = "Add New User";
            sendRequest.UseVisualStyleBackColor = true;
            sendRequest.Click += sendRequest_Click;
            // 
            // urlField
            // 
            urlField.Location = new Point(181, 43);
            urlField.Name = "urlField";
            urlField.Size = new Size(607, 27);
            urlField.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 40);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 5;
            label2.Text = "Plase URL here";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(urlField);
            Controls.Add(sendRequest);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            Controls.Add(apiKeyField);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(818, 497);
            MinimizeBox = false;
            MinimumSize = new Size(818, 497);
            Name = "Form1";
            Text = "SDP API";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox apiKeyField;
        private Label label1;
        private RichTextBox richTextBox1;
        private Button sendRequest;
        private TextBox urlField;
        private Label label2;
    }
}
