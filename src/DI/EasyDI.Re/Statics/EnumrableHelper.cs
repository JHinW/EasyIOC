using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EasyDI.Re.Statics
{
    public static class EnumrableHelper
    {
        public static Object CreateEnumrable(Type type, object[] parameters)
        {
            Type dictType = typeof(List<>).MakeGenericType(type);
            var lst = Activator.CreateInstance(dictType);
            MethodInfo info = typeof(List<>).MakeGenericType(type).GetMethod("Add");
            foreach (var par in parameters)
            {
                info.Invoke(lst, new[] { par });
            }
            return lst;
        }
    }
}
