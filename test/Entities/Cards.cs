using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;

namespace BlackJack.Entities
{
    internal class Cards
    {
        public string Suit { get; }
        public string Value { get; }

        public Cards(string value, string suits)
        {
            Value = value;
            Suit = suits;
        }

        public int ValueModifier()
        {
            if (Value == "K" || Value == "Q" || Value == "J")
            {
                return 10;
            }
            if (Value == "A")
            {
                return 11;
            }
            else
            {
                return int.Parse(Value);
            }
        }
        public override string ToString()
        {
            return $"{Value} de {Suit}";
        }
    }
}
