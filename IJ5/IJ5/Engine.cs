
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IJ5
{
    class Engine
    {
        SceneConfig sc;
        bool GameOver;

        public Engine(SceneConfig config)
        {
            sc = config;
        }

        void Update()
        {

        }

        public void Start()
        {
            while (!GameOver)
            {
                Update()
            }
        }

    }
}