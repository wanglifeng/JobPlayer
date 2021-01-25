using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Manage.Data.CaseView;
namespace CL.Manage.Data
{
    public class DataList
    {
        private static Dictionary<string, string> List = new Dictionary<string,string>();
        public static string Get(string key)
        {
            if (!List.ContainsKey(key))
            {
                throw new Exception(string.Format("变量集合中不存在：{0}", key));
            }
            return List[key];
        }

        public static void Set(string key, string value)
        {
            if (!List.ContainsKey(key))
            {
                List.Add(key, value);
            }
            else{
                List[key] = value;            
            }
        }

        public static bool ContainKey(string key)
        {
            if (List.ContainsKey(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Remove(string key)
        {
            if (List.ContainsKey(key))
            {
                List.Remove(key);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
