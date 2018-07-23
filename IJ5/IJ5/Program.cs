using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJ5
{
    class Program
    {
        static void Main(string[] args)
        {
            SceneConfig sceneConf = new SceneConfig();
            Engine engine = new Engine(sceneConf);
            engine.Start();
        }
    }
}
