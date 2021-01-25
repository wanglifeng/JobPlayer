using CL.Manage.Data.CaseView;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CL.Manage.Data
{
    public static class DataStatus
    {
       private static IWebDriver webDriver { get; set; }
       private static bool dispose = false;
       public static bool DevelopeModel = false;
       public static bool CleanModel = true;
       public static bool ProcessModel = true;
       public static bool Dispose {
           get {
               bool temp = dispose;
               if (dispose == true)dispose = false;
               return temp;
           }
           set { dispose = value; }
       }

       public static void SetWebDriver(IWebDriver driver) {
           webDriver = driver;
       }
       public static bool WebQuit() {
           if (CleanModel == false) return false;
           try
           {
               if (webDriver != null)
               {
                   webDriver.Quit();
               }
           }
           catch (Exception)
           { }
           //杀死IE
           Process[] prosIE = Process.GetProcessesByName("IEXPLORE");
           foreach (System.Diagnostics.Process p in prosIE)
           {
               try
               {
                   p.Kill();
               }
               catch { }
           }
           //为了案例执行过程中卡死后无法继续后面的案例，杀掉IE进程
           Process[] pros1 = Process.GetProcessesByName("IEDriverServer");
           foreach (System.Diagnostics.Process p in pros1)
           {
               try
               {
                   p.Kill();
               }
               catch { }
           }
           //杀死chrome
           Process[] prosChrome = Process.GetProcessesByName("chrome");
           foreach (System.Diagnostics.Process p in prosChrome)
           {
               try
               {
                   if (p.MainWindowTitle.Contains("云测试管理平台") || p.MainWindowTitle == "")
                   {
                       continue;
                   }
                   p.Kill();
               }
               catch { }
           }
           //为了案例执行过程中卡死后无法继续后面的案例，杀掉IE进程
           Process[] pros2 = Process.GetProcessesByName("chromeServer");
           foreach (System.Diagnostics.Process p in pros2)
           {
               try
               {
                   p.Kill();
               }
               catch { }
           }
           GC.Collect();   //回收垃圾       
           return true;
       }
        public static IWebDriver GetWebDriver()
        {
            return webDriver;
        }
    }
}
