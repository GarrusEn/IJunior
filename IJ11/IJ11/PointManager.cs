using System;
using System.Collections.Generic;

namespace IJ11
{
    class PointManager
    {
        List<Point> _points = new List<Point>();



        // Custom points
        public PointManager(int[] points)
        {            
            CheckPoints(points);

            for (int i = 0; i < (points.Length) - 1; i++)
            {
                _points.Add(new Point(points[i], points[i + 1]));
                i++;
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


        

        // Check valid points
        void CheckPoints(int[] points)
        {
            if (points.Length % 2 != 0)
            {
                throw new ArgumentOutOfRangeException("points", "points is array of paired coordinates");
            }
        }
    }

    struct Point
    {
        int _x, _y;

        public Point(int X, int Y)
        {
            _x = X;
            _y = Y;
        }

        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _y;
        }
    }
}
