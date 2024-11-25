using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardAndDice
{
    internal class GameMove
    {
        


        private int RollDice()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }
        private int ChooseCard(Player me,Player opponent)
        {
            Random random = new Random();
            int cardType = random.Next(1, 5);
            return cardType;
        }

        private int Rabbit(Player me)
        {
            Console.WriteLine($"{me.GetName()} 得到了兔子卡，下回合步數增加 2。");
            return 1;
        }

        private int Turtle(Player me)
        {
            Console.WriteLine($"{me.GetName()} 得到了烏龜卡，下回合步數減少，最少移動 1 步。");
            return 2;
        }

        private int Angel(Player me, Player opponent)
        {
            Console.WriteLine($"{me.GetName()} 得到了天使卡，下回合對手 {opponent.GetName()} 步數增加 2。");
            return 1;
        }

        private int Devil(Player me, Player opponent)
        {
            Console.WriteLine($"{me.GetName()} 得到了惡魔卡，下回合對手 {opponent.GetName()} 步數減少，最少移動 1 步。");
            return 2;
        }
        private int useCard(int cardNumber,int diceNumber) {
            int extraStep = 0;
            switch (cardNumber) { 
                case 0:
                    extraStep = 0;
                    break;
                case 1:
                    diceNumber += 2;
                    break;
                case 2:
                    if (diceNumber <= 3)
                    {
                        diceNumber = 1;
                    }
                    else
                    {
                        diceNumber -= 2;
                    }
                    break;
            }
            return extraStep;
        }
        public bool Walk(Player me, Player opponent)
        {
            
            int tempStep = RollDice();
            int step =me.GetStep();
            if (me.getCard() != 0)
            {
                Console.WriteLine($"{me.GetName()} 受卡片效果影響，本回合移動將變化");
                tempStep=useCard(me.getCard(), tempStep);
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

            step += extraStep;
            if (extraStep != 0)
            {
                Console.WriteLine($"{playerName} 受卡片效果影響，額外移動 {extraStep} 步，當前位置：{step}");
                extraStep = 0;
            }

            if (step >= 100)
            {
                Console.WriteLine($"{playerName} 到達 100 格，獲得勝利！");
                return true;
            }
            return false;
        }
        
        public int GetStep() { return step; }
        public string GetName() { return playerName; }
    }
}
