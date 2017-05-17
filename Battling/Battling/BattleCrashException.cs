using System;

namespace Battling
{
    public class BattleCrashException:ApplicationException
    {
        public BattleCrashException(string message) : base(message)
        {
        }
    }
}