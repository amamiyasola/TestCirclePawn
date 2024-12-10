using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCirclePawn
{

    public class PointD
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double GetMainAxisPos(bool SwitchFlag)
        {
            if (SwitchFlag) return X;
            else return Y;
        }
    }



    public class DrawCircle
    {
        public double StartAngle { get; set; }

        public double EndAngle { get; set; }


        public double Radius { get; set; }
    }
    public class Circle
    {
        /// <summary>
        /// 圆心横坐标
        /// </summary>
        /// <value></value>
        public double X { get; set; }
        /// <summary>
        /// 圆心纵坐标
        /// </summary>
        /// <value></value>
        public double Y { get; set; }
        /// <summary>
        /// 圆半径
        /// </summary>
        /// <value></value>
        public double R { get; set; }
    }
}
