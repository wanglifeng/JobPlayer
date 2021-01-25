using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using CL.Manage.Data;
namespace CL.Web.SXDX.Support
{
    public static class  JAction
    {
        public static IList<IWebElement> elements;
        public static IWebElement element;

        #region Action
        static public void Click(IWebElement ele)
        {
            if (!JWait.WaitUntil(() =>
            {
                element = ele;
                element.Click();
            }, 30)){
                //Develop Model
                //if (DataStatus.DevelopeModel)
                //{
                //    WebUI.WclForm_Element(element, "元素点击失败");
                //    element.Click();
                //}
                //else
                //{                    
                    throw new Exception(string.Format("✘：【{0}】点击失败,当前页面可能存在重复项，请核对", element.Text));                    
                //}
            }
           
        }

        static public void ClickJS(IWebDriver driver,IWebElement element)
        {
            if (!JWait.WaitUntil(() =>
            {
                IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);
                js.ExecuteScript("arguments[0].click()", element);
            }, 30)) throw new Exception(string.Format("✘：【{0}】点击失败,当前页面可能存在重复项，请核对", element.Text));
        }

        static public void ClickAction(IWebDriver driver, IWebElement element)
        {
            if (!JWait.WaitUntil(() =>
            {
                Actions builder = new Actions(driver);
                builder.Click(element).Perform();
            }, 30)) throw new Exception(string.Format("✘：【{0}】点击失败,当前页面可能存在重复项，请核对", element.Text));
        }

        static public void EnterAction(IWebDriver driver, IWebElement element)
        {
            if (!JWait.WaitUntil(() =>
            {
                Actions builder = new Actions(driver);
                builder.SendKeys(Keys.Enter).Perform();
            }, 30)) throw new Exception(string.Format("✘：【{0}】回车失败", element.Text));
        }

        static public void RightClick(IWebDriver driver, IWebElement element)
        {
            if (!JWait.WaitUntil(() =>
            {
                Actions builder = new Actions(driver);
                builder.ContextClick(element).Perform();
            }, 30)) throw new Exception(string.Format("✘：【{0}】点击失败,当前页面可能存在重复项，请核对", element.Text));
        }

        static public void DoubleClick(IWebDriver driver,IWebElement element)
        {
            if (!JWait.WaitUntil(() =>
            {
                Actions builder = new Actions(driver);
                builder.DoubleClick(element).Perform();
            }, 30)) throw new Exception(string.Format("✘：【{0}】双击失败", element));
        }

        static public void MoveToElement(IWebDriver driver, IWebElement element)
        {
            if (!JWait.WaitUntil(() =>
            {
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }, 30)) throw new Exception(string.Format("✘：【{0}】移动至该元素失败,当前页面可能存在重复项，请核对", element.Text));
        }

        static public void SendKeys(IWebElement element,string Tvalue)
        {
            if (!JWait.WaitUntil(() =>
            {
                element.SendKeys(Tvalue);
            }, 30)) throw new Exception(string.Format("✘：【{0}】输入失败", element));
        }



        static public void Clear(IWebElement element)
        {
            if (!JWait.WaitUntil(() =>
            {
                element.Clear();
            }, 30)) throw new Exception(string.Format("✘：【{0}】清空失败", element));
        }

        #endregion

        #region//Switch PageNumuber
        public static void SwitchToPageNum(IWebDriver driver, string Tvalue)
        {
            JWait.WaitForAjaxComplete(driver, 30);
            elements = driver.FindElements(By.ClassName("page-num"));
            if (Tvalue.Contains("尾页"))
            {
                List<string> pageNumb = new List<string>();
                foreach (IWebElement item in elements)
                {
                    pageNumb.Add(item.Text);
                }
                Tvalue = pageNumb.Max();
            }
            IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);
            js.ExecuteScript(string.Format("javascript:gotoPage({0})", Tvalue));
        }
        #endregion

        #region//Alert
        static public void AlertYesOrNo(IWebDriver driver, string Message, string Judge)
        {
            if (!JWait.WaitUntil(() =>
            {
                IAlert a = driver.SwitchTo().Alert();
                if (a.Text.Contains(Message))
                {
                    switch (Judge)
                    {
                        case "确定":
                            a.Accept();
                            break;
                        case "取消":
                            a.Dismiss();
                            break;
                        default:
                            throw new Exception(string.Format("✘：核对{0}参数是否填写正确", Judge));
                    }
                }
                else
                {
                    throw new Exception(string.Format("✘：核对{0}文本内容", Message));
                }
            }, 30)) throw new Exception("✘：未找到弹出框");

        }

        #endregion
    }
}
