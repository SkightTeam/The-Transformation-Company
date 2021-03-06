﻿using System;
using System.Collections.Generic;

namespace Battling
{
    public class Battle
    {
        public Battle(Transformer fighter1, Transformer fighter2)
        {
            Fighter1 = fighter1;
            Fighter2 = fighter2;
            Winners = new  List<Transformer>();
            Losers = new  List<Transformer>();
            if(fighter1.is_special_name() && fighter2.is_special_name())
                throw new BattleCrashException("Boom!");

            if (try_battle_rule(BattleRules.win_on_special_name))
                return;

            if (try_battle_rule(BattleRules.win_on_courage_and_strength_rule))
                return;

            if (try_battle_rule(BattleRules.win_on_skill_rule))
                return;

            if (try_battle_rule(BattleRules.win_on_overall_rule))
                return;

            if (fighter1.is_tie_rating(fighter2))
            {
                Losers.Add(fighter1);
                Losers.Add(fighter2);
            }

        }

        public Transformer Fighter1 { get; private set; }
        public Transformer Fighter2 { get; private set; }
        public IList<Transformer> Winners { get; private set; }
        public IList<Transformer> Losers { get; private set; }

        private bool try_battle_rule(Func<Transformer,Transformer,bool> rule)
        {
            if (rule(Fighter1, Fighter2))
            {
                Winners.Add(Fighter1);
                Losers.Add(Fighter2);
                return true;
            }
            else if(rule(Fighter2, Fighter1))
            {
                Winners.Add(Fighter2);
                Losers.Add(Fighter1);
                return true;
            }
            return false;
        }
    }
    
}