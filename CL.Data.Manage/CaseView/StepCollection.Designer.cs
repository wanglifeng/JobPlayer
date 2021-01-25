namespace CL.Manage.Data.CaseView
{
    partial class StepCollection
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TestCaseGridView = new System.Windows.Forms.DataGridView();
            this.ColumnCaseOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditBtn = new CL.Manage.Data.CaseView.StepCollection.DataGridViewDisableButtonColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.锁定窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消锁定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.TestCaseGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TestCaseGridView
            // 
            this.TestCaseGridView.AllowUserToAddRows = false;
            this.TestCaseGridView.AllowUserToDeleteRows = false;
            this.TestCaseGridView.AllowUserToResizeRows = false;
            this.TestCaseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestCaseGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCaseOrder,
            this.ColumnSID,
            this.ColumnOrder,
            this.ColumnDescription,
            this.ColumnName,
            this.EditBtn});
            this.TestCaseGridView.Location = new System.Drawing.Point(12, 40);
            this.TestCaseGridView.Name = "TestCaseGridView";
            this.TestCaseGridView.RowTemplate.Height = 23;
            this.TestCaseGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TestCaseGridView.ShowCellToolTips = false;
            this.TestCaseGridView.Size = new System.Drawing.Size(562, 410);
            this.TestCaseGridView.TabIndex = 0;
            this.TestCaseGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TestCaseControlor_CellClick);
            // 
            // ColumnCaseOrder
            // 
            this.ColumnCaseOrder.HeaderText = "CaseOrder";
            this.ColumnCaseOrder.Name = "ColumnCaseOrder";
            // 
            // ColumnSID
            // 
            this.ColumnSID.HeaderText = "SID";
            this.ColumnSID.Name = "ColumnSID";
            this.ColumnSID.ReadOnly = true;
            this.ColumnSID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnSID.Width = 60;
            // 
            // ColumnOrder
            // 
            this.ColumnOrder.HeaderText = "Order";
            this.ColumnOrder.Name = "ColumnOrder";
            this.ColumnOrder.ReadOnly = true;
            this.ColumnOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnOrder.Width = 50;
            // 
            // ColumnDescription
            // 
            this.ColumnDescription.HeaderText = "Description";
            this.ColumnDescription.Name = "ColumnDescription";
            this.ColumnDescription.ReadOnly = true;
            this.ColumnDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnDescription.Width = 90;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnName.Width = 150;
            // 
            // EditBtn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("仿宋", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.NullValue = "Edit";
            this.EditBtn.DefaultCellStyle = dataGridViewCellStyle1;
            this.EditBtn.HeaderText = "";
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.ReadOnly = true;
            this.EditBtn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EditBtn.Width = 50;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(123)))), ((int)(((byte)(173)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(-75, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(680, 3);
            this.label7.TabIndex = 24;
            this.label7.Text = "label7";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.锁定窗口ToolStripMenuItem,
            this.取消锁定ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(586, 25);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 锁定窗口ToolStripMenuItem
            // 
            this.锁定窗口ToolStripMenuItem.Name = "锁定窗口ToolStripMenuItem";
            this.锁定窗口ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.锁定窗口ToolStripMenuItem.Text = "锁定窗口";
            this.锁定窗口ToolStripMenuItem.Click += new System.EventHandler(this.锁定窗口ToolStripMenuItem_Click);
            // 
            // 取消锁定ToolStripMenuItem
            // 
            this.取消锁定ToolStripMenuItem.Name = "取消锁定ToolStripMenuItem";
            this.取消锁定ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.取消锁定ToolStripMenuItem.Text = "取消锁定";
            this.取消锁定ToolStripMenuItem.Click += new System.EventHandler(this.取消锁定ToolStripMenuItem_Click);
            // 
            // StepCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 459);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TestCaseGridView);
            this.Controls.Add(this.menuStrip1);
            this.Name = "StepCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "步骤管理";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.StepCollection_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.TestCaseGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView TestCaseGridView;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 锁定窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消锁定ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCaseOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private StepCollection.DataGridViewDisableButtonColumn EditBtn;
    }
}

