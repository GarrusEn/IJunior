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

        public DrawManager(int WidthCanvas, int HeightCanvas)
        {
            _canvas = new Bitmap(WidthCanvas, HeightCanvas);
            _drawer = Graphics.FromImage(_canvas);
            _drawer.FillRectangle(Brushes.White, new Rectangle(0, 0, WidthCanvas, HeightCanvas));
        }      

        public void SetPoints(int[] points)
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

       public  void StartDrow()
        {
            for (int i = 0; i < _pointManager.GetCount()-1; i++)
            {
                DrawLine(_pointManager.GetPoint(i),_pointManager.GetPoint(i+1));                
            }
            Save();
        }

        void DrawLine(Point p1,Point p2)
        {
            Pen pen = new Pen(_colorManager.GetColor(), 2);
            _drawer.DrawLine(pen,p1.GetX(),p1.GetY(),p2.GetX(),p2.GetY());
        }

        void Save()
        {
            _drawer.Flush();
            _canvas.Save("canvas.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }

    class Mesh : DrawManager
    {
        public Mesh(int WidthCanvas, int HeightCanvas, int[] points) : base(WidthCanvas, HeightCanvas)
        {
            SetPoints(points);
            _colorManager = new ColorManager();
            StartDrow();
        }

        public Mesh(int WidthCanvas, int HeightCanvas, int[] points, Color color) : base(WidthCanvas, HeightCanvas)
        {
            SetPoints(points);
            _colorManager = new ColorManager(color);
            StartDrow();
        }

        public Mesh(int WidthCanvas, int HeightCanvas, int[] points, Color[] colors) : base(WidthCanvas, HeightCanvas)
        {
            SetPoints(points);
            _colorManager = new ColorManager(colors);
            StartDrow();
        }
    }

     
}
