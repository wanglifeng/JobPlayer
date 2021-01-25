namespace JobPlayer
{
    partial class SearchBar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchBar));
            this.SearchBarTxtBox = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.SearchGroup = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // SearchBarTxtBox
            // 
            this.SearchBarTxtBox.BackColor = System.Drawing.Color.LightGray;
            this.SearchBarTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchBarTxtBox.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SearchBarTxtBox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.SearchBarTxtBox.Location = new System.Drawing.Point(0, 0);
            this.SearchBarTxtBox.Name = "SearchBarTxtBox";
            this.SearchBarTxtBox.Size = new System.Drawing.Size(425, 41);
            this.SearchBarTxtBox.TabIndex = 1;
            this.SearchBarTxtBox.Text = "搜索";
            this.SearchBarTxtBox.TextChanged += new System.EventHandler(this.SearchBarTxtBox_TextChanged);
            this.SearchBarTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBarTxtBox_KeyDown);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // SearchGroup
            // 
            this.SearchGroup.Location = new System.Drawing.Point(1, 35);
            this.SearchGroup.Name = "SearchGroup";
            this.SearchGroup.Size = new System.Drawing.Size(425, 301);
            this.SearchGroup.TabIndex = 0;
            this.SearchGroup.TabStop = false;
            // 
            // SearchBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 336);
            this.Controls.Add(this.SearchBarTxtBox);
            this.Controls.Add(this.SearchGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchBar";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchBarTxtBox;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.GroupBox SearchGroup;
    }
}