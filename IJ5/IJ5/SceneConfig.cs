
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IJ5
{
    class SceneConfig
    {
        
        Scene Act1, Act1_2, Act1_Lose, Act1_Win;        

        public SceneConfig()
        {
            Act1 = new Scene("Ты Орк?", 0);
            Act1_2 = new Scene("Твоя Мать Орк?", 0);
            Act1_Lose = new Scene("Ты проиграл", -1);
            Act1_Win = new Scene("Ты выиграл", 1);

            Act1_2.SetYesorNo(Act1_Win,Act1_Lose);
            Act1.SetYesorNo(Act1_2, Act1_Lose);                       
        }
    }
}