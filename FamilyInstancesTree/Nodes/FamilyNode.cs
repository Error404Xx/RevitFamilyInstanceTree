using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace InstancesTree.Nodes
{
    internal class Familynode:Node
    {
        public Familynode(Element elem, Document doc) : base(elem, doc)
        {
            this.Doc = doc;
            this.Elem = elem;

            //NodeId是FamilyName
            this.NodeId = Util.GetFamilyName(this.Elem);
            //ParentId是CategoryName
            Category category = this.Elem.Category;
            this.ParentId = category.Id.ToString();
            

            string name = Util.GetFamilyName(this.Elem);
            this.NodeName = name;
        }

        public string GetNodeName()
        {
            return this.NodeName;
        }
    }
}
