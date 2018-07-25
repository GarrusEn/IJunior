using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IJ5
{
    class SceneTree
    {
        Scene CurrentScene;
        string _sceneName;

        public SceneTree(Scene scene, string nameScene)
        {
            CurrentScene = scene;
            _sceneName = nameScene;
        }

        public string GetSceneName()
        {
            return _sceneName;
        }

        public void ReadNode()
        {
            Console.WriteLine(CurrentScene.GetQuestion());
        }

        public bool IsGameOver()
        {
            if (CurrentScene.GetState() == -1)
            {
                Console.WriteLine("You Lose");
                return true;
            }
            else if (CurrentScene.GetState() == 1)
            {
                Console.WriteLine("You Win");
                return true;
            }
            return false;
        }

        public void GoToNode(string Ask)
        {
            switch (Ask)
            {
                case "yes":
                    CurrentScene = CurrentScene.GetRightNode();
                    break;
                case "no":
                    CurrentScene = CurrentScene.GetLeftNode();
                    break;
                default:
                    Console.WriteLine("Ответ может быть только \"yes\" или \"no\"");
                    break;
            }
        }
    }

    class Scene
    {
        string _question;
        Scene LeftNode;
        Scene RightNode;
        // state - флаг состояния: "-1" - проигрыш, "0" - есть два разветвления, "1" - выигрыш
        int _state;

        public Scene(string question, int state)
        {
            _question = question;
            _state = state;
        }

        public int GetState()
        {
            return _state;
        }

        public string GetQuestion()
        {
            return _question;
        }

        public void SetLeftNode(Scene value)
        {
            LeftNode = value;
        }

        public void SetRightNode(Scene value)
        {
            RightNode = value;
        }

        public Scene GetLeftNode()
        {
            return LeftNode;
        }

        public Scene GetRightNode()
        {
            return RightNode;
        }
    }
}