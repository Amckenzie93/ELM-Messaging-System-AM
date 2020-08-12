using System;
using System.Collections.Generic;
using System.Text;

namespace ELM__AM
{
    class ElmUtilities
    {
        public static bool IsNumber(string number)
        {
            foreach (char val in number.Replace(" ", ""))
            {
                if (val < '0' || val > '9')
                    return false;
            }
            return true;
        }
    }
}
