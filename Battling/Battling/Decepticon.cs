namespace Battling
{
    public class Decepticon:Transformer
    {
        public override Groups Group { get {return Groups.Decepticon;} }

        public Decepticon(string name, int strength, int intelligence, int speed, int endurance, int rank, int courage, int firepower, int skill) : base(name, strength, intelligence, speed, endurance, rank, courage, firepower, skill)
        {
        }
    }
}