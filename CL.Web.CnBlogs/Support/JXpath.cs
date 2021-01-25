using System;
using System.Collections.Generic;
namespace CL.Web.SXDX.Support
{
    public static class JXpath
    {
        public static string Xpath { get; set; }

        public static string Button(string Tvalue,string Target) {
            if (string.IsNullOrEmpty(Target))
            {
                //There isn't target value
                return Xpath = string.Format(@"//span[text()='{0}']|
                                               //button[text()='{0}']|
                                               //tr[contains(@class,'ax-datagrid-body-row')]//td//div[contains(text(),'{0}')]|
                                               //div[@class='ax-tab-header']//div[text()='{0}']|
                                               //td//div[contains(@class,'ax-datagrid-body-cell') and text()='{0}']
                                            ", Tvalue);
            }
            else {
                //Have target value
                return Xpath = string.Format(@"//div[contains(text(),'{0}')]//following::button[text()='{1}']
                                                ", Target, Tvalue);
            }
        }

        public static string Radio(string Tvalue, string Target)
        {
                //There isn't target value
                return Xpath = string.Format(@"(//div[text()='{0}']//following::span)[1]|
                                                //span[text()='{0}']//preceding::span[contains(@class,'checkbox')][1]
                                            ", Target);
        }

        public static string TreeNode(string Tvalue, string Target)
        {
            //There isn't target value
            return Xpath = string.Format(@"//span[text()='{0}']//preceding::span[contains(@class,'treeview')][1]
                                            ", Tvalue);
        }

        public static string Input(string Target, string Tvalue)
        {
            string[] targetCollection = Target.Split('-');
            if (targetCollection.Length > 1)
            {
                Xpath = string.Format(@"(//div[contains(text(),'{0}')]//following::div[text()='{1}']//following::input)[{2}]
                                        ", targetCollection[0], targetCollection[1], JSupport.Index);
            }
            else {
                Xpath = string.Format(@"(//div[text()='{0}']//following::input)[{1}]|
                                        //span[text()='{0}']//following::input[{1}]|
                                        //input[@placeholder='{0}']
                                        ", Target, JSupport.Index);
            }
            return Xpath;
        }

        public static string FileInput(string Target, string Tvalue)
        {
            //There isn't target value
            return Xpath = string.Format(@"(//div[text()='{0}']//following::input[@type='file'])[1]
                                            ", Target);
        }

        public static string Select(string Target, string Tvalue)
        {
            string[] targetCollection = Target.Split('-');
            if (targetCollection.Length > 1)
            {
                Xpath = string.Format(@"(//div[contains(text(),'{0}')]//following::div[text()='{1}']//following::div[contains(@class,'ax-selector ax-control')])[{2}]
                                        ", targetCollection[0], targetCollection[1], JSupport.Index);
            }
            else
            {
                Xpath = string.Format(@"//div[text()='{0}']//following::td[1]//div[contains(@class,'ax-selector ax-control')][{1}]|
                                        (//div[contains(text(),'{0}')]//..//..//..//div[contains(@class,'ax-selector ax-control')])[{1}]
                                     ", Target, JSupport.Index);    
            }
        
             JSupport.Index = null;
             return Xpath;
        }

        public static string DateTimeInput(string Target, string Tvalue, string sType)
        {
            if (!string.IsNullOrEmpty(sType))
            {
                return Xpath = string.Format(@"(//label[contains(text(),'{0}')]//..//input[1])[{1}]
                                            ", Target, sType);
            }
            else {
                return Xpath = string.Format(@"(//label[contains(text(),'{0}')]//..//input[1])
                                            ", Target);
            }
        }

        public static string DirectionButton(string Tvalue)
        {
            Dictionary<string, string> Direction = new Dictionary<string, string>(){
                {"左","left"},{"右","right"}
            };
                //Have target value
            return Xpath = string.Format(@"(//i[contains(@class,'{0}')])[1]", Direction[Tvalue]);
        }

        public static string IConButton(string Tvalue,string Target)
        {
            Dictionary<string, string> SpecialElement = new Dictionary<string, string>()
            {
                {"任务",@"//div[@title='任务']"},
                {"接通",@"//div[contains(text(),'"+Target+"')]//following::span[@class='ax-icon ax-icon-dial'][1]"},
                {"挂断",@"//div[contains(text(),'"+Target+"')]//following::span[@class='ax-icon ax-icon-hangup'][1]"}
            };
            if (SpecialElement.ContainsKey(Tvalue))
            {
                return SpecialElement[Tvalue];
            }
            else
            {
                throw new Exception(string.Format("特定元素中不存在：{0}", Tvalue));
            }
        }

        public static string Valid(string Tvalue, string Target)
        {
            if (string.IsNullOrEmpty(Target))
            {
                //There isn't target value
                return Xpath = string.Format(@"//div[@class='ax-tooltip-inner']
                                            ", Tvalue);
            }
            else
            {
                //Have target value
                return Xpath = string.Format(@"(//td[contains(text(),'{0}')]//..//a[text()='{1}'])|
                                               (//td[text()='{0}']//..//td[contains(text(),'{1}')])[1]
                                                ", Target, Tvalue);
            }
        }

    }
}
