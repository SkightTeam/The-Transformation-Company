using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Battling
{
    public class Team<T> :IEnumerable<T>
        where T:Transformer
    {
        private IList<T> members;
        private IList<T> eliminated_members;

        public Team( )
        {
            this.members = new List<T>();
            eliminated_members=new List<T>();
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

        public void try_eliminate(IEnumerable<Transformer> transformers)
        {
            foreach (var transformer in transformers)
            {
                if (members.Contains(transformer))
                {
                    eliminated_members.Add(transformer as T);
                }
            }
        }
    }
}