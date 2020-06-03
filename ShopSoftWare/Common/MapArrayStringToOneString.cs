using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSoftWare.Common
{
    public static class MapArrayStringToOneString
    {
        public static string MapString(string[] input, char kytughep)
        {
            var result = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (i == input.Length - 1)
                {
                    result += input[i];
                }
                else
                {
                    result += input[i] + "-";
                }
            }

            return result;
        }
    }
}