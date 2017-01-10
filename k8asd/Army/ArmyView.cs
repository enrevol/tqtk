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
using System.Diagnostics;

namespace k8asd {
    public partial class ArmyView : UserControl, IPacketReader {
        enum ArmyType {
            /// <summary>
            /// NPC thường.
            /// </summary>
            Normal,

            /// <summary>
            /// NCP tinh anh (rớt đồ).
            /// </summary>
            Elite,

            /// <summary>
            /// NPC tướng (đánh 1 lần).
            /// </summary>
            Hero,

            /// <summary>
            /// Quân đoàn.
            /// </summary>
            Army
        }

        private class Army {
            private int armyId;
            private int armyLevel;
            private string armyName;
            private int armyLimit;
            private int armyMaxLimit;
            private bool attackable;
            private bool completed;
            private string intro;
            private string droppedItemName;
            private int honor;
            private ArmyType armyType;

            public int Id { get { return armyId; } }
            public int Level { get { return armyLevel; } }
            public string Name { get { return armyName; } }
            public int Limit { get { return armyLimit; } }
            public int MaxLimit { get { return armyMaxLimit; } }
            public bool Attackable { get { return attackable; } }
            public string ItemName { get { return droppedItemName; } }
            public int Honor { get { return honor; } }
            public ArmyType Type { get { return armyType; } }

            public static Army Parse(JToken token) {
                var result = new Army();
                result.armyId = (int) token["armyid"];
                result.armyLevel = (int) token["armylevel"];
                result.armyName = (string) token["armyname"];
                result.armyLimit = (int) token["armynum"];
                result.armyMaxLimit = (int) token["armymaxnum"];
                result.attackable = (bool) token["attackable"];
                result.completed = (bool) token["complete"];
                result.intro = (string) token["intro"];
                result.droppedItemName = (string) token["itemname"];
                result.honor = (int) token["jyungong"];
                var type = (int) token["type"];
                if (type == 1) {
                    result.armyType = ArmyType.Normal;
                } else if (type == 2) {
                    result.armyType = ArmyType.Elite;
                } else if (type == 3) {
                    result.armyType = ArmyType.Hero;
                } else if (type == 5) {
                    result.armyType = ArmyType.Army;
                } else {
                    Debug.Assert(false);
                }
                return result;
            }

            public override string ToString() {
                return String.Format("{0} Lv. {1}", Name, Level);
            }
        }

        private Queue<int> pendingPowerIds;
        private BindingList<Army> armies;
        private IPacketWriter packetWriter;

        public ArmyView() {
            InitializeComponent();

            armies = new BindingList<Army>();
            armyList.DataSource = armies;

            pendingPowerIds = new Queue<int>();
        }

        public void SetPacketWriter(IPacketWriter writer) {
            packetWriter = writer;
        }

        private void RefreshArmies() {
            if (packetWriter.SendCommand("33201", "1")) {
                Enabled = false;
            }
        }

        private void refreshButton_Click(object sender, EventArgs e) {
            RefreshArmies();
        }

        public void OnPacketReceived(Packet packet) {
            if (packet.CommandId == "33201") {
                Parse33201(packet);
                if (pendingPowerIds.Count > 0) {
                    armies.Clear();
                    processPendingPower();
                } else {
                    Enabled = true;
                }
            }
            if (packet.CommandId == "33100") {
                Parse33100(packet);
                processPendingPower();
            }

            if (packet.CommandId == "34101" ||
                packet.CommandId == "34102" ||
                packet.CommandId == "34104" ||
                packet.CommandId == "34105" ||
                packet.CommandId == "34106" ||
                packet.CommandId == "34107") {
                var token = JToken.Parse(packet.Message);
                var message = token["message"];
                if (message != null) {
                    // FIXME.
                }
            }
        }

        private void Parse33201(Packet packet) {
            var token = JToken.Parse(packet.Message);
            pendingPowerIds.Clear();
            var powerList = token["powerList"];
            foreach (var power in powerList) {
                var powerId = (int) power["powerId"];
                pendingPowerIds.Enqueue(powerId);
            }
        }

        private void Parse33100(Packet packet) {
            var token = JToken.Parse(packet.Message);
            var armiesToken = token["army"];
            foreach (var armyToken in armiesToken) {
                var army = Army.Parse(armyToken);
                if (army.Type == ArmyType.Army) {
                    armies.Add(army);
                }
            }
        }

        private void processPendingPower() {
            if (pendingPowerIds.Count > 0) {
                var powerId = pendingPowerIds.Dequeue();
                packetWriter.SendCommand("33100", powerId.ToString());
            } else {
                Enabled = true;
            }
        }

        private void radArmy2_CheckedChanged(object sender, EventArgs e) {
            //radArmy1.Checked = !radArmy2.Checked;
        }

        private void radArmy1_CheckedChanged(object sender, EventArgs e) {
            // radArmy2.Checked = !radArmy1.Checked;
        }

        private void CreateArmy(int armyId, int minimumLevel, int regionLimit) {
            packetWriter.SendCommand("34101", armyId.ToString(), String.Format("4:{0};{1}", minimumLevel, regionLimit), "0");
        }

        private void JoinArmy(int hostId) {
            packetWriter.SendCommand("34102", hostId.ToString());
        }

        private void KickPlayer(int playerId) {
            packetWriter.SendCommand("34104", playerId.ToString());
        }

        private void Disband() {
            packetWriter.SendCommand("34105");
        }

        private void Quit() {
            packetWriter.SendCommand("34106");
        }

        private void Attack() {
            packetWriter.SendCommand("34107");
        }

        private void ForceAttack() {
            // Tạo quân đoàn đổng trác.
            CreateArmy(900001, 0, 0);

            // Tấn công.
            Attack();

            // Giải tán quân đoàn đổng trác.
            Disband();
        }

        /*
         * FIXME.
        private void btnArmyInvite_Click(object sender, EventArgs e) {
            int cnum = Convert.ToInt32(r34100.currentnum);
            int mnum = Convert.ToInt32(r34100.maxnum);
            if (cnum > 0 && cnum < mnum)
                SendMsg("10103", r11102.playername,
                "Tổ đội đánh " + r34100.name
                + " đã được lập, còn " + (mnum - cnum).ToString() + " vị trí, hãy mau chóng đến "
                + "<a href='event:teamBattle|" + r34100.listmember[0].playerid
                + "|" + (cbbArmy1.SelectedIndex + 1).ToString()
                + "|" + r34100.id
                + "|" + r34100.id
                + "'>[Gia nhập]</a>",
                (cbbChat.SelectedIndex + 1).ToString(), " ");
        }
        */

        private void armyList_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }


    /*

#region 33101
case "33101":
    /// FIXME.
    /*
    R33101 r33101 = new R33101(cdata);
    if (r33101.m == null) {
        lblExtraYinkuang.Visible = r33101.extrayinkuang.Equals("1");
        lblExtraNongtian.Visible = r33101.extranongtian.Equals("1");
        lblExtraZhengzhan.Visible = r33101.extrazhengzhan.Equals("1");
        lblExtraZhengfu.Visible = r33101.extrazhengfu.Equals("1");
        lblExtraGongji.Visible = r33101.extragongji.Equals("1");
        sysgold = r33101.sys_gold;
        usergold = r33101.user_gold;
        txtGold.Text = (Convert.ToInt32(sysgold) + Convert.ToInt32(usergold)).ToString();
        tokencd = Convert.ToInt32(r33101.tokencd);
        tokencdusable = r33101.tokencdusable;
        forces = r33101.forces;
        txtForces.Text = forces + "/" + maxforces;
        lblToken.Text = "Lượt: " + r33101.token + "/" + r11102.maxtoken;
        txtJyungong.Text = r33101.jyungong;
        LogText("[Chiến] Tỉ lệ: " + r33101.winp + ": " + r33101.message);
        if (r33101.items != "")
            txtLogs.AppendText(". Nhận được:" + r33101.items);
        txtLogs.AppendText(" ");
        //txtLogs.InsertLink("[Chiến báo]", r33101.id);
    } else
        LogText("[Chiến] " + r33101.m);
    armynext = true;
    armyok = true;
    break;
#endregion


#region 34100
case "34100":
    r34100 = new R34100(cdata);
    if (r34100.m == null) {
        if (chkArmy.Checked) {
            if (r34100.listmember.Count == 0)
                switch (cbbArmyMode.SelectedIndex) {
                case 0:
                    LogText("[Chiến] Lập tổ đội " + r34100.name);
                    SendMsg("34101", ((TagItem) lstArmyList.Items[armycycle]).tag, "4:0;2", "0");
                    break;
                case 1:
                    bool join = false;
                    foreach (RTeam.Team dt in r34100.listteam)
                        if ((dt.condition.Contains(r11102.legionname)
                            || dt.condition.Contains(V.listnation[Convert.ToInt32(r11102.nation)]))
                            && Convert.ToInt32(dt.currentnum) < Convert.ToInt32(r34100.maxplayer)) {
                            join = true;
                            LogText("[Chiến] Gia nhập tổ đội " + r34100.name
                                + " (" + dt.currentnum + "/" + r34100.maxplayer
                                + ") của " + dt.teamname);
                            SendMsg("34102", dt.teamid);
                            break;
                        }
                    if (!join)
                        if (cbbArmyMode.SelectedIndex == 2)
                            goto case 0;
                        else {
                            armynext = true;
                            armyok = true;
                        }
                    break;
                case 2:
                    goto case 1;
                } else
                if (chkArmyAttack.Checked
                    && r34100.listmember.Count >= numArmyAttack.Value
                    && Convert.ToInt32(r34100.currentnum)
                    >= Convert.ToInt32(r34100.minplayer)) {
                if (r11102.playername == r34100.listmember[0].playername)
                    SendMsg("34107", "0");
                else {
                    SendMsg("34101", "900001", "4:0;1", "0");
                    SendMsg("34107", "0");
                    SendMsg("34105");
                }
            } else
                armyok = true;
        } else {
            btnArmyTeam.Text = r34100.listteam.Count.ToString() + " tổ đội";
            KryptonContextMenu context = new KryptonContextMenu();
KryptonContextMenuItems items = new KryptonContextMenuItems();
            foreach (RTeam.Team tm in r34100.listteam) {
                KryptonContextMenuItem item = new KryptonContextMenuItem();
item.Text = tm.teamname + " ["
                    + tm.condition + "] ("
                    + tm.currentnum + "/"
                    + tm.maxnum + ")";
                item.Tag = tm.teamid;
                item.Click += btnArmyTeam_Click;
                // item.Enabled = r34100.listmember.Count == 0;
                items.Items.Add(item);
            }
            if (items.Items.Count > 0) {
                context.Items.Add(items);
                btnArmyTeam.KryptonContextMenu = context;
            } else
                btnArmyTeam.KryptonContextMenu = null;
            lstArmyMember.Items.Clear();
            foreach (RTeam.Member mem in r34100.listmember)
                lstArmyMember.Items.Add(mem.playername + " (" + mem.playerlevel + ")");
            if (r34100.listmember.Count == 0) {
                // btnArmyInfo.Enabled = true;
                // btnArmyCreate.Enabled = true;
                // btnArmyAttack.Enabled = false;
                // btnArmyDisband.Enabled = false;
                // btnArmyQuit.Enabled = false;
                // btnArmyInvite.Enabled = false;
            } else {
                // btnArmyInfo.Enabled = false;
                // btnArmyCreate.Enabled = false;
                // btnArmyAttack.Enabled = true;
                if (r34100.listmember[0].playername == r11102.playername) {
                    // btnArmyDisband.Enabled = true;
                    // btnArmyQuit.Enabled = false;
                } else {
                    // btnArmyDisband.Enabled = false;
                    // btnArmyQuit.Enabled = true;
                }
                btnArmyInvite.Enabled = r34100.listmember.Count<Convert.ToInt32(r34100.maxplayer);
                // if (r34100.listmember.Count < Convert.ToInt32(r34100.minplayer))
                // btnArmyAttack.Enabled = false;
            }
            armyok2 = true;
        }
    } else
        LogText("[Chiến] " + r34100.m);
    break;
#endregion

#region 34108
case "34108":
    R34108 r34108 = new R34108(cdata); {
        lstArmyMember.Items.Clear();
        lblExtraYinkuang.Visible = r34108.extrayinkuang.Equals("1");
        lblExtraNongtian.Visible = r34108.extranongtian.Equals("1");
        lblExtraZhengzhan.Visible = r34108.extrazhengzhan.Equals("1");
        lblExtraZhengfu.Visible = r34108.extrazhengfu.Equals("1");
        lblExtraGongji.Visible = r34108.extragongji.Equals("1");
        sysgold = r34108.sys_gold;
        usergold = r34108.user_gold;
        txtGold.Text = (Convert.ToInt32(sysgold) + Convert.ToInt32(usergold)).ToString();
        tokencd = Convert.ToInt32(r34108.tokencd);
        tokencdusable = r34108.tokencdusable;
        forces = r34108.forces;
        txtForces.Text = forces + "/" + maxforces;
        lblToken.Text = "Lượt: " + r34108.token + "/" + r11102.maxtoken;
        txtJyungong.Text = r34108.jyungong;
        if (r34108.gains == "")
            LogText("[Chiến] Tấn công thất bại");
        else
            LogText("[Chiến] Nhận được " + r34108.gains + " chiến tích");
    }
    armynext = true;
    armyok = true;
    break;
#endregion

    

private void chkArmyAll_CheckedChanged(object sender, EventArgs e) {
for (int i = 0; i < lstArmyList.Items.Count; i++)
lstArmyList.SetItemChecked(i, chkArmyAll.Checked);
}

private void chkArmy_CheckedChanged(object sender, EventArgs e) {
armyok = chkArmy.Checked;
cbbArmyMode.Enabled = !chkArmy.Checked;
cbbArmy1.Enabled = !chkArmy.Checked;
cbbArmy2.Enabled = !chkArmy.Checked;
grpArmyInfo.Enabled = !chkArmy.Checked;
grpArmyList.Enabled = !chkArmy.Checked;
if (!chkArmy.Checked) {
btnArmyQuit_Click(null, null);
btnArmyDisband_Click(null, null);
} else
armycycle = 0;
}

private void cbbArmy1_SelectedIndexChanged(object sender, EventArgs e) {
for (int i = 0; i < listpower.Length; i++)
if (listpower[i] == cbbArmy1.SelectedItem.ToString()) {
SendMsg("33100", (i + 1).ToString());
break;
}
}

private void cbbArmy2_SelectedIndexChanged(object sender, EventArgs e) {
R33100.Army am = r33100.listarmy[cbbArmy2.SelectedIndex];
grpArmyInfo.Text = am.armyname + " Lv." + am.armylevel;
if (am.armymaxnum == "0")
txtArmyInfo1.Text = "Không";
else
txtArmyInfo1.Text = am.armynum + "/" + am.armymaxnum;
txtArmyInfo2.Text = am.jyungong;
txtArmyInfo3.Text = am.itemname;
btnArmyInfo.Enabled = am.attackable == "1" && (am.complete == "0" || am.type != "3"
&& (am.armynum != "0" || am.armymaxnum == "0" || am.type == "5"));
btnArmyAdd.Enabled = am.attackable == "1" && (am.complete != "1" || am.type != "3");
}
*/
}
