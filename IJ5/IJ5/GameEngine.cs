using System;
using System.Collections.Generic;

namespace IJ5
{
    class GameEngine
    {
        List<Dialog> scenes = new List<Dialog>();
        PlayerGUI _player;

        public GameEngine()
        {
            // Сцена 1
            scenes.Add(new Dialog(new string[]
            { "Ты орк?", "Твоя мать орк?" },
            "Диалог с тупым и пьяным орком"));

            // Сцена 2
            scenes.Add(new Dialog(new string[]
            { "У тебя пропуск есть?", "В 11 уйдёшь?"},
            "Диалог с вахтовичкой в общаге"));

            // Сцена 3
            scenes.Add(new Dialog(new string[]
            { "Тебе налить?", "Ещё по одной?", "Ещё по одной?" },
            "Диалог с барменом"));

            _player = new PlayerGUI(scenes);

        }

        public void Start()
        {
            while (true)
            {
                _player.ShowAll();
                var scene = Convert.ToInt32(Console.ReadLine());
                if (scene is Int32)
                {
                    if (scene > 0 && scene <= scenes.Count)
                    {
                        _player.Start(scene - 1);
                    }
                    else
                    {
                        Console.WriteLine("Такой сцены нет");
                    }
                }
                else break;
            }
        }
    }
}
