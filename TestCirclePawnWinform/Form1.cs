using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCirclePawnWinform
{
    public partial class Form1 : Form
    {
        FormPointsAdd formPointsAdd = new FormPointsAdd();
        public Form1()
        {

            InitializeComponent();
            comboBox1.Items.Add(new MyObject() { Value = 1, Name = "三阶贝塞尔曲线" });
            comboBox1.Items.Add(new MyObject() { Value = 2, Name = "样条插值曲线" });
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            PointD[] points = new PointD[formPointsAdd.listBox1.Items.Count];
            var pointAll = formPointsAdd.listBox1.Items;
            for (int i = 0; i < pointAll.Count; i++)
            {
                var point = pointAll[i] as MyObject;
                points[i] = point?.Value as PointD;
            }

            if (points.Count() == 0)
            {
                MessageBox.Show("请添加对应的点位");


            }
            //formPointsAdd.listBox1.Dispose();
            int needDarwCount = 15;
            if (int.TryParse(textBox3.Text, out int value))
            {
                needDarwCount = value;
            }
            else
            {
                MessageBox.Show("请输入准确的点位数量");
                return;
            }

            double[] x_s = new double[points.Count()];
            double[] y_s = new double[points.Count()];
            x_s = points.Select(p => (double)p.X).ToArray();
            y_s = points.Select(p => (double)p.Y).ToArray();
            var selectItem = this.comboBox1.SelectedItem as MyObject;
            if (selectItem != null && (int)selectItem.Value == 1)
            {
                var fitResult = Fit.Polynomial(x_s, y_s, 3);

                // 输出拟合参数，参数顺序为：D, C, B, A
                Func<double, double> equation = x => fitResult[3] * x * x * x + fitResult[2] * x * x + (fitResult[1]) * x + (fitResult[0]);
                label1.Text = $"三阶曲线函数：y= {fitResult[3]} * x * x * x + {fitResult[2]} * x * x + {(fitResult[1])} * x + {(fitResult[0])}";
                FitCircleHelper fitCircleHelper = new FitCircleHelper();
                var circle = fitCircleHelper.LeastSquaresFit(points);

                label2.Text = $"圆心坐标为（{circle.CenterX},{circle.CenterY}）,半径:{circle.Radius}";
                var img = new ImageHelp(512, 512);
                img.DrawPoints(x_s, y_s, Brushes.Red);
                img.DrawCicle(new Circle() { X = circle.CenterY, Y = circle.CenterY, R = circle.Radius }, Brushes.Green);
                // 计算圆弧角度
                double startAngle = fitCircleHelper.AngleBetweenXAxisAndPoint(points[0], circle);
                double endAngle = fitCircleHelper.AngleBetweenXAxisAndPoint(points[points.Length - 1], circle);

                // 转换为[-π, π]
                if (endAngle - startAngle > Math.PI)
                    endAngle -= 2 * Math.PI;
                else if (endAngle - startAngle < -Math.PI)
                    endAngle += 2 * Math.PI;

                //转化度数
                var maxAngle = endAngle - startAngle;

                //等分圆弧
                var minAngle = maxAngle / needDarwCount;
                label3.Text = $"起始弧:{startAngle}，结束弧:{endAngle}，弧度:{maxAngle}";

                //计算等分圆弧
                var arcLength = minAngle * (Math.PI / 180) * circle.Radius;

                PointD[] pointDs = new PointD[needDarwCount];
                List<PointD> points2 = new List<PointD>();
                //一阶函数的斜率
                double m;

                //一阶函数的截距
                double n;

                double[] finalX = new double[needDarwCount];
                double[] finalY = new double[needDarwCount];

                StringBuilder stringBuilder = new StringBuilder();
                StringBuilder stringBuilder2 = new StringBuilder();

                for (int i = 0; i < needDarwCount; i++)
                {
                    pointDs[i] = new PointD(Math.Cos(minAngle * i) * circle.Radius, Math.Sin(minAngle * i) * circle.Radius);
                    points2.Add(new PointD(circle.CenterX, circle.CenterY));
                    points2.Add(new PointD(Math.Cos(minAngle * i) * circle.Radius, Math.Sin(minAngle * i) * circle.Radius));
                    stringBuilder.Append($"坐标=>x:{pointDs[i].X},y:{pointDs[i].Y}\r\n");
                    //计算一阶函数
                    FitLine(points2, out m, out n);
                    // 定义三次方程 f(x) - g(x) = 0
                    Func<double, double> equation2 = x => fitResult[3] * x * x * x + fitResult[2] * x * x + (fitResult[1] - m) * x + (fitResult[0] - n);

                    // 使用FindRoots方法找到所有实数根
                    var root = FindRoots.OfFunctionDerivative(equation2, x => 3 * fitResult[3] * x * x + 2 * fitResult[2] * x + (fitResult[1] - m), -10, 10);
                    var y = fitResult[3] * root * root * root + fitResult[2] * root * root + fitResult[1] * root + fitResult[0];
                    points2.Clear();
                    finalX[i] = root;
                    finalY[i] = y;

                    stringBuilder2.Append($"坐标=>x:{root},y:{y}\r\n");

                }
                textBox1.Text = stringBuilder.ToString();
                textBox2.Text = stringBuilder2.ToString();
                img.DrawPoints(pointDs.Select(p => p.X).ToArray(), pointDs.Select(p => p.Y).ToArray(), Brushes.Yellow);

                img.DrawPoints(finalX, finalY, Brushes.Blue);

                this.pictureBox1.Image = img._image;
            }
            else
            {

            }

        }

        public static PointD FindBezierFunctionIntersection(PointD bPoint1, PointD bPoint2, PointD bPoint3, PointD bPoint4, double a, double b)
        {
            // 计算贝塞尔曲线的导数，即二次方程
            double c = 3 * (bPoint2.Y - bPoint1.Y) - 3 * bPoint1.Y + bPoint1.Y;
            double b2 = 3 * (bPoint1.Y - 2 * bPoint2.Y + bPoint3.Y);
            double a2 = bPoint2.Y - 2 * bPoint1.Y + bPoint1.Y;

            // 解二次方程
            double discriminant = b2 * b2 - 4 * a2 * c;
            if (discriminant < 0)
            {
                // 没有实数解
                return null;
            }

            double t1 = (-b2 + Math.Sqrt(discriminant)) / (2 * a2);
            double t2 = (-b2 - Math.Sqrt(discriminant)) / (2 * a2);

            // 确保t值在[0, 1]范围内
            if (t1 >= 0 && t1 <= 1)
            {
                // 计算对应的y值
                double y = a * t1 * (t1 * (t1 - 2) + 1) + b * t1 * (t1 - 1) + t1;

                // 根据贝塞尔曲线的公式计算对应的x值
                double x = t1 * (t1 * (t1 - 2 * bPoint1.X + bPoint2.X) - 2 * bPoint1.X + bPoint2.X) + bPoint1.X;

                return new PointD(x, y);
            }
            else if (t2 >= 0 && t2 <= 1)
            {
                // 计算对应的y值
                double y = a * t2 * (t2 * (t2 - 2) + 1) + b * t2 * (t2 - 1) + t2;

                // 根据贝塞尔曲线的公式计算对应的x值
                double x = t2 * (t2 * (t2 - 2 * bPoint1.X + bPoint2.X) - 2 * bPoint1.X + bPoint2.X) + bPoint1.X;

                return new PointD(x, y);
            }
            return null;
        }

        /// <summary>
        /// 定义一阶函数，这里使用的是匿名函数
        /// </summary>
        /// <param name="slope">A</param>
        /// <param name="yIntercept">B</param>
        /// <returns></returns>
        public Func<double, double> CreateLinearFunction(double slope, double yIntercept)
        {
            return x => slope * x + yIntercept;
        }

        /// <summary>
        /// 计算一阶函数A,B
        /// </summary>
        /// <param name="points"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void FitLine(List<PointD> points, out double a, out double b)
        {
            int n = points.Count;
            double sumX = points.Sum(p => p.X);
            double sumY = points.Sum(p => p.Y);
            double sumX2 = points.Sum(p => p.X * p.X);
            double sumXY = points.Sum(p => p.X * p.Y);

            a = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            b = (sumY - a * sumX) / n;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formPointsAdd.StartPosition = FormStartPosition.CenterScreen;
            //if(formPointsAdd.listBox1.Items!=null)
            formPointsAdd.ShowDialog();
        }
    }
}
