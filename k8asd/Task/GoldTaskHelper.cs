using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    class GoldTaskHelper {
    }
}


/*
 * 
 * ////thu thue
            //packet = await packetWriter.IncreaseTaxAsync();
            //if (packet == null) //gui packet that bai
            //{
            //    return;
            //}

            ////xu ly het xu tang cuong, dang le cho nhan nhiem vu khac nhung cho ngung han
            //JToken token = JToken.Parse(packet.Message);
            //if (token["message"] != null && token["message"].ToString() != "")
            //{
            //    this.timerQuest.Stop();
            //    this.chkQuest.Checked = false;
            //    break;
            //}


            /*
            //uy phai ngua lv1
            packet = await packetWriter.CommissionAsync();
            if (packet == null) //gui packet that bai
            {
                return;
            }

            JToken token = JToken.Parse(packet.Message);
            //xu ly khong du bac (chua chinh xac)
            if (token["message"] != null && (token["message"].ToString().Contains("đủ"))) {
                packet = await packetWriter.CancelQuestAsync(qInfo.listQuest[check].id);
                removeQuest = check;
                return;
            }

            //nhan vat pham
            packet = await packetWriter.AcceptCommissionAsync();
            if (packet == null) //gui packet that bai
            {
                return;
            }

            //pha bang
            packet = await packetWriter.BreakIceCommissionAsync();
            if (packet == null) //gui packet that bai
            {
                return;
            }
            //xu ly khong du xu (chua chinh xac)
            if (token["message"] != null && (token["message"].ToString().Contains("đủ"))) {
                packet = await packetWriter.CancelQuestAsync(qInfo.listQuest[check].id);
                removeQuest = check;
                return;
            }
            */
