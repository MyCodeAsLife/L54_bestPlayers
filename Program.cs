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
            int topPlayersCount = 3;

            server.ShowTopPlayers(topPlayersCount);
        }
    }

    class Server
    {
        private List<Player> _players = new List<Player>();

        public Server()
        {
            FillDatabase();
        }

        public void ShowTopPlayers(int amount)
        {
            List<Player> bestInLevel = _players.OrderByDescending(player => player.Level).Take(amount).ToList();
            List<Player> bestInStrength = _players.OrderByDescending(player => player.Strenght).Take(amount).ToList();

            Console.WriteLine($"Топ {amount} игрока(ов) по уровню:");
            int maxLoginLenght = bestInLevel.Max(player => player.Name.Length);

            foreach (var player in bestInLevel)
                Console.WriteLine($"{{0, 4}} {{1, -{maxLoginLenght}}} {{2,12}}", "Ник:", $"{player.Name}", $"Уровень: {player.Level}");

            Console.WriteLine($"\nТоп {amount} игрока(ов) по силе:");
            maxLoginLenght = bestInStrength.Max(player => player.Name.Length);

            foreach (var player in bestInStrength)
                Console.WriteLine($"{{0, 4}} {{1, -{maxLoginLenght}}} {{2,12}}", "Ник:", $"{player.Name}", $"Сила: {player.Strenght}");
        }

        private void FillDatabase()
        {
            _players.Add(new Player("Убиватор3000"));
            _players.Add(new Player("Сакура"));
            _players.Add(new Player("ПилимНоги"));
            _players.Add(new Player("GGJHH^&*"));
            _players.Add(new Player("ゆうとみんと"));
            _players.Add(new Player("В_забой"));
            _players.Add(new Player("Твоя МаМка ЕпТа"));
            _players.Add(new Player("Водаврот"));
            _players.Add(new Player("100gramoВИЧ"));
            _players.Add(new Player("COCOK_B_NOCOK"));
        }
    }

    class Player
    {
        public Player(string name)
        {
            int maxLevel = 30;
            int maxStrenght = 68;

            Name = name;
            Level = RandomGenerator.GetRandomNumber(maxLevel + 1);
            Strenght = RandomGenerator.GetRandomNumber(maxStrenght + 1);
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Strenght { get; private set; }
    }

    static class RandomGenerator
    {
        private static Random s_random = new Random();

        public static int GetRandomNumber(int maxValue) => s_random.Next(maxValue);
    }
}
