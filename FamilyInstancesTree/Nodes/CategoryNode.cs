using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace InstancesTree.Nodes
{
    internal class Categorynode:Node
    {
        public Categorynode(Element elem, Document doc) : base(elem, doc)
        {
            this.Doc = doc;
            this.Elem = elem;
            Category category = this.Elem.Category;

            //NodeId是CategoryName
            this.NodeId = category.Id.ToString();
            //ParentId是3D视图的，是"-1"()任意值
            this.ParentId = "-1";

            string name = category.Name;
            this.NodeName = name;
        }

        public string GetNodeName()
        {
            return this.NodeName;
        }
    }
}
