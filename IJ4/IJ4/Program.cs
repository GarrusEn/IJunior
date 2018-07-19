using System;

namespace Delegates
{
    class LongList
    {
        string[][] MyLists = new string[3][];
        public LongList()
        {
            for (int i = 0; i < MyLists.Length; i++)
            {
                MyLists[i] = new string[0];
            }
        }

        public int WitchMax()
        {
            int maxIndex;
            maxIndex = MyLists[0].Length > MyLists[1].Length ? MyLists[0].Length : MyLists[1].Length;
            maxIndex = maxIndex > MyLists[2].Length ? maxIndex : MyLists[2].Length;
            return maxIndex;
        }

        public void ShowMeTheSheets()
        {
            Console.WriteLine("Личный | Рабочий | Семейный");

            for (int i = 0; i < WitchMax(); i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (MyLists[j].Length > i)
                    {
                        Console.Write(MyLists[j][i] + " | ");
                    }
                    else
                    {
                        Console.Write("Empty | ");
                    }
                }
                Console.WriteLine();
            }
            

        }

        public void AddTargetTo(int targetIndex, string target)
        {
            string[] newList = new string[MyLists[targetIndex].Length + 1];
            for (int i = 0; i < MyLists[targetIndex].Length; i++)
            {
                newList[i] = MyLists[targetIndex][i];
            }
            newList[newList.Length - 1] = target;
            MyLists[targetIndex] = newList;
        }

        public void AddTarget()
        {
            Console.WriteLine("Куда вы хотите добавить цель?");
            string listName = Console.ReadLine().ToLower(); //то что введёт пользователь переведённое в нижний регистр
            Console.WriteLine("Что это за цель?");
            string goal = Console.ReadLine();
            int targetIndex = new int();
            switch (listName)
            {
                case "личный":
                    targetIndex = 0;
                    break;
                case "рабочий":
                    targetIndex = 1;
                    break;
                case "семейный":
                    targetIndex = 2;
                    break;
                default:
                    break;
            }
            AddTargetTo(targetIndex, goal);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LongList myList = new LongList();

            while (true)
            {
                Console.Clear();
                myList.ShowMeTheSheets();
                myList.AddTarget();
            }
        }

    }
}