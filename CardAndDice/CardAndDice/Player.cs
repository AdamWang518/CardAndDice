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
            Name = name;
            _totalStep = 0;
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

        private void useCard(Player opponent)
        {

            Card.UseCard(this, opponent);
        }
        
    }

}