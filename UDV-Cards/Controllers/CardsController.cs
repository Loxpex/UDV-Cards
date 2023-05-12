using Microsoft.AspNetCore.Mvc;

namespace UDV_Cards.Controllers
{
    public class CardsController : Controller
    {
        private IConfiguration _configuration;
        public CardsController(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        [HttpGet, Route("CreateDeck/{name}")]
        public string CreateDecks(string name)
        {
            if (Deck.CreateDeck(name))
            {
                return $"Deck with name {name} - created";
            }
            return $"Deck with name {name} - already exist";
        }

        [HttpGet, Route("GetDeck/{name}")]
        public string GetDecks(string name)
        {
            return Deck.GetDeck(name);
        }

        [HttpGet, Route("DeleteDeck/{name}")]
        public string DeleteDecks(string name)
        {
            if (Deck.DeleteDeck(name))
            {
                return $"Deck '{name}' - deleted";
            }
            return "No decks with this name";
        }

        [HttpGet, Route("GetDecksNames")]
        public string GetDecksNames()
        {
            return Deck.GetDecksNames();
        }

        [HttpGet, Route("ShuffleDeck/{name}")]
        public string ShuffleDeck(string name) 
        {
            if(_configuration == null)
            {
                return "NoConfigSetings";
            }
            if (Deck.Shuffle(name, _configuration["SortType"]))
            {
                return "WrongConfigOrDeckName";
            }
            return _configuration["SortType"];
        }
        
    }
}
