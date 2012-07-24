using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.nsubstitue;
using meat;

namespace specs
{
    public class TurnQueueSpecs
    {
        public abstract class concern : Observes<IReturnTheNextPlayer,
                                            TurnQueue> {}

        [Subject(typeof(TurnQueue))]
        public class when_getting_the_next_player : concern
        {
            public class and_no_players_have_gone
            {
                Establish c = () =>
                {
                    the_first_player = fake.an<Player>();
                    depends.on<IEnumerable<Player>>(new[] { the_first_player, fake.an<Player>(), fake.an<Player>() });
                };

                Because of = () =>
                    the_next_player = sut.next();

                It should_return_the_first_player = () =>
                    the_next_player.ShouldEqual(the_first_player);

                static Player the_next_player;
                static Player the_first_player;
            }

            public class and_the_first_player_has_gone
            {
                Establish c = () =>
                {
                    the_second_player = fake.an<Player>();
                    depends.on<IEnumerable<Player>>(new[] { fake.an<Player>(), the_second_player, fake.an<Player>() });

                    sut_setup.run(x => x.next());
                };

                Because of = () =>
                    the_next_player = sut.next();

                It should_return_the_second_player = () =>
                    the_next_player.ShouldEqual(the_second_player);

                static Player the_next_player;
                static Player the_second_player;
            }

            public class and_every_player_has_gone
            {
                Establish c = () =>
                {
                    the_first_player = fake.an<Player>();
                    depends.on<IEnumerable<Player>>(new[] { the_first_player, fake.an<Player>(), fake.an<Player>() });

                    sut_setup.run(x => { x.next(); x.next(); x.next(); });
                };

                Because of = () =>
                    the_next_player = sut.next();

                It should_return_the_first_player_again = () =>
                    the_next_player.ShouldEqual(the_first_player);

                static Player the_next_player;
                static Player the_first_player;
            }
        }
    }
}
