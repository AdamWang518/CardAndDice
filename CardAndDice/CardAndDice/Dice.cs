using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardAndDice
{
    internal class Dice
    {
        public Dice() { }
        public int rollDice(int upperBound = 6, int diceNumber = 1) {
            int returner = 0;
            for (int i = 0; i < diceNumber; i++) {
                Random random = new Random();
                returner+= random.Next(1, upperBound+1);
            }
            return returner;
        }
    }
}
