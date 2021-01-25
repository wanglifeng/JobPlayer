using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using System.Xml.Linq;
using System.IO;
namespace CL.Manage.Data
{
    public enum DeviceType {
        Android,
        IOS
    }

    public enum Direction
    {
        UP,
        Left,
        Right,
        Down
    }
    public class DeviceStatus
    {
        public static DeviceType PlatForm { get; set; }
        public static Size Size { get; set; }
        public static List<XDocument> pageSourceCache{ get; set; }

        public static AndroidDriver<AndroidElement> driver_Android;
        public static IOSDriver<IOSElement> driver_IOS;


        public static void InitialDevice(DeviceType device,dynamic curDriver){
            PlatForm = device;
            switch(device){
                case DeviceType.Android:
                    driver_Android = curDriver;
                    Size = driver_Android.Manage().Window.Size;
                    break;
                case DeviceType.IOS:
                    driver_IOS = curDriver;
                    Size = driver_IOS.Manage().Window.Size;
                    break;
            }
        }

        public static void Dispose()
        {
            switch (PlatForm)
            {
                case DeviceType.Android:
                    driver_Android.Quit();
                    break;
                case DeviceType.IOS:
                    driver_IOS.Quit();
                    break;
            }
        }

        public static List<XDocument> GetSource()
        {
            pageSourceCache = new List<XDocument>();
            string path = null;
            switch (PlatForm)
            {
                case DeviceType.Android:
                    pageSourceCache.Add(XDocument.Parse(driver_Android.PageSource));
                    break;
                case DeviceType.IOS:
                    path = Environment.CurrentDirectory + @"\cache\";                    
                    pageSourceCache.Add(XDocument.Parse(driver_IOS.PageSource));
                    pageSourceCache.Add(XDocument.Load(string.Format("{0}{1}", path, "IphoneX-督办.xml")));
                    //pageSourceCache.Add(XDocument.Load(string.Format("{0}{1}", path, "IphoneX-驾驶舱.xml")));
                    break;
            }
            return pageSourceCache;
        }



        public static Bitmap GetScreenshot()
        {
            byte[] picture;
            MemoryStream ms;
            Bitmap image = null;
            switch (PlatForm)
            {
                case DeviceType.Android:
                    picture = driver_Android.GetScreenshot().AsByteArray;
                    ms = new MemoryStream(picture);
                    image = new Bitmap(ms);
                    break;
                case DeviceType.IOS:
                    picture = driver_IOS.GetScreenshot().AsByteArray;
                    ms = new MemoryStream(picture);
                    image = new Bitmap(ms);
                    break;
            }
            return image;         
        }

    }
}
