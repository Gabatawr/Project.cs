using System.Threading;

namespace CasinoThreads
{
    partial class Program
    {
        public class Player
        {
            public int Money { get; private set; }
            public int BetMoney { get; private set; }
            public int BetNumber { get; private set; }
            public bool IsReady { get; private set; }

            public void Bet()
            {
                BetNumber = Rand.Next(0, 36 + 1);
                Money -= BetMoney = Rand.Next(1, Money);
                IsReady = true;
            }
            public void Win(int win) => IsReady = (Money += win) < 0;
            public void Lose() => IsReady = false;

            public string Name => t.Name;
            Thread t;
            public Player(Table table, string name)
            {
                Money = Rand.Next(100_000, 1_000_000);

                t = new(table.Play) { Name = name };
                t.Start(this);
            }
        }
    }
}
