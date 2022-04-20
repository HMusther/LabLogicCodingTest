using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewApplication
{
    class Item : TreeElement
    {
        public Item(string name) : base("item")
        {
            this.name = name;
        }
    }
}
