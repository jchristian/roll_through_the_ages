using System.Collections.Generic;

namespace meat
{
    public class Turn
    {
        public Player player { get; set; }
        public int food { get; set; }
        public int number_of_food_dice { get; set; }
        public int goods { get; set; }
        public IEnumerable<Die> dice { get; set; }
    }

    public class Die
    {
        public int food { get; set; }
    }
}