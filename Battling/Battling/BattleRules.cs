namespace Battling
{
    public static class BattleRules
    {
        public static bool win_on_courage_and_strength_rule(this Transformer one, Transformer other)
        {
            if (one.Courage - other.Courage >= 4 && one.Strength - other.Strength >=3)
            {
                return true;
            }
            return false;
        }

        public static bool win_on_skill_rule(this Transformer one, Transformer other)
        {
            if (one.Skill - other.Skill >= 3)
            {
                return true;
            }
            return false;
        }

    }
}