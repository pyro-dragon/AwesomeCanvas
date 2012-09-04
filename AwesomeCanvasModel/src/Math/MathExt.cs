using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AwesomeCanvas
{
    public class MathExt
    {
        public static float Lerp(int pStart, int pEnd, float pAmmount) 
        {
            return pStart + (pEnd - pStart) * pAmmount;
        }

        public static float Lerp(float pStart, float pEnd, float pAmmount)
        {
            return pStart + (pEnd - pStart) * pAmmount;
        }

        public static int RoundToInt(float pValue) 
        {
            return (int)Math.Round(pValue);
        }
    }
}
