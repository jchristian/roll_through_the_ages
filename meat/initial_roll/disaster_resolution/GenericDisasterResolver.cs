using System;

namespace meat.initial_roll.disaster_resolution
{
    public class GenericDisasterResolver : IResolveAnDisaster
    {
        readonly Func<InitialRoll, bool> matches;
        readonly IResolveAnSingleDisaster resolution;

        public GenericDisasterResolver(Func<InitialRoll, bool> matches, IResolveAnSingleDisaster resolution)
        {
            this.matches = matches;
            this.resolution = resolution;
        }

        public bool can_resolve(InitialRoll initial_roll)
        {
            return matches(initial_roll);
        }

        public void resolve(InitialRoll initial_roll)
        {
            resolution.resolve(initial_roll);
        }
    }
}