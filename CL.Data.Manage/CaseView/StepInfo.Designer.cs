namespace CL.Manage.Data.CaseView
{
    partial class StepInfoFrom
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
            this.CancelBtn = new System.Windows.Forms.Button();
            this.StepInfoGridView = new System.Windows.Forms.DataGridView();
            this.FieldColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.excuteBtn = new System.Windows.Forms.Button();
            this.Errortxt = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.WebUIDebugStartBtn = new System.Windows.Forms.Button();
            this.AppUIDebugStartBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StepInfoGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(247, 202);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "继续";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // StepInfoGridView
            // 
            this.StepInfoGridView.AllowUserToAddRows = false;
            this.StepInfoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StepInfoGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FieldColumn,
            this.ValueColumn});
            this.StepInfoGridView.Location = new System.Drawing.Point(12, 12);
            this.StepInfoGridView.Name = "StepInfoGridView";
            this.StepInfoGridView.RowTemplate.Height = 23;
            this.StepInfoGridView.Size = new System.Drawing.Size(313, 170);
            this.StepInfoGridView.TabIndex = 2;
            // 
            // FieldColumn
            // 
            this.FieldColumn.HeaderText = "Field";
            this.FieldColumn.Name = "FieldColumn";
            // 
            // ValueColumn
            // 
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.Width = 160;
            // 
            // excuteBtn
            // 
            this.excuteBtn.Location = new System.Drawing.Point(14, 202);
            this.excuteBtn.Name = "excuteBtn";
            this.excuteBtn.Size = new System.Drawing.Size(59, 23);
            this.excuteBtn.TabIndex = 3;
            this.excuteBtn.Text = "启动";
            this.excuteBtn.UseVisualStyleBackColor = true;
            // 
            // Errortxt
            // 
            this.Errortxt.AutoSize = true;
            this.Errortxt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Errortxt.Location = new System.Drawing.Point(12, 237);
            this.Errortxt.Name = "Errortxt";
            this.Errortxt.Size = new System.Drawing.Size(53, 12);
            this.Errortxt.TabIndex = 4;
            this.Errortxt.Text = "错误信息";
            // 
            // WebUIDebugStartBtn
            // 
            this.WebUIDebugStartBtn.Location = new System.Drawing.Point(79, 202);
            this.WebUIDebugStartBtn.Name = "WebUIDebugStartBtn";
            this.WebUIDebugStartBtn.Size = new System.Drawing.Size(75, 23);
            this.WebUIDebugStartBtn.TabIndex = 5;
            this.WebUIDebugStartBtn.Text = "WebUI启动";
            this.WebUIDebugStartBtn.UseVisualStyleBackColor = true;
            // 
            // AppUIDebugStartBtn
            // 
            this.AppUIDebugStartBtn.Location = new System.Drawing.Point(160, 202);
            this.AppUIDebugStartBtn.Name = "AppUIDebugStartBtn";
            this.AppUIDebugStartBtn.Size = new System.Drawing.Size(81, 23);
            this.AppUIDebugStartBtn.TabIndex = 6;
            this.AppUIDebugStartBtn.Text = "APPUI启动";
            this.AppUIDebugStartBtn.UseVisualStyleBackColor = true;
            // 
            // StepInfoFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 262);
            this.Controls.Add(this.AppUIDebugStartBtn);
            this.Controls.Add(this.WebUIDebugStartBtn);
            this.Controls.Add(this.Errortxt);
            this.Controls.Add(this.excuteBtn);
            this.Controls.Add(this.StepInfoGridView);
            this.Controls.Add(this.CancelBtn);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 300);
            this.Name = "StepInfoFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Step";
            this.Load += new System.EventHandler(this.StepInfo_Load);
            this.Shown += new System.EventHandler(this.StepInfoFrom_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.StepInfoGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelBtn;
        public System.Windows.Forms.Button excuteBtn;
        public System.Windows.Forms.DataGridView StepInfoGridView;
        public System.Windows.Forms.Label Errortxt;
        public System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        public System.Windows.Forms.Button WebUIDebugStartBtn;
        public System.Windows.Forms.Button AppUIDebugStartBtn;
    }
}