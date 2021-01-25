using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Drawing;

namespace CL.Manage.Data.CaseView
{
    public class CaseView
    {
        public static string TestCaseID { get; set; }
        public static string StepOrder { get; set; }
        private static StepCollection StepCollectionForm { get; set; }
        public static HashSet<string> DebugList = new HashSet<string>();
        public static Dictionary<string, object> StepDataSourse = new Dictionary<string, object>();
        public static Dictionary<string, string> CurStep = new Dictionary<string, string>();


        public static void PraseSingleTestCase(string caseXml)
        {
            XDocument Xml = XDocument.Parse(caseXml);
            string caseID = Xml.Root.Attribute("name").Value;
            var XStep = Xml.Root.XPathSelectElements("//Step").ToList();
            XStep.Sort((x, y) =>
            {
                return int.Parse(x.Attribute("order").Value)
                    .CompareTo(int.Parse(y.Attribute("order").Value));
            });
            //Construct data sourse
            foreach (var Case in XStep)
            {
                string id = string.Empty;
                string name = Case.Attribute("name").Value;
                string order = Case.Attribute("order").Value;
                string desc = Case.Attribute("desc").Value;
                string stepName = string.Empty;
                string stepValue = string.Empty;
                Dictionary<string, string> attribute = new Dictionary<string, string>();
                foreach (var Step in Case.Elements())
                {
                    stepName = Step.Attribute("name").Value;
                    stepValue = Step.Attribute("value").Value;
                    if (stepName == "SID")
                    {
                        id = stepValue;
                        continue;
                    }
                    try
                    {
                        attribute.Add(stepName.ToLower(), stepValue);
                    }
                    catch
                    {
                        string error = string.Format("删除第{0}条案例，第{1}步骤后重试", caseID, order);
                        Console.WriteLine(error);
                        throw new Exception(error);
                    }
                }
                object parameter = new
                {
                    Step = new Dictionary<string, string>{
                        {"caseID",caseID},
                        {"id",id},
                        {"name",name},
                        {"order",order},
                        {"desc",desc}
                    },
                    Parameter = attribute
                };
                StepDataSourse.Add(id, parameter);
            }

        }

        public static void InitStepCaseForm()
        {
            if (DataStatus.ProcessModel) return;
            StepCollectionForm = new StepCollection();
        }

        public static void ShowStepCaseForm()
        {
            if (DataStatus.ProcessModel) return;
            if (StepDataSourse != null && StepDataSourse.Any() && StepCollectionForm != null && !StepCollectionForm.Visible)
            {
                Thread t = new Thread(delegate()
                {
                    StepCollectionForm.ShowDialog();
                });
                t.Start();
                while (!StepCollectionForm.Visible)
                {
                    Thread.Sleep(500);
                }
            }
            else
            {
                MessageBox.Show("请调试执行后重试！");
            }
        }

        public static void Hightlight(string SID, bool status)
        {
            StepCollectionForm.neonShow(SID, status);
        }

        public static void DataClear(string SID, bool force)
        {
            if (DataStatus.ProcessModel) return;
            if (force)
            {
                DebugList.Clear();
                StepDataSourse.Clear();
            }
            else
            {
                if (StepDataSourse.Last().Key == SID)
                {
                    DebugList.Clear();
                    StepDataSourse.Clear();
                }
            }
        }

        public static Dictionary<int, string> GetFileFath(string path)
        {
            Dictionary<int, string> fileArray = new Dictionary<int, string>();
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fil = dir.GetFiles();
            DirectoryInfo[] dii = dir.GetDirectories();
            fileArray.Clear();
            foreach (FileInfo f in fil)
            {
                string filePath = path + @"\" + f;
                string extension = Path.GetExtension(filePath);//截取文件后缀名
                if (extension == ".xml")
                {
                    string noextension = Path.GetFileNameWithoutExtension(filePath);
                    char[] arr = noextension.ToCharArray();
                    string str2 = string.Empty;
                    int result = 0;
                    if (arr[0] == 'T')
                    {
                        string[] arr2 = noextension.Split('O');
                        char[] arr3 = arr2[1].ToCharArray();
                        for (int i = 0; i < arr3.Length; i++)
                        {
                            if (arr3[i] >= '0' && arr3[i] <= '9')
                            {
                                str2 += arr3[i];
                            }
                        }
                        result = Convert.ToInt32(str2);
                        try
                        {
                            fileArray.Add(result, f.FullName);
                        }
                        catch
                        {
                            string message = "测试平台复合案例存在缓存，删除后重建";
                            Console.WriteLine(message);
                            throw new Exception(message);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return fileArray.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        public static void PraseProcessTestCase(string path, string processName)
        {
            StepDataSourse.Clear();
            XDocument XML = XDocument.Load(path + processName + ".xml");
            List<string> fileList = new List<string>();
            var Case = XML.Root.XPathSelectElements("//TestCase").ToList();
            Case.Sort((x, y) =>
            {
                int a = int.Parse(x.Attribute("order").Value);
                int b = int.Parse(y.Attribute("order").Value);
                return a.CompareTo(b);
            });
            foreach (XElement item in Case)
            {
                string fileName = item.Attribute("name").Value + ".xml";
                string testcasePath = path + fileName;
                string casxXml = File.ReadAllText(testcasePath);
                PraseSingleTestCase(casxXml);
            }
        }

        public static void SaveTestID(string testID)
        {
            if (DataStatus.ProcessModel) return;
            TestCaseID = testID;
        }


   
    }
}
