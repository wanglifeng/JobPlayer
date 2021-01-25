using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace CL.Manage.Data
{
    public class DeviceInfo
    {
        public string UID { get; set; }
        public string Device { get; set; }
        public string Product { get; set; }
        public bool Status { get; set; }
        public string IP { get; set; }
        public string PlatForm { get; set; }
        public string Acitity { get; set; }
        public int LocalPort { get; set; }
    }

    public static class DLink
    {
        public static string Uid { get; set; }
        public static string IP { get; set; }
        public static string Url { get; set; }
        private static string Server { get; set; }
        private static int LocalPort { get; set; }


        public static void StartServer(string platform,ref string uid,ref string url,ref int localport)
        {
            Dispose();
            if (DataStatus.ProcessModel)
            {
                Server = "http://10.1.96.23:8088";
                switch (platform)
                {
                    case "IOS":
                        if (string.IsNullOrEmpty(Uid))
                        {
                            AsignmentServerStart("MAC");
                        }
                        break;
                    case "Android":
                        if (string.IsNullOrEmpty(Uid))
                        {
                            AsignmentServerStart("WIN");
                        }
                        break;
                }
                uid = Uid;
                localport = LocalPort;
                url = Url;
            }
        }

        public static void Dispose()
        {
            if (DataStatus.ProcessModel)
            {
                AsignmentServerStop();
                DLink.Uid = null;
                DLink.Url = null;
            }
        }

        private static string AsignmentServerStart(string platform)
        {
            string result = "";
            try
            {
                Uri uri = new Uri(string.Format("{0}/home/AsignmentServerStart?platform={1}", Server, platform));
                WebRequest webRequest = WebRequest.Create(uri);
                webRequest.Method = "Get";
                WebResponse webResponse = webRequest.GetResponse();
                using (StreamReader mysTreamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
                {
                    result = mysTreamReader.ReadToEnd();
                    var devices = JsonConvert.DeserializeObject<DeviceInfo>(result);
                    Uid = devices.UID;
                    LocalPort = devices.LocalPort;
                    Url = string.Format("http://{0}:4724/wd/hub", devices.IP);
                    var c = new Uri(Url);
                }
                return "Initail success";
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Url: {0},Json：{1},Error:{2} :", Url, result, ex.Message));
            }
        }

        private static string AsignmentServerStop()
        {
            string result = "";
            try
            {
                Uri uri = new Uri(string.Format("{0}/home/AsignmentServerStop?uid={1}", Server, Uid));
                WebRequest webRequest = WebRequest.Create(uri);
                webRequest.Method = "Get";
                WebResponse webResponse = webRequest.GetResponse();
                using (StreamReader mysTreamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
                {
                    result = mysTreamReader.ReadToEnd();
                }
                return result;
            }
            catch
            {
                return "Relase devices faild";
            }
        }
    }
}
