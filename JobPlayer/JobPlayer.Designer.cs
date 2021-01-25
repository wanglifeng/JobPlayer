namespace JobPlayer
{
    partial class JobPlayer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobPlayer));
            this.jobPlayerIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.jobPlayerMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Hote = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_infor = new System.Windows.Forms.DataGridView();
            this.combox_Service = new System.Windows.Forms.ComboBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.combox_hotkey2 = new System.Windows.Forms.ComboBox();
            this.lab_Num = new System.Windows.Forms.Label();
            this.combox_hotkey1 = new System.Windows.Forms.ComboBox();
            this.lab_Hote = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.HotkeyOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstHotkey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondHotkey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobPlayerMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Hote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_infor)).BeginInit();
            this.SuspendLayout();
            // 
            // jobPlayerIcon
            // 
            this.jobPlayerIcon.ContextMenuStrip = this.jobPlayerMenuStrip;
            this.jobPlayerIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("jobPlayerIcon.Icon")));
            this.jobPlayerIcon.Text = "JobPlay";
            this.jobPlayerIcon.Visible = true;
            this.jobPlayerIcon.DoubleClick += new System.EventHandler(this.jobPlayerIcon_DoubleClick);
            // 
            // jobPlayerMenuStrip
            // 
            this.jobPlayerMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.jobPlayerMenuStrip.Name = "jobPlayerMenuStrip";
            this.jobPlayerMenuStrip.Size = new System.Drawing.Size(101, 26);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Hote);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(586, 319);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage_Hote
            // 
            this.tabPage_Hote.Controls.Add(this.label1);
            this.tabPage_Hote.Controls.Add(this.dgv_infor);
            this.tabPage_Hote.Controls.Add(this.combox_Service);
            this.tabPage_Hote.Controls.Add(this.btn_Save);
            this.tabPage_Hote.Controls.Add(this.button1);
            this.tabPage_Hote.Controls.Add(this.combox_hotkey2);
            this.tabPage_Hote.Controls.Add(this.lab_Num);
            this.tabPage_Hote.Controls.Add(this.combox_hotkey1);
            this.tabPage_Hote.Controls.Add(this.lab_Hote);
            this.tabPage_Hote.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Hote.Name = "tabPage_Hote";
            this.tabPage_Hote.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Hote.Size = new System.Drawing.Size(578, 293);
            this.tabPage_Hote.TabIndex = 0;
            this.tabPage_Hote.Text = "热键";
            this.tabPage_Hote.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "服务：";
            // 
            // dgv_infor
            // 
            this.dgv_infor.AllowUserToAddRows = false;
            this.dgv_infor.AllowUserToResizeColumns = false;
            this.dgv_infor.AllowUserToResizeRows = false;
            this.dgv_infor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_infor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HotkeyOrder,
            this.FirstHotkey,
            this.SecondHotkey,
            this.Service});
            this.dgv_infor.Location = new System.Drawing.Point(8, 53);
            this.dgv_infor.Name = "dgv_infor";
            this.dgv_infor.RowTemplate.Height = 23;
            this.dgv_infor.Size = new System.Drawing.Size(554, 199);
            this.dgv_infor.TabIndex = 8;
            this.dgv_infor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_infor_KeyDown);
            // 
            // combox_Service
            // 
            this.combox_Service.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combox_Service.FormattingEnabled = true;
            this.combox_Service.Location = new System.Drawing.Point(349, 23);
            this.combox_Service.Name = "combox_Service";
            this.combox_Service.Size = new System.Drawing.Size(209, 20);
            this.combox_Service.TabIndex = 7;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(373, 258);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 6;
            this.btn_Save.Text = "添加";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(466, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // combox_hotkey2
            // 
            this.combox_hotkey2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combox_hotkey2.FormattingEnabled = true;
            this.combox_hotkey2.Location = new System.Drawing.Point(160, 23);
            this.combox_hotkey2.Name = "combox_hotkey2";
            this.combox_hotkey2.Size = new System.Drawing.Size(118, 20);
            this.combox_hotkey2.TabIndex = 3;
            // 
            // lab_Num
            // 
            this.lab_Num.AutoSize = true;
            this.lab_Num.Location = new System.Drawing.Point(124, 26);
            this.lab_Num.Name = "lab_Num";
            this.lab_Num.Size = new System.Drawing.Size(41, 12);
            this.lab_Num.TabIndex = 2;
            this.lab_Num.Text = "热键：";
            // 
            // combox_hotkey1
            // 
            this.combox_hotkey1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combox_hotkey1.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combox_hotkey1.FormattingEnabled = true;
            this.combox_hotkey1.Items.AddRange(new object[] {
            "None",
            "Alt",
            "Ctrl",
            "Shift",
            "WindowsKey"});
            this.combox_hotkey1.Location = new System.Drawing.Point(44, 23);
            this.combox_hotkey1.Name = "combox_hotkey1";
            this.combox_hotkey1.Size = new System.Drawing.Size(66, 20);
            this.combox_hotkey1.TabIndex = 1;
            // 
            // lab_Hote
            // 
            this.lab_Hote.AutoSize = true;
            this.lab_Hote.Location = new System.Drawing.Point(6, 26);
            this.lab_Hote.Name = "lab_Hote";
            this.lab_Hote.Size = new System.Drawing.Size(41, 12);
            this.lab_Hote.TabIndex = 0;
            this.lab_Hote.Text = "热键：";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(814, 356);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "其它";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // HotkeyOrder
            // 
            this.HotkeyOrder.HeaderText = "序号";
            this.HotkeyOrder.Name = "HotkeyOrder";
            // 
            // FirstHotkey
            // 
            this.FirstHotkey.DataPropertyName = "FirstHotkey";
            this.FirstHotkey.HeaderText = "热键1";
            this.FirstHotkey.Name = "FirstHotkey";
            // 
            // SecondHotkey
            // 
            this.SecondHotkey.DataPropertyName = "SecondHotkey";
            this.SecondHotkey.HeaderText = "热键2";
            this.SecondHotkey.Name = "SecondHotkey";
            // 
            // Service
            // 
            this.Service.DataPropertyName = "Service";
            this.Service.HeaderText = "服务";
            this.Service.Name = "Service";
            this.Service.Width = 210;
            // 
            // JobPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 341);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(626, 379);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(626, 379);
            this.Name = "JobPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JobPlayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JobPlayer_FormClosing);
            this.Load += new System.EventHandler(this.JobPlayer_Load);
            this.jobPlayerMenuStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Hote.ResumeLayout(false);
            this.tabPage_Hote.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_infor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip jobPlayerMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        public System.Windows.Forms.NotifyIcon jobPlayerIcon;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Hote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_infor;
        private System.Windows.Forms.ComboBox combox_Service;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox combox_hotkey2;
        private System.Windows.Forms.Label lab_Num;
        private System.Windows.Forms.ComboBox combox_hotkey1;
        private System.Windows.Forms.Label lab_Hote;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn HotkeyOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstHotkey;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondHotkey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service;
    }
}

