using Machine.Specifications;

namespace Battling.Specs
{
    public class BattleSpecs
    {
        private Because of = () => battle = new Battle(fighter1, fighter2);

        protected static Transformer fighter1;
        protected static Transformer fighter2;
        protected static Battle battle;
    }
    public class When_one_with_4_more_point_of_courage: BattleSpecs
    {
        private Establish context = () =>
        {
            fighter1 = Transformer.Create('D', 1, 1, 1, 1, 1, 10, 1, 1);
            fighter2 = Transformer.Create('A', 9, 9, 9, 9, 9, 6, 1, 1);
        };

        It fighter1_should_not_be_a_winner = () => battle.Winners.ShouldNotContain(fighter1);

    }
    public class When_one_with_3_more_point_of_strength : BattleSpecs
    {
        private Establish context = () =>
        {
            fighter1 = Transformer.Create('D', 4, 1, 1, 1, 1, 10, 1, 1);
            fighter2 = Transformer.Create('A', 1, 9, 9, 9, 9, 6, 1, 1);
        };

        It fighter1_should_be_a_winner = () => battle.Winners.ShouldContainOnly(fighter1);
        It fighter2_should_be_a_loser = () => battle.Losers.ShouldContainOnly(fighter2);

    }

    public class When_one_with_3_more_point_of_skill : BattleSpecs
    {
        private Establish context = () =>
        {
            fighter1 = Transformer.Create('D', 4, 4, 4, 4, 4, 4, 4, 4);
            fighter2 = Transformer.Create('A', 4, 4, 4, 4, 4, 4, 4, 1);
        };

        It fighter1_should_be_a_winner = () => battle.Winners.ShouldContainOnly(fighter1);
        It fighter2_should_be_a_loser = () => battle.Losers.ShouldContainOnly(fighter2);

    }
}