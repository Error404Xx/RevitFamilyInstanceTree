using System;
using System.Data;
using Autodesk.Revit.DB;

namespace InstancesTree.Nodes
{
    /// <summary>
    /// 这是所有节点的父类
    /// </summary>
    internal abstract class Node
    {
        public Element Elem { get; set; }

        public string NodeId { get; set; }

        public string ParentId { get; set; }

        //节点的名称
        public string NodeName { get; set; }

        public Document Doc { get; set; }

        protected Node(Element elem, Document doc)
        {
            this.Elem = elem;
            this.Doc = doc;
        }

        public void AddData(DataTable datatable)
        {
            //新建一行
            var dataRow = datatable.NewRow();
            foreach (DataRow datarow in datatable.Rows)
            {
                if ((string)datarow["NodeID"] == this.NodeId)
                {
                    return;
                }
            }
            dataRow["NodeID"] = this.NodeId;
            dataRow["NodeName"] = this.NodeName;
            dataRow["ParentID"] = this.ParentId;

            //把数据添加到一行
            datatable.Rows.Add(dataRow);
        }
    }
}
