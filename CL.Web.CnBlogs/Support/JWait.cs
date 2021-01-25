using System;
using OpenQA.Selenium;
using System.Threading;
namespace CL.Web.SXDX.Support
{
    public static class JWait
    {
        #region//Wait action untill correct
        public static bool WaitUntil(Action function, int timeout = 5)
        {
            for (int i = 0; i < timeout; i++)
            {
                try
                {
                    function();
                    return true;
                }
                catch
                {
                    Thread.Sleep(500);
                    continue;
                }
            }
            return false;
        }
        #endregion;

        #region//Wait for ajax complete
        static public void WaitForAjaxComplete(IWebDriver driver, int maxSeconds)
        {
            bool is_ajax_compete = false;
            for (int i = 1; i <= maxSeconds; i++)
            {
                is_ajax_compete = (bool)((IJavaScriptExecutor)driver).
                ExecuteScript("return window.jQuery != undefined && jQuery.active == 0");
                if (is_ajax_compete)
                {
                    return;
                }
                System.Threading.Thread.Sleep(1000);
            }
            throw new Exception("页面加载超时 " + maxSeconds + " 秒");
        }
        #endregion
    }
}
