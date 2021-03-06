using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.nsubstitue;
using meat;
using meat.initial_roll;
using meat.initial_roll.goods_collection;

namespace specs.initial_roll.goods_collection
{
    public class GoodCollectorSpecs
    {
        public abstract class concern : Observes<GoodCollector> {}

        [Subject(typeof(GoodCollector))]
        public class when_collecting_goods : concern
        {
            Establish c = () =>
            {
                die_one = new Die { goods = 2 };
                die_two = new Die { goods = 1 };

                var player = fake.an<Player>();

                initial_roll = new InitialRoll { dice = new[] { die_one, die_two }, player = player };
            };

            Because of = () =>
                sut.collect(initial_roll);

            It should_add_the_rolled_quantity_of_goods = () =>
                initial_roll.player.received(x => x.add_goods(die_one.goods + die_two.goods));

            static InitialRoll initial_roll;
            static Die die_one;
            static Die die_two;
        }
    }
}