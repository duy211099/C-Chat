namespace WindowsFormsApp1
{
    partial class Server
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
            this.lblConnections = new System.Windows.Forms.Label();
            this.lvChatAll = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbOnline = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendAll = new System.Windows.Forms.Button();
            this.txtChatAll = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblConnections
            // 
            this.lblConnections.AutoSize = true;
            this.lblConnections.Location = new System.Drawing.Point(85, 3);
            this.lblConnections.Name = "lblConnections";
            this.lblConnections.Size = new System.Drawing.Size(13, 13);
            this.lblConnections.TabIndex = 0;
            this.lblConnections.Text = "0";
            // 
            // lvChatAll
            // 
            this.lvChatAll.FormattingEnabled = true;
            this.lvChatAll.Location = new System.Drawing.Point(2, 3);
            this.lvChatAll.Margin = new System.Windows.Forms.Padding(2);
            this.lvChatAll.Name = "lvChatAll";
            this.lvChatAll.Size = new System.Drawing.Size(561, 329);
            this.lvChatAll.TabIndex = 23;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbOnline);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lblConnections);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSendAll);
            this.splitContainer1.Panel2.Controls.Add(this.txtChatAll);
            this.splitContainer1.Panel2.Controls.Add(this.lvChatAll);
            this.splitContainer1.Size = new System.Drawing.Size(776, 371);
            this.splitContainer1.SplitterDistance = 209;
            this.splitContainer1.TabIndex = 26;
            // 
            // lbOnline
            // 
            this.lbOnline.FormattingEnabled = true;
            this.lbOnline.Location = new System.Drawing.Point(3, 20);
            this.lbOnline.Name = "lbOnline";
            this.lbOnline.Size = new System.Drawing.Size(203, 342);
            this.lbOnline.TabIndex = 27;
            this.lbOnline.SelectedIndexChanged += new System.EventHandler(this.lbOnline_SelectedIndexChanged);
            this.lbOnline.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbOnline_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "người dùng online.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Hiện tại đang có";
            // 
            // btnSendAll
            // 
            this.btnSendAll.Location = new System.Drawing.Point(479, 339);
            this.btnSendAll.Name = "btnSendAll";
            this.btnSendAll.Size = new System.Drawing.Size(81, 23);
            this.btnSendAll.TabIndex = 25;
            this.btnSendAll.Text = "Gửi";
            this.btnSendAll.UseVisualStyleBackColor = true;
            this.btnSendAll.Click += new System.EventHandler(this.btnSendAll_Click);
            // 
            // txtChatAll
            // 
            this.txtChatAll.Location = new System.Drawing.Point(3, 341);
            this.txtChatAll.Name = "txtChatAll";
            this.txtChatAll.Size = new System.Drawing.Size(470, 20);
            this.txtChatAll.TabIndex = 24;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 395);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Server";
            this.Text = "Server";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Server_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Server_KeyPress_1);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblConnections;
        private System.Windows.Forms.ListBox lvChatAll;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbOnline;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendAll;
        private System.Windows.Forms.TextBox txtChatAll;
    }
}

