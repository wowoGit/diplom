using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace testing.Extensions
{
    public static class Extensions
    {
        public static DisplayAttribute GetDisplayAttribute(this Enum enumValue) 
    {
        return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>();
    }
    }
}
