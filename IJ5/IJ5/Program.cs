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
            // Соберём парочку цепочек сцен из говна и палок
            Scene Act1 = new Scene("Ты куда прёшь, пропуск есть у тебя?", 0);
            Act1.SetLeftNode(new Scene("Убирайся отсюда или я позову стражу", -1));
            Act1.SetRightNode(new Scene("Так посмотрим, выходит ты на службу явился?", 0));
            Act1.GetRightNode().SetLeftNode(new Scene("Нам тут посторонние ни к чему, катись отсюда", -1));
            Act1.GetRightNode().SetRightNode(new Scene("Добро пожаловать в наши славные ряды солдат!", 1));

            Scene Act2 = new Scene("Помоги дедушке, дай пару монет горло смочить?", 0);
            Act2.SetLeftNode(new Scene("Ну и что подошёл тогда. Ходят тут всякие!", -1));
            Act2.SetRightNode(new Scene("О, смотрю ты хороший человек, тебе в казарму попасть надо?", 0));
            Act2.GetRightNode().SetLeftNode(new Scene("А я и не спрашивал у тебя ничего про казарму", -1));
            Act2.GetRightNode().SetRightNode(new Scene("Тут пьяный офицер как-то ключ обронил, а я его нашёл. Возьми, мне он ни к чему", 1));


            List<SceneTree> st = new List<SceneTree>();
            st.Add(new SceneTree(Act1, "Стражник у ворот казармы."));
            st.Add(new SceneTree(Act2, "Нетрезвый старик у стены."));

            for (int i = 0; i < st.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {st[i].GetSceneName()}");
            }

            Console.WriteLine("Выберите сцену");

            int act = Convert.ToInt32(Console.ReadLine());


            if (act < st.Count && act > 0)
            {
                Engine engine = new Engine(st[act - 1]);
                engine.Start();
            }
            else { Console.WriteLine("неверный номер сцены"); }

            Console.WriteLine("Игра всё");
            Console.ReadLine();
        }
    }
}
