using System.ComponentModel;

namespace CardAndDice
{
    class Program
    {
        //設定兩個人物，A 是你，B 是電腦
        //每回合擲骰子，隨機走 1~6 步，
        //若剛好停在(經過不算)第 10/20/30.../90 格時隨機取得(不論是 A 或 B 都有取得機會)

        //兔子卡，每次移動步數 +2，持續一回合
        //烏龜卡，每次移動步數 -2，但若擲出步數 <=3，就走 1 步(至少可以走一步的意思)，持續一回合
        //天使卡，同兔子卡，只是作用在對手身上
        //惡魔卡，同烏龜卡，只是作用在對手身上
        //先到 100 格的人就是贏家，
        //每回合會顯示你和對手目前所在位置，
        //若你勝利，分數就是 100 分，
        //若對手勝利，分數就是你所在格子，

        static void Main(string[] args)
        {
            DiceGame Game=new DiceGame();
            Game.Gameing();
            return;
        }
    }
}
