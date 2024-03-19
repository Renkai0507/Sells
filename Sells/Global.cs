using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sells
{
    public static class Global
    {
        public static string[] StrToArray(string Str)
        {
            string[] result = Str.Split(' ');
            return result;
        }
    }
}
