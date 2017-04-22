using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.IO;

namespace k8asd
{
    public partial class QuestView : UserControl
    {
        private IPacketWriter packetWriter;

        public QuestView()
        {
            InitializeComponent();
        }

        public void SetPacketWriter(IPacketWriter writer)
        {
            if (packetWriter != null)
            {
                packetWriter.PacketReceived -= OnPacketReceived;
            }
            packetWriter = writer;
            packetWriter.PacketReceived += OnPacketReceived;
        }

        private void OnPacketReceived(object sender, Packet packet)
        {
            //
        }

        public void EnableAutoQuest()
        {
            this.chkQuest.Checked = true;
        }

        public void DisableAutoQuest()
        {
            this.chkQuest.Checked = false;
        }

        private void chkQuest_CheckedChanged(object sender, EventArgs e)
        {
            if (chkQuest.Checked)
            {
                timerQuest.Start();
            }
            else
            {
                timerQuest.Stop();
            }
        }

        private bool checkAutoReady = false;
        private int removeQuest = -1; //kiem tra nhiem vu nao da loai ko hoan thanh dc
        public async void Auto()
        {
            //lay danh sach nhiem vu hang ngay
            var packet = await packetWriter.RefreshListQuestAsync();
            if (packet == null)
            {
                return;
            }

            JToken tokenn = JToken.Parse(packet.Message);

            if (tokenn["message"] != null && tokenn["message"].ToString() != "")
            {
                return;
            }
            QuestInfo qInfo = QuestInfo.Parse(JToken.Parse(packet.Message));

            //packet = await packetWriter.CollectTaxAsync();

            if (qInfo.donenum < 6)
            {
                //lay so sao cua moi nhiem vu
                foreach (var q in qInfo.listQuest)
                {
                    packet = await packetWriter.GetStartOfQuestAsync(q.id);
                    if (packet == null)
                    {
                        return;
                    }
                    JToken token = JToken.Parse(packet.Message);
                    if (token["message"] != null && token["message"].ToString() != "")
                    {
                        return;
                    }
                    q.quality = (int)token["taskdto"]["quality"];
                }

                if (qInfo.listQuest == null || qInfo.listQuest[qInfo.listQuest.Count - 1].quality == 0)
                {
                    return;
                }

                int check = FindQuest1(qInfo.listQuest, qInfo.listQuest[qInfo.listQuest.Count-1].quality, removeQuest);
                removeQuest = -1;

                if (check == -2)
                {
                    this.timerQuest.Stop();
                    this.chkQuest.Checked = false;
                    return;
                }

                if (check != -1) //tim duoc nhiem vu mua ban lua
                {
                    if (qInfo.listQuest[check].name == "Mua bán lúa")
                    {
                        //nhan nhiem vu mua ban lua
                        packet = await packetWriter.AcceptQuestAsync(qInfo.listQuest[check].id);
                        if (packet == null) //gui packet that bai
                        {
                            return;
                        }

                        checkAutoReady = true;

                        for (int i = 0; i < qInfo.listQuest[check].quality; i++)
                        {
                            //ban lua
                            packet = await packetWriter.SalePaddyAsync();
                            if (packet == null) //gui packet that bai
                            {
                                return;
                            }

                            JToken token = JToken.Parse(packet.Message);
                            //xu ly mua ban khong thanh cong do da ban het lua
                            if (token["message"] != null && token["message"].ToString() == "Hôm nay không có đủ lượng giao dịch")
                            {
                                //neu da ban het lua thi mua cho den
                                packet = await packetWriter.BuyPaddyInMaketAsync();
                                if (packet == null) //gui packet that bai
                                {
                                    return;
                                }
                                //xu ly khong the mua lua cho den (chua co acc test) co the huy nhiem vu nay nhan nhiem vu ke
                                //...
                            }
                        }

                        //hoan thanh nhiem vu
                        packet = await packetWriter.CompleteQuestAsync(qInfo.listQuest[check].id);
                    }

                    if (qInfo.listQuest[check].name == "Cải tạo")
                    {
                        //nhan nhiem vu cai tao
                        packet = await packetWriter.AcceptQuestAsync(qInfo.listQuest[check].id);
                        if (packet == null) //gui packet that bai
                        {
                            return;
                        }
                        checkAutoReady = true;

                        //lay danh sach tuong
                        packet = await packetWriter.GetListHeroAsync();
                        if (packet == null)
                        {
                            return;
                        }

                        Barracks barracks = Barracks.Parse(JToken.Parse(packet.Message));
                        //lay id tuong dau tien
                        int id = barracks.Heroes[0].Id;

                        for (int i = 0; i < qInfo.listQuest[check].quality; i++)
                        {
                            //cai tien tuong
                            packet = await packetWriter.HeroImproveAsync(id);
                            if (packet == null) //gui packet that bai
                            {
                                return;
                            }

                            //xu ly khong du chien tich (chua lam)

                            //cai tien thanh cong xu ly giu chi so
                            packet = await packetWriter.NotUpdateHeroImproveAsync(id);
                        }

                        //hoan thanh nhiem vu
                        packet = await packetWriter.CompleteQuestAsync(qInfo.listQuest[check].id);
                    }

                    if (qInfo.listQuest[check].name == "Chinh chiến")
                    {
                        //nhan nhiem vu chinh chiến
                        packet = await packetWriter.AcceptQuestAsync(qInfo.listQuest[check].id);
                        if (packet == null) //gui packet that bai
                        {
                            return;
                        }
                        checkAutoReady = true;

                        for (int i = 0; i < qInfo.listQuest[check].quality; i++)
                        {
                            //chinh chien nguy tuc - lu bo
                            packet = await packetWriter.BattleNguyTucAsync();
                            if (packet == null) //gui packet that bai
                            {
                                return;
                            }

                            JToken token = JToken.Parse(packet.Message);
                            //if (token["message"] != null && token["message"].ToString() == "Không đủ lượt")
                            //{
                            //    removeQuest = check;
                            //    return;
                            //}
                            if (token["message"] != null)
                            {
                                packet = await packetWriter.CancelQuestAsync(qInfo.listQuest[check].id);
                                removeQuest = check;
                                return;
                            }

                            //xu ly chinh chien that bai (chua lam)
                            //if (token["battlereport"]["message"].ToString() == "Ngài đã thất bại .....")
                            //{
                            //    //phai danh lai cho du so sao (chua lam)
                            //}
                        }

                        //hoan thanh nhiem vu
                        packet = await packetWriter.CompleteQuestAsync(qInfo.listQuest[check].id);
                    }

                    if (qInfo.listQuest[check].name == "Nâng cấp trang bị")
                    {
                        //nhan nhiem vu chinh chiến
                        packet = await packetWriter.AcceptQuestAsync(qInfo.listQuest[check].id);
                        if (packet == null) //gui packet that bai
                        {
                            return;
                        }
                        checkAutoReady = true;

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
                        //hoan thanh nhiem vu
                        packet = await packetWriter.CompleteQuestAsync(qInfo.listQuest[check].id);
                    }

                    if (qInfo.listQuest[check].name == "Thu Thuế")
                    {
                        //nhan nhiem vu thu thue
                        packet = await packetWriter.AcceptQuestAsync(qInfo.listQuest[check].id);
                        if (packet == null) //gui packet that bai
                        {
                            return;
                        }
                        checkAutoReady = true;

                        for (int i = 0; i < qInfo.listQuest[check].quality; i++)
                        {
                            //thu thue
                            packet = await packetWriter.CollectTaxAsync();
                            if (packet == null) //gui packet that bai
                            {
                                return;
                            }
                            JToken token = JToken.Parse(packet.Message);
                            if (token["message"] != null && (token["message"].ToString() == "Không thể tiếp tục tăng cường thu thuế trong hôm nay" || token["message"].ToString() == "Thao tác này đang đóng băng"))
                            {
                                //neu da het so lan thu thue thi tang cuong thue
                                packet = await packetWriter.IncreaseTaxAsync();
                                if (packet == null) //gui packet that bai
                                {
                                    return;
                                }
                                //xu ly het xu tang cuong (chua lam)
                                //...
                            }
                        }

                        //hoan thanh nhiem vu
                        packet = await packetWriter.CompleteQuestAsync(qInfo.listQuest[check].id);
                    }
                    if (qInfo.listQuest[check].name == "Sử dụng Xu")
                    {
                        //nhan nhiem vu su dung xu
                        packet = await packetWriter.AcceptQuestAsync(qInfo.listQuest[check].id);
                        if (packet == null) //gui packet that bai
                        {
                            return;
                        }
                        checkAutoReady = true;

                        for (int i = 0; i < qInfo.listQuest[check].quality; i++)
                        {
                            ////thu thue
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

                            //uy phai ngua lv1
                            packet = await packetWriter.CommissionAsync();
                            if (packet == null) //gui packet that bai
                            {
                                return;
                            }

                            JToken token = JToken.Parse(packet.Message);
                            //xu ly khong du bac (chua chinh xac)
                            if (token["message"] != null && (token["message"].ToString().Contains("đủ")))
                            {
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
                            if (token["message"] != null && (token["message"].ToString().Contains("đủ")))
                            {
                                packet = await packetWriter.CancelQuestAsync(qInfo.listQuest[check].id);
                                removeQuest = check;
                                return;
                            }
                        }

                        //hoan thanh nhiem vu
                        packet = await packetWriter.CompleteQuestAsync(qInfo.listQuest[check].id);
                    }
                    //khong co nhiem vu nao
                    if (!checkAutoReady)
                    {
                        this.timerQuest.Stop();
                        this.chkQuest.Checked = false;
                    }
                    else
                    {
                        checkAutoReady = false;
                    }
                }
                else
                {
                    this.timerQuest.Stop();
                    this.chkQuest.Checked = false;
                }
            }
            else
            {
                this.timerQuest.Stop();
                this.chkQuest.Checked = false;
            }
        }

        //khong dung de qui tim nhiem vu de lam nhat (tam thoi khong cai tien)
        private int FindQuest(List<QuestInfo> listQuest, int quality)
        {
            if (quality == 4)
            {
                return -1;
            }

            //tim dung so sao
            for (int i = listQuest.Count - 1; i >= 0; i--)
            {
                if (listQuest[i].name == "Mua bán lúa" && listQuest[i].quality == quality)
                {
                    return i;
                }
            }
            //tim lon hon so sao + 1
            for (int i = listQuest.Count - 1; i >= 0; i--)
            {
                if (listQuest[i].name == "Mua bán lúa" && listQuest[i].quality == (quality+1))
                {
                    return i;
                }
            }

            for (int i = listQuest.Count - 1; i >= 0; i--)
            {
                if (listQuest[i].name == "Cải tạo" && listQuest[i].quality == quality)
                {
                    return i;
                }
            }
            for (int i = listQuest.Count - 1; i >= 0; i--)
            {
                if (listQuest[i].name == "Cải tạo" && listQuest[i].quality == (quality+1))
                {
                    return i;
                }
            }

            //co the lam them nhiem vu chinh phuc clone
            //co the lam them nhiem vu chinh chien

            //co the lam them nhiem vu nang cap do

            //co the lam them nhiem vu tan cong

            for (int i = listQuest.Count - 1; i >= 0; i--)
            {
                if (listQuest[i].name == "Thu Thuế" && listQuest[i].quality == quality)
                {
                    return i;
                }
            }
            for (int i = listQuest.Count - 1; i >= 0; i--)
            {
                if (listQuest[i].name == "Thu Thuế" && listQuest[i].quality == (quality + 1))
                {
                    return i;
                }
            }

            for (int i = listQuest.Count - 1; i >= 0; i--)
            {
                if (listQuest[i].name == "Sử dụng Xu" && listQuest[i].quality == quality)
                {
                    return i;
                }
            }
            for (int i = listQuest.Count - 1; i >= 0; i--)
            {
                if (listQuest[i].name == "Sử dụng Xu" && listQuest[i].quality == (quality + 1))
                {
                    return i;
                }
            }

            if (listQuest == null || quality == 0)
            {
                return -2;
            }
            //quality = quality + 1;
            //return FindQuest(listQuest, quality);
            return -1;
        }

        //dung de qui de toi uu so sao it nhat
        private int FindQuest1(List<QuestInfo> listQuest, int quality, int removeQuest)
        {
            if (quality == 3)
            {
                return -1;
            }

            //tim dung so sao
            for (int i = listQuest.Count - 1; i >= 0; i--)
            {
                if (listQuest[i].name == "Mua bán lúa" && listQuest[i].quality == quality && i != removeQuest) 
                {
                    return i;
                }
            }

            for (int i = listQuest.Count - 1; i >= 0; i--)
            {
                if (listQuest[i].name == "Cải tạo" && listQuest[i].quality == quality && i != removeQuest)
                {
                    return i;
                }
            }

            //co the lam them nhiem vu chinh phuc clone

            //co the lam them nhiem vu chinh chien
            for (int i = listQuest.Count - 1; i >= 0; i--)
            {
                if (listQuest[i].name == "Chinh chiến" && listQuest[i].quality == quality && i != removeQuest)
                {
                    return i;
                }
            }

            //co the lam them nhiem vu nang cap do
            for (int i = listQuest.Count - 1; i >= 0; i--)
            {
                if (listQuest[i].name == "Nâng cấp trang bị" && listQuest[i].quality == quality && i != removeQuest)
                {
                    return i;
                }
            }

            //co the lam them nhiem vu tan cong

            for (int i = listQuest.Count - 1; i >= 0; i--)
            {
                if (listQuest[i].name == "Thu Thuế" && listQuest[i].quality == quality && i != removeQuest)
                {
                    return i;
                }
            }

            for (int i = listQuest.Count - 1; i >= 0; i--)
            {
                if (listQuest[i].name == "Sử dụng Xu" && listQuest[i].quality == quality && i != removeQuest)
                {
                    return i;
                }
            }

            if (listQuest == null || quality == 0)
            {
                return -2;
            }
            quality = quality + 1;
            return FindQuest1(listQuest, quality, removeQuest);
        }

        public async void ReportQuest(string username, string name)
        {
            //lay danh sach nhiem vu hang ngay
            var packet = await packetWriter.RefreshListQuestAsync();
            if (packet == null)
            {
                return;
            }
            JToken tokenn = JToken.Parse(packet.Message);
            if (tokenn["message"] != null && tokenn["message"].ToString() != "")
            {
                return;
            }
            QuestInfo qInfo = QuestInfo.Parse(JToken.Parse(packet.Message));
            //ghi file bao cao
            string fileName = DateTime.Now.Day +".txt";
            using (StreamWriter w = new StreamWriter(fileName, true))
            {
                w.WriteLine(username + " - " + name + " - " + qInfo.donenum + "/6");
                w.Close();
            }
        }

        private void timerQuest_Tick(object sender, EventArgs e)
        {
            Auto();
        }
    }
}
