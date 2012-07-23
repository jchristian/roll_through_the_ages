using System.Linq;

namespace meat.initial_roll.disaster_resolution
{
    public class DisasterResolver
    {
        public virtual void resolve(InitialRoll initial_roll)
        {
            // Resolve disasters from famine
            if (initial_roll.player.cities > initial_roll.player.food)
                initial_roll.player.disasters += initial_roll.player.cities - initial_roll.player.food;

            // Resolve disasters from dice rolls
            var number_of_disasters = initial_roll.dice.Sum(x => x.disasters);
            
            if(number_of_disasters == 2 && !initial_roll.player.has(Development.Irrigation))
                initial_roll.player.disasters += 2;

            if(number_of_disasters == 3)
                foreach (var opponent in initial_roll.opponents)
                    opponent.disasters += 3;
        }
    }
}