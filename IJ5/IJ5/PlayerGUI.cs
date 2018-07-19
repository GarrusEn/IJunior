using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJ5
{
    class PlayerGUI
    {
        List<Dialog> _scenes;

        public PlayerGUI(List<Dialog> scenes)
        {
            _scenes = scenes;
        }
        public void ShowAll()
        {
            Console.WriteLine($"Наши великие гейм-дизайнеры придумали аж целых {_scenes.Count} сцен");
            Console.WriteLine("Выберите номер сцены");            
            for (int i = 0; i < _scenes.Count; i++)
            {
                Console.WriteLine($"{i+1}- {_scenes[i].nameDialog}");
            }
        }
        public void Start(int index)
        {
            _scenes[index].StartDialog();
        }

    }
}
