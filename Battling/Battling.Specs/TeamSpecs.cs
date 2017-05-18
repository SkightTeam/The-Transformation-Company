using System.Linq;
using Machine.Specifications;
using Rhino.Mocks.Impl;

namespace Battling
{
    public class When_member_join_team_always_sorted_by_rank
    {

        Establish context = () =>
        {
            subject = new Team<Autobot>();
            subject.join(stub(4));
            subject.join(stub(6));
            subject.join(stub(3));
            subject.join(stub(1));
            subject.join(stub(2));
        };

        private It should_list_in_order = () => 
            subject.Select(x => x.Rank).SequenceEqual(new[]{6, 4, 3, 2, 1}).ShouldBeTrue();

        private static Team<Autobot> subject;

        static Autobot stub(int rank)
        {
            return Transformer.Create(rank.ToString(), 'A', 5, 5, 5, 5,rank, 5,5, 5) as Autobot;
        }
    }
}