using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingDojo
{
    public class SibalaGame
    {
        public string Play(string gameData)
        {
            var player1 = new Dice(gameData.Split("  ").First());
            var player2 = new Dice(gameData.Split("  ").Last());
            
            if (IsDifferentGameResultType(player1, player2))
            {
                var winner = player1.GetSamePointCount() > player2.GetSamePointCount() ? player2 : player1;
                return GetResult(winner);
            }
            
            if (IsTie(player1, player2))
            {
                return "Tie.";
            }

            return GetResult(GetWinner(player1, player2));
        }

        private static string GetResult(Dice winner)
        {
            return $"{winner.Name} wins.{winner.GetDiceType()}:{winner.GetPoint()}";
        }

        private static bool IsDifferentGameResultType(Dice player1, Dice player2)
        {
            return player1.GetSamePointCount() != player2.GetSamePointCount();
        }

        private static bool IsTie(Dice player1, Dice player2)
        {
            return player1.GetPoint() == player2.GetPoint();
        }

        private static Dice GetWinner(Dice player1, Dice player2)
        {
            var winner = player1.GetPoint() > player2.GetPoint() ? player1 : player2;
            return winner;
        }
    }

    public class Dice
    {
        public string Name { get; set; }
        private List<int> Points { get; set; }

        public Dice(string gameData)
        {
            this.Name = gameData.Split(":").First();
            this.Points = gameData.Split(":").Last().Split().Select(int.Parse).ToList();
        }

        public int GetPoint()
        {
            if (GetSamePointCount() == 3)
            {
                return Points.GroupBy(p => p)
                    .Where(x => x.Count() == 1)
                    .Sum(x => x.Key);
            }
            
            if (GetSamePointCount() == 2)
            {
                return Points.GroupBy(p => p)
                    .Max(p => p.Key) * 2;
            }

            return Points.First();
        }

        public int GetSamePointCount()
        {
            return Points.GroupBy(p => p).Count();
        }

        public string GetDiceType()
        {
            return GetSamePointCount() == 1 ? "all the same kind" : "normal point";
        }
    }
}
