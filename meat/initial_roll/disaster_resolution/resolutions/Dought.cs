namespace meat.initial_roll.disaster_resolution.resolutions
{
    public class Dought : IResolveAnSingleDisaster
    {
        public void resolve(InitialRoll initial_roll)
        {
            if (!initial_roll.player.has(Development.Irrigation))
                initial_roll.player.disasters += 2;
        }
    }
}