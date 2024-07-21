using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong
{
    internal static class HelperClass
    {
        public static int BetterRound(double num, bool isPositive)
        {
            if (isPositive)
            {
                return (int)Math.Ceiling(num);
            } else
            {
                return (int)Math.Floor(num);
            }
        }
    }
}
