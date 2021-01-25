using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using System.Threading;
using CL.Manage.Data;
namespace CL.Web.SXDX.Support
{
    public static class JFind
    {
        public static IWebElement element;
        public static IList<IWebElement> elements;
        static public IWebElement XPath(IWebDriver driver,string Xpathstring){
            if (!JWait.WaitUntil(() =>
            {
                elements = driver.FindElements(By.XPath(Xpathstring)).Where(x => x.Displayed && x.Enabled).ToList();
                if (elements.Count < 1) throw new NoSuchElementException();
            }, 10)) {
                //Develop Model Set
                //if (DataStatus.DevelopeModel)
                //{
                //    WebUI.WclForm_Xpath(Xpathstring);
                //}
                //else {
                    throw new NoSuchElementException(string.Format("✘：找不到元素，请检查参数是否填写正确,xpath：{0}", Xpathstring));                 
                //}
            }
            return elements[0];
        }

        static public IWebElement TagName(IWebDriver driver, string TagName)
        {
            if (!JWait.WaitUntil(() =>
            {
                elements = driver.FindElements(By.TagName(TagName)).Where(x => x.Displayed && x.Enabled).ToList(); 
                if (elements.Count < 1) throw new NoSuchElementException();
            }, 10)) throw new NoSuchElementException(string.Format("✘：【{0}】TagName错误，找不到元素", TagName));
            return elements[0];
        }

        static public IWebElement Name(IWebDriver driver, string Name)
        {
            if (!JWait.WaitUntil(() =>
            {
                elements = driver.FindElements(By.Name(Name)).Where(x => x.Displayed && x.Enabled).ToList();
                if (elements.Count < 1) throw new NoSuchElementException();
            }, 10)) throw new NoSuchElementException(string.Format("✘：【{0}】Name错误，找不到元素", Name));
            return elements[0];
        }

        static public IWebElement ID(IWebDriver driver, string ID)
        {
            if (!JWait.WaitUntil(() =>
            {
                element = driver.FindElement(By.Id(ID));
            }, 10)) throw new NoSuchElementException(string.Format("✘：【{0}】ID错误，找不到元素", ID));
            return element;
        }

        static public IWebElement ClassName(IWebDriver driver, string ClassName)
        {
            if (!JWait.WaitUntil(() =>
            {
                elements = driver.FindElements(By.ClassName(ClassName)).Where(x => x.Displayed && x.Enabled).ToList();
                if (elements.Count < 1) throw new NoSuchElementException();
            }, 10)) throw new NoSuchElementException(string.Format("✘：【{0}】ClassName错误，找不到元素", ClassName));
            return elements[0];
        }

        static public IList<IWebElement> XPaths(IWebDriver driver, string Xpathstring)
        {
            if (!JWait.WaitUntil(() =>
            {
                elements = driver.FindElements(By.XPath(Xpathstring)).Where(x => x.Displayed && x.Enabled).ToList();
                if (elements.Count < 1) throw new NoSuchElementException();
            }, 10)) throw new NoSuchElementException(string.Format("✘：【{0}】语句错误，找不到元素", Xpathstring));
            return elements;
        }

        static public IList<IWebElement> TagNames(IWebDriver driver, string TagName)
        {
            if (!JWait.WaitUntil(() =>
            {
                elements = driver.FindElements(By.TagName(TagName)).Where(x => x.Displayed && x.Enabled).ToList();
                if (elements.Count < 1) throw new NoSuchElementException();
            }, 10)) throw new NoSuchElementException(string.Format("✘：【{0}】TagName错误，找不到元素", TagName));
            return elements;
        }

        static public IList<IWebElement> Names(IWebDriver driver, string Name)
        {
            if (!JWait.WaitUntil(() =>
            {
                elements = driver.FindElements(By.Name(Name)).Where(x => x.Displayed && x.Enabled).ToList(); 
                if (elements.Count < 1) throw new NoSuchElementException();
            }, 10)) throw new NoSuchElementException(string.Format("✘：【{0}】Name错误，找不到元素", Name));
            return elements;
        }

        static public IList<IWebElement> ClassNames(IWebDriver driver, string ClassName)
        {
            if (!JWait.WaitUntil(() =>
            {
                elements = driver.FindElements(By.ClassName(ClassName)).Where(x => x.Displayed && x.Enabled).ToList();
                if (elements.Count < 1) throw new NoSuchElementException();
            }, 10)) throw new NoSuchElementException(string.Format("✘：【{0}】ClassName错误，找不到元素", ClassName));
            return elements;
        }

        static public IWebElement GetMatchText(IList<IWebElement> elements, string Tvalue)
        {
            bool hasValue = false;
            foreach (IWebElement item in elements)
            {
                if (item.Text == Tvalue)
                {
                    element = item;
                    hasValue = true;
                    break;
                }
            }
            if (hasValue) {
                return element;
            }
            else {
                throw new NoSuchElementException("✘：未找到匹配文本");
            }
            
        }

        static public IWebElement FindElementRecursion(IWebDriver driver,string Xpathstring)
        {
            //Frist find element
            By Element  = By.XPath(Xpathstring);
            By IFrame = By.XPath("//iframe|frame");
            //IF current IFrame can not find element
            if (!JSupport.IsElementExist(driver, Element, 2))
            {
                //Search all of Iframe 
                if (JSupport.IsElementExist(driver, IFrame, 2))
                {
                    var IFrameElements = driver.FindElements(IFrame);
                    foreach (IWebElement item in IFrameElements)
                    {
                        driver.SwitchTo().Frame(item);
                        FindElementRecursion(driver, Xpathstring);
                    }
                }
                else {
                    driver.SwitchTo().ParentFrame();
                }
                return element;
            }
            else { return element = driver.FindElement(Element);}
        }

        public static IWebElement FindTableByTd(IWebDriver driver, IWebElement Td, int row, int cell)
        {
            var js = ((IJavaScriptExecutor)driver);
            var element = js.ExecuteScript(@"
                                function FindTable(element){
	                                var element = element.parentNode;
	                                if(element.tagName == 'TABLE'){
		                                return element;
	                                }
		                                return FindTable(element);
                                }
                                var element = arguments[0];
                                var Tabel = FindTable(element);
                                var cellIndex = element.cellIndex + arguments[2];
                                var rowIndex = element.parentNode.rowIndex + arguments[1];
                                return Tabel.rows[rowIndex].cells[cellIndex];
                             ", Td, row, cell);
            return element as IWebElement;
        }

    }
}
