using System;
using System.Data;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace InstancesTree.Nodes
{
    internal class Instancenode:Node
    {
        /// <summary>
        /// Instancenode的构造函数，包括导入族和系统族实例
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="doc"></param>
        public Instancenode(Element elem,Document doc) : base(elem,doc)
        {
            this.Elem = elem;
            this.Doc = doc;

            this.NodeId = elem.Id.ToString();
            this.ParentId = elem.GetTypeId().ToString();
       
            string name = Util.GetFamilyName(this.Elem) + " [" + this.Elem.Id + "]";
            this.NodeName = name;
        }

        public string GetNodeName()
        {
            return this.NodeName;
        }
    }
}
