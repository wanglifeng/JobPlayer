using JobPlayer.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobPlayer
{
    public partial class SearchBar : Form
    {
        ExcuteEngine excuteEngine = new ExcuteEngine();
        string key = "";
        int nextIndex = 0, beforeIndex = 0, curIndex = 0;
        List<Label> labelList = new List<Label>();
        public SearchBar()
        {
            InitializeComponent();
        }

        private void SearchBarTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (SearchBarTxtBox.Text == "搜索")
            {
                SearchBarTxtBox.Text = "";
            }

            switch (e.KeyData)
            {
                case Keys.Enter:
                    excuteEngine.Excute(SearchGroup.Controls[curIndex].Text);                    
                    HideOrShow_SearchBar();
                    break;
                case Keys.Up:
                    selecResearch(Keys.Up);
                    break;
                case Keys.Down:
                    selecResearch(Keys.Down);
                    break;


            }
         
        }

        public void HideOrShow_SearchBar()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
                Show();
            }
            else
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            }
        }

        private void SearchBarTxtBox_TextChanged(object sender, EventArgs e)
        {
            curIndex = 0;
            int P_int_x = 0;
            int P_int_y = 10;
            key = SearchBarTxtBox.Text;
            SearchGroup.Controls.Clear();
            if (string.IsNullOrEmpty(key)) return;
            var query = excuteEngine.GetActionList().Where(x => x.Contains(key)).ToList();
            if (query.Any())
            {
                for (int i = 0; i < query.Count; i++)
                {
                    Label label1 = new Label();
                    label1.Text = query[i];

                    label1.AutoSize = false;
                    label1.Name = "label1" + (i + 1).ToString();
                    label1.Width = 426;
                    label1.Height = 22;                    
                    label1.Location = new Point(P_int_x, P_int_y);
                    label1.TabIndex = i;
                    label1.TextAlign = ContentAlignment.MiddleLeft;
                    //P_int_x += 50;
                    P_int_y += 20;
                    if (((i + 1) % 10) == 0)
                    {
                        P_int_x = 0;
                        P_int_y += 25;
                    }
                    SearchGroup.Controls.Add(label1);
                }

            }
        }

        private void selecResearch(Keys direction) {
            int count = SearchGroup.Controls.Count;
            if(count == 0) return;           
            if (count == 1) {
                SearchGroup.Controls[0].BackColor = Color.LightGray;
                return;
            }
            //Cancel color of  search item            
            SearchGroup.Controls[curIndex].BackColor = SystemColors.Control;

            if (direction == Keys.Down)
            {
                if (nextIndex >= count) return;
                SearchGroup.Controls[nextIndex].BackColor = SystemColors.ControlLight;
                curIndex = nextIndex++;
                beforeIndex = curIndex - 1;

            }
            else {
                if (beforeIndex < 0) return;
                SearchGroup.Controls[beforeIndex].BackColor = SystemColors.ControlLight;
                curIndex = beforeIndex--;
                nextIndex = curIndex + 1;
            }




        }
    }
}
