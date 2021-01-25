using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CL.Web.SXDX.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using CL.Web.SXDX.Support;
using CL.Manage.Data;
using System.IO;
using System.Text;
using CL.Manage.Data.CaseView;
namespace CL.Web.SXDX.View
{
    public partial class WebUIForm : Form
    {
        public string Xpath { set; get; }
        public static bool State { set; get; }

        public IWebDriver driver;
        public static IList<IWebElement> elements;
        public string CommandString { set; get; }
        public IWebElement element;
        public int? Index { set; get; }

        public WebUIForm()
        {
            InitializeComponent();
            StepLabel.Text = CaseView.StepOrder;
            TvalueTxtBox.Text = CaseView.CurStep.ContainsKey("tvalue") ? CaseView.CurStep["tvalue"] : "";
            TargetTxtBox.Text = CaseView.CurStep.ContainsKey("target") ? CaseView.CurStep["target"] : "";
            txtLindex.Text = CaseView.CurStep.ContainsKey("lindex") ? CaseView.CurStep["lindex"] : "";
            if (CaseView.CurStep.ContainsKey("stype"))
            {
                var sTypeCollectiton = CaseView.CurStep["stype"].Replace("@", string.Empty).Split('|');
                foreach (string item in sTypeCollectiton)
                {
                    if (SelectOptions.Items.Contains(item))
                    {
                        SelectOptions.Text = item;
                        break;
                    }
                }
            }
        }

        public void GenerateXpath_Click(object sender, EventArgs e)
        {
            string Tvalue = TvalueTxtBox.Text;
            string Target = TargetTxtBox.Text;
            if (!string.IsNullOrEmpty(txtLindex.Text))
            {
                JSupport.Index = txtLindex.Text;
            }
            string Option = SelectOptions.Text;
            if (string.IsNullOrEmpty(Option))
            {
                MessageBox.Show("控件选择为必填项");
            }
            else
            {
                XpathDateView.Rows.Clear();
                try
                {
                    switch (Option)
                    {
                        case "普通按钮":
                            Xpath = JXpath.Button(Tvalue, Target);
                            break;
                        case "勾选按钮":
                            Xpath = JXpath.Radio(Tvalue, Target);
                            break;
                        case "树节点按钮":
                            Xpath = JXpath.TreeNode(Tvalue, Target);
                            break;
                        case "图标按钮":
                            Xpath = JXpath.IConButton(Tvalue, Target);
                            break;
                        case "普通文本框":
                            Xpath = JXpath.Input(Target, Tvalue);
                            break;
                        case "文件文本框":
                            Xpath = JXpath.FileInput(Target, Tvalue);                            
                            break;
                        case "普通下拉框":
                            Xpath = JXpath.Select(Target, Tvalue);
                            break;
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(string.Format("{0}：请重试", error));
                }
                //Print xpath and control format
                var Collection = Xpath.Split('|');
                foreach (string item in Collection)
                {
                    XpathDateView.Rows.Add(item.Trim());
                }
            }
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ComandCollection.Text))
            {
                MessageBox.Show("请先选择命令");
            }
            else
            {
                try
                {
                    int index = ResultDateView.CurrentRow.Index;
                    element = elements[index];
                }
                catch
                {
                    MessageBox.Show(string.Format("请先选择元素，再进行操作"));
                }

                string action = ComandCollection.Text;
                try
                {
                    ClearXpathBorder();
                    switch (action)
                    {
                        case "单击":
                            JAction.Click(element);
                            break;
                        case "JS单击":
                            JAction.ClickJS(driver, element);
                            break;
                        case "Action单击":
                            JAction.ClickAction(driver, element);
                            break;
                        case "双击":
                            JAction.DoubleClick(driver, element);
                            break;
                        case "右击":
                            JAction.RightClick(driver, element);
                            break;
                        case "输入":
                            JAction.SendKeys(element, TvalueTxtBox.Text);
                            break;
                        case "清空":
                            JAction.Clear(element);
                            break;
                        case "下拉-文本选择":
                            SelectElement SelectOption = new SelectElement(element);
                            SelectOption.SelectByText(TvalueTxtBox.Text);
                            break;
                        case "切换IFrame":
                            JSupport.SwitchIFrame(driver, IFrameCollection.Text);
                            break;
                        default:
                            break;
                    }
                    MessageBox.Show(string.Format("{0}-命令操作成功", action));
                }
                catch
                {
                    MessageBox.Show(string.Format("{0}-命令操作失败", action));
                }
            }

        }

        private void Copy_Click(object sender, EventArgs e)
        {
            string Xpath = GetXpathCollection();
            if (string.IsNullOrEmpty(Xpath))
            {
                MessageBox.Show("请先生成Xpath之后再复制");
            }
            else
            {
                Clipboard.SetDataObject(Xpath);
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            XpathDateView.Rows.Clear();
            ResultDateView.Rows.Clear();
            TvalueTxtBox.Text = null;
            TargetTxtBox.Text = null;
            txtLindex.Text = null;
            ClearXpathBorder();
        }

        private void ResearchBtn_Click(object sender, EventArgs e)
        {
            driver = SXDXWeb.driver;
            ResultDateView.Rows.Clear();
            //Clean broder
            ClearXpathBorder();
            //Find elements
            string Xpath = GetXpathCollection();
            elements = driver.FindElements(By.XPath(Xpath)).Where(x => x.Enabled && x.Displayed && x.Size.Width > 0 && x.Size.Height > 0).ToList();
            if (elements.Count == 0)
            {
                MessageBox.Show("未找到任何元素，请重试");
            }
            else
            {
                foreach (IWebElement item in elements)
                {
                    string TagName = item.TagName;
                    string Text = item.Text;
                    string Name = item.GetAttribute("Name");
                    string Value = item.GetAttribute("Value");
                    string width = item.Size.Width.ToString();
                    string height = item.Size.Height.ToString();
                    ResultDateView.Rows.Add(TagName, Text, Name, Value, width, height);
                }
                ResultDateView.ClearSelection();
            }
        }

        private void RetrunElement_Click(object sender, EventArgs e)
        {
            try
            {
                int index = ResultDateView.CurrentRow.Index;
                JFind.elements.Clear();
                JFind.elements.Add(elements[index]);
                JAction.element = elements[index];
                this.Close();
            }
            catch
            {
                MessageBox.Show("请选择元素，再进行返回操作");
            }

        }

        private void ResultDateView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IWebElement OldElement, NewElement;
            if (Index.HasValue)
            {
                OldElement = elements[Index.Value];
            }
            else
            {
                OldElement = elements[ResultDateView.CurrentRow.Index];
            }
            Index = ResultDateView.CurrentRow.Index;
            NewElement = elements[Index.Value];
            try
            {
                JS.WclForm_ClearBorder(driver, OldElement);
                JS.WclForm_SetBorder(driver, NewElement);
            }
            catch
            {
                MessageBox.Show("找不到元素，重新查找元素");
            }

        }

        private void WclForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearXpathBorder();
        }

        public string GetXpathCollection()
        {
            string Xpath = null;
            int loopTimes = XpathDateView.Rows.Count;
            for (int i = 0; i <= loopTimes - 2; i++)
            {
                Xpath += XpathDateView.Rows[i].Cells[0].Value.ToString();
                if (i != loopTimes - 2)
                {
                    Xpath += "|\n";
                }
            }
            return Xpath;
        }

        public void ClearXpathBorder()
        {
            if (Index.HasValue)
            {
                try
                {
                    JS.WclForm_ClearBorder(driver, elements[Index.Value]);
                    Index = null;
                }
                catch
                {
                    MessageBox.Show("网页已被刷新，如果是IE浏览器，driver丢失");
                }
            }
        }

        private void ComandCollection_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ComandCollection.Text == "切换IFrame")
            {
                IFrameCollection.Enabled = true;
                labIFrame.Enabled = true;
            }
            else
            {
                IFrameCollection.Text = null;
                IFrameCollection.Enabled = false;
                labIFrame.Enabled = false;
            }
        }

        private void WclForm_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //1:Get all of variable
            string Lindex, Action, IFrame, Target, Tvale, sType, Step;
            Lindex = txtLindex.Text.ToString();
            sType = SelectOptions.Text.ToString();
            Target = TargetTxtBox.Text.ToString();
            Tvale = TvalueTxtBox.Text.ToString();
            Action = ComandCollection.Text.ToString();
            IFrame = IFrameCollection.Text.ToString();
            Step = StepLabel.Text.ToString();
            //2.Combin all of condition
            //if (!string.IsNullOrEmpty(Target))
            //{
            //    if (!string.IsNullOrEmpty(Lindex))
            //    {
            //        Lindex = "@索引-" + Lindex;
            //        Target += "|" + Lindex;
            //    }
            //}
            if (!string.IsNullOrEmpty(sType))
            {
                sType = "@" + sType;
                if (!string.IsNullOrEmpty(IFrame))
                {
                    IFrame = "@切入-" + IFrame;
                    sType = string.IsNullOrEmpty(sType) ? IFrame : IFrame + "|" + sType;
                }
                if (!string.IsNullOrEmpty(Action))
                {
                    sType += Action.Contains("切换IFrame") ? string.Empty : "|@" + Action;
                }
            }
            CommandString = "Order:" + Step + "\r\nTarget:" + Target + "\r\nsType:" + sType + "\r\nTvalue:" + Tvale + "\r\nLindex:" + Lindex;

         //Clipboard.SetDataObject(CommandString);
         //MessageBox.Show(CommandString);
        }
    }
}

