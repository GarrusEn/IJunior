using System;

namespace IJ6
{
    class Stack
    {
        int[] Data = new int[1];
        int Top = -1;
        Random r = new Random();

        public void ShowCakes()
        {
            Console.WriteLine($"На тарелке сейчас {Top+1} блинов");
        }

        public void CookCake()
        {
            Top++;
            SacramentOfCreationCake();
        }

        void SacramentOfCreationCake()
        {
            var old = Data;
            Data = new int[old.Length + 1];
            Array.Copy(old, Data, old.Length);

            int calories = r.Next(1, 20);
            Console.WriteLine($"Вы испекли блинчик с {calories} калориями");

            Data[Top] = calories;
            
        }
        
        public void EatCake()
        {
            if(Top >= 0)
            {
                Console.WriteLine($"В блинчике {Data[Top]} калорий");
                Top--;
            }
            else
            {
                Console.WriteLine("Сначала надо испеч блинчик");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack pancakes = new Stack();
            bool AreYouHungry = false;

            Console.WriteLine("Вы можете использовать команды: eat // cook // stop");

            while (!AreYouHungry)                
            {
                pancakes.ShowCakes();                
                Console.WriteLine("Что вы хотите?");
                string command = Console.ReadLine();
                
                switch (command)
                {                    
                    case "eat":
                        pancakes.EatCake();
                        break;
                    case "cook":
                        pancakes.CookCake();
                        break;
                    case "stop":
                        AreYouHungry = true;
                        break;
                    default:
                        break;
                }
            }            
        }
    }
}
