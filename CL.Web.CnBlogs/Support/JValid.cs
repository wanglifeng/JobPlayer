using System;
using OpenQA.Selenium;
namespace CL.Web.SXDX.Support
{
    public static class JValid
    {
        static public void ValidAlert(IWebDriver driver, string Message)
        {
            JWait.WaitUntil(()=>{
                IAlert a = driver.SwitchTo().Alert();
                if (!a.Text.Equals(Message))
                {
                    throw new Exception(string.Format("✘：弹出框文本验证失败"));
                }            
            });
        }
    }
}
