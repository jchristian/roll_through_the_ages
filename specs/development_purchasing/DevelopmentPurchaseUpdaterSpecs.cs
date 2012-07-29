using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using NSubstitute;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.nsubstitue;
using meat;
using meat.development_purchasing;

namespace specs.development_purchasing
{
    public class DevelopmentPurchaseUpdaterSpecs
    {
        public abstract class concern : Observes<DevelopmentPurchaseUpdater> {}

        [Subject(typeof(DevelopmentPurchaseUpdater))]
        public class when_a_player_purchases_a_development : concern
        {
            public class and_a_development_is_purchased
            {
                Establish c = () =>
                {
                    development_purchase = new DevelopmentPurchase { player = fake.an<Player>(), was_development_purchased = true, development = Development.Agriculture, goods_sold = Enumerable.Empty<Good>(), food_sold = 2 };
                };

                Because of = () =>
                    sut.update_for(development_purchase);

                It should_add_the_development_to_the_player = () =>
                    development_purchase.player.received(x => x.add(development_purchase.development));

                It should_remove_the_goods_selected_to_pay_for_the_development = () =>
                    development_purchase.player.received(x => x.remove_goods(development_purchase.goods_sold));

                It should_remove_the_food_sold_to_pay_for_the_development = () =>
                    development_purchase.player.received(x => x.remove_food(development_purchase.food_sold));

                static DevelopmentPurchase development_purchase;
            }

            public class and_no_development_is_purchased
            {
                Establish c = () =>
                {
                    development_purchase = new DevelopmentPurchase { player = fake.an<Player>(), was_development_purchased = false };
                };

                Because of = () =>
                    sut.update_for(development_purchase);

                It should_not_remove_the_goods_selected_to_pay_for_the_development = () =>
                    development_purchase.player.never_received(x => x.remove_goods(Arg.Any<IEnumerable<Good>>()));

                static DevelopmentPurchase development_purchase;
            }
        }
    }
}
