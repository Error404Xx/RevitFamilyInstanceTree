using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace InstancesTree.Nodes
{
    internal class Symbolnode:Node
    {
        public Symbolnode(Element elem, Document doc) : base(elem, doc)
        {
            this.Doc = doc;
            this.Elem = elem;
            this.NodeId = elem.GetTypeId().ToString();

            //如果是导入族，则有FamilyID，若是系统族则没有
            ElementId cuElementSymbolId = this.Elem.GetTypeId();
            FamilySymbol familySymbol = Doc.GetElement(cuElementSymbolId) as FamilySymbol;

            //TODO:可能这样效率不高
            if (familySymbol != null)
            {
                Family family = familySymbol.Family;
                this.ParentId = family.Name;
            }
            else
            {
                //系统族没有Family这种说法;
                this.ParentId = Util.GetFamilyName(elem);
            }

            string name = this.Doc.GetElement(cuElementSymbolId).Name;
            this.NodeName = name;
        }

        public string GetNodeName()
        {
            return this.NodeName;
        }
    }
}
