using System;
using System.Collections.Generic;

namespace k8asd
{
    class Permutation
    {
        private List<int> listmap;
        private int count;
        public List<List<int>> result;

        public Permutation(List<int> listmap)
        {
            this.listmap = listmap;
            count = listmap.Count;
            result = new List<List<int>>();
            List<int> curlist = new List<int>();
            Recursion(0, curlist);
        }

        private void Recursion(int k, List<int> curlist)
        {
            if (k == count)
            {
                result.Add(curlist);
                return;
            }
            foreach (int n in listmap)
            {
                bool contain = false;
                foreach (int i in curlist)
                    if (i == n)
                    {
                        contain = true;
                        break;
                    }
                if (!contain)
                {
                    List<int> temp = new List<int>(curlist);
                    int m = k;
                    temp.Add(n);
                    Recursion(++m, temp);
                }
            }
        }
    }
}