using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace InstancesTree
{
    public static class Util
    {
        public static string GetFamilyName(Element element)
        {
            var name = "";
            var familyname = element.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM);
            if (familyname != null &&
                familyname.StorageType == StorageType.ElementId)
            {
                name = familyname.AsValueString();
            }
                return name;
        }
    }
}
