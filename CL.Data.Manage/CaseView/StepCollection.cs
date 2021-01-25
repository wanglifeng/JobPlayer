using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
namespace CL.Manage.Data.CaseView
{
    public partial class StepCollection : Form
    {
        private DataGridViewDisableButtonCell curButtonCell;
        private DataGridViewDisableButtonCell beforeButtonCell;
        private int HeighlightIndex { get; set; }


        public StepCollection()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string caseID, id, order, desc, name;
            if (TestCaseGridView.RowCount > 1) return;
            foreach (var step in CaseView.StepDataSourse)
            {
                id = step.Key;
                dynamic stepAttribute = ((dynamic)step.Value).Step;
                order = stepAttribute["order"];
                desc = stepAttribute["desc"];
                name = stepAttribute["name"];
                caseID = stepAttribute["caseID"];
                TestCaseGridView.Rows.Add(caseID, id, order, desc, name);
            }
        }
        private void TestCaseControlor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string buttonText = this.TestCaseGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();
                if (buttonText == "Edit" && HeighlightIndex < e.RowIndex)
                {
                    string SID = this.TestCaseGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                    TestCaseGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(213, 233, 99);
                    CaseView.DebugList.Add(SID);
                    curButtonCell = this.TestCaseGridView.Rows[e.RowIndex].Cells["EditBtn"] as DataGridViewDisableButtonCell;
                    curButtonCell.Enabled = false;
                }
            }
            catch
            {
                //do nothing 
            }

        }
        public void neonShow(string SID, bool Success)
        {
            for (int i = 0; i < TestCaseGridView.RowCount; i++)
            {
                if (TestCaseGridView.Rows[i].Cells[1].Value.ToString() == SID)
                {

                    HeighlightIndex = i;
                    if (i != 0)
                    {
                        beforeButtonCell = this.TestCaseGridView.Rows[i - 1].Cells["EditBtn"] as DataGridViewDisableButtonCell;
                        beforeButtonCell.Enabled = false;
                        TestCaseGridView.Rows[i - 1].DefaultCellStyle.BackColor = Color.FromArgb(190, 190, 190);
                    }
                    curButtonCell = this.TestCaseGridView.Rows[i].Cells["EditBtn"] as DataGridViewDisableButtonCell;
                    curButtonCell.Enabled = false;
                    if (Success)
                    {
                        TestCaseGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(130, 206, 111);
                    }
                    else
                    {
                        TestCaseGridView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }

        }



        #region//Cell disable button
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = TestCaseGridView.Columns[e.ColumnIndex];

        }
        public class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
        {
            public DataGridViewDisableButtonColumn()
            {
                this.CellTemplate = new DataGridViewDisableButtonCell();
            }
        }
        public class DataGridViewDisableButtonCell : DataGridViewButtonCell
        {
            private bool enableValue;

            public bool Enabled
            {
                get
                {
                    return enableValue;
                }
                set
                {
                    enableValue = value;
                }
            }

            public override object Clone()
            {
                DataGridViewDisableButtonCell cell = (DataGridViewDisableButtonCell)base.Clone();

                cell.Enabled = this.Enabled;
                return cell;
            }
            public DataGridViewDisableButtonCell()
            {
                this.enableValue = true;

            }

            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                if (!this.enableValue)
                {
                    if ((paintParts & DataGridViewPaintParts.Background) == DataGridViewPaintParts.Background)
                    {
                        SolidBrush cellBackground = new SolidBrush(cellStyle.BackColor);
                        graphics.FillRectangle(cellBackground, cellBounds);
                        cellBackground.Dispose();
                    }

                    if ((paintParts & DataGridViewPaintParts.Border) == DataGridViewPaintParts.Border)
                    {
                        PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
                    }
                    Rectangle buttonArea = cellBounds;
                    Rectangle buttonAdjustment = this.BorderWidths(advancedBorderStyle);
                    buttonArea.X += buttonAdjustment.X;
                    buttonArea.Y += buttonAdjustment.Y;
                    buttonArea.Height -= buttonAdjustment.Height;
                    buttonArea.Width -= buttonAdjustment.Width;

                    ButtonRenderer.DrawButton(graphics, buttonArea, System.Windows.Forms.VisualStyles.PushButtonState.Disabled);

                    if (this.FormattedValue is string)
                    {
                        TextRenderer.DrawText(graphics, (string)this.FormattedValue, this.DataGridView.Font, buttonArea, SystemColors.GrayText);

                    }

                }
                else
                {
                    base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
                }
            }
        }
        #endregion

        private void 锁定窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void 取消锁定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void StepCollection_Shown(object sender, EventArgs e)
        {
            this.TopMost = true;
        }








    }
}
