using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using CL.Web.SXDX.Drivers;
using System.Threading;
using CL.Web.SXDX.View;
using CL.Web.SXDX.Support;
using CL.Manage;
namespace CL.Web.SXDX
{
    public  static class WebUI
    {
        #region//WclForm_Debug
        public static void WebUIDebug(string Tvalue, string Target)
        {
            WebUIForm Form = new WebUIForm();
            Form.Text += ": " + "调试模式";
            Form.TvalueTxtBox.Text = Tvalue;
            Form.TargetTxtBox.Text = Target;
            Form.RetrunElement.Enabled = false;
            Form.GenerateXpath_Click(Form, new EventArgs());
            Form.TopMost = true;
            Form.Focus();
            Form.ShowDialog();
        }
        #endregion

        #region//WclForm_Xpath
        public static void WclForm_Xpath(string Xpath)
        {
            WebUIForm Form = new WebUIForm();
            Form.Text += ": " + "Xpath找不到对应元素";
            var Collection = Xpath.Split('|');
            foreach (string item in Collection)
            {
                Form.XpathDateView.Rows.Add(item.Trim());
            }
            Form.TopMost = true;
            Form.Focus();
            Form.ShowDialog();
        }
        #endregion

        #region//WclForm_Element
        public static void WclForm_Element(IWebElement element,string Title)
        {
            WebUIForm Form = new WebUIForm();
            WebUIForm.elements.Add(element);
            JS.WclForm_SetBorder(SXDXWeb.driver, element);
            Form.Text += ": " + Title;
            string TagName = element.TagName;
            string Text = element.Text;
            string Name = element.GetAttribute("Name");
            string Value = element.GetAttribute("Value");
            string width = element.Size.Width.ToString();
            string height = element.Size.Height.ToString();
            Form.ResultDateView.Rows.Add(TagName, Text, Name, Value, width, height);
            Form.TopMost = true;
            Form.Focus();
            Form.ShowDialog();
        }
        #endregion

    }
}
