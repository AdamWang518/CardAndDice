using System;
namespace CardAndDice
{
    internal class Player
    {
        private readonly string playerName;
        private int step;
        public Player(string name)
        {
            playerName = name;
            step = 0;
        }
        private int Card;
        public int getCard() { return Card; }
        public int setCard(int CardNum) {  Card=CardNum; }
        public int GetStep() { return step; }
        public string GetName() { return playerName; }
    }
}