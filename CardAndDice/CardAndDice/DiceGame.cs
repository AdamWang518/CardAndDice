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
            Player playerB = new Player("電腦");
            int round = 1;
            bool gameEnded = false;
            while (!gameEnded)
            {
                Console.WriteLine($"第{round}回合:");
                round++;
                gameEnded = Walk(playerA, playerB);
                if (gameEnded)
                {
                    Console.WriteLine("遊戲結束！");
                    Console.WriteLine($"分數是100分");
                    break;
                }
                gameEnded=  Walk(playerB, playerA);
                if (gameEnded)
                {
                    Console.WriteLine("遊戲結束！");
                    Console.WriteLine($"分數是{playerA.totalStep}分");
                    break;
                }
            }
            return;

        }
        public bool Walk(Player me, Player opponent)
        {
            int point = me.RollDice();
            Console.WriteLine($"{me.Name} 擲骰子，得到了{point}點，當前位置：{me.totalStep}");
            me.tempStep = point;
            if (me.OwnerCard!= 0)
            {
                Console.WriteLine($"{me.Name}使用卡片，本回合的移動將會變化");
                me.useCard(opponent);
            }
            me.Move();
            Console.WriteLine($"{me.Name}，移動了 {me.tempStep} 步，當前位置：{me.totalStep}");
            //兔子卡，每次移動步數 +2，持續一回合
            //烏龜卡，每次移動步數 -2，但若擲出步數 <=3，就走 1 步(至少可以走一步的意思)，持續一回合
            //天使卡，同兔子卡，只是作用在對手身上
            //惡魔卡，同烏龜卡，只是作用在對手身上
            if (me.totalStep % 10 == 0 && me.totalStep < 100)
            {
                me.ChooseCard(opponent);
            }
            if (me.totalStep >= 100)
            {
                Console.WriteLine($"{me.Name} 到達 100 格，獲得勝利！");
                return true;
            }
            return false;
        }
        
    }
}
