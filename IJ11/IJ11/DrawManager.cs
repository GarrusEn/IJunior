using System;
using System.Drawing;

namespace IJ11
{
    class DrawManager
    {
        Bitmap _canvas;
        Graphics _drawer;
        Color _defaultColor = Color.Red;
        PointManager _pointManager;
        ColoreManager _coloreManager;

        public DrawManager(int WidthCanvas, int HeightCanvas)
        {
            _canvas = new Bitmap(WidthCanvas, HeightCanvas);
            _drawer = Graphics.FromImage(_canvas);
            _drawer.FillRectangle(Brushes.White, new Rectangle(0, 0, WidthCanvas, HeightCanvas));
        }

        public void DrawMesh(int[] points)
        {
            SetPoints(points);
            StartDrow();
        }

        void SetPoints(int[] points)
        {
            _pointManager = new PointManager(points);
        }

        // Print points
        void PrintPoints()
        {
            for (int i = 0; i < _pointManager.GetCount(); i++)
            {
                Console.WriteLine($"point X:{_pointManager.GetPoint(i).GetX()} Y:{_pointManager.GetPoint(i).GetY()}\n");
            }
        }

        void StartDrow()
        {
            for (int i = 0; i < _pointManager.GetCount(); i++)
            {
                DrawLine(_pointManager.GetPoint(i),_pointManager.GetPoint(i+1));
                i++;
            }
        }

        void DrawLine(Point p1,Point p2)
        {
            //Pen pen = new Pen(color, 2);
            //_drawer.DrawLine();
        }

        void Save()
        {
            _drawer.Flush();
            _canvas.Save("canvas.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
