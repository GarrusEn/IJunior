using System.Collections.Generic;
using System.Drawing;

namespace IJ11
{
    class Palette
    {
        List<ColorNode> _colors = new List<ColorNode>();
        Color _color;
        ColorNode _currentColor;

        //State of color plette: -1 default, 0 concrette color, 1 several colors
        int state;

        // Default color
        public Palette()
        {
            _color = Color.Red;
            state = -1;
        }

        // Custom color
        public Palette(Color Color)
        {
            _color = Color;
            state = 0;
        }

        // Several colors
        public Palette(Color[] Colors)
        {
            for (int i = 0; i < Colors.Length; i++)
            {
                _colors.Add(new ColorNode(Colors[i]));
                if (i > 0)
                {
                    _colors[i - 1].SetNextColor(_colors[i]);
                }
                if (i == _colors.Count - 1)
                {
                    _colors[i].SetNextColor(_colors[0]);
                }
            }
            _currentColor = _colors[0];
            state = 1;
        }

        public Color GetColor()
        {
            if (state == -1 || state == 0) return _color;
            else return GetNextColor();
        }

        Color GetNextColor()
        {
            Color currentColor = _currentColor.GetColor();
            _currentColor = _currentColor.GetNextNode();
            return currentColor;
        }
    }

    class ColorNode
    {
        ColorNode _nextNode;
        Color _color;

        public ColorNode(Color Color)
        {
            _color = Color;
        }

        public void SetNextColor(ColorNode NextColorNode)
        {
            _nextNode = NextColorNode;
        }

        public ColorNode GetNextNode()
        {
            return _nextNode;
        }

        public Color GetColor()
        {
            return _color;
        }
    }
}
