using System;
using System.Collections.Generic;
using System.Linq;

namespace Battling
{
    public static class FightingStrategy
    {
        public static Tuple<Team<Autobot>, Team<Decepticon>> divide(this IEnumerable<Transformer> transformers)
        {
            var result = Tuple.Create(new Team<Autobot>(), new Team<Decepticon>());
            foreach (var transformer in transformers)
            {
                if (transformer is Autobot)
                {
                    result.Item1.join(transformer as Autobot);
                }
                if (transformer is Decepticon)
                {
                    result.Item2.join(transformer as Decepticon);
                }
            }
            return result;
        }

        public static IEnumerable<Tuple<Autobot,Decepticon>> organize_fighting(this Tuple<Team<Autobot>, Team<Decepticon>> teams)
        {
            var enumerator1 = teams.Item1.GetEnumerator();
            var enumerator2 = teams.Item2.GetEnumerator();
            
            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                yield return Tuple.Create(enumerator1.Current, enumerator2.Current);
            }
        }
    }
}