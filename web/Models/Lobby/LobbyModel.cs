using System.Collections.Generic;

namespace web.Models.Lobby
{
    public class LobbyModel
    {
        public IEnumerable<GameModel> Games { get; set; } 
    }
}