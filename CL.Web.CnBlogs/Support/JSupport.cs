using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using CL.Web.SXDX.Drivers;
using CL.Manage.Data;
using CL.Manage.Data.String;
namespace CL.Web.SXDX.Support
{
    public static class JSupport
    {        
        public static  IWebElement element;
        public static IList<IWebElement> elements;
        public static string index;
        public static string Index
        {
            get {
                string temp = index;
                index = null;
                return temp ?? "1";
            }
            set { index = value; }
        }

        //------         NICE TOOLS FOR DEVELOPER         ------//

        #region//Command parise
        public static List<string> ComandParse(ref string Tvalue, ref string Target, ref string sType)
        {
            //1.Combine all variable
            string[] command = (Tvalue + '|' + Target + '|' + sType).Split('|');
            List<string> Items = new List<string>(command).FindAll(x => x.Contains("@"));
            //2.Deal with speical variable
            if (Items.Exists(x => x.Contains("@保存") || x.Contains("@释放") ||
                                  x.Contains("@生成") || x.Contains("@索引") ||
                                  x.Contains("@切入") || x.Contains("@Debug") 
                                  ))
            {
                CommonVariable(ref Tvalue, ref Target, ref sType);
                //3.Filtration variable
                Items.RemoveAll(x => x.Contains("@保存") || x.Contains("@释放") ||
                                     x.Contains("@生成") || x.Contains("@索引") ||
                                     x.Contains("@切入") || x.Contains("@Debug"));
            }
            return Items;
        }
        #endregion

        #region//Switch to IFrame
        public static void SwitchIFrame(IWebDriver driver, string option)
        {
            //1.Initial iframe path
            Dictionary<string, string> IframeCollection = new Dictionary<string, string>(){
                {"主界面","defaul"},
                {"右侧","main-frame"},
                {"机构选择","main-frame/index-1"}
            };
            //2.Valid option is it exsit
            if (!IframeCollection.Keys.Contains(option))
            {
                throw new ArgumentOutOfRangeException(string.Format("IFrame命令输入错误:{0}，请重新输入", option));
            }
            //3.Switch to iframe path
            driver.SwitchTo().DefaultContent();
            var IframeItems = IframeCollection[option].Split('/');
            foreach (string item in IframeItems)
            {
                //Switch to defaulcontent
                if (item.Contains("defaul")) break;
                //Switch to iframe by index
                if (item.Contains("index-"))
                {
                    int index = Convert.ToInt16(item.Split('-')[1]);
                    driver.SwitchTo().Frame(index); continue;
                }
                //Switch to iframe by iframe's id or name
                driver.SwitchTo().Frame(item);
            }
        }
        #endregion

        #region//Save, release, generate, switch ifram 
        public static void CommonVariable(ref string Tvalue, ref string Target, ref string sType)
        {
            string Key,Value;
            //1.Tvalue
            if (Tvalue.Contains("@生成") || Tvalue.Contains("@释放"))
            {
                Key = Tvalue.Split('-')[0];
                Value = Tvalue.Split('-')[1];
                switch (Key)
                {
                    case "@生成":
                        switch (Value)
                        {
                            case "姓名":
                                Tvalue = Tvalue.CreateCnName();
                                break;
                            case "邮箱":
                                Tvalue = Tvalue.CreateEmail();
                                break;
                            case "手机号":
                                Tvalue = Tvalue.CreatePhoneNumber();
                                break;
                            case "身份证号":
                                Tvalue = Tvalue.CreateID();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(string.Format("✘：Tvalue生成变量集合命令中不存在：{0}", Value));
                        }
                        break;
                    case "@释放":
                        switch (Value)
                        {
                            case "姓名":
                                Tvalue = DataList.Get("姓名");
                                break;
                            case "邮箱":
                                Tvalue = DataList.Get("邮箱");
                                break;
                            case "手机号":
                                Tvalue = DataList.Get("手机号");
                                break;
                            case "身份证号":
                                Tvalue = DataList.Get("身份证号");
                                break;
                            default:
                               try {
                                   Tvalue = DataList.Get(Tvalue);
                                }
                                catch{
                                    throw new Exception(string.Format("✘：Tvalue释放变量集合中不存在：{0}", Value));                                
                                }
                                break;
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(string.Format("✘：Tvalue命令集合中不存在：{0}", Key));
                }
            }
            //2.Target
            if (!string.IsNullOrEmpty(Target) && (Target.Contains("@释放") || Target.Contains("@索引")))
            {
                var Save = new List<string>(Target.Split('|')).FindAll(x => x.Contains("@"));
                foreach (string item in Save)
                {
                    Key = item.Split('-')[0];
                    Value = item.Split('-')[1];
                    switch (Key)
                    {
                        case "@释放":
                            switch (Value)
                            {
                                case "姓名":
                                    Tvalue = DataList.Get("姓名");
                                    break;
                                case "邮箱":
                                    Tvalue = DataList.Get("邮箱");
                                    break;
                                case "手机号":
                                    Tvalue = DataList.Get("手机号");
                                    break;
                                case "身份证号":
                                    Tvalue = DataList.Get("身份证号");
                                    break;
                                default:
                                    try
                                    {
                                        Target = DataList.Get(Tvalue);
                                    }
                                    catch
                                    {
                                        throw new Exception(string.Format("✘：Target释放变量集合中不存在：{0}", Value));
                                    }                                    
                                    break;                                    
                            }
                            break;
                        case "@索引":
                            JSupport.Index = Value;
                            Target = Target.Remove(Target.IndexOf('|'));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(string.Format("✘：Target命令集合中不存在：{0}", Key));
                    }
                }
            }
            //3.sType
            if (!string.IsNullOrEmpty(sType) && sType.Contains("@保存") || sType.Contains("@切入") || sType.Contains("@Debug"))
            {
                var Save = new List<string>(sType.Split('|')).FindAll(x => x.Contains("@保存") || x.Contains("@切入") || x.Contains("@Debug"));
                foreach (string item in Save)
                {
                    Key = item.Split('-')[0];
                    Value = item.Split('-')[1];
                    switch (Key)
                    {
                        case "@保存":
                            switch (Value)
                            {
                                case "姓名":
                                    DataList.Set("姓名", Tvalue);
                                    break;
                                case "邮箱":
                                    DataList.Set("邮箱", Tvalue);
                                    break;
                                case "手机号":
                                    DataList.Set("手机号", Tvalue);
                                    break;
                                case "身份证号":
                                    DataList.Set("身份证号", Tvalue);
                                    break;
                                default:
                                    DataList.Set(Value, Tvalue);
                                    break;                                    
                            }
                            break;
                        case "@切入":
                            JSupport.SwitchIFrame(SXDXWeb.driver, Value);
                            break;
                        case "@Debug":
                            WebUI.WebUIDebug(Tvalue,Target);                            
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(string.Format("✘：sType命令集合中不存在：{0}", Key));
                    }
                }

            }
        }
        #endregion    

        #region//Judge element is it exsit
        static public bool IsElementExist(IWebDriver driver, By locator, int? Time = 10)
        {
            try
            {
                if (!JWait.WaitUntil(() =>
                {
                    driver.FindElement(locator);
                }, Time.Value)) throw new Exception("✘：未找到元素");
                return true;
            }
            catch
            {
                //Element is not exsit, we don't do anything
                return false;
            }
        }

        #endregion

    }
}
