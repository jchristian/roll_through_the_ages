namespace meat.initial_roll.disaster_resolution.resolutions
{
    public class Pestilence : IResolveAnSingleDisaster
    {
        public void resolve(InitialRoll initial_roll)
        {
            foreach (var opponent in initial_roll.opponents)
                if (!opponent.has(Development.Medicine))
                    opponent.disasters += 3;
        }
    }
}