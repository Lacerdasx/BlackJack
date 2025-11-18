using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
    internal class Player
    {
        public string Name { get; set; }
        public List<Cards> Hand { get; set; }
        public Player(string name)
        {
            Name = name;
            Hand = new List<Cards>();
        }

       public int CalculateScore()
        {
            int totalScore = 0;//Inicializa a pontuação total como 0
            int aceCount = 0;


            foreach (Cards card in Hand)
            {
                totalScore += card.ValueModifier();//Adiciona o valor da carta à pontuação total
                if (card.Value == "A")//Conta o número de ases na mão
                {
                    aceCount++;//Incrementa o contador de ases
                }
            }
            while (totalScore > 21 && aceCount > 0)//Ajusta o valor dos ases se a pontuação total exceder 21
            {
                totalScore -= 10;
                aceCount--;
            }
            return totalScore;
        }
    }
}
