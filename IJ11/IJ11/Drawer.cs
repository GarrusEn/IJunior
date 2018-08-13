using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJ11
{
    class Drawer
    {
        Graphics _drawer;
        Bitmap _canvas;
        PointManager _points;
        Palette _palette;

        public Drawer(PointManager Points, Palette Palette, Canvas Canvas)
        {
            _points = Points;
            _palette = Palette;
            _canvas = new Bitmap((int)Canvas.GetWidth(), (int)Canvas.GetHeight());
            _drawer = Graphics.FromImage(_canvas);
            _drawer.FillRectangle(Brushes.White, new Rectangle(0, 0, (int)Canvas.GetWidth(), (int)Canvas.GetHeight()));
        }

        public void StartDrow()
        {
            for (int i = 0; i < _points.GetCount() - 1; i++)
            {
                DrawLine(_points.GetPoint(i), _points.GetPoint(i + 1),_palette.GetColor());
            }
            Save();
        }        

        void DrawLine(Point p1, Point p2, Color color)
        {
            Pen pen = new Pen(color, 2);
            _drawer.DrawLine(pen, p1.GetX(), p1.GetY(), p2.GetX(), p2.GetY());
        }

        void Save()
        {
            _drawer.Flush();
            _canvas.Save("canvas.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
