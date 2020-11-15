using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GenericList
{
    [ExportClass]
    public static class ClassEnumerator
    {
        public static DynamicList<Type> GetPublicTypes(Assembly asm)
        {
            var types = new DynamicList<Type>();
            foreach (Type type in asm.GetTypes().Where(typeVal => Attribute.IsDefined(typeVal, typeof(ExportClass)) && typeVal.IsClass && typeVal.IsPublic))
            {
                types.Add(type);
            }

            return types;
        }
    }
}
