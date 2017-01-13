using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace k8asd {
    public static class F {
        private static string encode = "~!@#$%^&*()_+`1234567890-=QWERTYUIOP{}|qwertyuiop[]ASDFGHJKL:asdfghjkl;ZXCVBNM<>?zxcvbnm,./";

        public static string EncryptPass(string pass) {
            int len = pass.Length;
            int len2 = encode.Length;
            char[] s = new char[len];
            for (int i = 0; i < len; i++) {
                int id = CharPos(pass[i]) + i * i;
                id %= len2;
                s[i] = encode[id];
            }
            return new String(s);
        }

        public static string DecryptPass(string pass) {
            int len = pass.Length;
            int len2 = encode.Length;
            char[] s = new char[len];
            for (int i = 0; i < len; i++) {
                int id = CharPos(pass[i]) - i * i;
                id %= len2;
                if (id < 0)
                    id += len2;
                s[i] = encode[id];
            }
            return new String(s);
        }

        private static int CharPos(char s) {
            for (int i = 0; i < encode.Length; i++)
                if (s == encode[i])
                    return i;
            return -1;
        }

        public static void TotalCost(List<int> listmapint, List<PointW> listmap,
            int curindex, int curcost, ref int cost) {
            if (curindex == listmapint.Count - 1) {
                cost = Math.Min(cost, curcost);
                return;
            }
            foreach (PointW.PointD pd in listmap[listmapint[curindex]].lst)
                if (pd.p.Equals(listmap[listmapint[curindex + 1]].p)) {
                    TotalCost(listmapint, listmap, curindex + 1, curcost + pd.cost, ref cost);
                    break;
                }
        }

        /*
        public static void CampMap(string moveInfo, Point p,
            ref KryptonButton[,] bt, R47107 r47107) {
            int w = Convert.ToInt32(r47107.width);
            int h = Convert.ToInt32(r47107.height);
            for (int k = 0; k < 4; k++)
                if (moveInfo[k] == '1') {
                    Point sp = new Point(p.X + (k - 2) % 2, p.Y + (k - 1) % 2);
                    if (0 <= sp.X && sp.X < w
                        && 0 <= sp.Y && sp.Y < h) {
                        string move = r47107.listblock[sp.Y * w + sp.X].moveInfo;
                        if (!bt[sp.Y, sp.X].Visible && move != "0000") {
                            bt[sp.Y, sp.X].Visible = true;
                            CampMap(move, sp, ref bt, r47107);
                        }
                    }
                }
        }
        */

        public static void SearchPath(string moveInfo, Point cur, List<Point> curPath,
            int curCost, List<Point> limit, R47107 r47107,
            ref int[,] finCost, ref List<Point>[,] finPath) {
            int w = Convert.ToInt32(r47107.width);
            int h = Convert.ToInt32(r47107.height);
            for (int k = 0; k < 4; k++)
                if (moveInfo[k] == '1') {
                    Point side = new Point(cur.X + (k - 2) % 2, cur.Y + (k - 1) % 2);
                    if (0 <= side.X && side.X < w
                        && 0 <= side.Y && side.Y < h)
                        foreach (Point p in limit)
                            if (p.Equals(side)) {
                                List<Point> tempPath = new List<Point>(curPath);
                                tempPath.Add(side);
                                R47107.Block bl = r47107.listblock[side.Y * w + side.X];
                                int[] sCost = { 13, 30, 13 };
                                int tempCost = sCost[Convert.ToInt32(bl.dx)] + curCost;
                                if (finCost[side.X, side.Y] == -1 || tempCost <= finCost[side.X, side.Y]) {
                                    finCost[side.X, side.Y] = tempCost;
                                    finPath[side.X, side.Y] = tempPath;
                                    SearchPath(bl.moveInfo, side, tempPath,
                                        tempCost, limit, r47107,
                                        ref finCost, ref finPath);
                                }
                                break;
                            }
                }
        }
    }
}
