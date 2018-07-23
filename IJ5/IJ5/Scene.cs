
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IJ5
{
    class Scene
    {
        string _question;
        Scene _yes;
        Scene _no;

        // state - state level: -1 = you lose, 0 = you continue, 1 = you win;
        int _state;

        public Scene(string question, int state)
        {
            _question = question;
            _state = state;
        }

        public void SetYesorNo(Scene yes, Scene no)
        {
            _yes = yes;
            _no = no;
        }

        public string GetQuestion()
        {
            return _question;
        }

        public int GetState()
        {
            return _state;
        }

        public void Go()
        {

        }
    }
}