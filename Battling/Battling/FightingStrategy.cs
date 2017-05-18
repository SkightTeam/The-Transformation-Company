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

        
        public static IEnumerable<string> fight(this IEnumerable<Transformer> transformers)
        {
            var messages=new List<string>();
            var teams = transformers.divide();
            var pairs = teams.organize_fighting();
            var battle_count = 0;
            foreach (var pair in pairs)
            {
                try
                {
                    var battle = new Battle(pair.Item1, pair.Item2);
                    teams.Item1.try_eliminate(battle.Losers);
                    teams.Item2.try_eliminate(battle.Losers);
                    battle_count++;
                }
                catch (BattleCrashException e)
                {
                    teams.Item1.eliminate_all();
                    teams.Item2.eliminate_all();
                    break;
                }
            }
            messages.Add($"{battle_count} battle(s)");
            if (teams.Item1.EliminatedMembers.Count() < teams.Item2.EliminatedMembers.Count())
            {
                messages.Add($"Winning team ({teams.Item1}): {string.Join(",", teams.Item1.Survivers.Select(x=>x.Name))}");
                messages.Add($"Survivors from the losing team ({teams.Item2}): {string.Join(",", teams.Item2.Survivers.Select(x=>x.Name))}");
            }
            else if (teams.Item1.EliminatedMembers.Count() > teams.Item2.EliminatedMembers.Count())
            {
               
                messages.Add($"Winning team ({teams.Item2}): {string.Join(",", teams.Item2.Survivers.Select(x => x.Name))}");
                messages.Add($"Survivors from the losing team ({teams.Item1}): {string.Join(",", teams.Item1.Survivers.Select(x => x.Name))}");
            }
            else
            {
                messages.Add($"No Winning Team");
                messages.Add($"Suvierors from team({teams.Item1}): {string.Join(",", teams.Item1.Survivers.Select(x => x.Name))}");
                messages.Add($"Suvierors from team({teams.Item2}): {string.Join(",", teams.Item2.Survivers.Select(x => x.Name))}");

            }
            return messages;
        }
    }
}