using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.nsubstitue;
using meat;
using meat.excess_good_discarding;

namespace specs.excess_goods_discarding
{
    public class ExcessGoodsDiscarderSpecs
    {
        public abstract class concern : Observes<ExcessGoodsDiscarder> {}

        [Subject(typeof(ExcessGoodsDiscarder))]
        public class when_discarding_excess_goods : concern
        {
            Establish c = () =>
            {
                discard_excess_goods = new DiscardExcessGoods
                {
                    player = fake.an<Player>(),
                    goods = new[] { new DiscardGoods { good = Good.Wood, quantity = 2 }, new DiscardGoods { good = Good.Stone, quantity = 1 } }
                };
            };

            Because of = () =>
                sut.update_for(discard_excess_goods);

            It should_remove_the_excess_goods = () =>
            {
                foreach (var good in discard_excess_goods.goods)
                    discard_excess_goods.player.received(x => x.remove(good.good, good.quantity));
            };

            static DiscardExcessGoods discard_excess_goods;
        }
    }
}
