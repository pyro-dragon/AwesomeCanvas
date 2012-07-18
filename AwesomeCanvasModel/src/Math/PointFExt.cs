using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace AwesomeCanvas
{
    public static class PointFExt
    {
        public static PointF Subtract(this PointF pSelf, PointF pAmmount) { 
            return new PointF(pSelf.X - pAmmount.X, pSelf.Y - pAmmount.Y); 
        }
        /// <summary>
        /// Interpolate from one point to another
        /// </summary>
        /// <param name="pFrom"></param>
        /// <param name="pTo"></param>
        /// <param name="pQuota"> 0.0 == pFrom, 1.0 == pTo</param>
        /// <returns></returns>
        public static PointF Lerp(PointF pFrom, PointF pTo, float pQuota) {
            return new PointF(pFrom.X + (pTo.X - pFrom.X) * pQuota, pFrom.Y + (pTo.Y - pFrom.Y) * pQuota);
        }
        /// <summary>
        /// The length or magnitude of the pointf
        /// </summary>
        /// <param name="pSelf"></param>
        /// <returns></returns>
        public static float Length(this PointF pSelf) {
            return (float)System.Math.Sqrt(DotProduct(pSelf, pSelf));
        }
        /// <summary>
        /// create a unit vecotor (Length == 1)
        /// </summary>
        /// <param name="pSelf"></param>
        /// <returns></returns>
        public static PointF Normalized(this PointF pSelf) {
            float len = pSelf.Length();
            return new PointF(pSelf.X / len, pSelf.Y / len);
        }
        /// <summary>
        /// The Dotproduct
        /// </summary>
        /// <param name="pA"></param>
        /// <param name="pB"></param>
        /// <returns></returns>
        public static float DotProduct(PointF pA, PointF pB) { return pA.X * pB.X + pA.Y * pB.Y; }

        /// <summary>
        /// Distance between two points
        /// </summary>
        /// <param name="pFrom"></param>
        /// <param name="pTo"></param>
        /// <returns></returns>
        public static float Distance(PointF pFrom, PointF pTo) {
            return (new PointF(pTo.X - pFrom.X, pTo.Y - pFrom.Y)).Length();
        }
        public static Point ToPointRounded(this PointF pSelf) { return new Point((int)System.Math.Round(pSelf.X), (int)System.Math.Round(pSelf.Y)); }
        public static Point ToPoint(this PointF pSelf) { return new Point((int)pSelf.X, (int)pSelf.Y); }
        public static PointF FromPoint(Point p) { return new PointF(p.X, p.Y); }
    }
}
