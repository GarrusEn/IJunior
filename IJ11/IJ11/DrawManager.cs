using System;
using System.Drawing;

namespace IJ11
{
    class DrawManager
    {
        Bitmap _canvas;
        Graphics _drawer;
        PointManager _pointManager;
        protected ColorManager _colorManager;

        protected DrawManager(int WidthCanvas, int HeighCanvas)
        {
            _canvas = new Bitmap(WidthCanvas, HeighCanvas);
            _drawer = Graphics.FromImage(_canvas);
            _drawer.FillRectangle(Brushes.White, new Rectangle(0, 0, WidthCanvas, HeighCanvas));
        }

        protected void SetPoints(int[] points)
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

        protected void StartDrow()
        {
            for (int i = 0; i < _pointManager.GetCount() - 1; i++)
            {
                DrawLine(_pointManager.GetPoint(i), _pointManager.GetPoint(i + 1));
            }
            Save();
        }

        void DrawLine(Point p1, Point p2)
        {
            Pen pen = new Pen(_colorManager.GetColor(), 2);
            _drawer.DrawLine(pen, p1.GetX(), p1.GetY(), p2.GetX(), p2.GetY());
        }

        void Save()
        {
            _drawer.Flush();
            _canvas.Save("canvas.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }

    class DrawMesh : DrawManager
    {
        public DrawMesh(int WidthCanvas, int HeighCanvas, int[] points) : base(WidthCanvas, HeighCanvas)
        {
            SetPoints(points);
            _colorManager = new ColorManager();
            StartDrow();
        }

        public DrawMesh(int WidthCanvas, int HeighCanvas, int[] points, Color color) : base(WidthCanvas, HeighCanvas)
        {
            SetPoints(points);
            _colorManager = new ColorManager(color);
            StartDrow();
        }

        public DrawMesh(int WidthCanvas, int HeighCanvas, int[] points, Color[] colors) : base(WidthCanvas, HeighCanvas)
        {
            SetPoints(points);
            _colorManager = new ColorManager(colors);
            StartDrow();
        }
    }

    class DrowRectangle : DrawManager
    {
        int _heigh;
        int _width;

        public DrowRectangle(int WidthCanvas, int HeightCanvas, int HeighRectangle, int WidthRectangle) : base(WidthCanvas, HeightCanvas)
        {
            _heigh = HeighRectangle;
            _width = WidthRectangle;

        }


    }
}
