using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;

namespace InstancesTree
{
    /// <summary>
    /// 这个类用于将文档中的每一个元素进行收集并分类
    /// </summary>
    class Classifier
    {
        //存放所有的元素
        public List<Element> ListElements;

        //public Element Elem { get; set; }

        #region 存放所有的系统族
        //所有墙 —— 建筑
        public List<Wall> ListWalls = new List<Wall>();

        //所有屋顶 —— 建筑
        public List<FootPrintRoof> ListFootPrintRoofs = new List<FootPrintRoof>();

        //所有楼板 —— 建筑
        public List<Floor> ListFloors = new List<Floor>();

        //所有风管 —— 系统
        public List<Duct> ListDucts = new List<Duct>();

        //软风管 —— 系统
        public List<FlexDuct> ListFlexDucts = new List<FlexDuct>();

        //所有管道 —— 系统
        public List<Pipe> ListPipes = new List<Pipe>();

        //幕墙竖梃 —— 建筑
        public List<Mullion> ListMullions = new List<Mullion>();

        //天花板 —— 建筑
        public List<Ceiling> ListCeilings = new List<Ceiling>();


        //所有标高 —— 三维视图中并不会导出
        public List<Level> ListLevels = new List<Level>();

        //幕墙嵌板
        public List<Panel> ListPanels = new List<Panel>();

        //网格线
        public List<CurtainGridLine> ListCurtainGridLines = new List<CurtainGridLine>();

        //忽略幕墙网格 CurtainGridLine

        //TODO：轴网、视口类型、图纸

        //族实例
        public List<FamilyInstance> ListFamilyInstances = new List<FamilyInstance>();

        #endregion

        //对元素进行分类
        public void Classify()
        {
            foreach (var elem in ListElements)
            {
                if (elem is Wall)
                {
                    ListWalls.Add(elem as Wall);
                }
                else if (elem is FootPrintRoof)
                {
                    ListFootPrintRoofs.Add(elem as FootPrintRoof);
                }
                else if (elem is Floor)
                {
                    ListFloors.Add(elem as Floor);
                }
                else if (elem is Duct)
                {
                    ListDucts.Add(elem as Duct);
                }
                else if (elem is Pipe)
                {
                    ListPipes.Add(elem as Pipe);
                }
                else if (elem is Level)
                {
                    ListLevels.Add(elem as Level);
                }
                else if (elem is Mullion)
                {
                    ListMullions.Add(elem as Mullion);
                }
                else if (elem is Ceiling)
                {
                    ListCeilings.Add(elem as Ceiling);
                }
                else if (elem is FlexDuct)
                {
                    ListFlexDucts.Add(elem as FlexDuct);
                }
                else if (elem is Panel)
                {
                    ListPanels.Add(elem as Panel);
                }
                else if (elem is CurtainGridLine)
                {
                    ListCurtainGridLines.Add(elem as CurtainGridLine);
                }
                else if (elem is FamilyInstance)
                {
                    ListFamilyInstances.Add(elem as FamilyInstance);
                }
            }
        }

        public Classifier(List<Element> elems)
        {
            this.ListElements = elems;
        }

    }
}
