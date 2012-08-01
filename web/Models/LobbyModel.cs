using System.Collections.Generic;

namespace web.Models
{
    public class LobbyModel
    {
        public IEnumerable<GameModel> Games { get; set; } 
    }

    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfPlayers { get; set; }
    }
}