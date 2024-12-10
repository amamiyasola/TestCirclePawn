﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace TestCirclePawn
{
    public class ImageHelp
    {
        private Image _image;
        public ImageHelp(int width, int height)
        {
            _image = new Bitmap(width, height);
            var graph = Graphics.FromImage(_image);
            graph.Clear(Color.White);
        }
        public void DrawCicle(Circle circle, Brush brush)
        {
            var graph = Graphics.FromImage(_image);
            var count = 200;
            var fitPoints = new Point[count + 1];
            var step = 2 * Math.PI / count;
            for (int i = 0; i < count; i++)
            {
                //circle
                var p = new Point();
                p.X = (int)(circle.X + Math.Cos(i * step) * circle.R);
                p.Y = (int)(circle.Y + Math.Sin(i * step) * circle.R);
                fitPoints[i] = p;
            }
            fitPoints[count] = fitPoints[0];//闭合圆
            graph.DrawLines(new Pen(brush, 2), fitPoints);
            graph.Dispose();
        }
        public void DrawPoints(double[] X, double[] Y, Brush brush)
        {
            var graph = Graphics.FromImage(_image);
            for (int i = 0; i < X.Length; i++)
            {
                graph.DrawEllipse(new Pen(brush, 2), (int)X[i], (int)Y[i], 6, 6);
            }
            graph.Dispose();
        }
        public void SaveImage(string file)
        {
            _image.Save(file, System.Drawing.Imaging.ImageFormat.Png);
        }
    }

}
