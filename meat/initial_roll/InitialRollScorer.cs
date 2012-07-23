using meat.initial_roll.city_feeding;
using meat.initial_roll.disaster_resolution;
using meat.initial_roll.food_collection;
using meat.initial_roll.goods_collection;

namespace meat.initial_roll
{
    public class InitialRollScorer
    {
        GoodCollector good_collector;
        FoodCollector food_collector;
        DisasterResolver disaster_resolver;
        CityFeeder city_feeder;

        protected InitialRollScorer() { }
        public InitialRollScorer(GoodCollector good_collector, FoodCollector food_collector, DisasterResolver disaster_resolver, CityFeeder city_feeder)
        {
            this.good_collector = good_collector;
            this.food_collector = food_collector;
            this.disaster_resolver = disaster_resolver;
            this.city_feeder = city_feeder;
        }

        public virtual void score(InitialRoll initial_roll)
        {
            good_collector.collect(initial_roll);
            food_collector.collect(initial_roll);
            disaster_resolver.resolve(initial_roll);
            city_feeder.feed(initial_roll.player);
        }
    }
}