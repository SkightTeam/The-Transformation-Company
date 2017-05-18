using System;
using System.Collections.Generic;
using System.Linq;

namespace Battling
{
    public static class FightingStrategy
    {
        public static Tuple<Team<Autobot>, Team<Decepticons>> divide(this IEnumerable<Transformer> transformers)
        {
            var result = Tuple.Create(new Team<Autobot>(), new Team<Decepticons>());
            foreach (var transformer in transformers)
            {
                if (transformer is Autobot)
                {
                    result.Item1.join(transformer as Autobot);
                }
                if (transformer is Decepticons)
                {
                    result.Item2.join(transformer as Decepticons);
                }
            }
            return result;
        }
    }
}