namespace Client
{
    partial class ClientxClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbChat = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMess = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbChat
            // 
            this.lbChat.FormattingEnabled = true;
            this.lbChat.Location = new System.Drawing.Point(12, 12);
            this.lbChat.Name = "lbChat";
            this.lbChat.Size = new System.Drawing.Size(320, 264);
            this.lbChat.TabIndex = 11;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(276, 289);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(56, 19);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Gui";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMess
            // 
            this.txtMess.Location = new System.Drawing.Point(11, 289);
            this.txtMess.Margin = new System.Windows.Forms.Padding(2);
            this.txtMess.Name = "txtMess";
            this.txtMess.Size = new System.Drawing.Size(234, 20);
            this.txtMess.TabIndex = 9;
            // 
            // ClientxClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 321);
            this.Controls.Add(this.lbChat);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMess);
            this.Name = "ClientxClient";
            this.Text = "ClientxClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbChat;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMess;
    }
}