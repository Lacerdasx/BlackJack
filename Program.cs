using BlackJack.Entities;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Serialization;
using System.Globalization;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player player = new Player("Você");
            Player home = new Player("Casa");
            double currentBet;

            player.Hand.Add(deck.Distribute());//Distribui duas cartas para o jogador e para a casa
            home.Hand.Add(deck.Distribute());
            player.Hand.Add(deck.Distribute());
            home.Hand.Add(deck.Distribute());


            Console.WriteLine("-------Bem Vindo ao Tigrinho-------");//Começo do jogo
            Console.WriteLine("Quanto você vai querer depositar? ");
            currentBet = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("Saldo" + currentBet);



            string choice;
                       do
            {
                Console.WriteLine($"Sua mão é");
                foreach (var card in player.Hand)//Mostra as cartas do jogador
                {
                    Console.WriteLine(card.ToString());
                }
                Console.WriteLine($"Seus pontos: {player.CalculateScore()}");
                Console.WriteLine("Vai querer outra carta? (s/n)");
                choice = Console.ReadLine();
                if (choice.ToLower() == "s")
                {
                    player.Hand.Add(deck.Distribute());//Distribui outra carta para o jogador
                }
            } while (choice.ToLower() == "s" && player.CalculateScore() <= 21);//Enquanto o jogador quiser outra carta e não estourar

            if (player.CalculateScore() > 21)
            {
                Console.WriteLine("Você estorou!");
            }
            while (home.CalculateScore() < 17)
            {
                home.Hand.Add(deck.Distribute());
            }
            int playerScore = player.CalculateScore();
            int homeScore = home.CalculateScore();

            if (playerScore > 21)
            {
                Console.WriteLine("Você Perdeu");
            }
            else if (homeScore > 21 || playerScore > homeScore)
            {
                Console.WriteLine("Você ganhou");
            }
            else if (playerScore < homeScore)
            {
                Console.WriteLine("Voê Perdeu");
            }
            else
            {
                Console.WriteLine("Empate");
            }
            Console.WriteLine($"Mão da Casa: {home.CalculateScore()}");
            foreach (var card in home.Hand)
            {
                Console.WriteLine(card.ToString());
            }

            Console.ReadKey();
        }
    }
}