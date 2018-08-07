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
            _coloreManager = new ColoreManager();
            StartDrow();
        }

        public void DrawMesh(int[] points, Color color)
        {
            SetPoints(points);
            _coloreManager = new ColoreManager(color);
            StartDrow();
        }

        public void DrawMesh(int[] points,Color[] colors)
        {
            SetPoints(points);
            _coloreManager = new ColoreManager(colors);
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
            for (int i = 0; i < _pointManager.GetCount()-1; i++)
            {
                DrawLine(_pointManager.GetPoint(i),_pointManager.GetPoint(i+1));                
            }

            Save();
        }

        void DrawLine(Point p1,Point p2)
        {
            Pen pen = new Pen(_coloreManager.GetColor(), 2);
            _drawer.DrawLine(pen,p1.GetX(),p1.GetY(),p2.GetX(),p2.GetY());
        }

        void Save()
        {
            _drawer.Flush();
            _canvas.Save("canvas.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
