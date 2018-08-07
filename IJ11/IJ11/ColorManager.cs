using System.Collections.Generic;
using System.Drawing;

namespace IJ11
{
    class ColoreManager
    {
        List<ColorNode> colors = new List<ColorNode>();
        Color _color;
        ColorNode _currentColor;

        // State of color manager: -1 default color, 0 concrette color, 1 several colors 
        int state;

        // Default color
        public ColoreManager()
        {
            _color = Color.Red;
            state = -1;
        }

        // Custom color
        public ColoreManager(Color color)
        {
            _color = color;
            state = 0;
        }

        // Several colors
        public ColoreManager(Color[] Colors)
        {
            for (int i = 0; i < Colors.Length; i++)
            {
                colors.Add(new ColorNode(Colors[i]));
                if (i > 0)
                {
                    colors[i - 1].SetNextColor(colors[i]);
                }
                if (i == colors.Count - 1)
                {
                    colors[i].SetNextColor(colors[0]);
                }
            }
            _currentColor = colors[0];
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

        public ColorNode(Color color)
        {
            _color = color;
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
