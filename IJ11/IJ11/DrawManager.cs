using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJ11
{
    class DrawManager
    {
        protected Canvas _canvas;
        protected Palette _palette;
        protected PointManager _points;
        protected Drawer draw;

        protected DrawManager(float CanvasHeigh, float CanvasWidth)
        {
            _canvas = new Canvas(CanvasHeigh, CanvasWidth);
            _points = new PointManager(_canvas);
            _palette = new Palette();
        }

        virtual public void Draw()
        {
            draw = new Drawer(_points, _palette, _canvas);
            draw.StartDrow();
        }
    }

    class DrawMesh : DrawManager
    {
        public DrawMesh(float CanvasHeigh, float CanvasWidth, float[] Points) : base(CanvasHeigh, CanvasWidth)
        {
            _points.SetMeshPoints(Points);
        }

        public DrawMesh(float CanvasHeigh, float CanvasWidth, float[] Points, Color Color) : base(CanvasHeigh, CanvasWidth)
        {
            _points.SetMeshPoints(Points);
            _palette = new Palette(Color);
        }

        public DrawMesh(float CanvasHeigh, float CanvasWidth, float[] Points, Color[] Colors) : base(CanvasHeigh, CanvasWidth)
        {
            _points.SetMeshPoints(Points);
            _palette = new Palette(Colors);
        }

        override public void Draw()
        {
            base.Draw();
        }
    }

    class DrawRectangle : DrawManager
    {
        public DrawRectangle(float CanvasHeigh, float CanvasWidth, float RectangleWidth, float RectangleHeight) : base(CanvasHeigh, CanvasWidth)
        {
            _points.SetRectanglePoints(RectangleWidth, RectangleHeight);
        }

        public DrawRectangle(float CanvasHeigh, float CanvasWidth, float RectangleWidth, float RectangleHeight, Color Color) : base(CanvasHeigh, CanvasWidth)
        {
            _points.SetRectanglePoints(RectangleWidth, RectangleHeight);
            _palette = new Palette(Color);
        }

        public override void Draw()
        {
            base.Draw();
        }
    }

    class DrawSquare : DrawManager
    {
        public DrawSquare(float CanvasHeigh, float CanvasWidth, float SquareWidth) : base(CanvasHeigh, CanvasWidth)
        {
            _points.SetSquarePoints(SquareWidth);
        }

        public DrawSquare(float CanvasHeigh, float CanvasWidth, float SquareWidth, Color Color) : base(CanvasHeigh, CanvasWidth)
        {
            _points.SetSquarePoints(SquareWidth);
            _palette = new Palette(Color);
        }

        public override void Draw()
        {
            base.Draw();
        }        
    }

    class DrawTriangle : DrawManager
    {
        public DrawTriangle(float CanvasHeigh, float CanvasWidth, float TriangleHeigh) : base(CanvasHeigh, CanvasWidth)
        {
            _points.SetTrianglePoints(TriangleHeigh);
        }

        public DrawTriangle(float CanvasHeigh, float CanvasWidth, float TriangleHeigh, Color[] Colors) : base(CanvasHeigh, CanvasWidth)
        {
            _points.SetTrianglePoints(TriangleHeigh);
            _palette = new Palette(Colors);
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
