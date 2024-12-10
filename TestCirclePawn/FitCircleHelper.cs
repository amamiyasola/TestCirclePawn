using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCirclePawn
{
    public class FitCircleHelper
    {
        public double centerX { get; private set; }
        public double centerY { get; private set; }
        public double centerRadius { get; private set; }

        // 多项式求值函数
        public double PolynomialEvaluation(double[] coefficients, double x)
        {

            double result = 0;
            double power = 1;
            for (int i = coefficients.Length - 1; i >= 0; i--)
            {
                result += coefficients[i] * power;
                power *= x;
            }
            return result;
        }

        public DrawCircle LeastSquaresFit(PointD[] points)
        {
            if (points.Length < 3) return null;

            double sum_x = 0.0f, sum_y = 0.0f, sum_x2 = 0.0f, sum_y2 = 0.0f,
                sum_x3 = 0.0f, sum_y3 = 0.0f, sum_xy = 0.0f, sum_x1y2 = 0.0f, sum_x2y1 = 0.0f;

            int N = points.Length;
            double x, y, x2, y2;

            for (int i = 0; i < N; i++)
            {
                x = points[i].X;
                y = points[i].Y;

                x2 = x * x;
                y2 = y * y;

                sum_x += x;
                sum_y += y;
                sum_x2 += x2;
                sum_y2 += y2;
                sum_x3 += x2 * x;
                sum_y3 += y2 * y;
                sum_xy += x * y;
                sum_x1y2 += x * y2;
                sum_x2y1 += x2 * y;
            }

            double C, D, E, G, H;
            double a, b, c;

            C = N * sum_x2 - sum_x * sum_x;
            D = N * sum_xy - sum_x * sum_y;
            E = N * sum_x3 + N * sum_x1y2 - (sum_x2 + sum_y2) * sum_x;
            G = N * sum_y2 - sum_y * sum_y;
            H = N * sum_x2y1 + N * sum_y3 - (sum_x2 + sum_y2) * sum_y;

            a = (H * D - E * G) / (C * G - D * D);
            b = (H * C - E * D) / (D * D - G * C);
            c = -(a * sum_x + b * sum_y + sum_x2 + sum_y2) / N;

            centerX = a / (-2);
            centerY = b / (-2);
            centerRadius = Math.Sqrt(a * a + b * b - 4 * c) / 2;

            return new DrawCircle()
            {
                StartAngle = centerX,
                EndAngle = centerY,
                Radius = centerRadius
            };
        }



    }
}
