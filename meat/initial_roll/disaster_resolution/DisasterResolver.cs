using System.Linq;

namespace meat.initial_roll.disaster_resolution
{
    public class DisasterResolver
    {
        public virtual void resolve(InitialRoll initial_roll)
        {
            if (initial_roll.player.cities > initial_roll.player.food)
                initial_roll.player.disasters += initial_roll.player.cities - initial_roll.player.food;

            if(initial_roll.dice.Sum(x => x.disasters) == 2)
                initial_roll.player.disasters += 2;
        }
    }
}