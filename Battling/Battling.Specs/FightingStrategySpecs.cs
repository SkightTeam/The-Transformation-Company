using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using NUnit.Framework;

namespace Battling.Specs
{
    public class When_divie_a_group_of_transformers_into_teams
    {
        Establish context = () => subject = new List<Transformer>
        {
            stub("Soundwave",'D' ),
            stub("Bluestreak",'A'),
            stub("Pounce",'D'),
            stub("Blades",'A'),
            stub("Firefighter",'A'),
        };

        private Because of = () => result = subject.divide();

        private It autobot_team_should_have_members_correctly = () =>
                result.Item1.Select(x => x.Name).ShouldContainOnly("Bluestreak", "Blades", "Firefighter");

        private It decepticon_team_should_have_members_correctly = () =>
                result.Item2.Select(x => x.Name).ShouldContainOnly("Soundwave", "Pounce");

        private static List<Transformer> subject;
        private static Tuple<Team<Autobot>, Team<Decepticons>> result;

        static Transformer stub(string name, char group)
        {
            return Transformer.Create(name, group, 5, 5, 5, 5, 5, 5, 5, 5);
        }
    }
}