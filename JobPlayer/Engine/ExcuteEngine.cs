using JobPlayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPlayer.Engine
{

    class ExcuteEngine:IEngine
    {
        public ProcessEngine processEngine ;
        public WebEngine webEngine;
        public CmdEngine cmdEngine;
        public SearchBar searchBar;
        public JobPlayer jobplayer;

        //JobPlayer和SearchBar界面命令设置
        Dictionary<string, string> actionList = new Dictionary<string, string>() {
            { "显示搜索","searchBar:HideOrShow_SearchBar"},
            { "显示主界面","jobplayer:HideOrShow_Home"}
        };
        public Dictionary<string, string> ActionList
        {
            get
            {
                return actionList;
            }
        }

        public void init()
        {
            processEngine = new ProcessEngine();
            webEngine = new WebEngine();
            cmdEngine = new CmdEngine();
        }

    public void Excute(string action)
        {
            string key = action.Split(':')[0];
            string value = action.Split(':')[1];
            switch (key)
            {
                case "/cmd":
                    cmdEngine.Excute(value);
                    break;
                case "/web":
                    webEngine.Excute(value);
                    break;
                case "/process":
                    processEngine.Excute(value);
                    break;
                case "/sys":
                    ExuciteFunction(value);
                    break;
                default:
                    break;
            }
    
        }

        public List<string> GetActionList()
        {
            init();
            List<string> ActionMap = new List<string>();
            ActionMap.AddRange(processEngine.GetActionList());
            ActionMap.AddRange(webEngine.GetActionList());
            ActionMap.AddRange(cmdEngine.GetActionList());
            List<string> result = new List<string>();
            foreach (var item in ActionList)
            {
                if (item.Key.Contains("显示搜索") || item.Key.Contains("显示主界面")) continue;
                ActionMap.Add("/sys:" + item.Key);
            }           
            return ActionMap;
        }

        public void ExuciteFunction(string action) {
            string className = actionList[action].Split(':')[0];
            string MethodName = actionList[action].Split(':')[1];

            switch (className)
            {
                case "jobplayer":
                    jobplayer.GetType().GetMethod(MethodName).Invoke(jobplayer, new object[] { });
                    break;
                case "searchBar":
                    searchBar.GetType().GetMethod(MethodName).Invoke(searchBar, new object[] { });
                    break;
                default:
                    break;
            }
            //JobPlayer.Jobplay.GetType().GetMethod("HideOrShow_Home").Invoke(JobPlayer.Jobplay, new object[] {});
        }
    }
}
