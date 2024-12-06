using System;
namespace CardAndDice
{
    internal class Player
    {
        public  string Name {  get; set; }
        private int _totalStep = 0;
        public int tempStep=0;
        public int TotalStep { 
            get { return _totalStep; }
            set {
                if (value > 100)
                    _totalStep = 100;
                else if(value<0)
                    _totalStep = 0;
                else 
                    _totalStep = value; 
            } 
        }
        public Player(string name)
        {
            playerName = name;
            totalStep = 0;
        }
        public int OwnerCard=0;
   
        private int RollDice()
        {
            Dice dice= new Dice();
            return dice.rollDice();
        }
        private void ChooseCard(Player opponent)
        {
            Card.ChooseCard(this.Name,opponent);
        }

        private int useCard(Player opponent)
        {

            Card.UseCard(this, opponent);
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