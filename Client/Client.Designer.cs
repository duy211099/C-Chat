namespace Client
{
    partial class Client
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
            this.btnSendAll = new System.Windows.Forms.Button();
            this.txtChatAll = new System.Windows.Forms.TextBox();
            this.lbChatAll = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblConnections = new System.Windows.Forms.Label();
            this.lbOnline = new System.Windows.Forms.ListBox();
            this.btnSendToServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSendAll
            // 
            this.btnSendAll.Location = new System.Drawing.Point(465, 175);
            this.btnSendAll.Name = "btnSendAll";
            this.btnSendAll.Size = new System.Drawing.Size(75, 23);
            this.btnSendAll.TabIndex = 5;
            this.btnSendAll.Text = "Send";
            this.btnSendAll.UseVisualStyleBackColor = true;
            this.btnSendAll.Click += new System.EventHandler(this.btnSendAll_Click);
            // 
            // txtChatAll
            // 
            this.txtChatAll.Location = new System.Drawing.Point(221, 177);
            this.txtChatAll.Name = "txtChatAll";
            this.txtChatAll.Size = new System.Drawing.Size(238, 20);
            this.txtChatAll.TabIndex = 4;
            // 
            // lbChatAll
            // 
            this.lbChatAll.FormattingEnabled = true;
            this.lbChatAll.Location = new System.Drawing.Point(221, 9);
            this.lbChatAll.Name = "lbChatAll";
            this.lbChatAll.Size = new System.Drawing.Size(315, 160);
            this.lbChatAll.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "người dùng online.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Hiện tại đang có";
            // 
            // lblConnections
            // 
            this.lblConnections.AutoSize = true;
            this.lblConnections.Location = new System.Drawing.Point(94, 9);
            this.lblConnections.Name = "lblConnections";
            this.lblConnections.Size = new System.Drawing.Size(13, 13);
            this.lblConnections.TabIndex = 29;
            this.lblConnections.Text = "0";
            // 
            // lbOnline
            // 
            this.lbOnline.FormattingEnabled = true;
            this.lbOnline.Location = new System.Drawing.Point(12, 25);
            this.lbOnline.Name = "lbOnline";
            this.lbOnline.Size = new System.Drawing.Size(203, 173);
            this.lbOnline.TabIndex = 31;
            this.lbOnline.SelectedIndexChanged += new System.EventHandler(this.lbOnline_SelectedIndexChanged);
            this.lbOnline.DoubleClick += new System.EventHandler(this.lbOnline_DoubleClick);
            this.lbOnline.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbOnline_MouseDoubleClick);
            // 
            // btnSendToServer
            // 
            this.btnSendToServer.Location = new System.Drawing.Point(438, 203);
            this.btnSendToServer.Name = "btnSendToServer";
            this.btnSendToServer.Size = new System.Drawing.Size(102, 23);
            this.btnSendToServer.TabIndex = 35;
            this.btnSendToServer.Text = "Chat with Server";
            this.btnSendToServer.UseVisualStyleBackColor = true;
            this.btnSendToServer.Click += new System.EventHandler(this.btnSendToServer_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 230);
            this.Controls.Add(this.btnSendToServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblConnections);
            this.Controls.Add(this.lbOnline);
            this.Controls.Add(this.lbChatAll);
            this.Controls.Add(this.btnSendAll);
            this.Controls.Add(this.txtChatAll);
            this.Name = "Client";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendAll;
        private System.Windows.Forms.TextBox txtChatAll;
        private System.Windows.Forms.ListBox lbChatAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConnections;
        private System.Windows.Forms.ListBox lbOnline;
        private System.Windows.Forms.Button btnSendToServer;
    }
}

