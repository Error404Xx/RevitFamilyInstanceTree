using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using InstancesTree.Nodes;

namespace InstancesTree
{
    [Autodesk.Revit.Attributes.Transaction(
        Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class App : Autodesk.Revit.UI.IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication application = commandData.Application;
            UIDocument activeUiDocument = application.ActiveUIDocument;

            if (activeUiDocument == null)
            {
                return Result.Cancelled;
            }

            Document document = activeUiDocument.Document;

            if (document == null)
            {
                return Result.Cancelled;
            }

            if (document.ActiveView is View3D)
            {
                //如果当前视图是三维视图则运行接下来的指令
                Application.Run(new InstanceTree(document));
            }
            else
            {
                MessageBox.Show("必须切换到三维视图");
            }

            return Autodesk.Revit.UI.Result.Succeeded;
        }
    }
}