using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace meat.initial_roll.disaster_resolution.resolutions
{
    public class DisasterResolutions : IEnumerable<IResolveAnDisaster>
    {
        public IEnumerator<IResolveAnDisaster> GetEnumerator()
        {
            yield return new GenericDisasterResolver(initial_roll => get_number_of_disasters(initial_roll.dice) == 0, new DoNothing());
            yield return new GenericDisasterResolver(initial_roll => get_number_of_disasters(initial_roll.dice) == 1, new DoNothing());
            yield return new GenericDisasterResolver(initial_roll => get_number_of_disasters(initial_roll.dice) == 2, new Dought());
            yield return new GenericDisasterResolver(initial_roll => get_number_of_disasters(initial_roll.dice) == 3, new Pestilence());
            yield return new GenericDisasterResolver(initial_roll => get_number_of_disasters(initial_roll.dice) == 4, new Invasion());
            yield return new GenericDisasterResolver(initial_roll => get_number_of_disasters(initial_roll.dice) == 5, new Revolt());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        int get_number_of_disasters(IEnumerable<Die> dice)
        {
            return dice.Sum(x => x.disasters);
        }
    }
}