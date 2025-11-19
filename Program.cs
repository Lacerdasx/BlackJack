using BlackJack;
using BlackJack.Entities;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Deck deck = new Deck();
            Player player = new Player("Você");
            Player home = new Player("Casa");

            player.Hand.Add(deck.Distribute());//Distribui duas cartas para o jogador e para a casa
            home.Hand.Add(deck.Distribute());
            player.Hand.Add(deck.Distribute());
            home.Hand.Add(deck.Distribute());


            Console.WriteLine("🍀🍀🍀🐯🐯Bem Vindo ao Tigrinho🐯🐯🍀🍀🍀");//Começo do jogo
            Console.WriteLine("Quanto você vai querer depositar? 💵 ");
            Console.WriteLine();
            
            double d = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Balance account = new Balance(d);
            Console.WriteLine();
           
            Console.WriteLine($"Seu saldo é: $ {account.Amount}");
            Console.WriteLine();
            Console.WriteLine("Precione qualquer botão para comecar.");
            Console.ReadKey(); 
            Console.Clear();



            string choice;
             do{
                Console.WriteLine($"Sua mão é");
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
                Console.WriteLine("Você estorou!🤬");
            }
            while (home.CalculateScore() < 17)//
            {
                home.Hand.Add(deck.Distribute());
            }
            Console.WriteLine("❓❓❓❓❓Bora ver a Casa❓❓❓❓❓");
            Console.WriteLine("Aperte qualquer botão para continuar");
            Console.ReadKey();
            Console.Clear();
            
            int playerScore = player.CalculateScore();
            int homeScore = home.CalculateScore();

            if (playerScore > 21)
            {
                Console.WriteLine("Você Perdeu 😭😭😭 \n");
                account.ResetAccount();
                Console.WriteLine("Seu saldo: $" + account.Amount);
            }
            else if (homeScore > 21 || playerScore > homeScore)
            {
                Console.WriteLine("Você ganhou🤑🤑🤑🤑 \n");
                account.PayApostate(playerScore, homeScore, d);
                Console.WriteLine("Seu saldo: $" + account.Amount);
            }
            else if (playerScore < homeScore)
            {
                Console.WriteLine("Você Perdeu😭😭😭");
                account.ResetAccount();
                Console.WriteLine("Seu saldo: $" + account.Amount);
            }
            else
            {
                Console.WriteLine("Empate😐😐");
                account.PayApostate(playerScore, homeScore, 0);
                Console.WriteLine("Seu saldo: $" + account.Amount);
            }
            Console.WriteLine($"Mão da Casa🐯🐯: {home.CalculateScore()}");
            Console.WriteLine();
            foreach (var card in home.Hand)
            {
                Console.WriteLine(card.ToString());
            }
            Console.ReadKey();
        }
    }
}