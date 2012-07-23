namespace meat.initial_roll.city_feeding
{
    public class CityFeeder
    {
        public virtual void feed(Player player)
        {
            player.food -= player.cities;
        }
    }
}