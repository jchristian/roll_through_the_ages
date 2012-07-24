namespace meat.initial_roll.disaster_resolution.resolutions
{
    public class Revolt : IResolveAnSingleDisaster
    {
        public void resolve(InitialRoll initial_roll)
        {
            if (initial_roll.player.has(Development.Religion))
                foreach (var opponent in initial_roll.opponents)
                    opponent.remove_all_goods();
            else
                initial_roll.player.remove_all_goods();
        }
    }
}