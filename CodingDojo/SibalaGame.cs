using System.Collections.Generic;
using System.Linq;

namespace CodingDojo
{
    public class SibalaGame
    {
        public string Play(string gameData)
        {
            var dice1 = new Dice(gameData.Split("  ").First());
            var dice2 = new Dice(gameData.Split("  ").Last());

            if (dice1.DiceType != dice2.DiceType)
            {

            }
            if (dice2.Points.First() == dice1.Points.First())
            {
                return "Tie.";
            }


            return $"{GetWinner(dice2, dice1).PlayerName} wins. all the same kind:{GetWinner(dice2, dice1).Points.First()}";
        }

        private static Dice GetWinner(Dice dice2, Dice dice1)
        {
            var winner = dice2.Points.First() > dice1.Points.First()
                ? dice2
                : dice1;

            return winner;
        }
    }
}

public class Dice
{
    public Dice(string gameData)
    {
        this.Points = gameData.Split(":").Last().Split().Select(int.Parse).ToList();
        this.PlayerName = gameData.Split(":").First();
        this.DiceType = this.Points.GroupBy(x => x).Count() == 1 ? DiceType.AllTheSameKind : DiceType.NoPoints;
    }

    public DiceType DiceType { get; set; }

    public string PlayerName { get; set; }

    public List<int> Points { get; set; }
}

public enum DiceType
{
    NoPoints,
    AllTheSameKind
}