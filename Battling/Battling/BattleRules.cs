namespace Battling
{
    public static class BattleRules
    {
        public static bool win_on_courage_rule(this Transformer one, Transformer other)
        {
            if (one.Courage - other.Courage >= 4)
            {
                return true;
            }
            return false;
        }

        public static bool win_on_strength_rule(this Transformer one, Transformer other)
        {
            if (one.Strength - other.Strength >= 3)
            {
                return true;
            }
            return false;
        }

    }
}