using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewApplication
{
    class TreeElement
    {

        public string name { get; set; }
        public readonly string type;

        public TreeElement()
        {

        }

        protected TreeElement (string type)
        {
            this.type = type;
        }


    }
}
