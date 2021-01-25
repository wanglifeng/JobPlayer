using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Workflow.ComponentModel;
using System.IO;
namespace CL.Manage.Data.CaseView
{
    public partial class StepInfoFrom : Form
    {
        private string SID;
        public StepInfoFrom(string sid)
        {
            SID = sid;
            InitializeComponent();
        }

        private void StepInfo_Load(object sender, EventArgs e)
        {
            var StepDataSourse = CaseView.StepDataSourse[SID];
            CaseView.CurStep = ((dynamic)StepDataSourse).Parameter;
            foreach (var item in CaseView.CurStep)
            {
                if (item.Key == "SID") continue;
                StepInfoGridView.Rows.Add(item.Key, item.Value);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            string command = "";
            foreach (var item in CaseView.CurStep)
            {
                string name = item.Key;
                string value = item.Value;
                command += string.Format("{0}:{1}\r\n", name, value);
            }
            string path = Environment.CurrentDirectory + @"\log.txt";
            try
            {
                StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8);
                string text = string.Format("TestCaseID:{0}\r\n{1}", CaseView.TestCaseID, this.Text);
                sw.Write(text + "\r\n" + command);
                sw.Write("-----------------------------------------------------------------------------------\r\n");
                sw.Close();
            }
            catch
            {
                //Do nothing
            }
            this.Close();
        }


        //public void SavaData(string Model)
        //{
        //    for (int i = 0; i < StepInfoGridView.RowCount; i++)
        //    {
        //        string value;
        //        string name = StepInfoGridView.Rows[i].Cells[0].Value.ToString();
        //        //filter string or empty
        //        if (StepInfoGridView.Rows[i].Cells[1].Value == null ||
        //            string.IsNullOrEmpty(StepInfoGridView.Rows[i].Cells[1].Value.ToString()))
        //        {
        //            value = "";
        //        }
        //        else
        //        {
        //            value = StepInfoGridView.Rows[i].Cells[1].Value.ToString();
        //        }
        //        if (Model == "Debug")
        //        {
        //            if (name == "stype")
        //            {
        //                CaseView.CurStep[name] = value + "|@Debug-Z";
        //                continue;
        //            }
        //        }
        //        CaseView.CurStep[name] = value;
        //    }
        //}

        public void SavaData(string Model)
        {
            for (int i = 0; i < StepInfoGridView.RowCount; i++)
            {
                string value;
                string name = StepInfoGridView.Rows[i].Cells[0].Value.ToString();
                //filter string or empty
                if (StepInfoGridView.Rows[i].Cells[1].Value == null ||
                    string.IsNullOrEmpty(StepInfoGridView.Rows[i].Cells[1].Value.ToString()))
                {
                    value = "";
                }
                else
                {
                    value = StepInfoGridView.Rows[i].Cells[1].Value.ToString();
                }
                if (Model == "AppUI" || Model == "WebUI")
                {
                    if (name == "stype")
                    {
                        CaseView.CurStep[name] = value + "|@Debug-" + Model;
                        continue;
                    }
                }
                CaseView.CurStep[name] = value;
            }
        }
        private void StepInfoFrom_Shown(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
    }
}
