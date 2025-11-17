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
            Hand = new List<Cards>();//Inicializa a mão do jogador como uma lista vazia
        }

       public int CalculateScore()//Calcula a pontuação da mão do jogador
        {
            int totalScore = 0;//Inicializa a pontuação total como 0
            int aceCount = 0;


            foreach (Cards card in Hand)//Percorre todas as cartas na mão do jogador
            {
                totalScore += card.ValueModifier();
                if (card.Value == "A")
                {
                    aceCount++;
                }
            }
            while (totalScore > 21 && aceCount > 0)
            {
                totalScore -= 10;
                aceCount--;
            }
            return totalScore;
        }
    }
}
