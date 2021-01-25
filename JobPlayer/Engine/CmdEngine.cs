using JobPlayer.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPlayer.Engine
{
    class CmdEngine : IEngine
    {
        //cmd的快捷键命令设置
        Dictionary<string, string> actionList = new Dictionary<string, string>() {
            { "cmd测试1",@""},
            { "cmd测试2",@""},
            { "cmd测试3",@""}
        };

        public Dictionary<string, string> ActionList
        {
            get
            {
                return actionList;
            }
        }

        public void Excute(string command)
        {
            //string rInfo;
            //try
            //{
            //    Process myProcess = new Process();
            //    ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("cmd.exe");
            //    myProcessStartInfo.UseShellExecute = false;
            //    myProcessStartInfo.CreateNoWindow = true;
            //    myProcessStartInfo.RedirectStandardOutput = true;
            //    myProcess.StartInfo = myProcessStartInfo;
            //    myProcessStartInfo.Arguments = "/c " + command;
            //    myProcess.Start();
            //    StreamReader myStreamReader = myProcess.StandardOutput;
            //    rInfo = myStreamReader.ReadToEnd();
            //    myProcess.Close();
            //    rInfo = command + "\r\n" + rInfo;
            //    return rInfo;
            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}
        }

        public List<string> GetActionList()
        {
            List<string> result = new List<string>();
            foreach (var item in ActionList)
            {             
                result.Add("/cmd:" + item.Key);
            }
            return result;
        }


    }
}
