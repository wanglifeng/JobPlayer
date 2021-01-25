using JobPlayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPlayer.Engine
{
    class WebEngine : IEngine
    {
        //Web操作的命令设置
        Dictionary<string, string> actionList = new Dictionary<string, string>() {
            { "web测试1",@"\\10.28.138.199\自动化共享盘\唐鹏"},
            { "web测试2",@"\\10.7.169.53"},
            { "web测试3",@"\\10.1.120.30"}
        };

        public Dictionary<string, string> ActionList
        {
            get
            {
                return actionList;
            }
        }

        public void Excute(string Action)
        {
            throw new NotImplementedException();
        }

        public List<string> GetActionList()
        {
            List<string> result = new List<string>();
            foreach (var item in ActionList)
            {
                result.Add("/web:" + item.Key);
            }
            return result;
        }
    }
}
