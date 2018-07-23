
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IJ5
{
    class Engine
    {
        SceneTree _st;
        bool GameOver;

        public Engine(SceneTree st)
        {
            _st = st;
        }

        void Update()
        {
            _st.ReadNode();
            if (_st.IsGameOver())
            {
                GameOver = true;
                return;
            }            
            _st.GoToNode(Convert.ToString(Console.ReadLine()));            
        }

        public void Start()
        {

            while (!GameOver)
            {
                Update();
            }
        }

    }
}