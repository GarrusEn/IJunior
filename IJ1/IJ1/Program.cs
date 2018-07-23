using System;
using System.Collections.Generic;

namespace IJ1
{

    //public QuestionsAndAnswers()
    //{
    //    // Fill in the strings
    //    _answers = new string[3][]
    //    {
    //        new string[] { "Человек", "Брандлмуха", "Кхаджит" },
    //        new string[] { "Победить Аразота", "Стать богатым", "Найти боевых товарищей" },
    //        new string[] { "Я отлчиный воин", "Я добротный маг", "Я могу работать в кузнице" }
    //    };
    //    _questions = new string[3] { "Кто вы?", "Что вы хотите?",  };
    //    _isDoorOpen = new bool[] { false, false, false };

    //    // First message
    //    Console.WriteLine("Совершенно очевидно, что мы не берём в наш орден кого попало. По этому заполни вот эту анкету, " +
    //                     "и мы примем решение, брать тебя или нет");
    //}


    class Act
    {
        private string _question;
        private string[] _answers;
        private bool _door;

        public Act(string question, string[] answers)
        {
            _question = question;
            _answers = answers;
            _door = false;
        }

        public void AskMe()
        {
            Console.WriteLine(_question);
            for (int i = 0; i < _answers.Length; i++)
            {
                Console.WriteLine("[{0}]>{1}", i, _answers[i]);
            }
            Console.ReadLine();
            _door = true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Act> acts = new List<Act>();

            Act act1 = new Act("Кто вы?", new string[] { "Человек", "Брандлмуха", "Кхаджит" });
            Act act2 = new Act("Что вы хотите?", new string[] { "Победить Аразота", "Стать богатым", "Найти боевых товарищей" });
            Act act3 = new Act("Чем вы можете помочь ордену?",
                new string[] { "Я отлчиный воин", "Я добротный маг", "Я могу работать в кузнице" });

            acts.Add(act1);
            acts.Add(act2);
            acts.Add(act3);        

            for (int i = 0; i < 3; i++)
            {
                acts[i].AskMe();
            }
        }
    }
}
