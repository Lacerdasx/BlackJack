using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;

namespace BlackJack.Entities
{
    internal class Deck
    {
        List<Cards> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Cards>();
            Boot();
            Shuffle();
            Distribute();
        }
        private void Boot()
        {
            string[] suits = { "Ouro", "Espada", "Copas", "Paus" };
            string[] values = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    Cards.Add(new Cards(value, suit));
                }
            }
        }
        private void Shuffle()
        {
            Cards = Cards.OrderBy(x => Guid.NewGuid()).ToList();
        }
        public Cards Distribute()
        {
            if (Cards.Count == 0)
            {
                return null;
            }
            Cards cardToReturn = Cards[0];

            Cards.RemoveAt(0);

            return cardToReturn;
        }
    }
}
