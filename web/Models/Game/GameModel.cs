using System.Collections.Generic;
using System.Linq;

namespace web.Models.Game
{
    public class GameModel
    {
        public string Name { get; set; }
        public PlayerModel Player { get; set; }
        public IEnumerable<PlayerModel> Opponents { get; set; }
        public DiceModel Dice { get; set; }
    }
}