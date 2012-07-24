namespace meat.initial_roll.disaster_resolution
{
    public class ResolutionFromFamine
    {
        public void resolve(InitialRoll initial_roll)
        {
            if (initial_roll.player.cities > initial_roll.player.food)
                initial_roll.player.disasters += initial_roll.player.cities - initial_roll.player.food;
        }
    }
}