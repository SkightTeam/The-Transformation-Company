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
            fighter1 = Transformer.Create("Soundwave",'D', 1, 1, 1, 1, 1, 10, 1, 1);
            fighter2 = Transformer.Create("Bluestreak",'A', 9, 9, 9, 9, 9, 6, 1, 1);
        };

        It fighter1_should_not_be_a_winner = () => battle.Winners.ShouldNotContain(fighter1);

    }

    public class When_fighter2_with_4_more_point_of_courage_ : BattleSpecs
    {
        private Establish context = () =>
        {
            fighter1 = Transformer.Create("Soundwave", 'D', 9, 9, 9, 9, 9, 6, 9, 9);
            fighter2 = Transformer.Create("Bluestreak", 'A', 1, 1, 1, 1, 1, 10, 1, 1);
        };

        It fighter1_should_not_be_a_winner = () => battle.Winners.ShouldNotContain(fighter2);

    }
    public class When_one_with_3_more_point_of_strength : BattleSpecs
    {
        private Establish context = () =>
        {
            fighter1 = Transformer.Create("Soundwave",'D', 4, 1, 1, 1, 1, 10, 1, 1);
            fighter2 = Transformer.Create("Bluestreak",'A', 1, 9, 9, 9, 9, 6, 1, 1);
        };

        It fighter1_should_be_a_winner = () => battle.Winners.ShouldContainOnly(fighter1);
        It fighter2_should_be_a_loser = () => battle.Losers.ShouldContainOnly(fighter2);

    }

    public class When_one_with_3_more_point_of_skill : BattleSpecs
    {
        private Establish context = () =>
        {
            fighter1 = Transformer.Create("Soundwave",'D', 4, 4, 4, 4, 4, 4, 4, 4);
            fighter2 = Transformer.Create("Bluestreak",'A', 4, 4, 4, 4, 4, 4, 4, 1);
        };

        It fighter1_should_be_a_winner = () => battle.Winners.ShouldContainOnly(fighter1);
        It fighter2_should_be_a_loser = () => battle.Losers.ShouldContainOnly(fighter2);

    }

    public class When_one_with_more_overall_rating : BattleSpecs
    {
        private Establish context = () =>
        {
            fighter1 = Transformer.Create("Soundwave",'D', 4, 5, 4, 4, 4, 4, 4, 4);
            fighter2 = Transformer.Create("Bluestreak",'A', 4, 4, 4, 4, 4, 4, 4, 4);
        };

        It fighter1_should_be_a_winner = () => battle.Winners.ShouldContainOnly(fighter1);
        It fighter2_should_be_a_loser = () => battle.Losers.ShouldContainOnly(fighter2);

    }

    public class When_is_tie_overall_rating : BattleSpecs
    {
        private Establish context = () =>
        {
            fighter1 = Transformer.Create("Soundwave", 'D', 4, 4, 4, 4, 4, 4, 4, 4);
            fighter2 = Transformer.Create("Bluestreak", 'A', 4, 4, 4, 4, 4, 4, 4, 4);
        };

        It fighter1_should_be_a_winner = () => battle.Winners.ShouldBeEmpty();
        It fighter2_should_be_a_loser = () => battle.Losers.ShouldContainOnly(fighter1,fighter2);

    }

    public class When_a_special_name_Predaking_appear_in_battle : BattleSpecs
    {
        private Establish context = () =>
        {
            fighter1 = Transformer.Create("Predaking", 'D', 1, 1, 1, 1, 1, 1, 1, 1);
            fighter2 = Transformer.Create("Bluestreak", 'A', 9, 9, 9, 9, 9, 9, 9, 9);
        };

        It fighter1_should_be_a_winner = () => battle.Winners.ShouldContainOnly(fighter1);
        It fighter2_should_be_a_loser = () => battle.Losers.ShouldContainOnly(fighter2);

    }
    public class When_a_special_name_Optimus_Prime_appear_in_battle : BattleSpecs
    {
        private Establish context = () =>
        {
            fighter1 = Transformer.Create("Soundwave", 'D', 1, 1, 1, 1, 1, 1, 1, 1);
            fighter2 = Transformer.Create("Optimus Prime", 'A', 9, 9, 9, 9, 9, 9, 9, 9);
        };

        It fighter1_should_be_a_winner = () => battle.Winners.ShouldContainOnly(fighter2);
        It fighter2_should_be_a_loser = () => battle.Losers.ShouldContainOnly(fighter1);

    }
}