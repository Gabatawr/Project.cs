using System;
using System.Threading;
using System.Threading.Tasks;

namespace CasinoThreads
{
    partial class Program
    {
        public class Table
        {
            public TableStat Statistic = new();
            static readonly object block = new();
            ManualResetEvent sync = new(true);

            int maxP, counterP;
            Player[] players;

            public Table(int MaxPlayers)
            {
                maxP = MaxPlayers;
                PlayersPerDay = counterP = Rand.Next(20, 100);
                players = new Player[maxP];

                Task.Run(AutoUpdatePlayer);
                Task.Run(Spin);
            }

            public int PlayersPerDay { get; private set; }
            public bool InGame => counterP > 0;
            bool isAllPlayerReady()
            {
                foreach (var p in players)
                    if (p?.IsReady is false) return false;
                return true;
            }

            int luckyNumb;
            void Spin()
            {
                while (InGame)
                {
                    lock (block) luckyNumb = Rand.Next(0, 36 + 1);

                    while (isAllPlayerReady() is false);
                    sync.Set();
                }
            }

            public void Play(object o)
            {
                if (o is Player p)
                {
                    while (InGame)
                    {
                        p.Bet();
                        sync.WaitOne();

                        if (InGame is false)
                        {
                            p.Win(p.BetMoney);
                            Statistic.List[p.Name].End = p.Money;
                            return;
                        }

                        if (luckyNumb == p.BetNumber)
                        {
                            p.Win(p.BetMoney * 2);
                            Console.WriteLine(p.Name + " : Win! : " + $"{p.BetMoney * 2} ");
                        }
                        else
                        {
                            //Console.WriteLine(p.Name + " : Lose : " + p.BetMoney);
                            p.Lose();
                            if (p.Money == 0)
                            {
                                players[Array.IndexOf(players, p)] = null;
                                return;
                            }
                        }
                    }
                }
            }

            void AutoUpdatePlayer()
            {
                for (int i = 0; InGame; i = i == maxP - 1 ? 0 : i + 1)
                {
                    if (players[i] == null)
                    {
                        Interlocked.Decrement(ref counterP);
                        players[i] = new(this, Rand.Next(1_000_000).ToString().PadLeft(6, '0'));
                        Statistic.List.Add(players[i]?.Name, new TableStat.MoneyStat() { Start = players[i].Money });
                    }
                }
            }
        }
    }
}
