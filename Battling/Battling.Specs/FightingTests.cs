using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Battling.Specs
{
    [TestFixture]
    public class FightingTests
    {
        [Test]
        public void SimpleFightingCase()
        {
            var subject = new List<Transformer>
            {
                Transformer.Create("Soundwave", 'D', 8, 9, 2, 6, 7, 5, 6, 10),
                Transformer.Create("Bluestreak", 'A', 6, 6, 7, 9, 5, 2, 9, 7),
                Transformer.Create("Hubcap:", 'A', 4, 4, 4, 4, 4, 4, 4, 4),
            };

            var messages = subject.fight();

            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
        }
    }
}