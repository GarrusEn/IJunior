using System;
using System.Drawing;


namespace IJ11
{

    class Program
    {
        static void Main(string[] args)
        {
            

            // Any pairs points for drow 
            int[] points = {
                10,10,
                13,17,
                26,40,
                47,13,
                31,97,
                44,71,
                68,37,
                57,40,
                10,10
            };

            Color[] colors =
            {
                Color.Green,
                Color.Blue,
                Color.Orange
            };

            DrawMesh mesh = new DrawMesh(100, 100, points, colors);


        }
    }
}
