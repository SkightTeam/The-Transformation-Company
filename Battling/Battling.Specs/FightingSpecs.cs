using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Machine.Specifications;

namespace Battling.Specs
{
    public class FightingSpecs
    {
        private Because of = () =>
        {
            messages = subject.fight();
            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
        };
        protected static List<Transformer> subject;
        public static IEnumerable<string> messages;

    }

    public class SimpleFightingCases : FightingSpecs
    {
        Establish context = () => subject = new List<Transformer>
        {
            Transformer.Create("Soundwave", 'D', 8,9,2,6,7,5,6,10),
            Transformer.Create("Bluestreak", 'A', 6,6,7,9,5,2,9,7),
            Transformer.Create("Hubcap:", 'A', 4,4,4,4,4,4,4,4),
        };

        It message_should_generate = () => messages.ShouldNotBeEmpty();
    }
}