using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    class UpgradeTaskHelper : ITaskHelper {
        public Task<bool> CanDo(IPacketWriter writer, int times) {
            return Task.FromResult(true);
        }

        public async Task<bool> Do(IPacketWriter writer, int times) {

            /*
            //lay id vu khi trang dau tien
                       //lay danh sach vu khi
                       packet = await packetWriter.GetListWeaponsAsync();
                       if (packet == null) //gui packet that bai
                       {
                           return;
                       }

                       JToken token = JToken.Parse(packet.Message);
                       JArray arrequip = (JArray)tokenn["equip"];

                       string magic = tokenn["magic"].ToString();
                       string storeid = "";
                       for (int i = 0; i < arrequip.Count; i++)
                       {
                           JObject objCur = (JObject)arrequip[i];
                           if (objCur["quality"].ToString() == "1")
                           {
                               storeid = objCur["storeid"].ToString();
                               break;
                           }
                       }

                       //xu ly neu co vu khi
                       if (storeid != "")
                       {
                           //ha cap trang bi
                           packet = await packetWriter.DownGradeWeaponsAsync(storeid);
                           if (packet == null) //gui packet that bai
                           {
                               return;
                           }

                           //nang cap trang bi
                           for (int i = 0; i < qInfo.listQuest[check].quality;)
                           {
                               //nang cap trang bi
                               packet = await packetWriter.UpGradeWeaponsAsync(storeid, magic);
                               if (packet == null) //gui packet that bai
                               {
                                   return;
                               }


                               token = JToken.Parse(packet.Message);

                               //xu ly khong du bac de nang cap (chua chinh xac)
                               if (token["message"] != null && token["message"].ToString().Contains("đủ"))
                               {
                                   packet = await packetWriter.CancelQuestAsync(qInfo.listQuest[check].id);
                                   removeQuest = check;
                                   return;
                               }

                               if (token["message"] != null && token["message"].ToString() == "Thất bại! Chúc may mắn lần sau!")
                               {
                                   //xu ly nhan nhiem vu khac (chua lam)
                               }
                               else
                               {
                                   i++;
                               }
                           }
                       }
                       else
                       {
                           packet = await packetWriter.CancelQuestAsync(qInfo.listQuest[check].id);
                           removeQuest = check;
                           return;
                       }
                       */

            return true;
        }

        private async Task<bool> DoSingle(IPacketWriter writer, int equipmentId) {



            return true;
        }
    }
}
