using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPlayer.Interface
{
    interface IEngine
    {
        Dictionary<string, string> ActionList { get;}

        void Excute(string Action);

        List<string> GetActionList();


    }
}
