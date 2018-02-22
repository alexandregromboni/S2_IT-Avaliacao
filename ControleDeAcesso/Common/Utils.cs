using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Utils
    {
        public static string GetEnumDescription(Enum input)
        {
            Type type = input.GetType();
            MemberInfo[] memInfo = type.GetMember(input.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = (object[])memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return input.ToString();
        }
    }
}
