using System;

namespace CardAndDice
{
    internal class Player
    {
        private readonly string playerName;
        private int step;
        private int extraStep;

        public Player(string name)
        {
            playerName = name;
            step = 0;
            extraStep = 0;
        }
        public void ApplyExtraStep(int steps)
        {
            extraStep += steps;
        }

        private int RollDice()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }


        private void ChooseCard(Player opponent)
        {
            Random random = new Random();
            int cardType = random.Next(1, 5);
            switch (cardType)
            {
                case 1:
                    Rabbit();
                    break;
                case 2:
                    Turtle();
                    break;
                case 3:
                    Angel(opponent);
                    break;
                case 4:
                    Devil(opponent);
                    break;
            }
        }


        private void Rabbit()
        {
            extraStep += 2;
            Console.WriteLine($"{playerName} 獲得了兔子卡，步數增加 2。");
        }


        private void Turtle()
        {
            int move = RollDice();
            extraStep += (move <= 3) ? 1 : -2;
            Console.WriteLine($"{playerName} 獲得了烏龜卡，步數減少，最少移動 1 步。");
        }


        private void Angel(Player opponent)
        {
            opponent.ApplyExtraStep(2);
            Console.WriteLine($"{playerName} 使用了天使卡，對手 {opponent.playerName} 步數增加 2。");
        }


        private void Devil(Player opponent)
        {
            int move = RollDice();
            opponent.ApplyExtraStep((move <= 3) ? 1 : -2);
            Console.WriteLine($"{playerName} 使用了惡魔卡，對手 {opponent.playerName} 步數減少，最少移動 1 步。");
        }


        public bool Walk(Player opponent)
        {
            int tempStep = RollDice();
            step += tempStep;
            Console.WriteLine($"{playerName} 擲骰子，移動了 {tempStep} 步，當前位置：{step}");


            if (step % 10 == 0 && step < 100)
            {
                ChooseCard(opponent);
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
