using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCirclePawnWinform
{
    public class Bezier
    {
        public static void createCurve(PointD[] originPoint, int originCount, out List<PointD> curvePoint)
        {
            curvePoint = new List<PointD>();
            //控制点收缩系数 ，经调试0.6较好
            double scale = 0.6;
            PointD[] midpoints = new PointD[originCount];
            //生成中点       
            for (int i = 0; i < originCount; i++)
            {
                int nexti = (i + 1) % originCount;
                midpoints[i] = new PointD((originPoint[i].X + originPoint[nexti].X) / 2.0, (originPoint[i].Y + originPoint[nexti].Y) / 2.0);
                //midpoints[i].X = (originPoint[i].X + originPoint[nexti].X) / 2.0;
                //midpoints[i].Y = (originPoint[i].Y + originPoint[nexti].Y) / 2.0;
            }

            //平移中点  
            PointD[] extrapoints = new PointD[2 * originCount];
            for (int i = 0; i < originCount; i++)
            {
                int nexti = (i + 1) % originCount;
                int backi = (i + originCount - 1) % originCount;
                PointD midinmid = new PointD((midpoints[i].X + midpoints[backi].X) / 2.0, (midpoints[i].Y + midpoints[backi].Y) / 2.0);
                //midinmid.X = (midpoints[i].X + midpoints[backi].X) / 2.0;
                //midinmid.Y = (midpoints[i].Y + midpoints[backi].Y) / 2.0;
                double offsetx = originPoint[i].X - midinmid.X;
                double offsety = originPoint[i].Y - midinmid.Y;
                int extraindex = 2 * i;
                extrapoints[extraindex] = new PointD(midpoints[backi].X + offsetx, midpoints[backi].Y + offsety);
                //extrapoints[extraindex].X = midpoints[backi].X + offsetx;
                //extrapoints[extraindex].Y = midpoints[backi].Y + offsety;
                //朝 originPoint[i]方向收缩   
                double addx = (extrapoints[extraindex].X - originPoint[i].X) * scale;
                double addy = (extrapoints[extraindex].Y - originPoint[i].Y) * scale;
                extrapoints[extraindex].X = originPoint[i].X + addx;
                extrapoints[extraindex].Y = originPoint[i].Y + addy;

                int extranexti = (extraindex + 1) % (2 * originCount);
                extrapoints[extranexti] = new PointD(midpoints[i].X + offsetx, midpoints[i].Y + offsety);
                //extrapoints[extranexti].X = midpoints[i].X + offsetx;
                //extrapoints[extranexti].Y = midpoints[i].Y + offsety;
                //朝 originPoint[i]方向收缩   
                addx = (extrapoints[extranexti].X - originPoint[i].X) * scale;
                addy = (extrapoints[extranexti].Y - originPoint[i].Y) * scale;
                extrapoints[extranexti].X = originPoint[i].X + addx;
                extrapoints[extranexti].Y = originPoint[i].Y + addy;

            }

            PointD[] controlPoint = new PointD[4];
            //生成4控制点，产生贝塞尔曲线  
            for (int i = 0; i < originCount; i++)
            {
                controlPoint[0] = originPoint[i];
                int extraindex = 2 * i;
                controlPoint[1] = extrapoints[extraindex + 1];
                int extranexti = (extraindex + 2) % (2 * originCount);
                controlPoint[2] = extrapoints[extranexti];
                int nexti = (i + 1) % originCount;
                controlPoint[3] = originPoint[nexti];
                double u = 1;
                while (u >= 0)
                {
                    double px = bezier3funcX(u, controlPoint);
                    double py = bezier3funcY(u, controlPoint);
                    //u的步长决定曲线的疏密  
                    u -= 0.1;
                    PointD tempP = new PointD(px, py);
                    //存入曲线点   
                    curvePoint.Add(tempP);
                }
            }
        }
        //三次贝塞尔曲线  
        static double bezier3funcX(double uu, PointD[] controlP)
        {
            double part0 = controlP[0].X * uu * uu * uu;
            double part1 = 3 * controlP[1].X * uu * uu * (1 - uu);
            double part2 = 3 * controlP[2].X * uu * (1 - uu) * (1 - uu);
            double part3 = controlP[3].X * (1 - uu) * (1 - uu) * (1 - uu);
            return part0 + part1 + part2 + part3;
        }
        static double bezier3funcY(double uu, PointD[] controlP)
        {
            double part0 = controlP[0].Y * uu * uu * uu;
            double part1 = 3 * controlP[1].Y * uu * uu * (1 - uu);
            double part2 = 3 * controlP[2].Y * uu * (1 - uu) * (1 - uu);
            double part3 = controlP[3].Y * (1 - uu) * (1 - uu) * (1 - uu);
            return part0 + part1 + part2 + part3;
        }
    }
}
