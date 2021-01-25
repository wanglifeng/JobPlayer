using System.Collections.Generic;
using OpenQA.Selenium;
namespace CL.Web.SXDX.Support
{
    public static class JElement
    {
        public static IWebElement element;
        public static IList<IWebElement> elements;

        #region//Get element
        public static IWebElement GetBtnElement(IWebDriver driver, string Tvalue, string Target)
        {
            JWait.WaitForAjaxComplete(driver, 30);
            string sXpath = JXpath.Button(Tvalue, Target);
            return element = JFind.XPath(driver, sXpath);
        }


        public static IWebElement GetRadioElement(IWebDriver driver, string Tvalue, string Target)
        {
            JWait.WaitForAjaxComplete(driver, 30);
            string sXpath = JXpath.Radio(Tvalue, Target);
            return element = JFind.XPath(driver, sXpath);
        }

        public static IWebElement GetTreeNodeElement(IWebDriver driver, string Tvalue, string Target)
        {
            JWait.WaitForAjaxComplete(driver, 30);
            string sXpath = JXpath.TreeNode(Tvalue, Target);
            return element = JFind.XPath(driver, sXpath);
        }

        public static IWebElement GetIConElement(IWebDriver driver, string Tvalue, string Target)
        {
            JWait.WaitForAjaxComplete(driver, 30);
            string sXpath = JXpath.IConButton(Tvalue,Target);
            return element = JFind.XPath(driver, sXpath);
        }

        public static IWebElement GetInputElement(IWebDriver driver, string Tvalue, string Target)
        {
            JWait.WaitForAjaxComplete(driver, 30);
            string sXpath = JXpath.Input(Target, Tvalue);
            return element = JFind.XPath(driver, sXpath);
        }
        public static IWebElement GetFileInputElement(IWebDriver driver, string Tvalue, string Target)
        {
            JWait.WaitForAjaxComplete(driver, 30);
            string sXpath = JXpath.FileInput(Target, Tvalue);
            return element = driver.FindElement(By.XPath(sXpath));
        }

        public static IWebElement GetSelectElement(IWebDriver driver, string Tvalue, string Target)
        {
            JWait.WaitForAjaxComplete(driver, 30);
            string sXpath = JXpath.Select(Target, Tvalue);
            return element = JFind.XPath(driver, sXpath);
        }

        public static IWebElement GetDateTimeElement(IWebDriver driver, string Target, string Tvalue, string sType)
        {
            JWait.WaitForAjaxComplete(driver, 30);
            string sXpath = JXpath.DateTimeInput(Target, Tvalue, sType);
            return element = JFind.XPath(driver, sXpath);
        }

        public static IWebElement GetDirectionElement(IWebDriver driver, string Tvalue)
        {
            JWait.WaitForAjaxComplete(driver, 30);
            string sXpath = JXpath.DirectionButton(Tvalue);
            return element = JFind.XPath(driver, sXpath);
        }

        public static IWebElement GetValidXpath(IWebDriver driver, string Tvalue, string Target)
        {
            JWait.WaitForAjaxComplete(driver, 30);
            string sXpath = JXpath.Valid(Tvalue, Target);
            return element = JFind.XPath(driver, sXpath);

        }
        #endregion
    }
}
