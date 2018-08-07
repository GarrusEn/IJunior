using System;
using System.Drawing;

namespace IJ11
{
    class Drawer
    {
        Bitmap _canvas;
        Graphics _drawer;
        Color _defaultColor = Color.Red;

        public Drawer(int WidthCanvas, int HeightCanvas)
        {
            _canvas = new Bitmap(WidthCanvas, HeightCanvas);
            _drawer = Graphics.FromImage(_canvas);
            _drawer.FillRectangle(Brushes.White, new Rectangle(0, 0, WidthCanvas, HeightCanvas));
        }

        void CheckPoints(int[] points)
        {
            if (points.Length % 2 != 0)
            {
                throw new ArgumentOutOfRangeException("points", "points is array of paired coordinates");
            }
        }

        public void DrawMesh(int[] points)
        {
            CheckPoints(points);

            for (int i = 0; i < (points.Length / 2) - 1; i++)
            {
                int[] point1 = GetPoint(points, i);
                int[] point2 = GetPoint(points, i + 1);
                DrawLine(point1, point2, _defaultColor);
            }

            Save();
        }

        public void DrawMesh(int[] points, Color[] colors)
        {
            ColoreManager DrawColors = new ColoreManager(colors);

            CheckPoints(points);

            for (int i = 0; i < (points.Length / 2) - 1; i++)
            {
                int[] point1 = GetPoint(points, i);
                int[] point2 = GetPoint(points, i + 1);
                DrawLine(point1, point2, DrawColors.GetNextColor());
            }

            Save();
        }

        void DrawLine(int[] fromPoint, int[] toPoint, Color color)
        {
            Pen pen = new Pen(color, 2);
            _drawer.DrawLine(pen, fromPoint[0], fromPoint[1], toPoint[0], toPoint[1]);
        }

        static int[] GetPoint(int[] points, int index)
        {
            int[] point = new int[2];
            int pointStart = index * 2;
            point[0] = points[pointStart];
            point[1] = points[pointStart + 1];
            return point;
        }

        void Save()
        {
            _drawer.Flush();
            _canvas.Save("canvas.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
