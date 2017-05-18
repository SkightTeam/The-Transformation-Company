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
        private static Tuple<Team<Autobot>, Team<Decepticon>> result;

        static Transformer stub(string name, char group)
        {
            return Transformer.Create(name, group, 5, 5, 5, 5, 5, 5, 5, 5);
        }
    }

    public class When_organize_2_team_to_fight
    {
        Establish context = () =>
        {
            var team1=new Team<Autobot>();
            team1.join(stub("Bluestreak",'A',10) as Autobot);
            team1.join(stub("Blades", 'A',8) as Autobot);
            team1.join(stub("Firefighter", 'A',5) as Autobot);

            var team2=new Team<Decepticon>();
            team2.join(stub("Soundwave", 'D', 9) as Decepticon);
            team2.join(stub("Pounce", 'D', 6) as Decepticon);

            subject = Tuple.Create(team1, team2);
        };

        private Because of = () => result=subject.organize_fighting();

        private It should_organize_2_battles_on_rank = () =>
            result.Select(x => $"{x.Item1.Name}:{x.Item2.Name}").SequenceEqual(
                new[] {"Bluestreak:Soundwave", "Blades:Pounce"}).ShouldBeTrue();

        private static Tuple<Team<Autobot>, Team<Decepticon>> subject;
        private static IEnumerable<Tuple<Autobot, Decepticon>> result;

        static Transformer stub(string name, char group, int rank)
        {
            return Transformer.Create(name, group, 5, 5, 5, 5, rank, 5, 5, 5);
        }
    }
   
}