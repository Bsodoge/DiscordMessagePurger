namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.guildsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.friendsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.friendsLabel = new System.Windows.Forms.Label();
            this.serversLabel = new System.Windows.Forms.Label();
            this.errorAuth = new System.Windows.Forms.Label();
            this.messageContainer = new System.Windows.Forms.ListView();
            this.Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(254)))));
            this.textBox1.Location = new System.Drawing.Point(12, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(425, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(456, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // guildsContainer
            // 
            this.guildsContainer.AutoScroll = true;
            this.guildsContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guildsContainer.Location = new System.Drawing.Point(421, 94);
            this.guildsContainer.Name = "guildsContainer";
            this.guildsContainer.Size = new System.Drawing.Size(363, 174);
            this.guildsContainer.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(683, 274);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 24);
            this.button2.TabIndex = 4;
            this.button2.Text = "Yes";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(624, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Purge all?";
            // 
            // friendsContainer
            // 
            this.friendsContainer.AutoScroll = true;
            this.friendsContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.friendsContainer.Location = new System.Drawing.Point(12, 94);
            this.friendsContainer.Name = "friendsContainer";
            this.friendsContainer.Size = new System.Drawing.Size(403, 174);
            this.friendsContainer.TabIndex = 3;
            // 
            // friendsLabel
            // 
            this.friendsLabel.AutoSize = true;
            this.friendsLabel.Location = new System.Drawing.Point(9, 78);
            this.friendsLabel.Name = "friendsLabel";
            this.friendsLabel.Size = new System.Drawing.Size(55, 13);
            this.friendsLabel.TabIndex = 6;
            this.friendsLabel.Text = "Friends: 0";
            // 
            // serversLabel
            // 
            this.serversLabel.AutoSize = true;
            this.serversLabel.Location = new System.Drawing.Point(418, 78);
            this.serversLabel.Name = "serversLabel";
            this.serversLabel.Size = new System.Drawing.Size(57, 13);
            this.serversLabel.TabIndex = 7;
            this.serversLabel.Text = "Servers: 0";
            // 
            // errorAuth
            // 
            this.errorAuth.AutoSize = true;
            this.errorAuth.ForeColor = System.Drawing.Color.Red;
            this.errorAuth.Location = new System.Drawing.Point(118, 9);
            this.errorAuth.Name = "errorAuth";
            this.errorAuth.Size = new System.Drawing.Size(0, 13);
            this.errorAuth.TabIndex = 9;
            // 
            // messageContainer
            // 
            this.messageContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.messageContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageContainer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Author,
            this.Message});
            this.messageContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(254)))));
            this.messageContainer.FullRowSelect = true;
            this.messageContainer.GridLines = true;
            this.messageContainer.HideSelection = false;
            this.messageContainer.Location = new System.Drawing.Point(12, 304);
            this.messageContainer.MultiSelect = false;
            this.messageContainer.Name = "messageContainer";
            this.messageContainer.Size = new System.Drawing.Size(772, 142);
            this.messageContainer.TabIndex = 10;
            this.messageContainer.UseCompatibleStateImageBehavior = false;
            this.messageContainer.View = System.Windows.Forms.View.Details;
            // 
            // Author
            // 
            this.Author.Text = "Author";
            // 
            // Message
            // 
            this.Message.Text = "Message";
            this.Message.Width = 712;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Authorization Code:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(141)))), ((int)(((byte)(211)))));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(254)))));
            this.linkLabel1.Location = new System.Drawing.Point(9, 51);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(183, 13);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "How do I get my authorization code?";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(121)))), ((int)(((byte)(184)))));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(790, 451);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.messageContainer);
            this.Controls.Add(this.errorAuth);
            this.Controls.Add(this.serversLabel);
            this.Controls.Add(this.friendsLabel);
            this.Controls.Add(this.friendsContainer);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guildsContainer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(254)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Discord Message Purger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel guildsContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel friendsContainer;
        private System.Windows.Forms.Label friendsLabel;
        private System.Windows.Forms.Label serversLabel;
        private System.Windows.Forms.Label errorAuth;
        private System.Windows.Forms.ListView messageContainer;
        private System.Windows.Forms.ColumnHeader Author;
        private System.Windows.Forms.ColumnHeader Message;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

