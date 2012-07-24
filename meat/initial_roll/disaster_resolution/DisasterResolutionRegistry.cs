using System.Collections.Generic;
using System.Linq;

namespace meat.initial_roll.disaster_resolution
{
    public class DisasterResolutionRegistry
    {
        IEnumerable<IResolveAnDisaster> resolvers;

        public DisasterResolutionRegistry(IEnumerable<IResolveAnDisaster> resolvers)
        {
            this.resolvers = resolvers;
        }

        public IResolveAnSingleDisaster get(InitialRoll initial_roll)
        {
            return resolvers.First(x => x.can_resolve(initial_roll));
        }
    }
}