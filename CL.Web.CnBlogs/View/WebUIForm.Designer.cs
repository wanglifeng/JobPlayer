namespace CL.Web.SXDX.View
{
    partial class WebUIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebUIForm));
            this.SXDXWebBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GenerateXpath = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TvalueTxtBox = new System.Windows.Forms.TextBox();
            this.TargetTxtBox = new System.Windows.Forms.TextBox();
            this.SelectOptions = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Copy = new System.Windows.Forms.Button();
            this.XpathDateView = new System.Windows.Forms.DataGridView();
            this._Xpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StepLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ResearchBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLindex = new System.Windows.Forms.TextBox();
            this.ResultDateView = new System.Windows.Forms.DataGridView();
            this._TagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetrunElement = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ComandCollection = new System.Windows.Forms.ComboBox();
            this.btnExcute = new System.Windows.Forms.Button();
            this.labIFrame = new System.Windows.Forms.Label();
            this.IFrameCollection = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SXDXWebBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XpathDateView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultDateView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GenerateXpath
            // 
            this.GenerateXpath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GenerateXpath.Location = new System.Drawing.Point(343, 96);
            this.GenerateXpath.Name = "GenerateXpath";
            this.GenerateXpath.Size = new System.Drawing.Size(80, 29);
            this.GenerateXpath.TabIndex = 0;
            this.GenerateXpath.Text = " 生成";
            this.GenerateXpath.UseVisualStyleBackColor = true;
            this.GenerateXpath.Click += new System.EventHandler(this.GenerateXpath_Click);
            // 
            // Clear
            // 
            this.Clear.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Clear.Location = new System.Drawing.Point(513, 96);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(80, 29);
            this.Clear.TabIndex = 12;
            this.Clear.Text = "清空";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Target:";
            // 
            // TvalueTxtBox
            // 
            this.TvalueTxtBox.Location = new System.Drawing.Point(83, 42);
            this.TvalueTxtBox.Name = "TvalueTxtBox";
            this.TvalueTxtBox.Size = new System.Drawing.Size(140, 22);
            this.TvalueTxtBox.TabIndex = 3;
            // 
            // TargetTxtBox
            // 
            this.TargetTxtBox.Location = new System.Drawing.Point(83, 73);
            this.TargetTxtBox.Name = "TargetTxtBox";
            this.TargetTxtBox.Size = new System.Drawing.Size(140, 22);
            this.TargetTxtBox.TabIndex = 4;
            // 
            // SelectOptions
            // 
            this.SelectOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectOptions.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectOptions.FormattingEnabled = true;
            this.SelectOptions.Items.AddRange(new object[] {
            "普通按钮",
            "勾选按钮",
            "树节点按钮",
            "图标按钮",
            "普通文本框",
            "文件文本框",
            "普通下拉框"});
            this.SelectOptions.Location = new System.Drawing.Point(378, 42);
            this.SelectOptions.Name = "SelectOptions";
            this.SelectOptions.Size = new System.Drawing.Size(187, 25);
            this.SelectOptions.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(309, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "控件选择:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tvalue:";
            // 
            // Copy
            // 
            this.Copy.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Copy.Location = new System.Drawing.Point(428, 96);
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(80, 29);
            this.Copy.TabIndex = 11;
            this.Copy.Text = "复制全部";
            this.Copy.UseVisualStyleBackColor = true;
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // XpathDateView
            // 
            this.XpathDateView.AllowUserToDeleteRows = false;
            this.XpathDateView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.XpathDateView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Xpath});
            this.XpathDateView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.XpathDateView.Location = new System.Drawing.Point(12, 176);
            this.XpathDateView.Name = "XpathDateView";
            this.XpathDateView.RowTemplate.Height = 23;
            this.XpathDateView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.XpathDateView.Size = new System.Drawing.Size(608, 250);
            this.XpathDateView.TabIndex = 14;
            this.XpathDateView.TabStop = false;
            // 
            // _Xpath
            // 
            this._Xpath.HeaderText = "Xpath";
            this._Xpath.Name = "_Xpath";
            this._Xpath.Width = 560;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.StepLabel);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ResearchBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtLindex);
            this.panel1.Controls.Add(this.GenerateXpath);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Clear);
            this.panel1.Controls.Add(this.TvalueTxtBox);
            this.panel1.Controls.Add(this.Copy);
            this.panel1.Controls.Add(this.TargetTxtBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.SelectOptions);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 142);
            this.panel1.TabIndex = 1;
            // 
            // StepLabel
            // 
            this.StepLabel.AutoSize = true;
            this.StepLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StepLabel.Location = new System.Drawing.Point(80, 15);
            this.StepLabel.Name = "StepLabel";
            this.StepLabel.Size = new System.Drawing.Size(147, 14);
            this.StepLabel.TabIndex = 17;
            this.StepLabel.Text = "ConpentName and step";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(42, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 14);
            this.label8.TabIndex = 16;
            this.label8.Text = "Step:";
            // 
            // ResearchBtn
            // 
            this.ResearchBtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResearchBtn.Location = new System.Drawing.Point(255, 96);
            this.ResearchBtn.Name = "ResearchBtn";
            this.ResearchBtn.Size = new System.Drawing.Size(80, 29);
            this.ResearchBtn.TabIndex = 15;
            this.ResearchBtn.Text = "查询";
            this.ResearchBtn.UseVisualStyleBackColor = true;
            this.ResearchBtn.Click += new System.EventHandler(this.ResearchBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "Lindex:";
            // 
            // txtLindex
            // 
            this.txtLindex.Location = new System.Drawing.Point(83, 105);
            this.txtLindex.Name = "txtLindex";
            this.txtLindex.Size = new System.Drawing.Size(140, 22);
            this.txtLindex.TabIndex = 14;
            // 
            // ResultDateView
            // 
            this.ResultDateView.AllowUserToAddRows = false;
            this.ResultDateView.AllowUserToDeleteRows = false;
            this.ResultDateView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultDateView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._TagName,
            this._Text,
            this._Name,
            this._Value,
            this._Width,
            this._Height});
            this.ResultDateView.Location = new System.Drawing.Point(12, 465);
            this.ResultDateView.MultiSelect = false;
            this.ResultDateView.Name = "ResultDateView";
            this.ResultDateView.ReadOnly = true;
            this.ResultDateView.RowTemplate.Height = 23;
            this.ResultDateView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultDateView.Size = new System.Drawing.Size(608, 196);
            this.ResultDateView.TabIndex = 15;
            this.ResultDateView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultDateView_CellClick);
            // 
            // _TagName
            // 
            this._TagName.HeaderText = "TagName";
            this._TagName.Name = "_TagName";
            this._TagName.ReadOnly = true;
            this._TagName.Width = 90;
            // 
            // _Text
            // 
            this._Text.HeaderText = "Text";
            this._Text.Name = "_Text";
            this._Text.ReadOnly = true;
            // 
            // _Name
            // 
            this._Name.HeaderText = "Name";
            this._Name.Name = "_Name";
            this._Name.ReadOnly = true;
            this._Name.Width = 90;
            // 
            // _Value
            // 
            this._Value.HeaderText = "Value";
            this._Value.Name = "_Value";
            this._Value.ReadOnly = true;
            this._Value.Width = 90;
            // 
            // _Width
            // 
            this._Width.HeaderText = "Width";
            this._Width.Name = "_Width";
            this._Width.ReadOnly = true;
            this._Width.Width = 90;
            // 
            // _Height
            // 
            this._Height.HeaderText = "Height";
            this._Height.Name = "_Height";
            this._Height.ReadOnly = true;
            // 
            // RetrunElement
            // 
            this.RetrunElement.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RetrunElement.Location = new System.Drawing.Point(15, 429);
            this.RetrunElement.Name = "RetrunElement";
            this.RetrunElement.Size = new System.Drawing.Size(80, 29);
            this.RetrunElement.TabIndex = 16;
            this.RetrunElement.Text = "返回元素";
            this.RetrunElement.UseVisualStyleBackColor = true;
            this.RetrunElement.Click += new System.EventHandler(this.RetrunElement_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(115, 439);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "命令库:";
            // 
            // ComandCollection
            // 
            this.ComandCollection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComandCollection.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComandCollection.FormattingEnabled = true;
            this.ComandCollection.Items.AddRange(new object[] {
            "单击",
            "JS单击",
            "Action单击",
            "双击",
            "右击",
            "下拉-文本选择",
            "输入",
            "清空",
            "切换IFrame"});
            this.ComandCollection.Location = new System.Drawing.Point(165, 433);
            this.ComandCollection.Name = "ComandCollection";
            this.ComandCollection.Size = new System.Drawing.Size(149, 25);
            this.ComandCollection.TabIndex = 16;
            this.ComandCollection.SelectedValueChanged += new System.EventHandler(this.ComandCollection_SelectedValueChanged);
            // 
            // btnExcute
            // 
            this.btnExcute.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExcute.Location = new System.Drawing.Point(321, 431);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(80, 29);
            this.btnExcute.TabIndex = 16;
            this.btnExcute.Text = "执行";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // labIFrame
            // 
            this.labIFrame.AutoSize = true;
            this.labIFrame.Enabled = false;
            this.labIFrame.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labIFrame.Location = new System.Drawing.Point(418, 438);
            this.labIFrame.Name = "labIFrame";
            this.labIFrame.Size = new System.Drawing.Size(51, 17);
            this.labIFrame.TabIndex = 18;
            this.labIFrame.Text = "IFrame:";
            // 
            // IFrameCollection
            // 
            this.IFrameCollection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IFrameCollection.Enabled = false;
            this.IFrameCollection.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IFrameCollection.FormattingEnabled = true;
            this.IFrameCollection.Items.AddRange(new object[] {
            "主界面",
            "右侧",
            "机构选择"});
            this.IFrameCollection.Location = new System.Drawing.Point(473, 432);
            this.IFrameCollection.Name = "IFrameCollection";
            this.IFrameCollection.Size = new System.Drawing.Size(131, 25);
            this.IFrameCollection.TabIndex = 19;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(226)))), ((int)(((byte)(243)))));
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(637, 25);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(61, 21);
            this.toolStripMenuItem1.Text = "帮助(&H)";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "导出命令(&S)";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(188)))), ((int)(((byte)(204)))));
            this.label6.Location = new System.Drawing.Point(-7, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(650, 2);
            this.label6.TabIndex = 21;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(123)))), ((int)(((byte)(173)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(-7, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(650, 3);
            this.label7.TabIndex = 22;
            this.label7.Text = "label7";
            // 
            // WclForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(637, 670);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.IFrameCollection);
            this.Controls.Add(this.labIFrame);
            this.Controls.Add(this.btnExcute);
            this.Controls.Add(this.ComandCollection);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RetrunElement);
            this.Controls.Add(this.ResultDateView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.XpathDateView);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WclForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WEB组件库";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WclForm_FormClosed);
            this.Load += new System.EventHandler(this.WclForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SXDXWebBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XpathDateView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultDateView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource SXDXWebBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TvalueTxtBox;
        public System.Windows.Forms.TextBox TargetTxtBox;
        public System.Windows.Forms.ComboBox SelectOptions;
        public System.Windows.Forms.TextBox txtLindex;
        public System.Windows.Forms.Button GenerateXpath;
        public System.Windows.Forms.Button Clear;
        public System.Windows.Forms.Button Copy;
        public System.Windows.Forms.Button ResearchBtn;
        public System.Windows.Forms.DataGridView XpathDateView;
        public System.Windows.Forms.Button RetrunElement;
        public System.Windows.Forms.ComboBox ComandCollection;
        public System.Windows.Forms.Button btnExcute;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Xpath;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Text;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Width;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Height;
        public System.Windows.Forms.Label labIFrame;
        public System.Windows.Forms.ComboBox IFrameCollection;
        public System.Windows.Forms.DataGridView ResultDateView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label StepLabel;
    }
}