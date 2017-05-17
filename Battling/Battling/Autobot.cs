using System;

namespace Battling
{
    public class Autobot:Transformer
    {
        public override Groups Group { get {return Groups.Autobot;} }

        public Autobot(int strength, int intelligence, int speed, int endurance, int rank, int courage, int firepower, int skill) : base(strength, intelligence, speed, endurance, rank, courage, firepower, skill)
        {
        }
    }
}