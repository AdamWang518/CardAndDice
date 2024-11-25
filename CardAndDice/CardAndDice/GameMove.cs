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
            return 3;
        }

        private int Devil(Player me, Player opponent)
        {
            Console.WriteLine($"{me.GetName()} 得到了惡魔卡，下回合對手 {opponent.GetName()} 步數減少，最少移動 1 步。");
            return 4;
        }
        private int useCard(int cardNumber) {
            switch (cardNumber) { 
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        
        }
        public bool Walk(Player me, Player opponent, int Card)
        {
            
            int tempStep = RollDice();
            int Card = 0;
            int step =me.GetStep();
            step += tempStep;
            Console.WriteLine($"{me.GetName()} 擲骰子，移動了 {tempStep} 步，當前位置：{step}");

            if (step % 10 == 0 && step < 100)
            {
                Card= ChooseCard(me, opponent);
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
