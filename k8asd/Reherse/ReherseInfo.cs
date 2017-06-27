using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd
{
    public class ReherseInfo
    {
        public long playerid;
        public string playername;
        public int playerlv; //so sao
        public int top;

        public static ReherseInfo Parse(JToken token)
        {
            var result = new ReherseInfo();
            result.playerid = (long) token["playerid"];
            result.playername = token["playername"].ToString();
            result.playerlv = (int)token["playerlv"];
            result.top = (int)token["top"];

            return result;
        }
    }
}
