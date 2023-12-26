using System;
using System.Collections.Generic;
using System.Linq;

namespace L54_bestPlayers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();

            server.ShowTopPlayers();
        }
    }

    class Server
    {
        private List<Player> _players = new List<Player>();
        private Random _random;

        private int _topPlayersCount = 3;

        public Server()
        {
            _random = new Random();
            FillServer();
        }

        public void ShowTopPlayers()
        {
            List<Player> bestInLevel = _players.OrderByDescending(player => player.Level).ToList();
            List<Player> bestInStrength = _players.OrderByDescending(player => player.Strenght).ToList();

            Console.WriteLine($"Топ {_topPlayersCount} игрока(ов) по уровню:");
            int maxLoginLenght = bestInLevel.Max(player => player.Name.Length);

            for (int i = 0; i < _topPlayersCount; i++)
                Console.WriteLine($"{{0, 4}} {{1, -{maxLoginLenght}}} {{2,12}}", "Ник:", $"{bestInLevel[i].Name}", $"Уровень: {bestInLevel[i].Level}");

            Console.WriteLine();
            Console.WriteLine($"Топ {_topPlayersCount} игрока(ов) по силе:");
            maxLoginLenght = bestInLevel.Max(player => player.Name.Length);

            for (int i = 0; i < _topPlayersCount; i++)
                Console.WriteLine($"{{0, 4}} {{1, -{maxLoginLenght}}} {{2,12}}", "Ник:", $"{bestInLevel[i].Name}", $"Сила: {bestInLevel[i].Level}");
        }

        private void FillServer()
        {
            _players.Add(new Player("Убиватор3000", _random));
            _players.Add(new Player("Сакура", _random));
            _players.Add(new Player("ПилимНоги", _random));
            _players.Add(new Player("GGJHH^&*", _random));
            _players.Add(new Player("ゆうとみんと", _random));
            _players.Add(new Player("В_забой", _random));
            _players.Add(new Player("Твоя МаМка ЕпТа", _random));
            _players.Add(new Player("Водаврот", _random));
            _players.Add(new Player("100gramoВИЧ", _random));
            _players.Add(new Player("COCOK_B_NOCOK", _random));
        }
    }

    class Player
    {
        private Random _random;
        private int _maxLevel = 30;
        private int _maxStrenght = 68;

        public Player(string name, Random random)
        {
            _random = random;
            Name = name;
            Level = _random.Next(_maxLevel + 1);
            Strenght = _random.Next(_maxStrenght + 1);
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Strenght { get; private set; }
    }
}
