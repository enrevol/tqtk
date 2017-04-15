using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd
{
    public class QuestInfo
    {
        public int id;
        public string name;
        public int quality;
        public int donenum;
        public List<QuestInfo> listQuest;

        public static QuestInfo Parse(JToken token)
        {
            var result = new QuestInfo();
            result.donenum = (int)token["donenum"];

            var listQuest = new List<QuestInfo>();
            var taskbasedto = token["taskbasedto"];
            foreach (var subQuest in taskbasedto)
            {
                var qInfo = new QuestInfo();
                qInfo.id = (int)subQuest["id"];
                qInfo.name = subQuest["name"].ToString();
                qInfo.quality = subQuest["quality"]!=null?(int)subQuest["quality"]:0;
                listQuest.Add(qInfo);
            }
            result.listQuest = listQuest;
            return result;
        }
    }
}
