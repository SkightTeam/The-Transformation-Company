using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Battling
{
    public class Team<T> :IEnumerable<T>
        where T:Transformer
    {
        private IList<T> members;

        public Team( )
        {
            this.members = new List<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return members.OrderByDescending(x=>x.Rank).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void join(T member)
        {
           members.Add(member);
        }
    }
}