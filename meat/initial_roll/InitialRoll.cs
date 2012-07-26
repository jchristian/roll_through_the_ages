using System.Collections.Generic;
using System.Linq;

namespace meat.initial_roll
{
    public class InitialRoll
    {
        public Player player { get; set; }
        public IEnumerable<Die> dice { get; set; }
        public IEnumerable<Player> opponents { get; set; }

        public InitialRoll()
        {
            dice = Enumerable.Empty<Die>();
        }
    }

    public class Die
    {
        public int food { get; set; }
        public int goods { get; set; }
        public int disasters { get; set; }
    }
}