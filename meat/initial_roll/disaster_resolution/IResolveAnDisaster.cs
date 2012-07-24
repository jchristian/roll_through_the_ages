namespace meat.initial_roll.disaster_resolution
{
    public interface IResolveAnDisaster : IResolveAnSingleDisaster
    {
        bool can_resolve(InitialRoll initial_roll);
    }
}