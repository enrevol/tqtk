using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd
{
    public class ComboboxResearch
    {
        public string index;
        public string name;
        public ComboboxResearch() { }
        public ComboboxResearch(string index, string name)
        {
            this.index = index;
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
