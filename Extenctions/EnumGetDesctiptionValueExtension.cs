using System;
using System.ComponentModel;
using System.Linq;

namespace Console_Battleship.Extenctions
{
    public static class EnumGetDesctiptionValueExtension
    {
        // source https://www.pavey.me/2015/04/aspnet-c-extension-method-to-get-enum.html

        public static string Description(this Enum value)
        {

            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;

        }
    }
}