using System;

namespace IJ1
{
    class QuestionsAndAnswers
    {
        string[][] _answers;
        string[] _questions;
        bool[] _isDoorOpen;

        public QuestionsAndAnswers()
        {
            // Fill in the strings
            _answers = new string[3][]
            {
                new string[] { "Человек", "Брандлмуха", "Кхаджит" },
                new string[] { "Победить Аразота", "Стать богатым", "Найти боевых товарищей" },
                new string[] { "Я отлчиный воин", "Я добротный маг", "Я могу работать в кузнице" }
            };
            _questions = new string[3] { "Кто вы?", "Что вы хотите?", "Чем вы можете помочь ордену?" };
            _isDoorOpen = new bool[] { false, false, false };

            // First message
            Console.WriteLine("Совершенно очевидно, что мы не берём в наш орден кого попало. По этому заполни вот эту анкету, " +
                             "и мы примем решение, брать тебя или нет");
        }

        public void AskMe(int index)
        {
            Console.WriteLine(_questions[index]);
            for (int i = 0; i < _answers[index].Length; i++)
            {
                Console.WriteLine("[{0}]>{1}", i, _answers[index][i]);
            }
            Console.ReadLine();
            _isDoorOpen[index] = true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            QuestionsAndAnswers act = new QuestionsAndAnswers();

            for (int i = 0; i < 3; i++)
            {
                act.AskMe(i);
            }
        }
    }
}
