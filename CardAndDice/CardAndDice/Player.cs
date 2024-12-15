using System;
namespace CardAndDice
{
    internal class Player
    {
        public  string Name {  get; set; }
        public int totalStep ;
        public int tempStep;
        public int OwnerCard;
        public Player(string name)
        {
            this.Name = name;
            this.totalStep = 0;
            this.tempStep = 0;
            this.OwnerCard = 0;
        }
        public int Move() {
            this.totalStep += this.tempStep;
            return tempStep;
        }

        public int RollDice()
        {
            Dice dice= new Dice();
            return dice.rollDice();
        }
        public void ChooseCard(Player opponent)
        {
            Card.ChooseCard(this, opponent);
            return;
        }

        public void useCard(Player opponent)
        {
            Card.UseCard(this, opponent);
            return;
        }
        
    }

}