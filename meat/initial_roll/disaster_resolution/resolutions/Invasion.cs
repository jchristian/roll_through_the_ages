namespace meat.initial_roll.disaster_resolution.resolutions
{
    public class Invasion : IResolveAnSingleDisaster
    {
        public void resolve(InitialRoll initial_roll)
        {
            if (!initial_roll.player.has(Monument.GreatWall))
                initial_roll.player.disasters += 4;
        }
    }
}