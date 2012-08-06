using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AwesomeCanvas
{
    public static class PointExt
    {
        public static Point Add(this Point pSelf, Point pAmmount) {
            return new Point(pSelf.X + pAmmount.X, pSelf.Y + pAmmount.Y);
        }

        public static Point Subtract(this Point pSelf, Point pAmmount) {
            return new Point(pSelf.X - pAmmount.X, pSelf.Y - pAmmount.Y);
        }
        public static PointF ToPointF(this Point pSelf) {
            return new PointF(pSelf.X, pSelf.Y);
        }
    }
}
