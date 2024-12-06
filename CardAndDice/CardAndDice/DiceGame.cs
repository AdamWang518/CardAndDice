using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardAndDice
{
    internal class DiceGame
    {
        public void Gameing()
        {
            //封裝: 使用者不應該也不需要知道該類別或該方法是如何被實現的，只要
            Player playerA = new Player("玩家A");
            playerA.TotalStep = 110;
            Player playerB = new Player("電腦");
            GameMove game = new GameMove();
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
                gameEnded = game.Walk(playerB, playerA);
                if (gameEnded)
                {
                    Console.WriteLine("遊戲結束！");
                    Console.WriteLine($"分數是{playerA.GetStep()}分");
                    break;
                }
            }

        }
        public bool Walk(Player me, Player opponent)
        {

            int tempStep = RollDice();
            int step = me.GetStep();
            if (me.getCard() != 0)
            {
                Console.WriteLine($"{me.GetName()} 受卡片效果影響，本回合移動將變化");
                tempStep = useCard(me.getCard(), tempStep);
                me.setCard(0);
            }
            step += tempStep;
            Console.WriteLine($"{me.GetName()} 擲骰子，移動了 {tempStep} 步，當前位置：{step}");
            //兔子卡，每次移動步數 +2，持續一回合
            //烏龜卡，每次移動步數 -2，但若擲出步數 <=3，就走 1 步(至少可以走一步的意思)，持續一回合
            //天使卡，同兔子卡，只是作用在對手身上
            //惡魔卡，同烏龜卡，只是作用在對手身上
            if (step % 10 == 0 && step < 100)
            {
                me.setCard(ChooseCard(me, opponent));
            }

            if (step >= 100)
            {
                Console.WriteLine($"{me.GetName()} 到達 100 格，獲得勝利！");
                return true;
            }
            return false;
        }
    }
}
