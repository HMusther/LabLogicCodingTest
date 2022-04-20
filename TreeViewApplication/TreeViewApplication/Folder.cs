using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewApplication
{
    class Folder : TreeElement 
    {
        private List<TreeElement> contents = new List<TreeElement>();
        public Folder(string name) : base("folder")
        {
            this.name = name;
        }

        public List<TreeElement> ReturnContents()
        {
            return contents;
        }

        public void AddElementToContents(TreeElement item)
        {
            contents.Add(item);
        }

        public void RemoveElementFromContents (int index)
        {
            contents.RemoveAt(index);
        }

        public List<TreeElement> GetNodes()
        {
            List<TreeElement> children = new List<TreeElement>();

            foreach(TreeElement element in contents)
            {
                if (element is Folder f)
                {
                    children.Add(f);
                    children.AddRange(f.GetNodes());
                }
                else
                {
                    children.Add(element);
                }
            }

            return children;
        }
    }
}
