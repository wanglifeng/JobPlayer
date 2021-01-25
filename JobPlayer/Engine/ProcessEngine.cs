using JobPlayer.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPlayer.Engine
{
    class ProcessEngine : IEngine
    {
        //Process命令设置
         Dictionary<string, string> actionList = new Dictionary<string, string>() {
            { "访问199",@"\\10.28.138.199\自动化共享盘\唐鹏"},
            { "访问53",@"\\10.7.169.53"},
            { "访问10.1.120.30",@"\\10.1.120.30"},
            { "打开记事本",Environment.CurrentDirectory+ "/Notes.txt"}
        };
         
        public  Dictionary<string, string> ActionList
        {
            get
            {
                return actionList;
            }
        }

        public void Excute(string Action)
        {
            try {
                Process.Start(ActionList[Action]);
            }
            catch {
                throw new Exception(string.Format("命令/process:{0}报错", Action));
            }
        }

        public  List<string> GetActionList()
        {
            List<string> result = new List<string>();
            foreach (var item in ActionList)
            {
                result.Add("/process:" + item.Key);
            }
            return result;
        }
    }
}
