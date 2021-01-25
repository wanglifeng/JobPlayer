using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Reflection;

namespace CL.Web.SXDX.Common
{
    public class Util
    {
        #region

        public static List<IWebElement> SwicthToFrameName(IWebDriver driver, string ID, string xpath)
        {
            List<IWebElement> elements = null;
            try
            {
                if (ID.Contains(">"))
                {
                    string[] fNodes = ID.Split(new char[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < fNodes.Length; i++)
                    {
                        if (i == 0)
                        {
                            driver.SwitchTo().ParentFrame();
                            driver.SwitchTo().Frame(fNodes[i]);
                        }
                        else { driver.SwitchTo().Frame(fNodes[i]); }
                    }
                }
                else
                {
                    driver.SwitchTo().Frame(ID);
                }
                elements = driver.FindElements(By.XPath(xpath)).Where(e => e.Enabled && e.Displayed).ToList();
            }
            catch (Exception)
            {
                driver.SwitchTo().ParentFrame();
                driver.SwitchTo().Frame(ID);
                elements = driver.FindElements(By.XPath(xpath)).Where(e => e.Enabled && e.Displayed).ToList();
            }
            return elements;
        }

        public static List<IWebElement> SwicthToFrameNum(IWebDriver driver, string Num, string xpath)
        {
            List<IWebElement> frames = driver.FindElements(By.XPath("//iframe|//frame")).ToList();
            List<IWebElement> elements = null;
            try
            {
                if (Num.Contains(">"))
                {
                    string[] fNumNodes = Num.Split(new char[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < fNumNodes.Length; i++)
                    {
                        int fnum = Convert.ToInt32(fNumNodes[i]) - 1;
                        if (i == 0)
                        {
                            driver.SwitchTo().ParentFrame();
                            driver.SwitchTo().Frame(frames[fnum]);
                        }
                        else { driver.SwitchTo().Frame(frames[fnum]); }
                    }
                }
                else
                {
                    int fnum = Convert.ToInt32(Num) - 1;
                    driver.SwitchTo().Frame(frames[fnum]);
                }
                elements = driver.FindElements(By.XPath(xpath)).Where(e => e.Enabled && e.Displayed).ToList();
            }
            catch (Exception)
            {
                int fnum = Convert.ToInt32(Num) - 1;
                driver.SwitchTo().ParentFrame();
                driver.SwitchTo().Frame(frames[fnum]);
                elements = driver.FindElements(By.XPath(xpath)).Where(e => e.Enabled && e.Displayed).ToList();
            }

            return elements;
        }

        public static List<IWebElement> SwicthToFrameTP(IWebDriver driver, string xpath)
        {
            List<IWebElement> elements;
            driver.SwitchTo().DefaultContent();//跳出所有iframe，到最外面查找
            elements = driver.FindElements(By.XPath(xpath)).Where(e => e.Enabled && e.Displayed).ToList();
            if (elements.Count > 0)
            {
                return elements;
            }
            List<IWebElement> frames = driver.FindElements(By.TagName("iframe")).ToList();
            for (int i = 0; i < frames.Count; i++)
            {
                try
                {
                    driver.SwitchTo().DefaultContent();
                    driver.SwitchTo().Frame(frames[i]);
                }
                catch (Exception)
                {
                    driver.SwitchTo().DefaultContent();
                    driver.SwitchTo().Frame(frames[i]);
                }
                elements = driver.FindElements(By.XPath(xpath)).ToList();
                if (elements.Count > 0)
                {
                    return elements;
                }
            }
            return null;
        }

        #endregion
        private static void KillProcess(string processName)
        {
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();
            //得到所有打开的进程
            try
            {
                foreach (Process thisproc in Process.GetProcessesByName(processName))
                {
                    if (!thisproc.CloseMainWindow())
                    {
                        thisproc.Kill();
                    }
                }
            }
            catch
            {
                throw new Exception(string.Format("杀掉进程[{0}]失败！", processName));
            }
        }
        //清空IE缓存记录
        #region//DeleteIEData
        public static void DeleteIEData()
        {
            //1.History (历史记录)
            //RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 1
            ////2.Cookies
            //RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 2
            ////3.Temporary Internet Files (Internet临时文件)
            //RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 8
            ////4.Form. Data (表单数据)
            //RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 16
            ////5.Passwords (密码)
            //RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 32
            ////6.Delete All (全部删除)
            //RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 255
            ////7.Delete All - "Also delete files and settings stored by add-ons"
            //RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 4351
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "RunDll32.exe";
            p.StartInfo.Arguments = "InetCpl.cpl,ClearMyTracksByProcess 4351";
            p.Start();
            p.StandardOutput.ReadToEnd();
            p.WaitForExit();
        }
        #endregion

        #region
        public static string getSecurityCode(Point point, ITakesScreenshot tss, string type, int imgWidth, int imgHeight)
        {
            Graphics g = null;
            Bitmap bmpDest = null;
            Bitmap bmp = null;
            try
            {
                Screenshot screenShotFile = tss.GetScreenshot();
                string saveCodePath = System.Windows.Forms.Application.StartupPath + "\\tmpe";
                string screenPicPath = saveCodePath + @"\screenPic.jsp";
                screenShotFile.SaveAsFile(screenPicPath, ScreenshotImageFormat.Bmp);
                //screenShotFile.SaveAsFile(@"C:\temp\SecurityCode\screenPic.jsp", ImageFormat.Bmp);

                //bmp = new Bitmap(System.Drawing.Image.FromFile(@"C:\temp\SecurityCode\screenPic.jsp"));
                bmp = new Bitmap(System.Drawing.Image.FromFile(screenPicPath));
                //int bmpDestWith = 68;
                //int bmpDestHight = 26;
                int bmpDestWith = imgWidth;
                int bmpDestHight = imgHeight;
                bmpDest = new Bitmap(bmpDestWith, bmpDestHight, PixelFormat.Format32bppRgb);
                //这个矩形定义了，你将要在被截取的图像上要截取的图像区域的左顶点位置和截取的大小
                Rectangle rectSource = new Rectangle(point.X, point.Y, bmpDestWith, bmpDestHight);

                //这个矩形定义了，你将要把 截取的图像区域 绘制到初始化的位图的位置和大小
                //我的定义，说明，我将把截取的区域，从位图左顶点开始绘制，绘制截取的区域原来大小
                Rectangle rectDest = new Rectangle(0, 0, bmpDestWith, bmpDestHight);
                g = Graphics.FromImage(bmpDest);
                //第一个参数就是加载你要截取的图像对象，第二个和第三个参数及如上所说定义截取和绘制图像过程中的相关属性，第四个属性定义了属性值所使用的度量单位
                g.DrawImage(bmp, rectDest, rectSource, GraphicsUnit.Pixel);
                string imagePath = saveCodePath + @"\image.jsp";
                bmpDest.Save(@"C:\temp\runner\image.jpg");
                bmpDest.Save(imagePath);

                string scode = null;

                // scode = ocr.GetOCRString(bmpSecurityCode, new Rectangle());
                scode = OrcText(bmpDest);
                Console.WriteLine(scode);
                return scode;
            }
            catch (Exception)
            {
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                g.Dispose();
                bmp.Dispose();
                //bmpSecurityCode.Dispose();
                bmpDest.Dispose();
            }
            return null;

        }
        #endregion

        public static string Read(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string result = "";
            string line = null;
            while ((line = sr.ReadLine()) != null)
            {
                result += line.ToString();
            }
            sr.Close();
            return result;
        }

        public static string OrcText(Bitmap bitmap, bool IsNum = false)
        {
            try
            {
                bitmap.Save("orc.png");
                using (System.Diagnostics.Process p = new System.Diagnostics.Process())
                {
                    //绝对路径
                    p.StartInfo.FileName = @"D:\Program Files (x86)\Tesseract-OCR\tesseract.exe";
                    p.StartInfo.Arguments = string.Format("orc.png result -l eng -psm 7 digits");
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();
                    p.WaitForExit();
                    p.Close();
                }
            }
            catch { }
            return Read("result.txt");
        }
    }
}
