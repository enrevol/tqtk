using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ComponentFactory;
using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Navigator;
using Newtonsoft.Json.Linq;

namespace k8asd {
    public partial class ClientView : UserControl {
        private CharacterInfoView characterInfoView;
        private MCUView mcuView;

        public int num;
        public int updateflag = 0;

        public JToken loadtoken;

        public TimeSpan sys;

        private WayPoint HDVS = new WayPoint();
        private WayPoint.Player camppl;

        private LoginHelper loginHelper;
        private PacketHandler packetHandler;

        private KryptonButton[,] btnCampMap;
        private KryptonPage[] pagChat = new KryptonPage[7];
        private RichTextBoxEx[] txtChatBox = new RichTextBoxEx[7];

        private Point campxy;
        private R47107.Block campbl;
        private R12200 r12200;
        private R12400 r12400;
        private R13100 r13100;
        private R14101 r14101;
        private R14103 r14103;
        private R33100 r33100;
        private R33201 r33201;
        private R34100 r34100;
        private R39100 r39100;
        private R39301 r39301;
        private R45200 r45200;
        private R45201 r45201;
        private R45300 r45300;
        private R47008 r47008;
        private R47107 r47107;

        private bool armyok, plusok, armyok2, weaveok;
        private bool weaveautoupdate, weavecreate;
        private bool armynext;
        private bool campend, campmap;

        private int curpower;
        private int imposecd, tokencd, guidecd, techcd, makecd, forcefreecd, refreshcd, upgradecd;
        private int campcd, campactcd, camprecd;
        private int traincycle, armycycle;
        private int lastbagindex;
        private int lastupgindex;

        private int[] traincd = new int[8];
        private int[] chatcd = new int[4];
        private int[] listarmy;
        private int[] bindcd = new int[60];

        private string tokencdusable, techcdusable, imposecdusable, guidecdusable, upgradeusable;
        private string campid;
        private string isimposelimit;
        private string magic, foodprice;

        private int systemGold;
        private int userGold;
        private int reputationPoints;
        private int honorPoints;
        private int food;
        private int maxFood;
        private int forces;
        private int maxForces;
        private int silver;
        private int maxSilver;
        private int mcu;
        private int maxMcu;
        private int mcuCooldown;

        private int SystemGold {
            get { return systemGold; }
            set {
                systemGold = value;
                characterInfoView.SetGold(systemGold + userGold);
            }
        }

        private int UserGold {
            get { return userGold; }
            set {
                userGold = value;
                characterInfoView.SetGold(systemGold + userGold);
            }
        }

        private int ReputationPoints {
            get { return reputationPoints; }
            set {
                reputationPoints = value;
                characterInfoView.SetReputationPoints(reputationPoints);
            }
        }

        private int HonorPoints {
            get { return honorPoints; }
            set {
                honorPoints = value;
                characterInfoView.SetHonorPoints(honorPoints);
            }
        }

        private int Food {
            get { return food; }
            set {
                food = value;
                characterInfoView.SetFood(food, maxFood);
            }
        }

        private int MaxFood {
            get { return maxFood; }
            set {
                maxFood = value;
                characterInfoView.SetFood(food, maxFood);
            }
        }

        private int Forces {
            get { return forces; }
            set {
                forces = value;
                characterInfoView.SetForces(forces, maxForces);
            }
        }

        private int MaxForces {
            get { return maxForces; }
            set {
                maxForces = value;
                characterInfoView.SetForces(forces, maxForces);
            }
        }

        private int Silver {
            get { return silver; }
            set {
                silver = value;
                characterInfoView.SetSilver(silver, maxSilver);
            }
        }

        private int MaxSilver {
            get { return maxSilver; }
            set {
                maxSilver = value;
                characterInfoView.SetSilver(silver, maxSilver);
            }
        }

        private int MCU {
            get { return mcu; }
            set {
                mcu = value;
                mcuView.SetMCU(mcu);
            }
        }

        private int MCUCooldown {
            get { return mcuCooldown; }
            set {
                mcuCooldown = value;
                mcuView.SetMCUCooldown(mcuCooldown);
            }
        }

        private string[] listpower = new string[25];

        public ClientView() {
            InitializeComponent();

            grpLog.Dock = DockStyle.Fill;

            this.Size = new Size(236, 145);

            for (int i = 0; i < 6; i++)
                cbbChat.Items.Add(V.listchat[i]);
            cbbChat.SelectedIndex = 3;

            for (int i = 0; i < 7; i++) {
                pagChat[i] = new KryptonPage();
                txtChatBox[i] = new RichTextBoxEx();
                txtChatBox[i].Dock = DockStyle.Fill;
                txtChatBox[i].BackColor = Color.Black;
                txtChatBox[i].ForeColor = V.listcolorchat[i];
                txtChatBox[i].Font = new Font("Sogue", 9.25f);
                txtChatBox[i].ReadOnly = true;
                txtChatBox[i].ScrollBars = RichTextBoxScrollBars.ForcedVertical;
                pagChat[i].Controls.Add(txtChatBox[i]);
                pagChat[i].Text = V.listchat[i];
                navChat.Pages.Add(pagChat[i]);
            }
            navChat.SelectedIndex = 6;
            
            cbbArmyMode.Items.AddRange(V.listarmymode);
            cbbArmyMode.SelectedIndex = 0;

            cbbWeaveMode.Items.AddRange(V.listweavemode);
            cbbWeaveMode.SelectedIndex = 0;

            int asz = 18;
            int sz = 30;
            int dist = 1;
            btnCampMap = new KryptonButton[asz, asz];
            for (int i = 0; i < asz; i++)
                for (int j = 0; j < asz; j++) {
                    btnCampMap[i, j] = new KryptonButton();
                    btnCampMap[i, j].Size = new Size(sz, sz);
                    btnCampMap[i, j].Location = new Point(dist + i * (sz + dist), dist + j * (sz + dist));
                    btnCampMap[i, j].Tag = i.ToString() + "." + j.ToString();
                    btnCampMap[i, j].Click += btnCampMap_Click;
                    pnlCampMap.Controls.Add(btnCampMap[i, j]);
                }
            cbbCamp.Items.AddRange(V.listcamp);
            cbbCamp.SelectedIndex = 0;

            WayPoint.Player player = new WayPoint.Player(new Point(0, 1));

            player.Add(new Point(0, 0), new Point(3, 6));
            HDVS.listplayer.Add(player);

            player = new WayPoint.Player(new Point(0, 8));
            player.Add(new Point(0, 7), new Point(2, 14));
            HDVS.listplayer.Add(player);

            player = new WayPoint.Player(new Point(0, 17));
            player.Add(new Point(0, 15), new Point(7, 17));
            player.Add(new Point(3, 12), new Point(7, 14));
            HDVS.listplayer.Add(player);

            player = new WayPoint.Player(new Point(7, 0));
            player.Add(new Point(4, 0), new Point(7, 5));
            HDVS.listplayer.Add(player);

            player = new WayPoint.Player(new Point(7, 5));
            player.Add(new Point(5, 6), new Point(7, 17));
            HDVS.listplayer.Add(player);

            cbbUpg1.SelectedIndexChanged -= cbbUpg2_SelectedIndexChanged;
            cbbUpg1.Items.AddRange(V.listequiptype);
            cbbUpg1.SelectedIndex = 0;
            cbbUpg1.SelectedIndexChanged += cbbUpg2_SelectedIndexChanged;
        }

        private void SetFood(int food) {
            this.food = food;
        }

        public void btnLog_Click(object sender, EventArgs e) {
            grpLog.Visible = false;
            txtLogs.Dock = DockStyle.Fill;

            LogIn(Int32.Parse(txtServer.Text), txtUsername.Text, txtPassword.Text);
        }

        public void LogIn(int serverId, string username, string password) {
            loginHelper = new LoginHelper(username, password);

            LogText("Bắt đầu đăng nhập tài khoản...");
            var loginAccountStatus = loginHelper.LoginAccount();
            switch (loginAccountStatus) {
            case LoginStatus.NoConnection:
                LogText("Không có kết nối mạng.");
                return;
            case LoginStatus.WrongUsernameOrPassword:
                LogText("Sai tên người dùng hoặc mật khẩu.");
                return;
            case LoginStatus.UnknownError:
                LogText("Có lỗi xảy ra.");
                return;
            }
            LogText("Đăng nhập tài khoản thành công.");

            LogText("Bắt đầu lấy thông tin để kết nối với máy chủ...");
            var loginServerStatus = loginHelper.LoginServer(serverId);
            switch (loginServerStatus) {
            case LoginStatus.NoConnection:
                LogText("Không có kết nối mạng.");
                return;
            case LoginStatus.UnknownError:
                LogText("Có lỗi xảy ra.");
                return;
            }
            LogText("Lấy thông tin thành công.");

            LogText("Bắt đầu kết nối với máy chủ...");
            packetHandler = new PacketHandler(loginHelper.Session);
            if (!packetHandler.Connect()) {
                LogText("Kết nối với máy chủ thất bại.");
            }

            tmrData.Start(); ;
            packetHandler.SendCommand("10100");
        }

        private void tmrData_Tick(object sender, EventArgs e) {
            var packet = packetHandler.ReadPacket();
            if (packet == null) {
                return;
            }
            if (packet.Message.Length == 0) {
                return;
            }

            var cmd = packet.CommandId;
            var cdata = packet.Raw;

            bool c41304 = false;
            bool c41100s = false;
            bool nextpower;

            switch (cmd) {
            #region 10100
            case "10100":
                tmrCd.Start();
                LogText("[Kết nối] Kết nối với server thành công");
                LogText("[Cập nhật] Thông tin nhân vật...");

                if (loadtoken != null)
                    numUpdate.Value = Convert.ToInt32(loadtoken["update"].ToString());

                SendMsg("11102");
                break;
            #endregion

            #region 10103
            case "10103": {
                    if (packet.Message.Length > 0) {
                        R10103 r10103 = new R10103(cdata);
                        int cat = Convert.ToInt32(r10103.category);
                        string msg = r10103.text;
                        int start = txtChatBox[6].TextLength;

                        txtChatBox[6].AppendText("\n" + msg);
                        if (cat != 8)
                            txtChatBox[cat - 1].AppendText("\n" + msg);

                        if (r10103.href != "") {
                            txtChatBox[6].InsertLink(r10103.disp, r10103.href);
                            if (cat != 8)
                                txtChatBox[cat - 1].InsertLink(r10103.disp, r10103.href);
                        }

                        txtChatBox[6].ScrollToCaret();
                        if (cat != 8)
                            txtChatBox[cat - 1].ScrollToCaret();

                        txtChatBox[6].Select(start, txtChatBox[6].TextLength - start);
                        txtChatBox[6].SelectionColor = r10103.color;
                        txtChatBox[6].SelectionLength = 0;
                    }
                }
                break;
            #endregion

            #region 11102
            case "11102": {
                    var token = JToken.Parse(cdata);

                    /*
                    systime = (string) player["systime"];
                    avoidWarStatus = (string) token["avoidWarStatus"];
                    protectcd = (string) player["protectcd"];
                    legionkey = (string) player["legionkey"];
                    guidestep = (string) player["guidestep"];
                    techcdusable = (string) player["techcdusable"];
                    vip = (string) player["vip"];
                    tokencdusable = (string) player["tokencdusable"];
                    trainnum = (string) player["trainnum"];
                    legionname = (string) player["legionname"];
                    year = (string) player["year"];
                    imposecdusable = (string) player["imposecdusable"];
                    guidecdusable = (string) player["guidecdusable"];
                    isimposelimit = (string) player["isimposelimit"];
                    arealevel = (string) player["arealevel"];
                    nation = (string) player["nation"];
                    newmail = (string) player["newmail"];
                    season = (string) player["season"];
                    id = (string) player["id"];
                    techcd = (string) player["techcd"];
                    guidecd = (string) player["guidecd"];
                    generalname = (string) player["generalname"];
                    map = (string) player["map"];            
                    imposecd = (string) player["imposecd"];
                    playerlevel = (string) player["playerlevel"];
                    playername = (string) player["playername"];
                    legionid = (string) player["legionid"];
                    */

                    // FIXME: handle case character not yet created.
                    var player = token["player"];
                    SystemGold = (int) player["sys_gold"];
                    UserGold = (int) player["user_gold"];
                    ReputationPoints = (int) player["prestige"];
                    HonorPoints = (int) player["jyungong"];
                    Food = (int) player["food"];
                    Forces = (int) player["forces"];
                    Silver = (int) player["copper"];
                    MCU = (int) player["token"];
                    MCUCooldown = (int) player["tokencd"];

                    var limitvalue = token["limitvalue"];
                    MaxFood = (int) limitvalue["maxfood"];
                    MaxForces = (int) limitvalue["maxforce"];
                    MaxSilver = (int) limitvalue["maxcoin"];

                    /*
                        // FIXME.
                        // characterBox.Text = r11102.playername + " Lv." + r11102.playerlevel + " [" + V.listnation[Convert.ToInt32(r11102.nation)] + "]";
                        grpCd.Text = r11102.year + V.listseason[Convert.ToInt32(r11102.season) - 1];

                        numForces.Maximum = Convert.ToInt32(maxforces);

                        lblToken.Text = "Lượt: " + r11102.token + "/" + r11102.maxtoken;

                        isimposelimit = r11102.isimposelimit;
                        imposecd = Convert.ToInt32(r11102.imposecd);
                        tokencd = Convert.ToInt32(r11102.tokencd);
                        guidecd = Convert.ToInt32(r11102.guidecd);
                        techcd = Convert.ToInt32(r11102.techcd);

                        tokencdusable = r11102.tokencdusable;
                        techcdusable = r11102.techcdusable;

                        if (updateflag == 0) {
                            LogText("[Cập nhật] Thông tin bang hội...");
                            SendMsg("32121");
                        }
                    } else
                        LogText("[Kết nối] Nhân vật không tồn tại");
                        */
                    break;
                }
            #endregion

            #region 11103
            case "11103": {
                    var token = JToken.Parse(cdata);
                    var playerupdateinfo = token["playerupdateinfo"];
                    if (playerupdateinfo != null) {
                        if (playerupdateinfo["sys_gold"] != null) {
                            SystemGold = (int) playerupdateinfo["sys_gold"];
                        }
                        if (playerupdateinfo["user_gold"] != null) {
                            UserGold = (int) playerupdateinfo["user_gold"];
                        }
                        if (playerupdateinfo["prestige"] != null) {
                            ReputationPoints = (int) playerupdateinfo["prestige"];
                        }
                        if (playerupdateinfo["jyungong"] != null) {
                            HonorPoints = (int) playerupdateinfo["jyungong"];
                        }
                        if (playerupdateinfo["food"] != null) {
                            Food = (int) playerupdateinfo["food"];
                        }
                        if (playerupdateinfo["maxfood"] != null) {
                            MaxFood = (int) playerupdateinfo["maxfood"];
                        }
                        if (playerupdateinfo["forces"] != null) {
                            Forces = (int) playerupdateinfo["forces"];
                        }
                        if (playerupdateinfo["maxforce"] != null) {
                            MaxForces = (int) playerupdateinfo["maxforces"];
                        }
                        if (playerupdateinfo["copper"] != null) {
                            Silver = (int) playerupdateinfo["copper"];
                        }
                        if (playerupdateinfo["maxcoin"] != null) {
                            MaxSilver = (int) playerupdateinfo["maxcoin"];
                        }
                        if (playerupdateinfo["token"] != null) {
                            MCU = (int) playerupdateinfo["token"];
                        }
                        if (playerupdateinfo["tokencd"] != null) {
                            MCUCooldown = (int) playerupdateinfo["tokencd"];
                        }
                    } else {
                        //
                    }
                    break;
                }
            // FIXME.
            /*
            R11103 r11103 = new R11103(cdata);
            if (r11103.contents != null)
                LogText("[" + r11103.title + "] " + r11103.contents);

            if (r11103.tokencdusable != null)
                tokencdusable = r11103.tokencdusable;

            if (r11103.year != null)
                grpCd.Text = r11103.year + V.listseason[Convert.ToInt32(r11103.season) - 1];

            if (r11103.isimposelimit != null)
                isimposelimit = r11103.isimposelimit;

            if (c41304)
                goto case "41302";

            if (c41100s)
                goto case "41100s";
                */
            #endregion

            #region 11104
            case "11104":
                R11104 r11104 = new R11104(cdata);

                refreshcd = 50000;
                if (r11104.message == null)
                    goto case "11103";

                break;
            #endregion

            #region 12200
            case "12200":
                r12200 = new R12200(cdata);
                //lstBuild.Items.Clear();

                forcefreecd = Convert.ToInt32(r12200.rightcd);

                //foreach (R12200.Main dt in dt_12200.listmain)
                //    if (dt != null)
                //        lstBuild.Items.Add(dt.buildname + " (" + dt.buildlevel + ")");
                //lstBuild.SelectedIndex = 0;
                //for (int i = 0; i < dt_12200.listconstruct.Count; i++)
                //    buildcd[i] = Convert.ToInt32(dt_12200.listconstruct[i].ctime);

                btnWorkshop.Enabled = r12200.listmain[24] != null;

                if (updateflag == 0) {
                    LogText("[Cập nhật] Thông tin thu thuế...");
                    SendMsg("12400");
                }
                goto case "11103";
            #endregion
                
                /*
            #region 13100
            case "13100":
                r13100 = new R13100(cdata);
                foodprice = r13100.price + V.arrow[Convert.ToInt32(Convert.ToBoolean(r13100.isup))];
                txtFoodPrice.Text = foodprice;
                txtFoodTrade.Text = r13100.crutrade + "/" + r13100.maxtrade;
                barFoodBuy.Value = barFoodSell.Value = 1;
                CheckFoodTrade(r13100.crutrade);
                if (updateflag == 0) {
                    LogText("[Cập nhật] Thông tin thành trì...");
                    SendMsg("12200", "1");
                }
                grpCd.Values.Description = "Lúa: " + foodprice + " - " + magic;
                break;
            #endregion
                */

            /*
            #region 13101
            case "13101":
                R13101 r13101 = new R13101(cdata);
                if (r13101.m == null) {
                    txtFoodTrade.Text = r13101.cde + "/" + r13100.maxtrade;
                    CheckFoodTrade(r13101.cde);
                    goto case "11103";
                } else
                    LogText("[Giao dịch lúa] " + r13101.m);
                break;
            #endregion
                */

            #region 14100
            case "14100": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["cde"] != null) {
                        forcefreecd = Convert.ToInt32(token["cde"].ToString());
                        goto case "11103";
                    } else {
                        LogText("[Lính] " + token["message"].ToString().Replace("\"", ""));
                        if (forcefreecd == 0)
                            forcefreecd += 600000;
                    }
                }
                break;
            #endregion

            #region 14101
            case "14101":
                r14101 = new R14101(cdata);
                numForcesRecruit.Maximum = Convert.ToInt32(r14101.forcemax);
                if (updateflag == 0) {
                    LogText("[Cập nhật] Thông tin cửa tiệm...");
                    SendMsg("39301", "0", "0", "0");
                }
                break;
            #endregion

            #region 14102
            case "14102": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["playerupdateinfo"] != null)
                        goto case "11103";
                }
                break;
            #endregion
                
            #region 32101
            case "32101":
                // R32101 r32101 = new R32101(cdata);
                if (updateflag == 0) {
                    LogText("[Cập nhật] Thông tin binh doanh...");
                    SendMsg("14101");
                }
                break;
            #endregion

            #region 32121
            case "32121":
                R32121 r32121 = new R32121(cdata);
                //txtLegionName.Text = dt_32121.legionname;
                //txtLegionDate.Text = dt_32121.createdate;
                //txtLegionLv.Text = dt_32121.legionlv;
                //txtLegionMemnum.Text = dt_32121.memnum + "/" + dt_32121.maxnum;
                //txtLegionNation.Text = sNation[Convert.ToInt32(dt_32121.nation)];
                //txtLegionCreater.Text = dt_32121.creater;
                //lblLegion.Text = "<b>Bang chủ: </b>" + dt_32121.jtz
                //    + "<br/><b>Đốc quân: </b>" + dt_32121.dj
                //    + "<br/><b>Doanh trưởng: </b>" + dt_32121.yz
                //    + "<br/><b>Thiên phu trưởng: </b>" + dt_32121.qfz
                //    + "<br/><b>Bách phu trưởng: </b>" + dt_32121.bfz
                //    + "<br/><br/><b>" + dt_32121.message + "</b>";
                if (updateflag == 0)
                    SendMsg("32101", "0", "1", "\x20");
                break;
            #endregion

            #region 33100
            case "33100":
                r33100 = new R33100(cdata);
                if (updateflag == 0) {
                    listpower[Convert.ToInt32(r33100.powerid) - 1] = r33100.powername;
                    nextpower = false;

                    int id = Convert.ToInt32(r33100.nextpowerid);
                    if (r33100.nextattackble == "1" && listpower[id - 1] == null) {
                        SendMsg("33100", r33100.nextpowerid);
                        nextpower = true;
                    } else
                        for (; curpower <= 17; curpower++)
                            if (r33201.listpower[curpower].powerState == "1") {
                                SendMsg("33100", (4 + curpower++).ToString());
                                nextpower = true;
                                break;
                            }

                    if (!nextpower)
                        UpdateComplete();
                }

                cbbArmy2.Items.Clear();
                if (r33100.listarmy != null) {
                    foreach (R33100.Army dt in r33100.listarmy)
                        cbbArmy2.Items.Add(dt.armyname + " (" + dt.armylevel + ")");
                    cbbArmy2.SelectedIndex = 0;
                }
                break;
            #endregion

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
                */
                break;
            #endregion

            #region 33201
            case "33201":
                r33201 = new R33201(cdata);

                cbbArmy1.Items.Clear();
                for (int i = 0; i < r33201.listpower.Count; i++)
                    listpower[i] = r33201.listpower[i].powerName;

                nextpower = false;
                if (r33201.listpower.Count > 15)
                    for (curpower = 15; curpower <= 17; curpower++)
                        if (r33201.listpower[curpower].powerState == "1") {
                            SendMsg("33100", (4 + curpower++).ToString());
                            nextpower = true;
                            break;
                        }
                if (!nextpower)
                    UpdateComplete();

                if (loadtoken != null) {
                    JObject obj = (JObject) loadtoken["army"];
                    chkArmy.Checked = Convert.ToBoolean(obj["check"].ToString());
                    cbbArmyMode.SelectedIndex = Convert.ToInt32(obj["mode"].ToString());
                    numArmyAttack.Value = Convert.ToInt32(obj["limit"].ToString());
                    chkArmyAttack.Checked = Convert.ToBoolean(obj["limitcheck"].ToString());
                    numArmyRefresh.Value = Convert.ToInt32(obj["refresh"].ToString());
                    chkArmyRefresh.Checked = Convert.ToBoolean(obj["refreshcheck"].ToString());
                    chkArmyCd.Checked = Convert.ToBoolean(obj["wait"].ToString());
                    JArray array = (JArray) obj["list"];
                    for (int i = 0; i < array.Count; i++) {
                        obj = (JObject) array[i];
                        lstArmyList.Items.Add(new TagItem(
                            obj["army"].ToString().Replace("\"", ""),
                            obj["id"].ToString().Replace("\"", "")));
                        lstArmyList.SetItemChecked(i, Convert.ToBoolean(obj["check"].ToString()));
                    }
                    obj = (JObject) loadtoken["forces"];
                    chkForces.Checked = Convert.ToBoolean(obj["forcecheck"].ToString());
                    numForces.Value = Convert.ToInt32(obj["forcenum"].ToString());
                    chkForcesFree.Checked = Convert.ToBoolean(obj["forcefree"].ToString());
                    loadtoken = null;
                }
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
                                /*
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
                                    */
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
                            /*
                            if (r11102.playername == r34100.listmember[0].playername)
                                SendMsg("34107", "0");
                            else {
                                SendMsg("34101", "900001", "4:0;1", "0");
                                SendMsg("34107", "0");
                                SendMsg("34105");
                            }
                            */
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
                            /*
                            if (r34100.listmember[0].playername == r11102.playername) {
                                // btnArmyDisband.Enabled = true;
                                // btnArmyQuit.Enabled = false;
                            } else {
                                // btnArmyDisband.Enabled = false;
                                // btnArmyQuit.Enabled = true;
                            }
                            */
                            btnArmyInvite.Enabled = r34100.listmember.Count < Convert.ToInt32(r34100.maxplayer);
                            // if (r34100.listmember.Count < Convert.ToInt32(r34100.minplayer))
                            // btnArmyAttack.Enabled = false;
                        }
                        armyok2 = true;
                    }
                } else
                    LogText("[Chiến] " + r34100.m);
                break;
            #endregion

            #region 34101
            case "34101": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token.ToString() != "\"\"") {
                        LogText("[Chiến] " + token["message"].ToString().Replace("\"", ""));
                        armynext = true;
                    }
                    armyok = true;
                }
                break;
            #endregion

            #region 34102
            case "34102": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token.ToString() != "\"\"")
                        LogText("[Chiến] " + token["message"].ToString().Replace("\"", ""));
                    armyok = true;
                }
                break;
            #endregion

            #region 34104
            case "34104": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token.ToString() != "\"\"")
                        LogText("[Chiến] " + token["message"].ToString().Replace("\"", ""));
                }
                break;
            #endregion

            #region 34105
            case "34105": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token.ToString() != "\"\"")
                        LogText("[Chiến] " + token["message"].ToString().Replace("\"", ""));
                }
                break;
            #endregion

            #region 34106
            case "34106": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] != null)
                        LogText("[Chiến]" + token["message"].ToString().Replace("\"", ""));
                }
                break;
            #endregion

            #region 34107
            case "34107": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] != null)
                        LogText("[Chiến]" + token["message"].ToString().Replace("\"", ""));
                    armyok = true;
                }
                break;
            #endregion

            #region 34108
            case "34108":
                /*
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
                */
                break;
            #endregion

            #region 39100
            case "39100":
                r39100 = new R39100(cdata);
                lblBag.Text = "Số ô: " + r39100.usesize + "/" + r39100.storesize;
                cbbBag.Items.Clear();
                for (int i = 0; i < r39100.listitem.Count; i++) {
                    R39100.Item it = r39100.listitem[i];
                    string s = it.name;
                    if (it.goodsnum != "-1")
                        s += " (" + it.goodsnum + "/" + it.fnum + ")";
                    cbbBag.Items.Add(s);
                    bindcd[i] = Convert.ToInt32(it.bindTime);
                }
                if (r39100.listitem.Count > 0) {
                    grpBag.Visible = true;
                    cbbBag.SelectedIndex = lastbagindex;
                } else
                    grpBag.Visible = false;
                break;
            #endregion

            #region 39101
            case "39101": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] == null) {
                        lastbagindex = 0;
                        SendMsg("39100", "0", "60");
                        goto case "11103";
                    } else
                        LogText("[Cửa tiệm] " + token["message"].ToString().Replace("\"", ""));
                    break;
                }
            #endregion

            #region 39103
            case "39103": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] == null) {
                        if (navShop.SelectedIndex == 0) {
                            lastbagindex = cbbBag.SelectedIndex;
                            SendMsg("39100", "0", "60");
                        } else if (navShop.SelectedIndex == 1) {
                            lastupgindex = cbbUpg2.SelectedIndex;
                            SendMsg("39301", V.attribredirect[cbbUpg1.SelectedIndex].ToString(), "0", "20");
                        }
                        goto case "11103";
                    } else
                        LogText("[Cửa tiệm] " + token["message"].ToString().Replace("\"", ""));
                    break;
                }
            #endregion

                /*
            #region 39301
            case "39301":
                r39301 = new R39301(cdata);
                magic = "Ma lực: " + r39301.magic + V.arrow[Convert.ToInt32(r39301.magicstate)];
                upgradecd = Convert.ToInt32(r39301.cd);
                upgradeusable = r39301.upgradecdusable;
                cbbUpg2.Items.Clear();
                for (int i = 0; i < r39301.listitem.Count; i++) {
                    R39301.Item it = r39301.listitem[i];
                    string s = it.equipname + " (" + it.equipstagename + " - " + it.equiplevel + ")";
                    cbbUpg2.Items.Add(s);
                    //bindcd[i] = Convert.ToInt32(it.bindTime);
                }
                if (r39301.listitem.Count > 0) {
                    grpUpg.Visible = true;
                    cbbUpg2.SelectedIndex = lastupgindex;
                } else
                    grpUpg.Visible = false;
                if (updateflag == 0) {
                    LogText("[Cập nhật] Thông tin giao dịch lúa...");
                    SendMsg("13100");
                }
                // grpCd.Values.Description = "Lúa: " + foodprice + " - " + magic;
                break;
            #endregion
            */

            /*
            #region 39302
            case "39302":
                R39302 r39302 = new R39302(cdata);
                if (r39302.m == null) {
                    if (r39302.message != null)
                        LogText("[Cửa tiệm] " + r39302.message);
                    if (r39302.replaySilver != null)
                        LogText("[Cửa tiệm] Nhận lại " + r39302.replaySilver + " Bạc");
                    grpCd.Values.Description = "Ma lực: " + r39302.magic + V.arrow[Convert.ToInt32(r39302.magicstate)];
                    upgradecd = Convert.ToInt32(r39302.cd);
                    upgradeusable = r39302.upgradecdusable;
                    lastupgindex = cbbUpg2.SelectedIndex;
                    SendMsg("39301", V.attribredirect[cbbUpg1.SelectedIndex].ToString(), "0", "20");
                    goto case "11103";
                } else
                    LogText("[Cửa tiệm] " + r39302.m);
                break;
            #endregion
            */

            #region 39306
            case "39306": {
                    lastbagindex = cbbBag.SelectedIndex;
                    SendMsg("39100", "0", "60");
                }
                break;
            #endregion

            #region 39307
            case "39307": {
                    lastbagindex = cbbBag.SelectedIndex;
                    SendMsg("39100", "0", "60");
                }
                break;
            #endregion

            #region 39308
            case "39308": {
                    lastbagindex = cbbBag.SelectedIndex;
                    SendMsg("39100", "0", "60");
                }
                break;
            #endregion

            #region 41100
            case "41100":
                /// FIXME
                /// Parse guide cd + guidecdusable.
            #endregion
            
            #region 41301
            case "41301": {
                    break;
                }

                /*
                R41301 r41301 = new R41301(cdata);
                if (r41301.m == null) {
                    lblPlusNew.Text = "D: " + r41302.baseleader + " + " + r41301.plusleader
                            + "\nK: " + r41302.baseforces + " + " + r41301.plusforces
                            + "\nT: " + r41302.baseintelligence + " + " + r41301.plusintelligence;
                    pnlPlusNew.Visible = true;
                    btnPlusKeep.Enabled = true;
                    btnPlusPlus.Enabled = false;
                    if (chkPlus.Checked) {
                        LogText("[Cải tiến] " + r41300.listgeneral[lstPlus.SelectedIndex].generalname
                            + ": D" + r41301.plusleader
                            + " K" + r41301.plusforces
                            + " T" + r41301.plusintelligence);
                        int att1 = cbbPlusAtt1.SelectedIndex;
                        int att2 = cbbPlusAtt2.SelectedIndex;
                        int[] org =
                        {
                                    Convert.ToInt32(r41302.originalattr.plusleader),
                                    Convert.ToInt32(r41302.originalattr.plusforces),
                                    Convert.ToInt32(r41302.originalattr.plusintelligence)
                                };
                        int[] bs =
                        {
                                    Convert.ToInt32(r41301.plusleader),
                                    Convert.ToInt32(r41301.plusforces),
                                    Convert.ToInt32(r41301.plusintelligence)
                                };
                        if ((!chkPlusAtt2.Checked && org[att1] < bs[att1])
                            || (chkPlusAtt2.Checked
                            && bs[att1] + 5 >= bs[F.AttPlus(att1, att2)]
                            && (org[att1] + org[F.AttPlus(att1, att2)]
                            < bs[att1] + bs[F.AttPlus(att1, att2)]
                            || (org[att1] + org[F.AttPlus(att1, att2)]
                            == bs[att1] + bs[F.AttPlus(att1, att2)]
                            && Math.Abs(org[att1] - org[F.AttPlus(att1, att2)])
                            > Math.Abs(bs[att1] - bs[F.AttPlus(att1, att2)]))))) {
                            txtLogs.AppendText(" -> Thay");
                            btnPlusChange_Click(null, null);
                        } else {
                            txtLogs.AppendText(" -> Giữ");
                            btnPlusKeep_Click(null, null);
                        }
                    }
                    goto case "11103";
                } else {
                    LogText("[Cải tiến] " + r41301.m);
                    chkPlus.Checked = false;
                }
                break;
                */
            #endregion

            #region 41302
            case "41302":
                // FIXME 

                /*
                r41302 = new R41302(cdata);
                grpPlusInfo.Text = r41302.generalname + " Lv." + r41302.generallevel;
                lstPlus.SelectedIndexChanged -= lstPlus_SelectedIndexChanged;
                lstPlus.Items[lstPlus.SelectedIndex] = r41302.generalname + " (" + r41302.generallevel + ")";
                lstPlus.SelectedIndexChanged += lstPlus_SelectedIndexChanged;
                txtPlusInfo1.Text = r41302.solidernum + "/" + r41302.maxsolidernum;
                txtPlusInfo2.Text = "D" + r41302.leader + " K" + r41302.forces + " T" + r41302.intelligence;
                txtPlusInfo3.Text = r41302.troopname;
                txtPlusInfo4.Text = r41302.troopstagename + " - " + r41302.trooplevel;
                txtPlusInfo5.Text = r41302.skillname;
                txtPlusInfo6.Text = "Tướng Lv. " + r41302.shiftlv + " trở lên";
                btnShift.Enabled = Convert.ToInt32(r41302.shiftlv) <= Convert.ToInt32(r41302.generallevel);
                lblPlusOrigin.Text = "D: " + r41302.baseleader + " + " + r41302.originalattr.plusleader
                    + "\nK: " + r41302.baseforces + " + " + r41302.originalattr.plusforces
                    + "\nT: " + r41302.baseintelligence + " + " + r41302.originalattr.plusintelligence;
                if (r41302.refreshable == "0") {
                    lblPlusNew.Text = "D: " + r41302.baseleader + " + " + r41302.newattr.plusleader
                        + "\nK: " + r41302.baseforces + " + " + r41302.newattr.plusforces
                        + "\nT: " + r41302.baseintelligence + " + " + r41302.newattr.plusintelligence;
                    pnlPlusNew.Visible = true;
                    btnPlusKeep.Enabled = true;
                    btnPlusPlus.Enabled = false;
                } else {
                    pnlPlusNew.Visible = false;
                    btnPlusKeep.Enabled = false;
                    btnPlusPlus.Enabled = true;
                }
                plusok = true;
                */
                break;
            #endregion
                
            #region 41304
            case "41304":
                c41304 = true;
                goto case "11103";
            #endregion

            #region 45200
            case "45200":
                r45200 = new R45200(cdata);

                txtWeaveInfo1.Text = r45200.info.totallevel + " Cấp";
                txtWeaveInfo2.Text = r45200.info.price + V.arrow[Convert.ToInt32(r45200.info.priceway)];
                txtWeaveInfo3.Text = r45200.info.succrate + " - " + r45200.info.baojirate;
                txtWeaveInfo4.Text = r45200.info.num + "/10";

                makecd = Convert.ToInt32(r45200.makecd);
                btnWeaveTeam.Text = r45200.listteam.Count.ToString() + " tổ đội"; {
                    bool playerishost = false;

                    KryptonContextMenu context = new KryptonContextMenu();
                    KryptonContextMenuItems items = new KryptonContextMenuItems();

                    foreach (R45200.Team tm in r45200.listteam) {
                        KryptonContextMenuItem item = new KryptonContextMenuItem();

                        item.Text = tm.teamname + " ["
                            + V.listnation[Convert.ToInt32(tm.nation)] + "] ("
                            + tm.num + "/"
                            + tm.maxnum + ") - Hạn chế cấp: "
                            + tm.limitlv
                            + " - Vải: " + tm.level
                            + " - Giá: " + tm.cost + " / " + tm.price
                            + " - Tỉ lệ: " + tm.succrate + " / " + tm.baojirate;
                        item.Tag = tm.teamid;

                        /*
                        if (r45300 == null)
                            item.Enabled = makecd == 0 && r45200.info.num != "0";
                        else
                            item.Enabled = r45300.type == "3" && tm.teamname == r11102.playername;
                            */

                        item.Click += btnWeaveTeam_Click;

                        items.Items.Add(item);
                        /*
                        if (tm.teamname == r11102.playername)
                            playerishost = true;
                            */
                    }
                    context.Items.Add(items);
                    if (items.Items.Count > 0)
                        btnWeaveTeam.KryptonContextMenu = context;
                    else
                        btnWeaveTeam.KryptonContextMenu = null;

                    if (r45300 == null) {
                        btnWeaveCreate.Enabled = makecd == 0 && r45200.info.num != "0";
                        lstWeaveMember.Items.Clear();
                        txtWeaveInfo5.Text = "";
                        txtWeaveInfo6.Text = "";
                        txtWeaveInfo7.Text = "";
                        btnWeaveDisband.Enabled = false;
                        btnWeaveMake.Enabled = false;
                        btnWeaveInvite.Enabled = false;
                        btnWeaveQuit.Enabled = false;
                        grpWeaveInfo2.Enabled = false;
                        lstWeaveMember.Enabled = false;
                    } else if (!playerishost && r45300.type == "3")
                        r45300 = null;
                }
                if (weaveautoupdate)
                    switch (cbbWeaveMode.SelectedIndex) {
                    case 1:
                        /*
                        foreach (R45200.Team tm in r45200.listteam)
                            if (((tm.nation == r11102.nation
                                && tm.legion == "0")
                                || tm.legion == r11102.legionid)
                                && Convert.ToInt32(tm.limitlv)
                                <= Convert.ToInt32(r45200.info.totallevel)
                                && Convert.ToInt32(tm.num) < 3) {
                                LogText("[Dệt] Gia nhập tổ đội dệt (" + tm.num + "/3) của " + tm.teamname);
                                SendMsg("45209", tm.teamid);
                                break;
                            }
                            */
                        break;
                    case 2:
                        /*
                        foreach (R45200.Team tm in r45200.listteam)
                            if (tm.teamname == r11102.playername) {
                                if (Convert.ToInt32(tm.num) >= numWeaveLimit.Value
                                    && chkWeaveMake.Checked)
                                    btnWeaveMake_Click(null, null);
                                break;
                            }
                            */
                        break;
                    }
                weaveok = true;
                break;
            #endregion

            #region 45201
            case "45201":
                r45201 = new R45201(cdata);
                if (r45201.m == null) {
                    cbbWeaveProduct.Items.Clear();
                    foreach (R45201.Product pr in r45201.listproduct)
                        cbbWeaveProduct.Items.Add("(" + pr.level + ") " + pr.name);
                    cbbWeaveProduct.SelectedIndex = 0;

                    cbbWeaveWorker.Items.Clear();
                    foreach (R45201.Worker wk in r45201.listworker)
                        cbbWeaveWorker.Items.Add("(" + wk.level + ") " + wk.name);
                    cbbWeaveWorker.SelectedIndex = 0;

                    grpWeaveCreate.Visible = true;
                    if (weavecreate) {
                        int a = r45201.listproduct.Count;
                        int b = Convert.ToInt32(numWeaveProduct.Value);
                        int n = Math.Max(a - b, 0);
                        cbbWeaveProduct.SelectedIndex = n;
                        LogText("[Dệt] Lập tổ đội dệt vải cấp " + Math.Min(a, b));
                        btnWeaveCreate1_Click(null, null);
                    }
                } else
                    LogText("[Dệt] " + r45201.m);
                break;
            #endregion

            #region 45202
            case "45202": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] != null)
                        LogText("[Dệt] " + token["message"].ToString().Replace("\"", ""));
                    grpWeaveParty.Enabled = true;
                    if (weavecreate) {
                        weavecreate = false;
                        weaveok = true;
                    }
                }
                break;
            #endregion

            #region 45206
            case "45206": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] != null)
                        LogText("[Dệt] " + token["message"].ToString().Replace("\"", ""));
                }
                break;
            #endregion

            #region 45207
            case "45207": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] != null)
                        LogText("[Dệt] " + token["message"].ToString().Replace("\"", ""));
                }
                break;
            #endregion

            #region 45208
            case "45208": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] != null)
                        LogText("[Dệt] " + token["message"].ToString().Replace("\"", ""));
                }
                break;
            #endregion

            #region 45209
            case "45209": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] != null)
                        LogText("[Dệt] " + token["message"].ToString().Replace("\"", ""));
                }
                break;
            #endregion

            #region 45210
            case "45210":
                break;
            #endregion

            #region 45300
            case "45300":
                r45300 = new R45300(cdata);

                lstWeaveMember.Items.Clear();

                if (r45300.type == "0") {
                    makecd = Convert.ToInt32(r45300.makecd) * 1000;
                    LogText("[Dệt] " + r45300.msg);
                    r45300 = null;
                } else if (r45300.type == "1")
                    r45300 = null;
                else if (r45300.type == "2") {
                    txtWeaveInfo5.Text = r45300.level;
                    txtWeaveInfo6.Text = r45300.succrate + " - " + r45300.baojirate;
                    txtWeaveInfo7.Text = r45300.cost + " - " + r45300.price;

                    grpWeaveInfo2.Enabled = true;
                    lstWeaveMember.Enabled = true;
                    btnWeaveCreate.Enabled = false;

                    foreach (R45300.Member mem in r45300.listmember)
                        lstWeaveMember.Items.Add("(" + mem.spinnerTotalLevel + ") "
                            + mem.name + " (" + mem.level + ") ["
                            + mem.price + "]");

                    if (r45300.leaderid == loginHelper.Session.UserId) {
                        btnWeaveQuit.Enabled = false;
                        btnWeaveMake.Enabled = true;
                        btnWeaveDisband.Enabled = true;
                    } else {
                        btnWeaveQuit.Enabled = true;
                        btnWeaveMake.Enabled = false;
                        btnWeaveDisband.Enabled = false;
                    }

                    btnWeaveInvite.Enabled = r45300.listmember.Count < 3;
                    if (chkWeave.Checked)
                        switch (cbbWeaveMode.SelectedIndex) {
                        case 0:
                            if (r45300.listmember.Count >= numWeaveLimit.Value
                                && chkWeaveMake.Checked)
                                btnWeaveMake_Click(null, null);
                            break;
                        case 2:
                            SendMsg("45206", r45300.teamid, loginHelper.Session.UserId);
                            break;
                        }
                } else if (r45300.type == "3") {
                    bool playerishost = false;
                    /*
                    foreach (R45200.Team tm in r45200.listteam)
                        if (tm.teamname == r11102.playername) {
                            playerishost = true;
                            break;
                        }
                        */

                    if (playerishost) {
                        btnWeaveDisband.Enabled = true;
                        btnWeaveMake.Enabled = true;
                        btnWeaveInvite.Enabled = true;
                    } else
                        r45300 = null;
                }
                break;
            #endregion

            #region 47001
            case "47001":
                break;
            #endregion

            #region 47007
            case "47007": {
                    JToken token = JObject.Parse(cdata)["m"];
                    var campaignId = (string) token["campaignId"];
                    var id = (string) token["id"];
                    SendMsg("47101", "1", id);
                }
                break;
            #endregion

            #region 47008
            case "47008":
                r47008 = new R47008(cdata);

                if (r47008.m == null) {
                    btnCampTeam.Text = r47008.listteam.Count.ToString() + " tổ đội";

                    KryptonContextMenu context = new KryptonContextMenu();
                    KryptonContextMenuItems items = new KryptonContextMenuItems();

                    foreach (RTeam.Team tm in r47008.listteam) {
                        KryptonContextMenuItem item = new KryptonContextMenuItem();
                        item.Text = tm.teamname + " ["
                            + tm.condition + "] ("
                            + tm.currentnum + "/"
                            + tm.maxnum + ")";
                        item.Tag = tm.teamid;
                        item.Click += btnCampTeam_Click;

                        item.Enabled = r47008.listmember.Count == 0;
                        items.Items.Add(item);
                    }

                    if (items.Items.Count > 0) {
                        context.Items.Add(items);
                        btnCampTeam.KryptonContextMenu = context;
                    } else
                        btnCampTeam.KryptonContextMenu = null;

                    lstCampMember.Items.Clear();
                    foreach (RTeam.Member mem in r47008.listmember)
                        lstCampMember.Items.Add(mem.playername + " (" + mem.playerlevel + ")");

                    if (r47008.listmember.Count == 0) {
                        btnCampInfo.Enabled = true && campid == null;
                        btnCampCreate.Enabled = true;
                        btnCampAttack.Enabled = false;
                        btnCampDisband.Enabled = false;
                        btnCampQuit.Enabled = false;
                        btnCampInvite.Enabled = false;
                    } else {
                        btnCampInfo.Enabled = false;
                        btnCampCreate.Enabled = false;

                        /*
                        if (r47008.listmember[0].playername == r11102.playername) {
                            btnCampAttack.Enabled = true;
                            btnCampDisband.Enabled = true;
                            btnCampQuit.Enabled = false;
                        } else {
                            btnCampAttack.Enabled = false;
                            btnCampDisband.Enabled = false;
                            btnCampQuit.Enabled = true;
                        }
                        */

                        btnCampInvite.Enabled = r47008.listmember.Count < Convert.ToInt32(r47008.maxplayer);
                        if (r47008.listmember.Count < Convert.ToInt32(r47008.minplayer))
                            btnCampAttack.Enabled = false;
                    }
                } else
                    LogText("[Chiến dịch] " + r47008.m);
                break;
            #endregion

            #region 47100
            case "47100":
                R47100 r47100 = new R47100(cdata);
                foreach (R47100.Reward rw in r47100.listreward)
                    LogText("[Chiến dịch] Nhận được " + rw.award + " " + rw.name);
                break;
            #endregion

            #region 47101
            case "47101": {
                    JToken token = JObject.Parse(cdata)["m"];
                    campcd = Convert.ToInt32(token["cd"].ToString());
                    campid = (string) token["id"];
                    SendMsg("47107", campid, "1");
                }
                break;
            #endregion

            #region 47102
            case "47102": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] != null)
                        LogText("[Chiến dịch] " + token["message"].ToString().Replace("\"", ""));
                }
                break;
            #endregion

            #region 47103
            case "47103": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] != null)
                        LogText("[Chiến dịch] " + token["message"].ToString().Replace("\"", ""));
                }
                break;
            #endregion

            #region 47106
            case "47106":
                lblCampCd.Text = "";
                pnlCampMap.SendToBack();
                btnCampQuitIn.Visible = false;
                grpCampInfo.Visible = false;
                btnCampInfo.Enabled = true;
                campend = true;
                break;
            #endregion

            #region 47107
            case "47107":
                r47107 = new R47107(cdata);
                if (btnCampInfo.Text == "Thoát")
                    btnCampInfo_Click(null, null);
                btnCampInfo.Enabled = false;
                for (int i = 0; i < 18; i++)
                    for (int j = 0; j < 18; j++) {
                        btnCampMap[i, j].Visible = false;
                        btnCampMap[i, j].Text = "";
                    }
                campmap = false;
                campend = false;
                goto case "47107s";
            #endregion

            #region 47107s
            case "47107s": {
                    int w = Convert.ToInt32(r47107.width);
                    int h = Convert.ToInt32(r47107.height);

                    for (int i = 0; i < r47107.listblock.Count; i++) {
                        R47107.Block bl = r47107.listblock[i];

                        Point p = new Point(Convert.ToInt32(bl.x), Convert.ToInt32(bl.y));

                        KryptonButton bt = btnCampMap[p.Y, p.X];

                        Color color = Color.AliceBlue;

                        bt.Text = "";
                        //bt.Tooltip = "";
                        if (bl.solider != null) {
                            //bt.Tooltip = bl.solider.name + " (" + bl.solider.level + ")"
                            //+ "\r\nBinh lực: " + bl.solider.currforcesnum + "/" + bl.solider.maxforcesnum;
                            /*bt.Tooltip +=
                                   + "\r\neffects: " + bl.solider.effects
                                   + "\r\nfiretime: " + bl.solider.firetime
                                   + "\r\nfx: " + bl.solider.fx
                                   + "\r\nhit: " + bl.solider.hit
                                   + "\r\nskill: " + bl.solider.skill;*/
                        }

                        if (bl.dx != "0") {
                            if (bl.dx == "2")
                                if (bl.solider.id == loginHelper.Session.UserId) {
                                    color = Color.Yellow;
                                    campxy = p;
                                    campbl = bl;
                                    if (!campmap)
                                        foreach (WayPoint.Player player in HDVS.listplayer)
                                            if (player.player.Equals(campxy))
                                                camppl = player;
                                    //bt.Tooltip += "\r\nTấn công: " + bl.solider.konum;
                                } else
                                    color = Color.Blue;
                            else if (bl.dx == "1")
                                color = Color.DarkRed;
                        } else
                            color = Color.FromArgb(150, 150, 150);

                        F.CampBt(ref bt, color);

                        //bt.Tooltip += "\r\nflag: " + bl.flag
                        //    + "\r\nmap: " + bl.map
                        //    + "\r\ntoken: " + bl.token;
                    }

                    if (!campmap) {
                        btnCampMap[campxy.Y, campxy.X].Visible = true;
                        F.CampMap(campbl.moveInfo, campxy, ref btnCampMap, r47107);
                        campmap = true;
                    }

                    for (int k = 0; k < 4; k++)
                        if (campbl.moveInfo[k] == '1') {
                            int m = campxy.Y + (k - 1) % 2;
                            int n = campxy.X + (k - 2) % 2;

                            if (0 <= n && n < w
                                && 0 <= m && m < h) {
                                btnCampMap[m, n].Text = "▲";
                                int[] orient = { 2, 0, 3, 1 };

                                btnCampMap[m, n].Orientation = (VisualOrientation) orient[k];
                                if (r47107.listblock[m * w + n].solider != null)
                                    btnCampMap[m, n].Text = "■";
                            }
                        }

                    txtCampInfo1.Text = r47107.info.armynum + "/" + r47107.maxarmynum;
                    campactcd = Convert.ToInt32(r47107.info.nextactiontime);
                    camprecd = Convert.ToInt32(r47107.info.remaintime);

                    /*btnCampaign.Tooltip =
                        "interval: " + dt_47107.info.interval
                        + "\r\nmapCount: " + dt_47107.info.mapCount
                        + "\r\nreducetime: " + dt_47107.info.reducetime
                        + "r\nreduceusetime: " + dt_47107.info.reduceusetime;*/
                }
                break;
            #endregion

            #region 47108
            case "47108":
                R47107 r47108 = new R47107(cdata); {
                    int w = Convert.ToInt32(r47108.width);
                    int h = Convert.ToInt32(r47108.height);

                    foreach (R47107.Block bl in r47108.listblock) {
                        if (bl.dx == "2" && bl.solider == null)
                            bl.dx = "0";
                        r47107.listblock[Convert.ToInt32(bl.y) * w + Convert.ToInt32(bl.x)] = bl;
                    }

                    for (int i = 0; i < h; i++)
                        for (int j = 0; j < w; j++) {
                            R47107.Block bl2 = r47107.listblock[i * w + j];
                            if (bl2.dx == "1")
                                bl2 = new R47107.Block("0", "0", "0", null, bl2.moveInfo, "0", bl2.x, bl2.y);
                        }

                    r47107.info = r47108.info;
                }
                goto case "47107s";
            #endregion

            #region 47109
            case "47109":
                R47109 r47109 = new R47109(cdata);
                LogText("[Chiến dịch] " + r47109.result);

                TimeSpan span = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(r47109.time));
                txtLogs.AppendText(". Thời gian: " + F.GetTimewH(span));

                if (r47109.rank != "-1") {
                    txtLogs.AppendText(" [" + V.listcamprank[Convert.ToInt32(r47109.rank) - 1] + "]");
                    LogText("[Chiến dịch] Mở tàng bảo đồ...");

                    SendMsg("47100", "1");
                }
                goto case "47106";
            #endregion

            case "64005": {
                    break;
                }

            case "64007": {
                    break;
                }

            default:
                break;
            }
        }

        public event EventHandler AccInfoChanged;

        #region Timer

        private void tmrCd_Tick(object sender, EventArgs e) {
            if (sys.Seconds == 1 && (sys.Minutes == 0 || sys.Minutes == 30)) {
                SendMsg("39301", "0", "0", "0");
                SendMsg("13100");
            }

            if (btnAuto.Text == "Dừng") {
                if (chkArmy.Checked)
                    armyok = true;
                if (chkWeave.Checked)
                    weaveok = true;
            }

            for (int i = 0; i < 60; i++) {
                F.DecTime(ref bindcd[i]);
                if (i == cbbBag.SelectedIndex)
                    F.ShowTimemH(txtBagBindCd, bindcd[i]);
            }

            for (int i = 0; i < 4; i++)
                F.DecTime(ref chatcd[i]);

            F.DecTime(ref forcefreecd);

            F.DecTime(ref refreshcd);

            /*
            #region TrainCd

            {
                for (int i = 0; i < 8; i++)
                    F.DecTime(ref traincd[i]);

                int index = lstTrain.SelectedIndex;
                if (index >= 0)
                    F.ShowTime(txtTrainTime, traincd[index]);
            }

            #endregion
            */

            #region CampaignOpenCd

            if (campcd == 0) {
                lblCampCd.Text = "";

                if (campid != null) {
                    lblCampCd.SendToBack();
                    grpCampInfo.Visible = true;
                    btnCampQuitIn.Visible = true;
                    campid = null;
                }
            } else {
                TimeSpan span = new TimeSpan(0, 0, 0, 0, campcd);
                lblCampCd.Text = "Chiến dịch bắt đầu sau " + span.Seconds.ToString() + " giây...";
            }

            F.DecTime(ref campcd);

            #endregion

            #region CampaignInnerCd

            if (r47107 != null) {
                int elapsed = Convert.ToInt32(r47107.info.interval) - camprecd;

                F.ShowTime(txtCampInfo2, elapsed);

                string[] slice = r47107.slice.Split(',');
                for (int i = 0; i < slice.Length; i++) {
                    int elapsedr = Convert.ToInt32(slice[i]) * 1000;
                    if (elapsed < elapsedr) {
                        int campslcd = elapsedr - elapsed;

                        TimeSpan span = new TimeSpan(0, 0, 0, 0, campslcd);
                        txtCampInfo4.Text = V.listcamprank[4 - i] + " " + F.GetTimewH(span);
                        break;
                    }
                }
            }

            #endregion

            F.ShowDecTime(txtCampInfo3, ref camprecd);

            F.ShowDecTime(txtCampInfo5, ref campactcd);

            //F.CoolDown(txtImposeCd, ref imposecd, ref imposecdusable);

            //F.CoolDown(txtGuideCd, ref guidecd, ref guidecdusable);

            //F.CoolDown(lblTokenCd, ref tokencd, ref tokencdusable);

           // F.CoolDown(txtTechCd, ref techcd, ref techcdusable);

           // F.CoolDown(txtUpgradeCd, ref upgradecd, ref upgradeusable);

            string makecdusable = makecd == 0 ? "1" : "0";

            //F.CoolDown(txtWeaveCd, ref makecd, ref makecdusable);

            /*
            if (updateflag != 0) {
                btnImpose.Enabled = isimposelimit == "1" && imposecdusable == "1";
                btnGuide.Enabled = guidecdusable == "1";
                if (cbbUpg2.SelectedIndex >= 0) {
                    R39301.Item it = r39301.listitem[cbbUpg2.SelectedIndex];
                    btnUpgUp.Enabled = it.upgradeable == "1"
                        && Convert.ToInt32(it.coppercost)
                        <= Convert.ToInt32(copper)
                        && upgradeusable == "1";
                }
            }
            */
        }

        private void tmrReq_Tick(object sender, EventArgs e) {
            tmrReq.Interval = Convert.ToInt32(numUpdate.Value);

            #region Refresh

            if (refreshcd == 0)
                SendMsg("11104");

            #endregion

            if (btnArmyInfo.Text == "Thoát"
                && armyok2) {
                armyok2 = false;
                SendMsg("34100", r33100.listarmy[cbbArmy2.SelectedIndex].armyid);
            }

            if (btnCampInfo.Text == "Thoát")
                SendMsg("47008", V.listcampid[cbbCamp.SelectedIndex].ToString());

            if (btnAuto.Text == "Dừng") {

                #region Impose

                {
                    /*
                    string s = txtImposeNum.Text;
                    if (chkImpose.Checked
                        && isimposelimit == "1"
                        && imposecdusable == "1"
                        && Convert.ToInt32(copper)
                        + Convert.ToInt32(txtImposeCopper.Text)
                        <= Convert.ToInt32(maxcopper)
                        && Convert.ToInt32(s.Remove(s.IndexOf("/"))) > 0)
                        SendMsg("12401", "0");
                        */
                }

                #endregion

                #region Train

                /*
                if (chkTrain.Checked
                    && lstGuide.Items.Count > 0) {
                    F.Cycle(ref traincycle, lstGuide.Items.Count - 1);

                    int index = 0;
                    int lv = 0;

                    TagItem it = (TagItem) lstGuide.Items[traincycle];
                    for (int i = 0; i < r41100.listgeneral.Count; i++) {
                        R41100.General gen = r41100.listgeneral[i];
                        if (it.tag == gen.generalid) {
                            lv = Convert.ToInt32(gen.generallevel);
                            index = i;
                            break;
                        }
                    }

                    int trainnum = 0;
                    for (int i = 0; i < r41100.listgeneral.Count; i++)
                        if (traincd[i] > 0)
                            trainnum++;
                            
                    if (it.tag != null && lv < Convert.ToInt32(r11102.playerlevel)) {
                        if (trainnum < Convert.ToInt32(r41100.maxnum)
                            && traincd[index] == 0)
                            SendMsg("41101", it.tag, "1");

                        if (guidecdusable == "1"
                            && traincd[index] > 0
                            && lstGuide.CheckedIndices.Contains(traincycle)
                            && Convert.ToInt32(txtJyungong.Text) >= Convert.ToInt32(r41100.jyungong))
                            SendMsg("41102", it.tag, "1", "1");
                    }
                }
                */

                #endregion

                #region Army

                {
                    bool ok = false;
                    if (!chkArmyRefresh.Checked)
                        ok = true;
                    else {
                        TimeSpan span2 = new TimeSpan(0, 30 + Convert.ToInt32(numArmyRefresh.Value), 0);
                        foreach (TimeSpan span in V.listtimerefresh)
                            if (sys >= span && sys <= span + span2) {
                                ok = true;
                                break;
                            }
                    }

                    /*
                    if (ok) {
                        string s = lblToken.Text;
                        s = s.Remove(s.IndexOf("/")).Substring(s.IndexOf(" ") + 1);
                        if (chkArmy.Checked
                            && tokencdusable == "1"
                            && lstArmyList.CheckedIndices.Count > 0
                            && Convert.ToInt32(s) > 0
                            && armyok
                            && (!chkArmyCd.Checked
                            || (chkArmyCd.Checked
                            && tokencd == 0))) {
                            listarmy = new int[lstArmyList.CheckedIndices.Count];

                            for (int i = 0; i < listarmy.Length; i++)
                                listarmy[i] = Convert.ToInt32(lstArmyList.CheckedIndices[i]);

                            armyok = false;
                            if (armynext)
                                F.Cycle2(ref armycycle, listarmy);

                            TagItem it = (TagItem) lstArmyList.Items[listarmy[armycycle]];
                            if (armynext) {
                                armynext = false;
                                LogText("[Chiến] Chờ " + it.text);
                            }

                            if (Convert.ToInt32(it.tag) > 900000)
                                SendMsg("34100", it.tag);
                            else
                                SendMsg("33101", it.tag, "0");
                        }
                    }
                    */
                }

                #endregion

                #region Forces

                {
                    if (chkForcesFree.Checked
                        && forcefreecd == 0)
                        SendMsg("14100");

                    int diff = Convert.ToInt32(numForces.Value) - Convert.ToInt32(forces);
                    double cost = diff * Convert.ToDouble(r14101.recruits);

                    if (chkForces.Checked
                        && diff > 0
                        && cost <= Convert.ToInt32(food)) {
                        SendMsg("14102", diff.ToString(), "0");
                        LogText("[Lính] Đào tạo " + diff + " lính");
                    }
                }

                #endregion

            }

            #region Plus

            /*
            if (chkPlus.Checked && plusok) {
                plusok = false;
                int index = lstPlus.SelectedIndex;
                int lv = Convert.ToInt32(r41300.listgeneral[index].generallevel);
                int att1 = cbbPlusAtt1.SelectedIndex;
                int att2 = cbbPlusAtt2.SelectedIndex;

                int[] org =
                {
                    Convert.ToInt32(r41302.originalattr.plusleader),
                    Convert.ToInt32(r41302.originalattr.plusforces),
                    Convert.ToInt32(r41302.originalattr.plusintelligence)
                };

                if (org[att1] >= lv + 20
                    && (!chkPlusAtt2.Checked
                    || org[F.AttPlus(att1, att2)] >= lv + 20)) {
                    LogText("[Cải tiến] Chỉ số đạt mức tối đa");
                    chkPlus.Checked = false;
                } else
                    btnPlusPlus_Click(null, null);
            }
            */

            #endregion

            #region Weave

            if (weaveok) {
                weaveautoupdate = false;
                if (btnAuto.Text == "Dừng"
                    && chkWeave.Checked
                    && makecd == 0
                    && Convert.ToInt32(r45200.info.num) > 0)
                    switch (cbbWeaveMode.SelectedIndex) {
                    case 0:
                        if (r45300 == null) {
                            weaveok = false;
                            weavecreate = true;
                            btnWeaveCreate_Click(null, null);
                        }
                        break;
                    case 1:
                        if (r45300 == null) {
                            weaveautoupdate = true;
                            weaveok = false;
                            SendMsg("45200");
                        }
                        break;
                    case 2:
                        weaveautoupdate = true;
                        weaveok = false;
                        SendMsg("45200");
                        goto case 0;
                    }

                if (navWorkshop.Visible
                    && !weaveautoupdate) {
                    weaveok = false;
                    SendMsg("45200");
                }
            }

            #endregion

            #region Campaign
            if (chkCamp.Checked
                && campactcd == 0
                && !campend) {
                int w = Convert.ToInt32(r47107.width);
                int h = Convert.ToInt32(r47107.height);

                int[,] xfinCost = new int[w, h];
                List<Point>[,] xfinPath = new List<Point>[w, h];
                {
                    List<Point> curPath = new List<Point>();
                    for (int i = 0; i < w; i++)
                        for (int j = 0; j < h; j++)
                            xfinCost[i, j] = -1;
                    F.SearchPath(campbl.moveInfo, campxy, curPath, 0, camppl.listmap, r47107, ref xfinCost, ref xfinPath);
                }

                List<PointW> listmap = new List<PointW>();
                for (int i = 0; i < r47107.listblock.Count; i++) {
                    R47107.Block bl = r47107.listblock[i];
                    if (bl.dx == "1") {
                        Point p = new Point(Convert.ToInt32(bl.x), Convert.ToInt32(bl.y));
                        foreach (Point p2 in camppl.listmap)
                            if (p2.Equals(p)) {
                                int[,] finCost = new int[w, h];
                                List<Point> curPath = new List<Point>();
                                List<Point>[,] finPath = new List<Point>[w, h];
                                for (int k = 0; k < w; k++)
                                    for (int j = 0; j < h; j++)
                                        finCost[k, j] = -1;
                                F.SearchPath(bl.moveInfo, p, curPath, 0, camppl.listmap, r47107, ref finCost, ref finPath);
                                listmap.Add(new PointW(p, finCost, r47107));
                                break;
                            }
                    }
                }

                List<int> listmapint = new List<int>();

                int num = 0;
                foreach (PointW pw in listmap)
                    listmapint.Add(num++);

                if (num != 0) {
                    Permutation pm = new Permutation(listmapint);

                    int first = -1;
                    int costlowest = 99999999;

                    foreach (List<int> list in pm.result) {
                        int tempcost = 99999999;

                        F.TotalCost(list, listmap, 0, xfinCost[listmap[list[0]].p.X, listmap[list[0]].p.Y], ref tempcost);
                        if (tempcost <= costlowest) {
                            costlowest = tempcost;
                            first = list[0];
                        }
                    }

                    Point nPoint = listmap[first].p;
                    Point nPath = xfinPath[nPoint.X, nPoint.Y][0];

                    R47107.Block nbl = r47107.listblock[nPath.Y * w + nPath.X];
                    if (nbl.dx != "2")
                        SendMsg(nbl.dx == "1" ? "47103" : "47102",
                            nPath.X.ToString(),
                            nPath.Y.ToString(),
                            r47107.id);

                    LogText("[Chiến dịch] Di chuyển đến toạ độ (" + nPath.X.ToString() + "," + nPath.Y.ToString() + ")");
                }
            }

            #endregion

        }

        #endregion

        #region Chat

        private void txtChat_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13 && txtChat.Text.Trim() != "") {
                int n = cbbChat.SelectedIndex - 1;
                if (chatcd[n] == 0) {
                    switch (n) {
                    case 0:
                    case 1:
                    case 3:
                        chatcd[n] = 3500;
                        break;
                    case 2:
                        chatcd[n] = 10000;
                        break;
                    }

                    // SendMsg("10103", r11102.playername, txtChat.Text, (n + 2).ToString(), " ");
                    txtChat.Text = "";
                }
            }
        }

        private void btnChatExpand_Click(object sender, EventArgs e) {
            if (btnChatExpand.Text == "+")
                btnChatExpand.Text = "1";
            navChat.BringToFront();
            if (btnChatExpand.Text == "1") {
                btnChatExpand.Text = "2";
                navChat.Top -= 200;
                navChat.Height += 200;
            } else if (btnChatExpand.Text == "2") {
                btnChatExpand.Text = "3";
                navChat.Width += 500;
            } else if (btnChatExpand.Text == "3") {
                btnChatExpand.Text = "1";
                navChat.Width -= 500;
                navChat.Height -= 200;
                navChat.Top += 200;
            }
        }

        #endregion

        #region Office

        #region Impose

        private void btnImpose_Click(object sender, EventArgs e) {
            SendMsg("12401", "0");
        }

        private void btnImposeForce_Click(object sender, EventArgs e) {
            SendMsg("12401", "1");
        }

        private void btnImposeAnswer1_Click(object sender, EventArgs e) {
            SendMsg("12406", "1");
        }

        private void btnImposeAnswer2_Click(object sender, EventArgs e) {
            SendMsg("12406", "2");
        }

        #endregion

        #region Salary

        private void btnSalary_Click(object sender, EventArgs e) {
            SendMsg("12302");
        }

        #endregion
        
        #region Food

        private void btnFoodBuy_Click(object sender, EventArgs e) {
            SendMsg("13101", "0", barFoodBuy.Value.ToString());
        }

        private void btnFoodSell_Click(object sender, EventArgs e) {
            SendMsg("13101", "1", barFoodSell.Value.ToString());
        }

        private void barFoodBuy_Scroll(object sender, EventArgs e) {
            lblFoodBuy.Text = "Tiêu tốn " + barFoodBuy.Value * Convert.ToDouble(r13100.price)
                + " Bạc để mua " + barFoodBuy.Value + " lúa";
        }

        private void barFoodSell_Scroll(object sender, EventArgs e) {
            lblFoodSell.Text = "Bán " + barFoodSell.Value + " lúa, nhận được "
                + barFoodSell.Value * Convert.ToDouble(r13100.price) + " Bạc";
        }

        #endregion

        #endregion

        #region Barrack
        
        #region Plus

        /*
        private void chkPlus_CheckedChanged(object sender, EventArgs e) {
            plusok = chkPlus.Checked;
            pnlPlusAtt.Enabled = !chkPlus.Checked;
            btnPower.Enabled = !chkPlus.Checked;
            lstPlus.Enabled = !chkPlus.Checked;
            pagTrain.Visible = !chkPlus.Checked;
            pnlNav.Enabled = !chkPlus.Checked;
        }
        */

        /*
        private void lstPlus_SelectedIndexChanged(object sender, EventArgs e) {
            SendMsg("41302", r41300.listgeneral[lstPlus.SelectedIndex].generalid);
        }

        private void btnPlusPlus_Click(object sender, EventArgs e) {
            SendMsg("41301", r41300.listgeneral[lstPlus.SelectedIndex].generalid, cbbPlusMode.SelectedIndex.ToString());
        }

        private void btnPlusKeep_Click(object sender, EventArgs e) {
            SendMsg("41303", r41300.listgeneral[lstPlus.SelectedIndex].generalid, "0");
        }

        private void btnPlusChange_Click(object sender, EventArgs e) {
            SendMsg("41303", r41300.listgeneral[lstPlus.SelectedIndex].generalid, "1");
        }

        private void btnShift_Click(object sender, EventArgs e) {
            SendMsg("41304", r41300.listgeneral[lstPlus.SelectedIndex].generalid, cbbShift.SelectedIndex.ToString());
        }
        */

            /*
        private void cbbPlusAtt1_SelectedIndexChanged(object sender, EventArgs e) {
            cbbPlusAtt2.Items.Clear();
            switch (cbbPlusAtt1.SelectedIndex) {
            case 0:
                cbbPlusAtt2.Items.AddRange(new string[] { "Kỹ", "Trí" });
                break;
            case 1:
                cbbPlusAtt2.Items.AddRange(new string[] { "Dũng", "Trí" });
                break;
            case 2:
                cbbPlusAtt2.Items.AddRange(new string[] { "Dũng", "Kỹ" });
                break;
            }
            cbbPlusAtt2.SelectedIndex = 0;
        }
        */

        #endregion

        #endregion

        #region Power

        private void navPower_SelectedPageChanged(object sender, EventArgs e) {
            switch (navPower.SelectedIndex) {
            case 1:
                /*
                if (r11102.id != "") {
                    SendMsg("47101", "1", r11102.id);
                    r11102.id = "";
                }
                */
                break;
            }
        }

        #region Armys

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

        private void btnArmyInfo_Click(object sender, EventArgs e) {
            if (btnArmyInfo.Text == "Thoát") {
                btnArmyInfo.Text = "Tấn công";
                grpArmyParty.Visible = false;
                cbbArmy1.Enabled = true;
                cbbArmy2.Enabled = true;
                chkArmy.Enabled = true;
                btnAuto.Enabled = true;
                armyok = false;
            } else {
                int index = cbbArmy2.SelectedIndex;
                if (index >= 0) {
                    int id = Convert.ToInt32(r33100.listarmy[index].armyid);
                    if (id >= 900000) {
                        armyok2 = true;
                        grpArmyParty.Visible = true;
                        btnArmyInfo.Text = "Thoát";
                        cbbArmy1.Enabled = false;
                        cbbArmy2.Enabled = false;
                        chkArmy.Enabled = false;
                        btnAuto.Enabled = false;
                    } else
                        SendMsg("33101", id.ToString(), "0");
                }
            }
        }

        private void radArmy2_CheckedChanged(object sender, EventArgs e) {
            radArmy1.Checked = !radArmy2.Checked;
        }

        private void radArmy1_CheckedChanged(object sender, EventArgs e) {
            radArmy2.Checked = !radArmy1.Checked;
        }

        private void btnArmyCreate_Click(object sender, EventArgs e) {
            SendMsg("34101", r33100.listarmy[cbbArmy2.SelectedIndex].armyid,
                "4:0;" + (radArmy2.Checked ? "2" : "3"), "0");
        }

        private void btnArmyTeam_Click(object sender, EventArgs e) {
            // if (r34100.listmember.Count == 0) {
            KryptonContextMenuItem item = (KryptonContextMenuItem) sender;
            SendMsg("34102", item.Tag.ToString());
            // }
        }

        private void lstArmyMember_SelectedValueChanged(object sender, EventArgs e) {
            int index = lstArmyMember.SelectedIndex;
            if (index != -1) {
                SendMsg("34104", r34100.listmember[index].playerid);
            }
        }

        private void btnArmyAttack_Click(object sender, EventArgs e) {
            int cnum = Convert.ToInt32(r34100.currentnum);
            int mnum = Convert.ToInt32(r34100.minplayer);
            /*
            if (cnum >= mnum)
                if (r11102.playername == r34100.listmember[0].playername)
                    SendMsg("34107", "0");
                else {
                    SendMsg("34101", "900001", "4:0;1", "0");
                    SendMsg("34107", "0");
                    SendMsg("34105");
                }
                */
        }

        private void btnArmyDisband_Click(object sender, EventArgs e) {
            SendMsg("34105");
        }

        private void btnArmyInvite_Click(object sender, EventArgs e) {
            int cnum = Convert.ToInt32(r34100.currentnum);
            int mnum = Convert.ToInt32(r34100.maxnum);
            /*
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
                    */
        }

        private void btnArmyQuit_Click(object sender, EventArgs e) {
            SendMsg("34106");
        }

        private void btnArmyAdd_Click(object sender, EventArgs e) {
            int id = cbbArmy2.SelectedIndex;
            if (id >= 0) {
                R33100.Army am = r33100.listarmy[id];

                bool ex = false;
                foreach (TagItem it in lstArmyList.Items)
                    if (it.tag == am.armyid) {
                        ex = true;
                        break;
                    }

                if (!ex)
                    lstArmyList.Items.Add(new TagItem(am.armyname, am.armyid));
            }
        }

        private void btnArmyDel_Click(object sender, EventArgs e) {
            if (lstArmyList.SelectedItems.Count > 0)
                lstArmyList.Items.RemoveAt(lstArmyList.SelectedIndex);
        }

        private void btnArmyUp_Click(object sender, EventArgs e) {
            int id = lstArmyList.SelectedIndex;
            if (id - 1 >= 0) {
                object obj = lstArmyList.Items[id];
                lstArmyList.Items[id] = lstArmyList.Items[id - 1];
                lstArmyList.Items[id - 1] = obj;
                lstArmyList.SelectedIndex = id - 1;
            }
        }

        private void btnArmyDown_Click(object sender, EventArgs e) {
            int id = lstArmyList.SelectedIndex;
            if (id + 1 < lstArmyList.Items.Count && id >= 0) {
                object obj = lstArmyList.Items[id];
                lstArmyList.Items[id] = lstArmyList.Items[id + 1];
                lstArmyList.Items[id + 1] = obj;
                lstArmyList.SelectedIndex = id + 1;
            }
        }

        #endregion

        #region Campaign

        private void btnCampCreate_Click(object sender, EventArgs e) {
            SendMsg("47001", V.listcampid[cbbCamp.SelectedIndex].ToString(), "4:0;" + (radCamp1.Checked ? "2" : "3"));
        }

        private void btnCampAttack_Click(object sender, EventArgs e) {
            int cnum = Convert.ToInt32(r47008.currentnum);
            int mnum = Convert.ToInt32(r47008.minplayer);
            if (cnum >= mnum)
                SendMsg("47007");
        }

        private void btnCampMap_Click(object sender, EventArgs e) {
            KryptonButton bt = (KryptonButton) sender;
            string s = bt.Tag.ToString();
            SendMsg(bt.Text == "■" ? "47103" : "47102",
                s.Substring(s.IndexOf(".") + 1),
                s.Remove(s.IndexOf(".")),
                r47107.id);
        }

        private void btnCampInfo_Click(object sender, EventArgs e) {
            if (btnCampInfo.Text == "Tấn công") {
                cbbCamp.Enabled = false;
                btnCampInfo.Text = "Thoát";
                grpCampParty.Visible = true;
            } else {
                cbbCamp.Enabled = true;
                btnCampInfo.Text = "Tấn công";
                grpCampParty.Visible = false;
            }
        }

        private void btnCampTeam_Click(object sender, EventArgs e) {
            if (r47008.listmember.Count == 0) {
                KryptonContextMenuItem item = (KryptonContextMenuItem) sender;
                SendMsg("47002", item.Tag.ToString());
            }
        }

        private void btnCampInvite_Click(object sender, EventArgs e) {
            int cnum = Convert.ToInt32(r47008.currentnum);
            int mnum = Convert.ToInt32(r47008.maxnum);
            /*
            if (cnum > 0 && cnum < mnum)
                SendMsg("10103", r11102.playername,
                    "Tổ đội đánh " + r47008.name
                    + " đã được lập, còn " + (mnum - cnum).ToString() + " vị trí, hãy mau chóng đến "
                    + "<a href='event:campaignBattle|" + r47008.listmember[0].playerid
                    + "|" + (cbbCamp.SelectedIndex + 8).ToString()
                    + "|" + r47008.id
                    + "|" + r47008.id
                    + "'>[Gia nhập]</a>",
                    (cbbChat.SelectedIndex + 1).ToString(), " ");
                    */
        }

        private void btnCampQuitIn_Click(object sender, EventArgs e) {
            SendMsg("47106", r47107.id);
        }

        private void btnCampDisband_Click(object sender, EventArgs e) {
            SendMsg("47006");
        }

        private void btnCampQuit_Click(object sender, EventArgs e) {
            SendMsg("47005");
        }

        #endregion

        #endregion

        #region Nav

        private void btnPower_CheckedChanged(object sender, EventArgs e) {
            if (btnPower.Checked) {
                chksetNav.CheckedButton = null;
                navPower.Visible = true;
            } else {
                chksetNav.CheckedButton = (KryptonCheckButton) sender;
                navPower.Visible = false;
            }
        }

        private void btnWorkshop_CheckedChanged(object sender, EventArgs e) {
            if (btnWorkshop.Checked) {
                chksetNav.CheckedButton = null;
                navWorkshop.Visible = true;
                weaveok = true;
            } else {
                chksetNav.CheckedButton = (KryptonCheckButton) sender;
                navWorkshop.Visible = false;
            }
        }

        private void btnOthers_CheckedChanged(object sender, EventArgs e) {
            if (btnOthers.Checked) {
                chksetNav.CheckedButton = null;
                navOthers.Visible = true;
                navOthers_SelectedPageChanged(null, null);
            } else {
                chksetNav.CheckedButton = (KryptonCheckButton) sender;
                navOthers.Visible = false;
            }
        }
        
        private void btnShop_CheckedChanged(object sender, EventArgs e) {
            if (btnShop.Checked) {
                chksetNav.CheckedButton = null;
                navShop.Visible = true;
                navShop_SelectedPageChanged(null, null);
            } else {
                chksetNav.CheckedButton = (KryptonCheckButton) sender;
                navShop.Visible = false;
            }
        }

        private void btnMsg_CheckedChanged(object sender, EventArgs e) {
            if (btnMsg.Checked) {
                chksetNav.CheckedButton = null;
                navMsg.Visible = true;
            } else {
                chksetNav.CheckedButton = (KryptonCheckButton) sender;
                navMsg.Visible = false;
            }
        }

        #endregion

        #region Weave

        private void chkWeave_CheckedChanged(object sender, EventArgs e) {
            //weaveok = chkWeave.Checked;
        }

        private void btnWeaveTeam_Click(object sender, EventArgs e) {
            /*
            KryptonContextMenuItem item = (KryptonContextMenuItem) sender;
            if (r45300 == null
                || (r45300.type == "3"
                && item.Text.Contains(r11102.playername)))
                SendMsg("45209", item.Tag.ToString());
                */
        }

        private void btnWeaveCreate_Click(object sender, EventArgs e) {
            grpWeaveParty.Enabled = false;
            SendMsg("45201");
        }

        private void cbbShift_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void testButton_Click(object sender, EventArgs e) {
            // packetHandler.SendCommand("64007", "5561282", "232");
        }

        private void btnWeaveMake_Click(object sender, EventArgs e) {
            SendMsg("45208", r45300.teamid);
        }

        private void btnWeaveDisband_Click(object sender, EventArgs e) {
            SendMsg("45207", r45300.teamid);
        }

        private void btnWeaveInvite_Click(object sender, EventArgs e) {
            int cnum = Convert.ToInt32(r45300.num);
            int mnum = Convert.ToInt32(r45300.maxnum);
            /*
            if (cnum <= mnum)
                SendMsg("10103", r11102.playername,
                    "Tổ đội dệt vải cấp " + r45300.level
                    + " đã được lập "
                    + "<a href='event:textile|" + r45300.teamid
                    + "'>[Gia nhập]</a>",
                    (cbbChat.SelectedIndex + 1).ToString(), " ");
                    */
        }

        private void btnWeaveCreate1_Click(object sender, EventArgs e) {
            grpWeaveCreate.Visible = false;
            SendMsg("45202", (cbbWeaveProduct.Items.Count - cbbWeaveProduct.SelectedIndex).ToString(), "0", "2");
        }

        private void btnWeaveCreate2_Click(object sender, EventArgs e) {
            grpWeaveCreate.Visible = false;
            grpWeaveParty.Enabled = true;
        }

        private void lstWeaveMember_SelectedValueChanged(object sender, EventArgs e) {
            int index = lstWeaveMember.SelectedIndex;
            if (lstWeaveMember.Items.Count >= 1
                && r45300.leaderid == loginHelper.Session.UserId)
                SendMsg("45206", r45300.teamid, r45300.listmember[index].playerid);
        }

        private void cbbWeaveProduct_SelectedIndexChanged(object sender, EventArgs e) {
            int index = cbbWeaveProduct.SelectedIndex;
            if (index >= 0) {
                R45201.Product pr = r45201.listproduct[index];
                txtWeaveInfo8.Text = pr.succrate + " - " + pr.baojirate;
                txtWeaveInfo9.Text = pr.cost + " - " + pr.price;
            }
        }

        private void cbbWeaveWorker_SelectedIndexChanged(object sender, EventArgs e) {
            int index = cbbWeaveWorker.SelectedIndex;
            if (index >= 0) {
                R45201.Worker wk = r45201.listworker[index];
                txtWeaveExp.Text = wk.exp + "%";
                lblWeaveSkill1.Text = "";
                lblWeaveSkill2.Text = "";
                KryptonLabel[] lblskill =
                {
                    lblWeaveSkill1,
                    lblWeaveSkill2
                };
                int i = 0;
                string[] skill = wk.skill.Split('|');
                foreach (string s in skill)
                    if (s != "")
                        lblskill[i++].Text = s;
            }
        }

        private void btnWeaveQuit_Click(object sender, EventArgs e) {
            SendMsg("45210", r45300.teamid);
        }

        #endregion

        #region Others

        private void navOthers_SelectedPageChanged(object sender, EventArgs e) {
            SendMsg("14101");
        }

        #endregion

        #region Misc

        private void btnSave_Click(object sender, EventArgs e) {
            SaveConfig();
        }

        private void btnAuto_Click(object sender, EventArgs e) {
            if (btnAuto.Text == "Bắt đầu") {
                btnAuto.Text = "Dừng";
                btnArmyInfo.Enabled = false;
            } else {
                btnAuto.Text = "Bắt đầu";
                btnArmyInfo.Enabled = true;
            }
            chkArmy_CheckedChanged(null, null);
            chkWeave_CheckedChanged(null, null);
        }

        private void txtLogs_TextChanged(object sender, EventArgs e) {
            txtLogs.SelectionStart = txtLogs.TextLength;
            txtLogs.ScrollToCaret();
        }

        #endregion

        #region Forces

        private void btnForcesRecruit_Click(object sender, EventArgs e) {
            SendMsg("14102", numForcesRecruit.Value.ToString(), "0");
        }

        private void btnForcesFree_Click(object sender, EventArgs e) {
            SendMsg("14100");
        }

        #endregion

        #region Shop

        private void navShop_SelectedPageChanged(object sender, EventArgs e) {
            switch (navShop.SelectedIndex) {
            case 0:
                lastbagindex = 0;
                SendMsg("39100", "0", "60");
                break;
            case 1:
                cbbUpg1_SelectedIndexChanged(null, null);
                break;
            }
        }

        #region Bag

        private void cbbBag_SelectedIndexChanged(object sender, EventArgs e) {
            R39100.Item it = r39100.listitem[cbbBag.SelectedIndex];
            txtBagInfo1.Text = V.listattribute[Convert.ToInt32(it.type) - 1] + " +" + it.attribute;
            txtBagInfo2.Text = "+" + it.hp;
            txtBagInfo3.Text = it.equipstagename + " - " + it.equiplevel;
            txtBagInfo4.Text = "Tướng Lv." + it.lv;
            btnBagSell.Enabled = it.bindstatus == "0";
            btnBagBind.Text = V.listbindstatus[Convert.ToInt32(it.bindstatus)];
            lblBagBindCd.Visible = txtBagBindCd.Visible = it.bindstatus == "2";
            txtBagSell.Text = it.value + " Bạc";
            txtBagDegrade.Text = it.degradecoppercost;
            btnBagDegrade.Enabled = it.degradeable == "1" && it.bindstatus == "0";
        }

        private void btnBagBind_Click(object sender, EventArgs e) {
            switch (btnBagBind.Text) {
            case "Khoá":
                SendMsg("39306", r39100.listitem[cbbBag.SelectedIndex].id);
                break;
            case "Mở khoá":
                SendMsg("39307", r39100.listitem[cbbBag.SelectedIndex].id);
                break;
            case "Huỷ":
                SendMsg("39308", r39100.listitem[cbbBag.SelectedIndex].id);
                break;
            }
        }

        private void btnBagSell_Click(object sender, EventArgs e) {
            SendMsg("39101", r39100.listitem[cbbBag.SelectedIndex].id, "-1");
        }

        #endregion

        #region Upg

        private void cbbUpg1_SelectedIndexChanged(object sender, EventArgs e) {
            lastupgindex = 0;
            SendMsg("39301", V.attribredirect[cbbUpg1.SelectedIndex].ToString(), "0", "20");
        }

        private void cbbUpg2_SelectedIndexChanged(object sender, EventArgs e) {
            R39301.Item it = r39301.listitem[cbbUpg2.SelectedIndex];
            txtUpgInfo1.Text = V.listattribute[Convert.ToInt32(it.equiptype) - 1] + " +" + it.attribute;
            txtUpgInfo2.Text = "+" + it.hp;
            txtUpgInfo3.Text = it.equipstagename + " - " + it.equiplevel;
            txtUpgInfo4.Text = "Yêu cầu cấp " + it.equiplimitlv;
            //btnBagBind.Text = listbindstatus[Convert.ToInt32(it.bindstatus)];
            //lblBagBindCd.Visible = txtBagBindCd.Visible = it.bindstatus == "2";
            txtUpgUp.Text = it.coppercost + " Bạc";
            txtUpgDe.Text = it.degradecoppercost + " Bạc";
            btnUpgDe.Enabled = it.degradeable == "1" && it.bindstatus == "0";
        }

        private void btnUpgUp_Click(object sender, EventArgs e) {
            SendMsg("39302", r39301.listitem[cbbUpg2.SelectedIndex].storeid, "0", r39301.magic);
        }

        private void btnUpgDe_Click(object sender, EventArgs e) {
            SendMsg("39103", r39301.listitem[cbbUpg2.SelectedIndex].storeid, "0", r39301.magic);
        }

        private void btnBagDegrade_Click(object sender, EventArgs e) {
            SendMsg("39103", r39100.listitem[cbbBag.SelectedIndex].id, "0", "100");
        }

        #endregion



        #endregion

    }
}