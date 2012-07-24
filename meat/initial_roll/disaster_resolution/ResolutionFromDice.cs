using meat.initial_roll.disaster_resolution.resolutions;

namespace meat.initial_roll.disaster_resolution
{
    public class ResolutionFromDice
    {
        DisasterResolutionRegistry disaster_resolution_registry;

        public ResolutionFromDice(DisasterResolutionRegistry disaster_resolution_registry)
        {
            this.disaster_resolution_registry = disaster_resolution_registry;
        }

        public void resolve(InitialRoll initial_roll)
        {
            disaster_resolution_registry.get(initial_roll).resolve(initial_roll);
        }
    }
}