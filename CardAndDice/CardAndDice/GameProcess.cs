using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardAndDice
{
    internal class GameProcess
    {
        public void Gameing()
        {
            Player playerA = new Player("玩家A");
            Player playerB = new Player("電腦");
            GameMove game=new GameMove();
            int Card_A = 0, Card_B = 0;
            bool gameEnded = false;
            while (!gameEnded)
            {
                gameEnded = game.Walk(playerA, playerB);
                if (gameEnded)
                {
                    Console.WriteLine("遊戲結束！");
                    Console.WriteLine($"分數是100分");
                    break;
                }
                gameEnded = game.Walk(playerB,playerA);
                if (gameEnded)
                {
                    Console.WriteLine("遊戲結束！");
                    Console.WriteLine($"分數是{playerA.GetStep()}分");

                    break;
                }
            }
        }
    }
}
