using CL.Manage.Data;
using CL.Manage.Data.String;
using CL.Web.SXDX.Support;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Automation;
using Excel = Microsoft.Office.Interop.Excel;
namespace CL.Web.SXDX.Drivers
{

    public class SXDXWeb
    {
        public int rep;
        public static IWebDriver driver;
        public IWebElement element;
        public IList<IWebElement> elements;

        //用于抓取并点击弹出窗体信息
        #region
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        const int MOUSEEVENTF_MOVE = 0x0001;
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标 
        #endregion


  

        //切换网页
        #region//BrowserTab
        public bool BrowserTab(string target, string sType)
        {
            Thread.Sleep(2000);
            bool isChange = false;
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    //在当前driver中比对URL，尝试切换Window
                    IList<string> Windows = driver.WindowHandles;
                    int WindowCount = Windows.Count();
                    for (int s = 0; s < WindowCount; s++)
                    {
                        driver.SwitchTo().Window(Windows[s]);
                        if ((!driver.Url.Contains(target)) || (!driver.Title.Contains(target)))
                        {
                            //暂时不用的浏览器最小化
                            driver.Manage().Window.Position = new System.Drawing.Point(-1500, 0);
                        }
                        if (driver.Url.Contains(target) || driver.Title.Contains(target))
                        {
                            isChange = true;
                            if (sType == "1")
                            {
                                try
                                {

                                    driver.Manage().Window.Maximize();
                                }
                                catch { }
                            }
                            else if (sType == "2")
                            {
                                driver.Close();
                            }
                            System.Threading.Thread.Sleep(1500);
                            return isChange;//比对RUL成功，切换浏览器成功
                        }

                    }
                    if (!isChange)
                    {
                        throw new Exception("切换浏览器失败！");
                    }
                }
            }
            catch (Exception)
            {
                Thread.Sleep(3000);
                IList<string> Windows = driver.WindowHandles;
                int WindowCount = Windows.Count();
                for (int s = 0; s < WindowCount; s++)
                {


                    if (driver.Url.Contains(target) || driver.Title.Contains(target))
                    {
                        isChange = true;
                        if (sType == "1")
                        {
                            try
                            {
                                driver.Manage().Window.Maximize();

                            }
                            catch { }
                        }
                        else if (sType == "2")
                        {
                            driver.Close();
                        }
                        System.Threading.Thread.Sleep(1500);
                        return isChange;//比对RUL成功，切换浏览器成功
                    }
                    if ((!driver.Url.Contains(target)) || (!driver.Title.Contains(target)))
                    {
                        //暂时不用的浏览器最小化
                        driver.Manage().Window.Position = new System.Drawing.Point(-1500, 0);
                        Thread.Sleep(1000);
                    }
                }
                if (!isChange)
                {
                    throw new Exception("切换浏览器失败！");
                }
            }
            return true;
        }
        #endregion

     
 

        //////////----------------------------         Regular component         ----------------------------//////////   
        #region//GotoUrlFast
        public bool GotoUrl(string url, string Browsertype, string WebDriverPath)
        {
            //judge browser type( chrome or ie )
            switch (Browsertype)
            {
                case "IE":
                    driver = new InternetExplorerDriver(WebDriverPath);
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl(url);
                    return true;
                case "CR":
                    ChromeOptions CROptions = new ChromeOptions();
                    CROptions.AddArgument("-start-maximized");
                    string ChromeXpathpath = Directory.GetCurrentDirectory().ToString() + "\\ChromeXpath.crx";
                    CROptions.AddExtension(ChromeXpathpath);
                    driver = new ChromeDriver(WebDriverPath);
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl(url);
                    return true;
                default:
                    return true;
            }
        }
        #endregion

        #region//Login
        public void Login(string Url, string driverPath, string userName, string Password)
        {
            //If password is null replace empty value
            Password = Password != null ? Password : "";
            //预上线环境账号
            ChromeOptions CROptions = new ChromeOptions();
            CROptions.AddArgument("-start-maximized");
            CROptions.AddArgument("--disable-gpu");
            if (!DataStatus.ProcessModel) {
                string ChromeXpathpath = Directory.GetCurrentDirectory().ToString() + "\\tools\\ChromeXpath.crx";
                CROptions.AddExtension(ChromeXpathpath);
            }
            driver = new ChromeDriver(driverPath, CROptions);
            DataStatus.SetWebDriver(driver);
            driver.Url = Url;
            JWait.WaitForAjaxComplete(driver, 30);
            if (!JWait.WaitUntil(() =>
            {                
                element = driver.FindElement(By.XPath("//input[@placeholder='用户名']"));
                element.Clear();
                element.SendKeys(userName);
                element = driver.FindElement(By.XPath("//input[@placeholder='密码']"));
                element.Clear();
                element.SendKeys(Password);
                element = driver.FindElement(By.XPath("//button[contains(text(),'登录')]"));
                element.Click();
                SwitchWebpage(driver.WindowHandles.Count);
            }, 30)) throw new Exception("✘：【登录失败】");
        }
        #endregion

        #region//Button
        public void ButtonClick(string Tvalue, string sType, string Target = null)
        {
            //Deal with Command
            List<string> Itmes = JSupport.ComandParse(ref Tvalue, ref Target, ref sType);
            //Action
            foreach (string item in Itmes)
            {
                switch (item)
                {
                    case "@单击":
                        JAction.Click(element);
                        break;
                    case "@JS单击":
                        JAction.ClickJS(driver, element);
                        break;
                    case "@右击":
                        JAction.RightClick(driver, element);
                        break;
                    case "@双击":
                        JAction.DoubleClick(driver, element);
                        break;
                    case "@普通按钮":
                        element = JElement.GetBtnElement(driver, Tvalue, Target);
                        break;
                    case "@勾选按钮":
                        element = JElement.GetRadioElement(driver, Tvalue, Target);
                        break;
                    case "@树节点按钮":
                        element = JElement.GetTreeNodeElement(driver, Tvalue, Target);
                        break;
                    case "@图标按钮":
                        element = JElement.GetIConElement(driver, Tvalue, Target);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(string.Format("✘：sType命令中不存在：{0}，请核对", Itmes));
                }
            }
        }
        #endregion

        #region//Input
        public void InputText(string Tvalue, string Target, string sType)
        {
            //Deal with Command
            List<string> Itmes = JSupport.ComandParse(ref Tvalue, ref Target, ref sType);
            //Action
            foreach (string item in Itmes)
            {
                switch (item)
                {
                    case "@普通文本框":
                        element = JElement.GetInputElement(driver, Tvalue, Target);
                        break;
                    case "@文件文本框":
                        element = JElement.GetFileInputElement(driver, Tvalue, Target);
                        break;
                    case "@清空":
                        JAction.Clear(element);
                        break;
                    case "@搜索":
                        JAction.EnterAction(driver, element);
                        break;
                    case "@输入":
                        JAction.SendKeys(element, Tvalue);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(string.Format("✘：sType命令中不存在：{0}，请核对", item));
                }
            }
        }
        #endregion

        #region//Select
        public void SelectOption(string Tvalue, string Target, string sType)
        {
            //Deal with Command
            var Itmes = JSupport.ComandParse(ref Tvalue, ref Target, ref sType);
            SelectElement SelectOption = null;
            //Action
            foreach (string item in Itmes)
            {
                switch (item)
                {                  
                    case "@传统下拉框":
                        element = JElement.GetSelectElement(driver, Tvalue, Target);
                        SelectOption = new SelectElement(element);
                        break;
                    case "@文本选择":
                        SelectOption.SelectByText(Tvalue);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(string.Format("✘：下拉框命令中不存在：{0}，请核对", item));
                }
            }
        }
        #endregion

        #region//DateTime
        public void InputDateTime(string Tvalue, string Target = null, string sType = null)
        {
            //Get element
            element = JElement.GetDateTimeElement(driver, Target, Tvalue, sType);
            //Set time
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].value ='" + Tvalue + "' ", element);
        }
        #endregion

        #region//Upload file
        public void UploadFile(string filePath)
        {
            //Name file path by Developer
            AutomationElement OpenDialog = null;
            AutomationElement EditElement = null;
            AutomationElement SubmitElement = null;
            //Get opendialog element 
            JWait.WaitUntil(() =>
            {
                AutomationElement Desktop = AutomationElement.RootElement;
                Condition OpenDialogConditon = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, "打开"),
                    new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "对话框")
                    );
                OpenDialog = Desktop.FindFirst(TreeScope.Descendants, OpenDialogConditon);
                if (OpenDialog == null) throw new Exception();
            }, 30);
            //Get Edit element an set value to input
            Condition EditConditon = new AndCondition(
                                new PropertyCondition(AutomationElement.NameProperty, "文件名(N):"),
                                new PropertyCondition(AutomationElement.ClassNameProperty, "Edit"),
                                new PropertyCondition(AutomationElement.IsValuePatternAvailableProperty, true)
                                );
            EditElement = OpenDialog.FindFirst(TreeScope.Descendants, EditConditon);
            ValuePattern EditAction = EditElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            EditAction.SetValue(filePath);
            //Get submit element and click the button
            Condition SubmitConditon = new AndCondition(
                      new PropertyCondition(AutomationElement.NameProperty, "打开(O)"),
                      new PropertyCondition(AutomationElement.ClassNameProperty, "Button"),
                      new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "按钮")
                      );
            SubmitElement = OpenDialog.FindFirst(TreeScope.Children, SubmitConditon);
            InvokePattern SubmitAction = SubmitElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            SubmitAction.Invoke();
        }
        #endregion

        #region//JavaScript Upload file
        public void UploadFileJs(string filePath, string Target)
        {
            string xpath = string.Format(@"//*[contains(text(),'{0}')]//..//..//span[@class='input-file']|
                                           //*[contains(text(),'{0}')]//..//following-sibling::div//span[@class='input-file']
                                        ", Target);
            element = JFind.XPath(driver, xpath);
            IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);
            js.ExecuteScript("$(\"<label><i class='icon icon-file'></i>" + filePath + "<input type='button' class='close' value='×'></label>\").appendTo(arguments[0])", element);
        }
        #endregion

        #region//Scroll control
        public void ScrollTo(string Tvalue)
        {
            JWait.WaitForAjaxComplete(driver, 10);
            JS.scrollJS(driver, Tvalue);
        }
        #endregion

        #region//Switch web page
        public void SwitchWebpage(int Lindex)
        {
            if (!JWait.WaitUntil(() =>
            {
                ReadOnlyCollection<String> windowHandles = driver.WindowHandles;
                String Index = windowHandles[Lindex - 1];
                driver.SwitchTo().Window(Index);
            }, 10)) throw new Exception(string.Format("✘：【切换网页】至第{0}标签页失败", Lindex));
        }
        #endregion

        #region//Valid
        public void Valid(string Tvalue, string sType = null, string Target = null)
        {
            //Deal with Command
            var Itmes = JSupport.ComandParse(ref Tvalue, ref Target, ref sType);
            //Action
            foreach (string item in Itmes)
            {
                switch (item)
                {
                    case "@弹出框校验":
                        JValid.ValidAlert(driver, Tvalue);
                        break;
                    case "@文本":
                        element = JElement.GetValidXpath(driver, Tvalue, Target);
                        break;
                    case "@对比":
                        if (!element.Text.Contains(Tvalue))throw new Exception(string.Format("✘：文本校验失败，请检查文本：{0}", Tvalue));                
                        break;                                         
                    default:
                        throw new ArgumentOutOfRangeException(string.Format("✘：sType命令中不存在：{0}，请核对", Itmes));
                }
            }
        }
        #endregion

        //////////----------------------------         Specific component         ----------------------------//////////  
    }
}
