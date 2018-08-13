using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJ11
{
    class PointManager
    {
        Canvas _canvas;
        List<Point> _points;
        List<Point> _pointsCenterFloorsForTriangle;


        public PointManager(Canvas canvas)
        {
            _canvas = canvas;
            _points = new List<Point>();
        }

        public void SetMeshPoints(float[] points)
        {
            CheckPoints(points);

            for (int i = 0; i < (points.Length) - 1; i++)
            {
                _points.Add(new Point(points[i], points[i + 1]));
                i++;
            }
        }

        public void SetSquarePoints(float SquareWidth, Point Centre = null)
        {
            if (Centre == null)
            {
                Centre = _canvas.GetCentreCanvas();
            }

            // s1,s2,s3,s4 - square tops
            Point s1 = new Point(Centre.GetX() - SquareWidth / 2, Centre.GetY() - SquareWidth / 2);
            Point s2 = new Point(s1.GetX() + SquareWidth, s1.GetY());
            Point s3 = new Point(s2.GetX(), s2.GetY() + SquareWidth);
            Point s4 = new Point(s3.GetX() - SquareWidth, s3.GetY());

            _points.AddRange(new List<Point> { s1, s2, s3, s4, s1 });
        }

        public void SetRectanglePoints(float RectangleWidth, float RectangleHeight, Point Centre = null)
        {
            if (Centre == null)
            {
                Centre = _canvas.GetCentreCanvas();
            }

            // r1,r2,r3,r4 - rectangle tops
            Point r1 = new Point(Centre.GetX() - RectangleHeight / 2, Centre.GetY() - RectangleWidth / 2);
            Point r2 = new Point(r1.GetX() + RectangleHeight, r1.GetY());
            Point r3 = new Point(r2.GetX(), r2.GetY() + RectangleWidth);
            Point r4 = new Point(r3.GetX() - RectangleHeight, r3.GetY());

            _points.AddRange(new List<Point> { r1, r2, r3, r4, r1 });
        }

        public void SetTrianglePoints(float TriangleHeigh)
        {
            int floors = HowFloorTriangle(TriangleHeigh);
            float SquareWidth = TriangleHeigh / floors;
            Point centerTriangle = _canvas.GetCentreCanvas();
            SetCenterFloors(centerTriangle, floors, SquareWidth);

            for (int i = _pointsCenterFloorsForTriangle.Count() - 1; i >= 0; i--)
            {
                SetSquareCentersAtFloor(i + 1, SquareWidth);
            }
        }

        void SetCenterFloors(Point CenterTriangle, int floors, float SquareWidth)
        {
            _pointsCenterFloorsForTriangle = new List<Point>();
            Point DownPointTriangle = new Point(CenterTriangle.GetX(), CenterTriangle.GetY() + ((floors * SquareWidth) / 2) - (SquareWidth / 2));
            _pointsCenterFloorsForTriangle.Add(DownPointTriangle);
            for (int i = 1; i < floors; i++)
            {
                Point p = new Point(_pointsCenterFloorsForTriangle[i - 1].GetX(), CenterTriangle.GetY() + SquareWidth);
                _pointsCenterFloorsForTriangle.Add(p);
            }
        }

        void SetSquareCentersAtFloor(int floor, float SquareWidth)
        {
            List<Point> _pointsInLine = new List<Point>();
            float WidthLine = floor * SquareWidth;
            Point LeftPoint = new Point(_pointsCenterFloorsForTriangle[floor - 1].GetX() - WidthLine / 2, _pointsCenterFloorsForTriangle[floor - 1].GetY() );
            _pointsInLine.Add(LeftPoint);
            SetSquarePoints(SquareWidth, LeftPoint);
            for (int i = 1; i < floor; i++)
            {
                Point p = new Point(_pointsInLine.Last().GetX() + SquareWidth, _pointsInLine.Last().GetY() );
                _pointsInLine.Add(p);
                SetSquarePoints(SquareWidth, p);
            }
        }


        int HowCountSquare(int Floors)
        {
            return (Floors * (Floors + 1)) / 2;
        }

        int HowFloorTriangle(float TriangleHeigh)
        {
            return (int)TriangleHeigh;
        }

        void CheckPoints(float[] points)
        {
            if (points.Length % 2 != 0)
            {
                throw new ArgumentOutOfRangeException("points", "points is array of paired coordinates");
            }
        }

        public int GetCount()
        {
            return _points.Count;
        }

        public Point GetPoint(int index)
        {
            return _points[index];
        }


    }

    class Point
    {
        float _x;
        float _y;

        public Point(float X, float Y)
        {
            _x = X;
            _y = Y;
        }

        public float GetX()
        {
            return _x;
        }

        public float GetY()
        {
            return _y;
        }
    }

    class Canvas
    {
        float _width;
        float _height;

        public Canvas(float Width, float Height)
        {
            _width = Width;
            _height = Height;
        }

        public Point GetCentreCanvas()
        {
            return new Point(_width / 2, _height / 2);
        }

        public float GetWidth()
        {
            return _width;
        }

        public float GetHeight()
        {
            return _height;
        }

    }
}
