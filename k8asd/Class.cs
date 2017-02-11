using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace k8asd {
        
    /*
    public class R11103 {
        public string caravanstate;
        public string contents;
        public string copper;
        public string extranongtian;
        public string extrayinkuang;
        public string extragongji;
        public string extrazhengzhan;
        public string extrazhengfu;
        public string food;
        public string forces;
        public string isimposelimit;
        public string jyungong;
        public string m;
        public string maxcoin;
        public string maxfood;
        public string maxforce;
        public string prestige;
        public string season;
        public string sys_gold;
        public string title;
        public string tokencdusable;
        public string tokencd;
        public string token;
        public string user_gold;
        public string year;

        public R11103(string json) {
            JToken token = JObject.Parse(json)["m"];
            if (token["CommandInfo"] != null) {
                JObject obj = (JObject) token["CommandInfo"]["MsgBox"];
                contents = obj["contents"].ToString().Replace("\"", "");
                title = obj["title"].ToString().Replace("\"", "");
            } else if (token["message"] == null) {
                JObject obj = (JObject) token["playerupdateinfo"];
                if (obj["tokencdusable"] != null)
                    tokencdusable = obj["tokencdusable"].ToString();
                if (obj["caravanstate"] != null)
                    caravanstate = obj["caravanstate"].ToString();
                if (obj["year"] != null) {
                    year = obj["year"].ToString();
                    season = obj["season"].ToString();
                }
                if (obj["isimposelimit"] != null)
                    isimposelimit = obj["isimposelimit"].ToString();
            } else
                m = token["message"].ToString().Replace("\"", "");
        }
    }
    */

    public class R11104 {
        public string message;

        public R11104(string json) {
            JToken token = JObject.Parse(json)["m"];
            if (token["message"] != null)
                message = token["message"].ToString().Replace("\"", "");
        }
    }

    public class R12200 {
        public class Main {
            public string buildlevel;
            public string buildname;
            public string cdtime;
            public string intro;
            public string nextcopper;
            public Main(string buildlevel, string buildname, string cdtime, string intro, string nextcopper) {
                this.buildlevel = buildlevel;
                this.buildname = buildname;
                this.cdtime = cdtime;
                this.intro = intro;
                this.nextcopper = nextcopper;
            }
        }

        public class Build {
            public string buildid;
            public string cd;
            public Build(string buildid, string cd) {
                this.buildid = buildid;
                this.cd = cd;
            }
        }

        public class Construct {
            public string buildcdusable;
            public string cid;
            public string ctime;
            public Construct(string buildcdusable, string cid, string ctime) {
                this.buildcdusable = buildcdusable;
                this.cid = cid;
                this.ctime = ctime;
            }
        }

        public Main[] listmain;
        public Build[] listbuild;
        public List<Construct> listconstruct;
        public string m;
        public string newplayerreward;
        public string maxforce;
        public string maxcoin;
        public string maxfood;
        public string rtotalcd;
        public string rightcd;

        public R12200(string json) {
            JToken token = JObject.Parse(json)["m"];
            if (token["message"] == null) {
                listmain = new Main[30];
                listbuild = new Build[30];
                listconstruct = new List<Construct>();

                if (token["rtotalcd"] != null) {
                    rtotalcd = token["rtotalcd"].ToString();
                    rightcd
                        = token["rightcd"].ToString();
                }

                JObject obj = (JObject) token["playerupdateinfo"];
                if (token["newplayerreward"] != null)
                    newplayerreward = token["newplayerreward"].ToString();

                JArray array = (JArray) token["buildcddto"];
                if (array != null)
                    for (int i = 0; i < array.Count; i++) {
                        obj = (JObject) array[i];
                        listbuild[Convert.ToInt32(obj["buildid"].ToString().Replace("\"", ""))] =
                            new Build(
                                obj["buildid"].ToString().Replace("\"", ""),
                                obj["cd"].ToString().Replace("\"", ""));
                    }

                array = (JArray) token["constructordto"];
                for (int i = 0; i < array.Count; i++) {
                    obj = (JObject) array[i];
                    listconstruct.Add(
                        new Construct(
                            obj["buildcdusable"].ToString(),
                            obj["cid"].ToString().Replace("\"", ""),
                            obj["ctime"].ToString().Replace("\"", "")));
                }

                array = (JArray) token["maincitydto"];
                for (int i = 0; i < array.Count; i++) {
                    obj = (JObject) array[i];
                    listmain[Convert.ToInt32(obj["buildid"].ToString())]
                        = new Main(
                            obj["buildlevel"].ToString(),
                            obj["buildname"].ToString().Replace("\"", ""),
                            obj["cdtime"].ToString(),
                            obj["intro"].ToString().Replace("\"", ""),
                            obj["nextcopper"].ToString());
                }
            } else
                m = token["message"].ToString().Replace("\"", "");
        }
    }

    public class R12300 {
        public string att;
        public string def;
        public string nowcopper;
        public string nowname;
        public string prestige;
        public string prestigetop;
        public string reduceprestige;
        public string nextatt;
        public string nextcopper;
        public string nextdef;
        public string nextfame;
        public string nextgeneral;
        public string nextid;
        public string nextname;
        public string nextrank;
        public string nextreduceprestige;
        public string cancont;
        public string contribejg_cd;
        public string disjungong;
        public string dispres;
        public string savesalary_cd;

        public R12300(string json) {
            JToken token = JObject.Parse(json)["m"];
            JObject obj = (JObject) token["officerdto"];
            att = obj["att"].ToString();
            def = obj["def"].ToString();
            nowcopper = obj["nowcopper"].ToString();
            nowname = obj["nowname"].ToString().Replace("\"", "");
            prestige = obj["prestige"].ToString();
            prestigetop = obj["prestigetop"].ToString();
            reduceprestige = obj["reduceprestige"].ToString();
            obj = (JObject) token["nextofficerdto"];
            nextatt = obj["nextatt"].ToString();
            nextcopper = obj["nextcopper"].ToString();
            nextdef = obj["nextdef"].ToString();
            nextfame = obj["nextfame"].ToString();
            nextgeneral = obj["nextgeneral"].ToString().Replace("\"", "");
            nextid = obj["nextid"].ToString();
            nextname = obj["nextname"].ToString().Replace("\"", "");
            nextrank = obj["nextrank"].ToString();
            nextreduceprestige = obj["reduceprestige"].ToString();
            obj = (JObject) token["officerstate"];
            cancont = obj["cancont"].ToString();
            contribejg_cd = obj["contribejg_cd"].ToString();
            disjungong = obj["disjungong"].ToString();
            dispres = obj["dispres"].ToString();
            savesalary_cd = obj["savesalary_cd"].ToString();
        }
    }

    public class R12302 {
        public string m;
        public string cd;

        public R12302(string json) {
            JToken token = JObject.Parse(json)["m"];
            if (token["message"] == null)
                cd = token["cd"].ToString();
            else
                m = token["message"].ToString().Replace("\"", "");
        }
    }

    public class R12400 {
        public string areaprosper;
        public string copper;
        public string countinglv;
        public string forceimposecost;
        public string gold;
        public string houseslv;
        public string imposecdusable;
        public string imposemaxnum;
        public string imposenum;
        public string lastimposetime;
        public string legionimposetech;
        public string loyalty;
        public string moneyfactorylv;
        public string occupancy;
        public string officelv;

        public R12400(string json) {
            JToken token = JObject.Parse(json)["m"];
            JObject obj = (JObject) token["imposedto"];
            officelv = obj["officelv"].ToString();
            legionimposetech = obj["legionimposetech"].ToString();
            houseslv = obj["houseslv"].ToString();
            copper = obj["copper"].ToString();
            areaprosper = obj["areaprosper"].ToString();
            countinglv = obj["countinglv"].ToString();
            imposenum = obj["imposenum"].ToString();
            imposemaxnum = obj["imposemaxnum"].ToString();
            moneyfactorylv = obj["moneyfactorylv"].ToString();
            forceimposecost = obj["forceimposecost"].ToString();
            loyalty = obj["loyalty"].ToString();
            gold = obj["gold"].ToString();
            imposecdusable = obj["imposecdusable"].ToString();
            occupancy = obj["occupancy"].ToString();
            lastimposetime = obj["lastimposetime"].ToString();
        }
    }

    public class R12401 {
        public string m;
        public string copper;
        public string cooperdis;
        public string cost;
        public string golddis;
        public string imposecd;
        public string imposecdusable;
        public string imposenum;
        public string loyalty;
        public string optdisc1;
        public string optdisc2;
        public string disc;
        public string name;

        public R12401(string json) {
            JToken token = JObject.Parse(json)["m"];
            if (token["message"] == null) {
                golddis = token["golddis"].ToString();
                cooperdis = token["cooperdis"].ToString();
                imposenum = token["imposenum"].ToString();
                copper = token["copper"].ToString();
                loyalty = token["loyalty"].ToString();
                imposecdusable = token["imposecdusable"].ToString();
                imposecd = token["imposecd"].ToString();
                cost = token["cost"].ToString();
                if (token["larrydto"] != null) {
                    JObject obj = (JObject) token["larrydto"];
                    optdisc1 = obj["optdisc1"].ToString().Replace("\"", "");
                    optdisc2 = obj["optdisc2"].ToString().Replace("\"", "");
                    disc = obj["disc"].ToString().Replace("\"", "");
                    name = obj["name"].ToString().Replace("\"", "");
                }
            } else
                m = token["message"].ToString().Replace("\"", "");
        }
    }

    public class R12406 {
        public string m;
        public string c;
        public string cnum;
        public string cooperdis;
        public string f;
        public string g;
        public string imposecdusable;
        public string l;
        public string lnum;
        public string s;
        public string t;
        public string tnum;

        public R12406(string json) {
            JToken token = JObject.Parse(json)["m"];
            if (token["message"] == null) {
                JObject obj = (JObject) token["ledto"];
                cooperdis = obj["cooperdis"].ToString();
                f = obj["f"].ToString();
                s = obj["s"].ToString();
                l = obj["l"].ToString();
                c = obj["c"].ToString();
                g = obj["g"].ToString();
                t = obj["t"].ToString();
                imposecdusable = obj["imposecdusable"].ToString();
                if (l != "0")
                    lnum = obj["lnum"].ToString();
                if (t != "0")
                    tnum = obj["tnum"].ToString();
                if (c != "0")
                    cnum = obj["cnum"].ToString();
            } else
                m = token["message"].ToString().Replace("\"", "").Trim();
        }
    }

    public class R13100 {
        public string isup;
        public string price;
        public string maxtrade;
        public string crutrade;

        public R13100(string json) {
            JToken token = JObject.Parse(json)["m"];
            isup = token["isup"].ToString();
            price = token["price"].ToString();
            maxtrade = token["maxtrade"].ToString();
            crutrade = token["crutrade"].ToString();
        }
    }

    public class R13101 {
        public string m;
        public string cde;

        public R13101(string json) {
            JToken token = JObject.Parse(json)["m"];
            if (token["message"] == null)
                cde = token["cde"].ToString();
            else
                m = token["message"].ToString().Replace("\"", "");
        }
    }

    public class R14101 {
        public string forcemax;
        public string recruits;

        public R14101(string json) {
            JToken token = JObject.Parse(json)["m"];
            forcemax = token["forcemax"].ToString();
            recruits = token["recruits"].ToString();
        }
    }

    public class R14103 {
        public class Vassal {
            public string areaname;
            public string coppers;
            public string flag;
            public string lastupdatetime;
            public string legionname;
            public string playerid;
            public string officername;
            public string playerlevel;
            public string playername;
            public string scope;
            public string skin;
            public Vassal(string areaname, string coppers,
                string flag, string lastupdatetime,
                string legionname, string officername,
                string playerid, string playerlevel,
                string playername, string scope,
                string skin) {
                this.areaname = areaname;
                this.coppers = coppers;
                this.flag = flag;
                this.lastupdatetime = lastupdatetime;
                this.legionname = legionname;
                this.officername = officername;
                this.playerid = playerid;
                this.playerlevel = playerlevel;
                this.playername = playername;
                this.scope = scope;
                this.skin = skin;
            }
        }

        public List<Vassal> listvassal;
        public string maxvassalnum;

        public R14103(string json) {
            listvassal = new List<Vassal>();
            JToken token = JObject.Parse(json)["m"];
            maxvassalnum = token["maxvassalnum"].ToString();
            JArray array = (JArray) token["vassal"];
            for (int i = 0; i < array.Count; i++) {
                JObject obj = (JObject) array[i];
                listvassal.Add(
                    new Vassal(
                        obj["areaname"].ToString().Replace("\"", ""),
                        obj["coppers"].ToString(),
                        obj["flag"].ToString(),
                        obj["lastupdatetime"].ToString().Replace("\"", ""),
                        obj["legionname"].ToString().Replace("\"", ""),
                        obj["officername"].ToString().Replace("\"", ""),
                        obj["playerid"].ToString(),
                        obj["playerlevel"].ToString(),
                        obj["playername"].ToString().Replace("\"", ""),
                        obj["scope"].ToString(),
                        obj["skin"].ToString()));
            }
        }
    }

    public class R32101 {
        public class Member {
            public string allcontribute;
            public string areaname;
            public string color;
            public string contribute;
            public string flag;
            public string lastLoginTime;
            public string legionname;
            public string message;
            public string officername;
            public string playerid;
            public string playerlv;
            public string playername;
            public string position;
            public string prestige;
            public string scope;
            public string skin;
            public string top;
            public string unlogindday;
            public Member(string allcontribute, string areaname,
                string color, string contribute,
                string flag, string lastLoginTime,
                string legionname, string message,
                string officername, string playerid,
                string playerlv, string playername,
                string position, string prestige,
                string scope, string skin,
                string top, string unlogindday) {
                this.allcontribute = allcontribute;
                this.areaname = areaname;
                this.color = color;
                this.contribute = contribute;
                this.flag = flag;
                this.lastLoginTime = lastLoginTime;
                this.legionname = legionname;
                this.message = message;
                this.officername = officername;
                this.playerid = playerid;
                this.playerlv = playerlv;
                this.playername = playername;
                this.position = position;
                this.prestige = prestige;
                this.scope = scope;
                this.skin = skin;
                this.top = top;
                this.unlogindday = unlogindday;
            }
        }

        public List<Member> lstmember;
        public Member self;

        public R32101(string json) {
            lstmember = new List<Member>();
            JToken token = JObject.Parse(json)["m"];
            JObject obj = (JObject) token["self"];
            self = new Member(
                obj["allcontribute"].ToString(),
                obj["areaname"].ToString(),
                obj["color"].ToString(),
                obj["contribute"].ToString(),
                obj["flag"].ToString(),
                obj["lastLoginTime"].ToString(),
                obj["legionname"].ToString(),
                obj["message"].ToString(),
                obj["officername"].ToString(),
                obj["playerid"].ToString(),
                obj["playerlv"].ToString(),
                obj["playername"].ToString(),
                obj["position"].ToString(),
                obj["prestige"].ToString(),
                obj["scope"].ToString(),
                obj["skin"].ToString(),
                obj["top"].ToString(),
                obj["unlogindday"].ToString());
            //JArray array = (JArray)token["legion_memberdto"];
        }
    }

    public class R32121 {
        public string nextupgold;
        public string qfz;
        public string badgelv;
        public string createdate;
        public string creater;
        public string yz;
        public string nation;
        public string message;
        public string bfz;
        public string maxnum;
        public string legionlv;
        public string jtz;
        public string dj;
        public string legionname;
        public string nextuplimit;
        public string badge;
        public string memnum;
        public string cd;
        public string m;

        public R32121(string json) {
            JToken token = JObject.Parse(json)["m"];
            if (token["message"] == null) {
                nextupgold = token["nextupgold"].ToString();
                qfz = token["qfz"].ToString().Replace("\"", "").Replace("，", ", ");
                badgelv = token["badgelv"].ToString();
                createdate = token["createdate"].ToString().Replace("\"", "");
                creater = token["creater"].ToString().Replace("\"", "");
                yz = token["yz"].ToString().Replace("\"", "").Replace("，", ", ");
                nation = token["nation"].ToString();
                message = token["message"].ToString().Replace("\"", "").Replace("\\r", "<br/>");
                bfz = token["bfz"].ToString().Replace("\"", "").Replace("，", ", ");
                maxnum = token["maxnum"].ToString();
                legionlv = token["legionlv"].ToString();
                jtz = token["jtz"].ToString().Replace("\"", "");
                dj = token["dj"].ToString().Replace("\"", "").Replace("，", ", ");
                legionname = token["legionname"].ToString().Replace("\"", "");
                nextuplimit = token["nextuplimit"].ToString();
                badge = token["badge"].ToString();
                memnum = token["memnum"].ToString();
                cd = token["cd"].ToString();
            } else
                m = token["message"].ToString().Replace("\"", "");
        }
    }

    public class R33101 : SReport {
        public string items;

        public R33101(string json)
            : base(json) {
            if (m == null) {
                items = "";
                JToken token = JObject.Parse(json)["m"];
                JArray array = (JArray) token["items"];
                for (int i = 0; i < array.Count; i += 2)
                    items += " " + array[i].ToString().Replace("\"", "");
            }
        }
    }

    public class Report {
        public string sys_gold;
        public string extrayinkuang;
        public string forces;
        public string extragongji;
        public string extrazhengzhan;
        public string extrazhengfu;
        public string tokencdusable;
        public string user_gold;
        public string token;
        public string extranongtian;
        public string jyungong;
        public string tokencd;
        public string m;

        public Report(string json) {
            JToken token = JObject.Parse(json)["m"];
            if (token["message"] == null) {
                JObject obj = (JObject) token["playerbattleinfo"];
                sys_gold = obj["sys_gold"].ToString();
                extrayinkuang = obj["extrayinkuang"].ToString();
                forces = obj["forces"].ToString();
                extragongji = obj["extragongji"].ToString();
                extrazhengzhan = obj["extrazhengzhan"].ToString();
                extrazhengfu = obj["extrazhengfu"].ToString();
                tokencdusable = obj["tokencdusable"].ToString();
                user_gold = obj["user_gold"].ToString();
                this.token = obj["token"].ToString();
                extranongtian = obj["extranongtian"].ToString();
                jyungong = obj["jyungong"].ToString();
                tokencd = obj["tokencd"].ToString();
            } else
                m = token["message"].ToString().Replace("\"", "");
        }
    }

    public class SReport : Report {
        public string fround;
        public string id;
        public string message;
        public string winp;
        public string winside;

        public SReport(string json)
            : base(json) {
            if (m == null) {
                JObject obj = (JObject) JObject.Parse(json)["m"]["battlereport"];
                fround = obj["fround"].ToString().Replace("\"", "");
                id = obj["id"].ToString().Replace("\"", "");
                message = obj["message"].ToString().Replace("\"", "");
                winp = obj["winp"].ToString().Replace("\"", "");
                winside = obj["winside"].ToString().Replace("\"", "");
            }
        }
    }
    
    public class R34108 : Report {
        public string gains;

        public R34108(string json)
            : base(json) {
            if (m == null) {
                JToken token = JObject.Parse(json)["m"];
                JObject obj = (JObject) token["battlereport"]["report"];
                gains = obj["gains"].ToString().Replace("\"", "");
            }
        }
    }

    public class R39100 {
        public class Item {
            public string attribute;
            public string bindTime;
            public string bindstatus;
            public string canBinding;
            public string chip;
            public string degradeable;
            public string degradecoppercost;
            public string equiplevel;
            public string equiplv;
            public string equipstagename;
            public string equiptype;
            public string fnum;
            public string formal;
            public string goodsid;
            public string goodsnum;
            public string hp;
            public string id;
            public string intro;
            public string lv;
            public string maxnum;
            public string name;
            public string quality;
            public string remaintime;
            public string type;
            public string usable;
            public string value;

            public Item(string attribute, string bindTime, string bindstatus,
                string canBinding, string chip, string degradeable, string degradecoppercost,
                string equiplevel, string equiplv, string equipstagename, string equiptype, string fnum,
                string formal, string goodsid, string goodsnum, string hp, string id, string intro, string lv, string maxnum,
                string name, string quality, string remaintime, string type, string usable, string value) {
                this.attribute = attribute;
                this.bindTime = bindTime;
                this.bindstatus = bindstatus;
                this.canBinding = canBinding;
                this.attribute = attribute;
                this.degradeable = degradeable;
                this.degradecoppercost = degradecoppercost;
                this.equiplevel = equiplevel;
                this.equiplv = equiplv;
                this.equipstagename = equipstagename;
                this.equiptype = equiptype;
                this.fnum = fnum;
                this.formal = formal;
                this.goodsid = goodsid;
                this.goodsnum = goodsnum;
                this.hp = hp;
                this.id = id;
                this.intro = intro;
                this.lv = lv;
                this.name = name;
                this.maxnum = maxnum;
                this.quality = quality;
                this.remaintime = remaintime;
                this.type = type;
                this.usable = usable;
                this.value = value;
            }
        }

        public List<Item> listitem;
        public string storesize;
        public string numCount;
        public string usesize;
        public string cost;

        public R39100(string json) {
            listitem = new List<Item>();

            JToken token = JObject.Parse(json)["m"];
            storesize = token["storesize"].ToString();
            numCount = token["numCount"].ToString();
            usesize = token["usesize"].ToString();
            cost = token["cost"].ToString();

            JArray array = (JArray) token["storehousedto"];
            for (int i = 0; i < array.Count; i++) {
                JObject obj = (JObject) array[i];
                listitem.Add(
                    new Item(
                        obj["attribute"].ToString(),
                        obj["bindTime"].ToString(),
                        obj["bindstatus"].ToString(),
                        obj["canBinding"].ToString(),
                        obj["chip"].ToString(),
                        obj["degradeable"].ToString(),
                        obj["degradecoppercost"].ToString(),
                        obj["equiplevel"].ToString(),
                        obj["equiplv"].ToString(),
                        obj["equipstagename"].ToString().Replace("\"", ""),
                        obj["equiptype"].ToString(),
                        obj["fnum"].ToString(),
                        obj["formal"].ToString(),
                        obj["goodsid"].ToString(),
                        obj["goodsnum"].ToString(),
                        obj["hp"].ToString(),
                        obj["id"].ToString(),
                        obj["intro"].ToString().Replace("\"", ""),
                        obj["lv"].ToString(),
                        obj["maxnum"].ToString(),
                        obj["name"].ToString().Replace("\"", ""),
                        obj["quality"].ToString(),
                        obj["remaintime"].ToString(),
                        obj["type"].ToString(),
                        obj["usable"].ToString(),
                        obj["value"].ToString()));
            }
        }
    }

    public class R39301 : Upgrade {
        public class Item {
            public string attribute;
            public string bindstatus;
            public string category;
            public string cbtime;
            public string chip;
            public string coppercost;
            public string degradeable;
            public string degradecoppercost;
            public string equipintro;
            public string equiplevel;
            public string equiplimitlv;
            public string equipname;
            public string equipstagename;
            public string equiptype;
            public string feedExp;
            public string generalname;
            public string hp;
            public string newRefine;
            public string quality;
            public string refine;
            public string regressSparNum;
            public string rewardType;
            public string splitValue;
            public string storeid;
            public string totalChip;
            public string upgradeable;

            public Item(string attribute, string bindstatus,
                string category, string cbtime, string chip, string coppercost, string degradeable,
                string degradecoppercost, string equipintro, string equiplevel,
                string equiplimitlv, string equipname, string equipstagename, string equiptype,
                string feedExp, string generalname, string hp, string newRefine, string quality,
                string refine, string regressSparNum, string rewardType, string splitValue,
                string storeid, string totalChip, string upgradeable) {
                this.attribute = attribute;
                this.bindstatus = bindstatus;
                this.category = category;
                this.cbtime = cbtime;
                this.chip = chip;
                this.coppercost = coppercost;
                this.degradeable = degradeable;
                this.degradecoppercost = degradecoppercost;
                this.equipintro = equipintro;
                this.equiplevel = equiplevel;
                this.equiplimitlv = equiplimitlv;
                this.equipname = equipname;
                this.equipstagename = equipstagename;
                this.equiptype = equiptype;
                this.feedExp = feedExp;
                this.generalname = generalname;
                this.hp = hp;
                this.newRefine = newRefine;
                this.quality = quality;
                this.refine = refine;
                this.regressSparNum = regressSparNum;
                this.rewardType = rewardType;
                this.splitValue = splitValue;
                this.storeid = storeid;
                this.totalChip = totalChip;
                this.upgradeable = upgradeable;
            }
        }

        public List<Item> listitem;

        public string numCount;

        public R39301(string json)
            : base(json) {
            listitem = new List<Item>();

            JToken token = JObject.Parse(json)["m"];
            numCount = token["numCount"].ToString();

            JArray array = (JArray) token["equip"];
            for (int i = 0; i < array.Count; i++) {
                JObject obj = (JObject) array[i];
                listitem.Add(
                    new Item(
                        obj["attribute"].ToString(),
                        obj["bindstatus"].ToString(),
                        obj["category"].ToString(),
                        obj["cbtime"].ToString(),
                        obj["chip"].ToString(),
                        obj["coppercost"].ToString(),
                        obj["degradeable"].ToString(),
                        obj["degradecoppercost"].ToString(),
                        obj["equipintro"].ToString().Replace("\"", ""),
                        obj["equiplevel"].ToString(),
                        obj["equiplimitlv"].ToString(),
                        obj["equipname"].ToString().Replace("\"", ""),
                        obj["equipstagename"].ToString().Replace("\"", ""),
                        obj["equiptype"].ToString(),
                        obj["feedExp"].ToString(),
                        obj["generalname"].ToString().Replace("\"", ""),
                        obj["hp"].ToString(),
                        obj["newRefine"].ToString(),
                        obj["quality"].ToString(),
                        obj["refine"].ToString(),
                        obj["regressSparNum"].ToString(),
                        obj["rewardType"].ToString(),
                        obj["splitValue"].ToString(),
                        obj["storeid"].ToString(),
                        obj["totalChip"].ToString(),
                        obj["upgradeable"].ToString()));
            }
        }
    }

    public class Upgrade {
        public string canusegold;
        public string magic;
        public string magicstate;
        public string upgradecdusable;
        public string cd;
        public string m;

        public Upgrade(string json) {
            JToken token = JObject.Parse(json)["m"];
            if (JObject.Parse(json)["r"].ToString() == "0") {
                canusegold = token["canusegold"].ToString();
                magic = token["magic"].ToString();
                magicstate = token["magicstate"].ToString();
                upgradecdusable = token["upgradecdusable"].ToString();
                cd = token["cd"].ToString();
            } else
                m = token["message"].ToString().Replace("\"", "");
        }
    }

    public class R39302 : Upgrade {
        public string message;
        public string flag;
        public string replaySilver;

        public R39302(string json)
            : base(json) {
            if (m == null) {
                JToken token = JObject.Parse(json)["m"];
                if (token["message"] != null)
                    message = token["message"].ToString().Replace("\"", "");
                if (token["replaySilver"] != null)
                    message = token["replaySilver"].ToString();
                flag = token["flag"].ToString();
            }
        }
    }

    public class R40101 {
        public class Merchant {
            public string cost;
            public string merchantid;
            public string merchantname;
            public Merchant(string cost, string merchantid, string merchantname) {
                this.cost = cost;
                this.merchantid = merchantid;
                this.merchantname = merchantname;
            }
        }

        public List<Merchant> listmerchant;

        public string first;
        public string appointcdusable;
        public string cd;

        public R40101(string json) {
            JToken token = JObject.Parse(json)["m"];
            listmerchant = new List<Merchant>();
            first = token["first"].ToString();
            appointcdusable = token["appointcdusable"].ToString();
            cd = token["cd"].ToString();
            JArray array = (JArray) token["merchant"];
            for (int i = 0; i < array.Count; i++) {
                JObject obj = (JObject) array[i];
                listmerchant.Add(
                    new Merchant(
                        obj["cost"].ToString(),
                        obj["merchantid"].ToString(),
                        obj["merchantname"].ToString().Replace("\"", "")));
            }
        }
    }

    public class R40102 {
        public string merchandisename;
        public string merchandisequality;
        public string storeId;
        public string m;

        public R40102(string json) {
            JToken token = JObject.Parse(json)["m"];
            if (token["message"] == null) {
                storeId = token["storeId"].ToString();
                JObject obj = (JObject) token["merchandise"];
                merchandisename = obj["merchandisename"].ToString().Replace("\"", "");
                merchandisequality = obj["merchandisequality"].ToString();
            } else
                m = token["message"].ToString().Replace("\"", "");
        }
    }

    /*
    public class R41100 : R41107 {
        public R41100(string json)
            : base(json) {
            if (m == null) {
                JToken token = JObject.Parse(json)["m"];
                listgeneral = new List<General>();
                listtime = new List<Time>();
                guidecdusable = token["guidecdusable"].ToString();
                cd = token["cd"].ToString();
            }
        }
    }
    */

    /*
    public class R41107 {
        public R41107(string json) {
            JToken token = JObject.Parse(json)["m"];
            if (token["message"] == null) {
                JObject obj = (JObject) token["generaldto"];
                coppercost = obj["coppercost"].ToString();
                gmId = obj["gmId"].ToString();
                intro = obj["intro"].ToString();
                modelTong = obj["modelTong"].ToString();
                modelYong = obj["modelYong"].ToString();
                modelZhi = obj["modelZhi"].ToString();
                pic = obj["pic"].ToString();
                skillintro = obj["skillintro"].ToString();
                troopintro = obj["troopintro"].ToString();
                trooptypename = obj["trooptypename"].ToString();
            } else
                m = token["message"].ToString().Replace("\"", "");
        }
    }
    */

        /*
    public class R41300 : R41302 {
        public class General {
            public string generalname;
            public string generalid;
            public string generallevel;
            public General(string generalname, string generalid, string generallevel) {
                this.generalname = generalname;
                this.generalid = generalid;
                this.generallevel = generallevel;
            }
        }

        public class Model {
            public string name;
            public string cost;
            public Model(string name, string cost) {
                this.name = name;
                this.cost = cost;
            }
        }

        public List<General> listgeneral;
        public List<Model> listmodel;

        public R41300(string json)
            : base(json) {
            listgeneral = new List<General>();
            listmodel = new List<Model>();
            JToken token = JObject.Parse(json)["m"];
            JArray array = (JArray) token["refreshmodel"];
            for (int i = 0; i < array.Count; i++) {
                JObject obj = (JObject) array[i];
                listmodel.Add(
                    new Model(
                        obj["name"].ToString().Replace("\"", ""),
                        obj["cost"].ToString().Replace("\"", "")));
            }
            array = (JArray) token["general"];
            for (int i = 0; i < array.Count - 1; i++) {
                JObject obj = (JObject) array[i];
                listgeneral.Add(
                    new General(
                        obj["generalname"].ToString().Replace("\"", "").Trim(),
                        obj["generalid"].ToString(),
                        obj["generallevel"].ToString()));
            }
        }
    }
    */

    /*
    public class R41301 : R11103 {
        public string plusleader;
        public string plusforces;
        public string plusintelligence;

        public R41301(string json)
            : base(json) {
            if (m == null) {
                JToken token = JObject.Parse(json)["m"];
                JObject obj = (JObject) token["general"];
                plusleader = obj["plusleader"].ToString();
                plusforces = obj["plusforces"].ToString();
                plusintelligence = obj["plusintelligence"].ToString();
            }
        }
    }
    */

        /*
    public class R41302 : R41107 {
        public class Att {
            public string plusleader;
            public string plusforces;
            public string plusintelligence;
            public Att(string plusleader,
                string plusforces, string plusintelligence) {
                this.plusleader = plusleader;
                this.plusforces = plusforces;
                this.plusintelligence = plusintelligence;
            }
        }

        public Att newattr;
        public Att originalattr;
        public string refreshable;
        public string baseforces;
        public string baseleader;
        public string baseintelligence;

        public R41302(string json)
            : base(json) {
            JToken token = JObject.Parse(json)["m"];
            refreshable = token["refreshable"].ToString();
            JObject obj = null;
            try {
                JArray array = (JArray) token["general"];
                obj = (JObject) array[array.Count - 1];
            } catch {
                obj = (JObject) token["general"];
            }
            baseleader = obj["baseleader"].ToString();
            baseforces = obj["baseforces"].ToString();
            baseintelligence = obj["baseintelligence"].ToString();
            JObject obj2 = (JObject) obj["newattr"];
            newattr = new Att(obj2["plusleader"].ToString(),
                obj2["plusforces"].ToString(),
                obj2["plusintelligence"].ToString());
            obj2 = (JObject) obj["originalattr"];
            originalattr = new Att(obj2["plusleader"].ToString(),
                  obj2["plusforces"].ToString(),
                  obj2["plusintelligence"].ToString());
        }
    }
    */

    public class R45200 {
        public class Info {
            public string num;
            public string price;
            public string maxnum;
            public string succrate;
            public string gold;
            public string totallevel;
            public string baojirate;
            public string priceway;
            public Info(string num, string price,
                string maxnum, string succrate,
                string gold, string totallevel,
                string baojirate, string priceway) {
                this.num = num;
                this.price = price;
                this.maxnum = maxnum;
                this.succrate = succrate;
                this.gold = gold;
                this.totallevel = totallevel;
                this.baojirate = baojirate;
                this.priceway = priceway;
            }
        }

        public class Team {
            public string baojirate;
            public string cost;
            public string desc;
            public string legion;
            public string level;
            public string limit;
            public string limitlv;
            public string maxnum;
            public string mnation;
            public string nation;
            public string num;
            public string price;
            public string product;
            public string succrate;
            public string teamid;
            public string teamname;
            public Team(string baojirate, string cost,
                string desc, string legion,
                string level, string limit,
                string limitlv, string maxnum,
                string mnation, string nation,
                string num, string price,
                string product, string succrate,
                string teamid, string teamname) {
                this.baojirate = baojirate;
                this.cost = cost;
                this.desc = desc;
                this.legion = legion;
                this.level = level;
                this.limit = limit;
                this.limitlv = limitlv;
                this.maxnum = maxnum;
                this.mnation = mnation;
                this.nation = nation;
                this.num = num;
                this.price = price;
                this.product = product;
                this.succrate = succrate;
                this.teamid = teamid;
                this.teamname = teamname;
            }
        }

        public Info info;
        public List<Team> listteam;
        public string merchants;
        public string makecd;
        public string protectedcd;

        public R45200(string json) {
            listteam = new List<Team>();
            JToken token = JObject.Parse(json)["m"];
            merchants = token["merchants"].ToString();
            makecd = token["makecd"].ToString();
            protectedcd = token["protectedcd"].ToString();
            JObject obj = (JObject) token["baseinfo"];
            info = new Info(
                obj["num"].ToString(),
                obj["price"].ToString(),
                obj["maxnum"].ToString(),
                obj["succrate"].ToString(),
                obj["gold"].ToString(),
                obj["totallevel"].ToString(),
                obj["baojirate"].ToString(),
                obj["priceway"].ToString());
            JArray array = (JArray) token["teamList"];
            for (int i = 0; i < array.Count; i++) {
                obj = (JObject) array[i];
                listteam.Add(new Team(
                    obj["baojirate"].ToString().Replace("\"", ""),
                    obj["cost"].ToString(),
                    obj["desc"].ToString().Replace("\"", ""),
                    obj["legion"].ToString(),
                    obj["level"].ToString(),
                    obj["limit"].ToString(),
                    obj["limitlv"].ToString(),
                    obj["maxnum"].ToString(),
                    obj["mnation"].ToString(),
                    obj["nation"].ToString(),
                    obj["num"].ToString(),
                    obj["price"].ToString(),
                    obj["product"].ToString().Replace("\"", ""),
                    obj["succrate"].ToString().Replace("\"", ""),
                    obj["teamid"].ToString(),
                    obj["teamname"].ToString().Replace("\"", "")));
            }
        }
    }

    public class R45201 {
        public class Product {
            public string baojirate;
            public string cost;
            public string desc;
            public string level;
            public string name;
            public string price;
            public string prodid;
            public string succrate;
            public Product(string baojirate, string cost,
                string desc, string level,
                string name, string price,
                string prodid, string succrate) {
                this.baojirate = baojirate;
                this.cost = cost;
                this.desc = desc;
                this.level = level;
                this.name = name;
                this.price = price;
                this.prodid = prodid;
                this.succrate = succrate;
            }
        }

        public class Worker {
            public string exp;
            public string level;
            public string name;
            public string skill;
            public string workid;
            public Worker(string exp,
                string level, string name,
                string skill, string workid) {
                this.exp = exp;
                this.level = level;
                this.name = name;
                this.skill = skill;
                this.workid = workid;
            }
        }

        public List<Product> listproduct;
        public List<Worker> listworker;
        public string m;
        public string merchants;

        public R45201(string json) {
            JToken token = JObject.Parse(json)["m"];
            if (token["message"] == null) {
                listproduct = new List<Product>();
                listworker = new List<Worker>();
                merchants = token["merchants"].ToString();
                JArray array = (JArray) token["productlist"];
                for (int i = array.Count - 1; i >= 0; i--) {
                    JObject obj = (JObject) array[i];
                    listproduct.Add(new Product(
                        obj["baojirate"].ToString().Replace("\"", ""),
                        obj["cost"].ToString(),
                        obj["desc"].ToString().Replace("\"", ""),
                        obj["level"].ToString(),
                        obj["name"].ToString().Replace("\"", ""),
                        obj["price"].ToString(),
                        obj["prodid"].ToString(),
                        obj["succrate"].ToString().Replace("\"", "")));
                }
                array = (JArray) token["workerlist"];
                for (int i = 0; i < array.Count; i++) {
                    JObject obj = (JObject) array[i];
                    listworker.Add(new Worker(
                        obj["exp"].ToString(),
                        obj["level"].ToString(),
                        obj["name"].ToString().Replace("\"", ""),
                        obj["skill"].ToString().Replace("\"", ""),
                        obj["workid"].ToString().Replace("\"", "")));
                }
            } else
                m = token["message"].ToString().Replace("\"", "");
        }
    }

    public class R45300 {
        public class Member {
            public string level;
            public string name;
            public string playerid;
            public string price;
            public string spinnerTotalLevel;
            public Member(string level,
                string name, string playerid,
                string price, string spinnerTotalLevel) {
                this.level = level;
                this.name = name;
                this.playerid = playerid;
                this.price = price;
                this.spinnerTotalLevel = spinnerTotalLevel;
            }
        }

        public List<Member> listmember;
        public string baojirate;
        public string cost;
        public string desc;
        public string leaderid;
        public string level;
        public string limit;
        public string maxnum;
        public string num;
        public string price;
        public string product;
        public string succrate;
        public string teamid;
        public string teamname;
        public string type;
        public string makecd;
        public string msg;

        public R45300(string json) {
            JToken token = JObject.Parse(json)["m"];
            type = token["type"].ToString();
            if (type == "2" || type == "3") {
                listmember = new List<Member>();
                JObject obj = (JObject) token["teamObject"];
                if (obj == null)
                    return;
                baojirate = obj["baojirate"].ToString().Replace("\"", "");
                cost = obj["cost"].ToString();
                desc = obj["desc"].ToString().Replace("\"", "");
                leaderid = obj["leaderid"].ToString();
                level = obj["level"].ToString();
                limit = obj["limit"].ToString();
                maxnum = obj["maxnum"].ToString();
                num = obj["num"].ToString();
                price = obj["price"].ToString();
                product = obj["product"].ToString().Replace("\"", "");
                succrate = obj["succrate"].ToString().Replace("\"", "");
                teamid = obj["teamid"].ToString();
                teamname = obj["teamname"].ToString().Replace("\"", "");
                JArray array = (JArray) obj["memberlist"];
                for (int i = 0; i < array.Count; i++) {
                    obj = (JObject) array[i];
                    listmember.Add(new Member(
                        obj["level"].ToString(),
                        obj["name"].ToString().Replace("\"", ""),
                        obj["playerid"].ToString(),
                        obj["price"].ToString(),
                        obj["spinnerTotalLevel"].ToString()));
                }
            } else if (type == "0") {
                makecd = token["makecd"].ToString();
                msg = token["msg"].ToString().Replace("\"", "");
            }
        }
    }

    public class R47100 {
        public class Reward {
            public string award;
            public string image;
            public string name;
            public string quality;
            public string rewardType;
            public string stuffId;

            public Reward(string award, string image,
                string name, string quality,
                string rewardType, string stuffId) {
                this.award = award;
                this.image = image;
                this.name = name;
                this.quality = quality;
                this.rewardType = rewardType;
                this.stuffId = stuffId;
            }
        }

        public List<Reward> listreward;

        public R47100(string json) {
            JToken token = JObject.Parse(json)["m"];
            listreward = new List<Reward>();
            JObject obj = (JObject) token["reward"];
            JArray array = (JArray) obj["totalItemList"];
            for (int i = 0; i < array.Count; i++) {
                obj = (JObject) array[i];
                listreward.Add(
                    new Reward(
                        obj["award"].ToString(),
                        obj["image"].ToString().Replace("\"", ""),
                        obj["name"].ToString().Replace("\"", ""),
                        obj["quality"].ToString(),
                        obj["rewardType"].ToString().Replace("\"", ""),
                        obj["stuffId"].ToString()));
            }
        }
    }

    public class R47107 {
        public class Solider {
            public string currforcesnum;
            public string firetime;
            public string fx;
            public string hit;
            public string hurt;
            public string id;
            public string konum;
            public string level;
            public string maxforcesnum;
            public string name;
            public string skill;

            public Solider(string currforcesnum,
                string firetime, string fx, string hit, string hurt,
                string id, string konum, string level, string maxforcesnum,
                string name, string skill) {
                this.currforcesnum = currforcesnum;
                this.firetime = firetime;
                this.fx = fx;
                this.hit = hit;
                this.hurt = hurt;
                this.id = id;
                this.konum = konum;
                this.level = level;
                this.maxforcesnum = maxforcesnum;
                this.name = name;
                this.skill = skill;
            }
        }

        public class Block {
            public Solider solider;
            public string dx;
            public string flag;
            public string map;
            public string moveInfo;
            public string token;
            public string x;
            public string y;

            public Block(string dx, string flag, string map,
                Solider solider, string moveInfo, string token,
            string x, string y) {
                this.dx = dx;
                this.flag = flag;
                this.map = map;
                this.solider = solider;
                this.moveInfo = moveInfo;
                this.token = token;
                this.x = x;
                this.y = y;
            }
        }

        public class Info {
            public string armynum;
            public string interval;
            public string playerlist;
            public string reducetime;
            public string reduceusetime;
            public string remaintime;
            public string currenttoken;
            public string mapCount;
            public string nextactiontime;
            public string nexttokentime;
            public string token;

            public Info(string armynum, string interval,
                string playerlist, string reducetime,
                string reduceusetime, string remaintime,
                string currenttoken, string mapCount,
                string nextactiontime, string nexttokentime,
                string token) {
                this.armynum = armynum;
                this.interval = interval;
                this.playerlist = playerlist;
                this.reducetime = reducetime;
                this.reduceusetime = reduceusetime;
                this.remaintime = remaintime;
                this.currenttoken = currenttoken;
                this.mapCount = mapCount;
                this.nextactiontime = nextactiontime;
                this.nexttokentime = nexttokentime;
                this.token = token;
            }
        }

        public Info info;
        public List<Block> listblock;
        public string height;
        public string id;
        public string maxarmynum;
        public string name;
        public string slice;
        public string width;

        public R47107(string json) {
            JToken token = JObject.Parse(json)["m"]["campaign"];
            height = token["height"].ToString();
            id = token["id"].ToString().Replace("\"", "");
            maxarmynum = token["maxarmynum"].ToString();
            name = token["name"].ToString().Replace("\"", "");
            slice = token["slice"].ToString().Replace("\"", "");
            width = token["width"].ToString();
            JObject obj = (JObject) token["self"];
            info = new Info(
                token["armynum"].ToString(),
                token["interval"].ToString(),
                token["playerlist"].ToString(),
                token["reducetime"].ToString(),
                token["reduceusetime"].ToString(),
                token["remaintime"].ToString(),
                obj["currenttoken"].ToString(),
                obj["mapCount"].ToString(),
                obj["nextactiontime"].ToString(),
                obj["nexttokentime"].ToString(),
                obj["token"].ToString());
            int w = Convert.ToInt32(width);
            int h = Convert.ToInt32(height);
            listblock = new List<Block>();
            JArray array = (JArray) token["block"];
            for (int i = 0; i < array.Count; i++) {
                obj = (JObject) array[i];
                Solider solider = null;
                var obj2 = obj["solider"];
                if (obj2.HasValues) {
                    solider = new Solider(
                        (string) obj2["currforcesnum"],
                        (string) obj2["firetime"],
                        (string) obj2["fx"],
                        (string) obj2["hit"],
                        (string) obj2["hurt"],
                        (string) obj2["id"],
                        (string) obj2["konum"],
                        (string) obj2["level"],
                        (string) obj2["maxforcesnum"],
                        (string) obj2["name"],
                        (string) obj2["skill"]);
                }
                listblock.Add(
                    new Block(
                        obj["dx"].ToString(),
                        obj["flag"].ToString(),
                        obj["map"].ToString(),
                        solider,
                        obj["moveInfo"].ToString().Replace("\"", ""),
                        obj["token"].ToString(),
                        obj["x"].ToString(),
                        obj["y"].ToString()));
            }
        }
    }

    public class R47109 {
        public string gets;
        public string maps;
        public string rank;
        public string result;
        public string time;

        public R47109(string json) {
            JToken token = JObject.Parse(json)["m"];
            gets = token["gets"].ToString();
            maps = token["maps"].ToString();
            rank = token["rank"].ToString();
            result = token["result"].ToString().Replace("\"", "");
            time = token["time"].ToString();
        }
    }

    public class WayPoint {
        public class Player {
            public List<Point> listmap;
            public Point player;

            public Player(Point player) {
                this.player = player;
                listmap = new List<Point>();
            }

            public void Add(Point map) {
                listmap.Add(map);
            }

            public void Add(Point topleft, Point bottomright) {
                for (int i = topleft.X; i <= bottomright.X; i++)
                    for (int j = topleft.Y; j <= bottomright.Y; j++)
                        listmap.Add(new Point(i, j));
            }
        }

        public List<Player> listplayer;

        public WayPoint() {
            listplayer = new List<Player>();
        }
    }

    public class PointW {
        public Point p;

        public class PointD {
            public Point p;
            public int cost;

            public PointD(Point p, int cost) {
                this.p = p;
                this.cost = cost;
            }
        }

        public List<PointD> lst;

        public PointW(Point p, int[,] finCost, R47107 r47107) {
            lst = new List<PointD>();
            this.p = p;
            foreach (R47107.Block bl in r47107.listblock)
                if (bl.dx == "1") {
                    int x = Convert.ToInt32(bl.x);
                    int y = Convert.ToInt32(bl.y);
                    try {
                        lst.Add(new PointD(new Point(x, y), finCost[x, y]));
                    } catch { }
                }
        }
    }

    public class TagItem {
        public string text;
        public string tag;

        public TagItem(string text, string tag) {
            this.text = text;
            this.tag = tag;
        }

        public override string ToString() {
            return text;
        }
    }

    public class RichTextBoxEx : RichTextBox {
        #region Interop-Defines
        [StructLayout(LayoutKind.Sequential)]
        private struct CHARFORMAT2_STRUCT {
            public UInt32 cbSize;
            public UInt32 dwMask;
            public UInt32 dwEffects;
            public Int32 yHeight;
            public Int32 yOffset;
            public Int32 crTextColor;
            public byte bCharSet;
            public byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] szFaceName;
            public UInt16 wWeight;
            public UInt16 sSpacing;
            public int crBackColor; // Color.ToArgb() -> int
            public int lcid;
            public int dwReserved;
            public Int16 sStyle;
            public Int16 wKerning;
            public byte bUnderlineType;
            public byte bAnimation;
            public byte bRevAuthor;
            public byte bReserved1;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private const int WM_USER = 0x0400;
        private const int EM_GETCHARFORMAT = WM_USER + 58;
        private const int EM_SETCHARFORMAT = WM_USER + 68;

        private const int SCF_SELECTION = 0x0001;
        private const int SCF_WORD = 0x0002;
        private const int SCF_ALL = 0x0004;

        #region CHARFORMAT2 Flags
        private const UInt32 CFE_BOLD = 0x0001;
        private const UInt32 CFE_ITALIC = 0x0002;
        private const UInt32 CFE_UNDERLINE = 0x0004;
        private const UInt32 CFE_STRIKEOUT = 0x0008;
        private const UInt32 CFE_PROTECTED = 0x0010;
        private const UInt32 CFE_LINK = 0x0020;
        private const UInt32 CFE_AUTOCOLOR = 0x40000000;
        private const UInt32 CFE_SUBSCRIPT = 0x00010000;		/* Superscript and subscript are */
        private const UInt32 CFE_SUPERSCRIPT = 0x00020000;		/*  mutually exclusive			 */

        private const int CFM_SMALLCAPS = 0x0040;			/* (*)	*/
        private const int CFM_ALLCAPS = 0x0080;			/* Displayed by 3.0	*/
        private const int CFM_HIDDEN = 0x0100;			/* Hidden by 3.0 */
        private const int CFM_OUTLINE = 0x0200;			/* (*)	*/
        private const int CFM_SHADOW = 0x0400;			/* (*)	*/
        private const int CFM_EMBOSS = 0x0800;			/* (*)	*/
        private const int CFM_IMPRINT = 0x1000;			/* (*)	*/
        private const int CFM_DISABLED = 0x2000;
        private const int CFM_REVISED = 0x4000;

        private const int CFM_BACKCOLOR = 0x04000000;
        private const int CFM_LCID = 0x02000000;
        private const int CFM_UNDERLINETYPE = 0x00800000;		/* Many displayed by 3.0 */
        private const int CFM_WEIGHT = 0x00400000;
        private const int CFM_SPACING = 0x00200000;		/* Displayed by 3.0	*/
        private const int CFM_KERNING = 0x00100000;		/* (*)	*/
        private const int CFM_STYLE = 0x00080000;		/* (*)	*/
        private const int CFM_ANIMATION = 0x00040000;		/* (*)	*/
        private const int CFM_REVAUTHOR = 0x00008000;


        private const UInt32 CFM_BOLD = 0x00000001;
        private const UInt32 CFM_ITALIC = 0x00000002;
        private const UInt32 CFM_UNDERLINE = 0x00000004;
        private const UInt32 CFM_STRIKEOUT = 0x00000008;
        private const UInt32 CFM_PROTECTED = 0x00000010;
        private const UInt32 CFM_LINK = 0x00000020;
        private const UInt32 CFM_SIZE = 0x80000000;
        private const UInt32 CFM_COLOR = 0x40000000;
        private const UInt32 CFM_FACE = 0x20000000;
        private const UInt32 CFM_OFFSET = 0x10000000;
        private const UInt32 CFM_CHARSET = 0x08000000;
        private const UInt32 CFM_SUBSCRIPT = CFE_SUBSCRIPT | CFE_SUPERSCRIPT;
        private const UInt32 CFM_SUPERSCRIPT = CFM_SUBSCRIPT;

        private const byte CFU_UNDERLINENONE = 0x00000000;
        private const byte CFU_UNDERLINE = 0x00000001;
        private const byte CFU_UNDERLINEWORD = 0x00000002; /* (*) displayed as ordinary underline	*/
        private const byte CFU_UNDERLINEDOUBLE = 0x00000003; /* (*) displayed as ordinary underline	*/
        private const byte CFU_UNDERLINEDOTTED = 0x00000004;
        private const byte CFU_UNDERLINEDASH = 0x00000005;
        private const byte CFU_UNDERLINEDASHDOT = 0x00000006;
        private const byte CFU_UNDERLINEDASHDOTDOT = 0x00000007;
        private const byte CFU_UNDERLINEWAVE = 0x00000008;
        private const byte CFU_UNDERLINETHICK = 0x00000009;
        private const byte CFU_UNDERLINEHAIRLINE = 0x0000000A; /* (*) displayed as ordinary underline	*/

        #endregion

        #endregion

        public RichTextBoxEx() {
            // Otherwise, non-standard links get lost when user starts typing
            // next to a non-standard link
            this.DetectUrls = false;
        }

        [DefaultValue(false)]
        public new bool DetectUrls {
            get { return base.DetectUrls; }
            set { base.DetectUrls = value; }
        }

        /// <summary>
        /// Insert a given text as a link into the RichTextBox at the current insert position.
        /// </summary>
        /// <param name="text">Text to be inserted</param>
        public void InsertLink(string text) {
            InsertLink(text, this.SelectionStart);
        }

        /// <summary>
        /// Insert a given text at a given position as a link. 
        /// </summary>
        /// <param name="text">Text to be inserted</param>
        /// <param name="position">Insert position</param>
        public void InsertLink(string text, int position) {
            if (position < 0 || position > this.Text.Length)
                throw new ArgumentOutOfRangeException("position");

            this.SelectionStart = position;
            this.SelectedText = text;
            this.Select(position, text.Length);
            this.SetSelectionLink(true);
            this.Select(position + text.Length, 0);
        }

        /// <summary>
        /// Insert a given text at at the current input position as a link.
        /// The link text is followed by a hash (#) and the given hyperlink text, both of
        /// them invisible.
        /// When clicked on, the whole link text and hyperlink string are given in the
        /// LinkClickedEventArgs.
        /// </summary>
        /// <param name="text">Text to be inserted</param>
        /// <param name="hyperlink">Invisible hyperlink string to be inserted</param>
        public void InsertLink(string text, string hyperlink) {
            InsertLink(text, hyperlink, this.SelectionStart);
        }

        /// <summary>
        /// Insert a given text at a given position as a link. The link text is followed by
        /// a hash (#) and the given hyperlink text, both of them invisible.
        /// When clicked on, the whole link text and hyperlink string are given in the
        /// LinkClickedEventArgs.
        /// </summary>
        /// <param name="text">Text to be inserted</param>
        /// <param name="hyperlink">Invisible hyperlink string to be inserted</param>
        /// <param name="position">Insert position</param>
        public void InsertLink(string text, string hyperlink, int position) {
            if (position < 0 || position > this.Text.Length)
                throw new ArgumentOutOfRangeException("position");
            var sb = new StringBuilder();
            foreach (var c in text) {
                if (c <= 0x7f)
                    sb.Append(c);
                else
                    sb.Append("\\u" + Convert.ToUInt32(c) + "?");
            }
            string _s = sb.ToString();
            this.SelectionStart = position;
            this.SelectedRtf = @"{\rtf1\ansi " + _s + @"\v #" + hyperlink + @"\v0}";
            this.Select(position, text.Length + hyperlink.Length + 1);
            this.SetSelectionLink(true);
            this.Select(position + text.Length + hyperlink.Length + 1, 0);
        }

        /// <summary>
        /// Set the current selection's link style
        /// </summary>
        /// <param name="link">true: set link style, false: clear link style</param>
        public void SetSelectionLink(bool link) {
            SetSelectionStyle(CFM_LINK, link ? CFE_LINK : 0);
        }
        /// <summary>
        /// Get the link style for the current selection
        /// </summary>
        /// <returns>0: link style not set, 1: link style set, -1: mixed</returns>
        public int GetSelectionLink() {
            return GetSelectionStyle(CFM_LINK, CFE_LINK);
        }


        private void SetSelectionStyle(UInt32 mask, UInt32 effect) {
            CHARFORMAT2_STRUCT cf = new CHARFORMAT2_STRUCT();
            cf.cbSize = (UInt32) Marshal.SizeOf(cf);
            cf.dwMask = mask;
            cf.dwEffects = effect;

            IntPtr wpar = new IntPtr(SCF_SELECTION);
            IntPtr lpar = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lpar, false);

            IntPtr res = SendMessage(Handle, EM_SETCHARFORMAT, wpar, lpar);

            Marshal.FreeCoTaskMem(lpar);
        }

        private int GetSelectionStyle(UInt32 mask, UInt32 effect) {
            CHARFORMAT2_STRUCT cf = new CHARFORMAT2_STRUCT();
            cf.cbSize = (UInt32) Marshal.SizeOf(cf);
            cf.szFaceName = new char[32];

            IntPtr wpar = new IntPtr(SCF_SELECTION);
            IntPtr lpar = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lpar, false);

            IntPtr res = SendMessage(Handle, EM_GETCHARFORMAT, wpar, lpar);

            cf = (CHARFORMAT2_STRUCT) Marshal.PtrToStructure(lpar, typeof(CHARFORMAT2_STRUCT));

            int state;
            // dwMask holds the information which properties are consistent throughout the selection:
            if ((cf.dwMask & mask) == mask) {
                if ((cf.dwEffects & effect) == effect)
                    state = 1;
                else
                    state = 0;
            } else {
                state = -1;
            }

            Marshal.FreeCoTaskMem(lpar);
            return state;
        }
    }
}