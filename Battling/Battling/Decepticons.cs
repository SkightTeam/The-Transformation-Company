namespace Battling
{
    public class Decepticons:Transformer
    {
        public override Groups Group { get {return Groups.Decepticon;} }

        public Decepticons(string name, int strength, int intelligence, int speed, int endurance, int rank, int courage, int firepower, int skill) : base(name, strength, intelligence, speed, endurance, rank, courage, firepower, skill)
        {
        }
    }
}