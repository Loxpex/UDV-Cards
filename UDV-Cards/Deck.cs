using System.Text;

namespace UDV_Cards
{       
    class Deck
    {
        private static Dictionary<string,Deck> Decks = new Dictionary<string, Deck>();

        private List<Card> DeckOfCards = new List<Card>();
        readonly string Name;

        private Deck(string name)
        {
            Name = name;
        }

        public static bool CreateDeck(string name)
        {
            if(Decks.ContainsKey(name)) 
            {
                return false;
            }
            
            Deck deck = new Deck(name);

            for(int i = (int)Suit.Clubs; i <= (int)Suit.Spades ; i++)
            {
                for(int j = (int)Dignity.Two; j <= (int)Dignity.Ace; j++)
                {
                    deck.DeckOfCards.Add(new Card(j, i));
                }
            }

            Decks.Add(name, deck);
            return true;
        }

        public static string GetDeck(string name) 
        {
            StringBuilder sb = new StringBuilder();
            if(Decks.ContainsKey(name))
            {
                foreach(Card card in Decks[name].DeckOfCards)
                {
                    sb.AppendLine(card.ToString());
                }

                return sb.ToString();
            }
            return "No decks with this name";
        }

        public static bool DeleteDeck(string name)
        {
            if (Decks.ContainsKey(name))
            {
                Decks.Remove(name);
                return true;
            }
            return false;
        }

        public static string GetDecksNames()
        {
            if(Decks.Count == 0)
            {
                return "No decks";
            }

            StringBuilder sb = new StringBuilder();
            List<string> keys = Decks.Keys.ToList();
            foreach(string key in keys) 
            {
                sb.AppendLine(key);
            }
            return sb.ToString();
        }

        public static bool Shuffle(string name, string ShuffleType)
        {
            if(!Decks.ContainsKey(name))
            {
                return false;
            }
            if(ShuffleType == "RandomSort")
            {
                var rnd = new Random();
                Decks[name].DeckOfCards = Decks[name].DeckOfCards.OrderBy(x => rnd.Next()).ToList();
                return true;
            }
            //другие потенциальные варианты перетаосвки
            return false;
        }
    }

    class Card
    {
        readonly Dignity Dignity;
        readonly Suit Suit;
        public Card(int digninty, int suit)
        {
            Dignity = (Dignity)digninty;
            Suit = (Suit)suit;
        }

        public override string ToString()
        {
            return Dignity.ToString() + " " + Suit.ToString();
        }

    }
}
