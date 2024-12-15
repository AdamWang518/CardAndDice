using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardAndDice
{
    internal class Card
    {
        public static void ChooseCard(Player me,Player opponent)
        {

            Random random = new Random();
            int cardType = random.Next(1, 5);
            switch (cardType)
            {
                case 1:
                    Console.WriteLine($"{me.Name} 得到了兔子卡，下回合步數增加 2。");
                    break;
                case 2:
                    Console.WriteLine($"{me.Name} 得到了烏龜卡，下回合步數減少，最少移動 1 步。");
                    break;
                case 3:
                    Console.WriteLine($"{me.Name} 得到了天使卡，下回合對手 {opponent.Name} 步數增加 2。");
                    break;
                case 4:
                    Console.WriteLine($"{me.Name} 得到了惡魔卡，下回合對手 {opponent.Name} 步數減少，最少移動 1 步。");
                    break;
            }
            me.OwnerCard = cardType;
            return;
        }
        public static void UseCard(Player me,Player opponent) {
            switch (me.OwnerCard)
            {
                case 1:
                    me.tempStep += 2;
                    break;
                case 2:
                    if (me.tempStep <= 3)
                    {
                        me.tempStep = 1;
                    }
                    else
                    {
                        me.tempStep -= 2;
                    }
                    break;
                case 3:
                    opponent.tempStep += 2;
                    break;
                case 4:
                    if (opponent.tempStep <= 3)
                    {
                        opponent.tempStep = 1;
                    }
                    else
                    {
                        opponent.tempStep -= 2;
                    }
                    break;
            }
            me.OwnerCard = 0;
        }
    }
    
}
