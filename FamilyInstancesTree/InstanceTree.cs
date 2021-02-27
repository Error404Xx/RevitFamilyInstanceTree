using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using InstancesTree.Nodes;
using Form = System.Windows.Forms.Form;
using Point = System.Drawing.Point;

namespace InstancesTree
{
    public partial class InstanceTree : Form
    {
        private readonly DataTable _datatable = new DataTable();
        private readonly DataSet _dataset = new DataSet();


        public List<Element> Allelems = new List<Element>();


        public InstanceTree(Document document)
        {
            InitializeComponent();

            var doc = document;

            InitialData(doc);

            //初始化树结构，根据DataTable中的数据进行递归生成
            this.InitTree(treeView1.Nodes, "-1");
        }

        /// <summary>
        /// 创建构件树
        /// </summary>
        private void InitialData(Document doc)
        {
            //创建一个DataTable
            _datatable.TableName = "Nodes";

            //在DataSet中添加DataTable
            _dataset.Tables.Add(_datatable);

            //DataTable中添加表单
            _datatable.Columns.Add("NodeID", typeof(string));
            _datatable.Columns.Add("NodeName", typeof(string));
            _datatable.Columns.Add("ParentID", typeof(string));


            var collector = new FilteredElementCollector(doc, doc.ActiveView.Id);

            foreach (var e in collector.ToElements())
            {
                var category = e.Category.Name;
                //有些图元没有类型，而且要把相机排除
                if (e.GetTypeId().ToString()!="-1"&& category!="相机")
                {
                    Allelems.Add(e);
                }
            }

            foreach (var elem in Allelems)
            {
                var insnode = new Instancenode(elem, doc);
                insnode.AddData(_datatable);

                var synode = new Symbolnode(elem, doc);
                synode.AddData(_datatable);

                var fanode = new Familynode(elem,doc);
                fanode.AddData(_datatable);

                var canode = new Categorynode(elem,doc);
                canode.AddData(_datatable);

            }

        }


        private void InitTree(TreeNodeCollection treeNodeCollection, string parentid)
        {
            //新建一个DataView
            //先去DataSet中名字为"Node"的DataTable中建立关联
            //随后指定"ParentID"为过滤条件
            var dataView = new DataView
            {
                Table = this._dataset.Tables["Nodes"],
                RowFilter = "ParentID='" + parentid + "'"
            };

            //遍历DataView中的数据;每次新建一个节点；
            foreach (DataRowView dataRowView in dataView)
            {
                //新建一个树节点；
                //设置数据为NodeID
                //设置树节点的名字为Name
                var tmpTreenode = new TreeNode
                {
                    Tag = dataRowView["NodeID"],
                    Text = dataRowView["NodeName"].ToString()
                };
                //将当前的树节点放在集合当中；
                treeNodeCollection.Add(tmpTreenode);

                InitTree(tmpTreenode.Nodes, (string)(tmpTreenode.Tag));
            }
        }


    }
}
