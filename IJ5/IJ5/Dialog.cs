using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJ5
{
    class Dialog
    {
        public string nameDialog;
        string[] _questions;
        string[] _answers = new string[] { "да", "нет" };

        public Dialog(string[] questions, string name)
        {
            _questions = questions;
            nameDialog = name;
        }

        public void StartDialog()
        {
            foreach (var question in _questions)
            {
                Console.WriteLine(question);
                string ask = Convert.ToString(Console.ReadLine());
                if (ask == _answers[0])
                {
                    Console.WriteLine("Ответ Верный");
                }
                else if (ask != _answers[1])
                {
                    Console.WriteLine("Отвечай только \"да\" или \"нет\"");
                    break;
                }
                else
                {
                    Console.WriteLine("Пошёл отсюдова");
                    break;                }
            }
        }        
    }
}
