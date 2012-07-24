namespace meat.initial_roll.disaster_resolution
{
    public class DisasterResolver
    {
        ResolutionFromFamine famine_resolution;
        ResolutionFromDice dice_resolution;

        protected DisasterResolver() {}
        public DisasterResolver(ResolutionFromFamine famine_resolution, ResolutionFromDice dice_resolution)
        {
            this.famine_resolution = famine_resolution;
            this.dice_resolution = dice_resolution;
        }

        public virtual void resolve(InitialRoll initial_roll)
        {
            famine_resolution.resolve(initial_roll);
            dice_resolution.resolve(initial_roll);
        }
    }
}