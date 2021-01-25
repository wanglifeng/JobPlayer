using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPlayer
{
    class CmdAction
    {
        public static Dictionary<string, string> Action = new Dictionary<string, string>() {
            { "访问199",@"\\10.28.138.199\自动化共享盘\唐鹏"},
            { "访问53",@"\\10.7.169.53"},
            { "访问130",@"\\10.1.120.30"}
        };
        public static string CmdExcute(string command)
        {
            string rInfo;
            try
            {
                Process myProcess = new Process();
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("cmd.exe");
                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.CreateNoWindow = true;
                myProcessStartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo = myProcessStartInfo;
                myProcessStartInfo.Arguments = "/c " + command;
                myProcess.Start();
                StreamReader myStreamReader = myProcess.StandardOutput;
                rInfo = myStreamReader.ReadToEnd();
                myProcess.Close();
                rInfo = command + "\r\n" + rInfo;
                return rInfo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static void ProcessExcute(string path)
        {
            if (Action.ContainsKey(path))
            {
                Process.Start(Action[path]);
            }
            else
            {
                throw new Exception(string.Format("命令库不存在：{0}", path));
            }
           
        }

        public static void ExcuteAction(string action) {
            if (Action.ContainsKey(action))
            {
                var result = CmdExcute(Action[action]);
            }
            else {
                throw new Exception(string.Format("命令库不存在：{0}", action));
            }
        }
    }
}
