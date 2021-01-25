using OpenQA.Selenium;
namespace CL.Web.SXDX.Support
{
    public static class JS
    {
        public static IJavaScriptExecutor js;

        #region//Scroll control
        public static bool scrollJS(IWebDriver driver, string Deep)
        {
            js = ((IJavaScriptExecutor)driver);
            if (Deep == "顶部")
            {
                js.ExecuteScript(string.Format("var q=document.documentElement.scrollTop=0"));
            }
            else
            {
                //bottom
                js.ExecuteScript(string.Format("var q=document.documentElement.scrollTop=10000"));
            }
            return true;
        }
        #endregion;

        #region//Focse on element
        public static void Focus(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);
            js.ExecuteScript(@"
                                var element = arguments[0];
                                    element.focus();
                                    ", element);
        }
        #endregion;

        #region//Open new broser web tap by JS
        public static bool OpenNewWebTap(IWebDriver driver, string Url)
        {
            js = ((IJavaScriptExecutor)driver);
            js.ExecuteScript(string.Format("window.open('{0}')", Url));
            return true;
        }
        #endregion;

        #region//WclForm border helper
        public static void WclForm_SetBorder(IWebDriver driver, IWebElement element)
        {
            js = ((IJavaScriptExecutor)driver);
            js.ExecuteScript(@"
                                var element = arguments[0];
                                    element.style.outline = '#10c710 dashed 2px';
                                    ", element);
        }

        public static void WclForm_ClearBorder(IWebDriver driver, IWebElement element)
        {
            js = ((IJavaScriptExecutor)driver);
            js.ExecuteScript(@"
                                var element = arguments[0];
                                    element.style.outline = 0;
                                    ", element);
        }
        #endregion        
    }
}
