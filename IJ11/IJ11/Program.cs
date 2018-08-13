using System;
using System.Drawing;


namespace IJ11
{

    class Program
    {
        static void Main(string[] args)
        {


            // Any pairs points for drow 
            float[] points = {
                10,10,
                13,17,
                26,40,
                47,13,
                80,27,
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

            //DrawMesh dm = new DrawMesh(100, 100, points, colors);
            //dm.Draw();

            //DrawSquare ds = new DrawSquare(100, 100, 45);
            //ds.Draw();

            DrawRectangle dr = new DrawRectangle(100, 100, 30, 60, Color.Aquamarine);
            dr.Draw();
        }
    }
}
