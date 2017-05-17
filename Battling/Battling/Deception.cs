namespace Battling
{
    public class Deception:Transformer
    {
        public override Groups Group { get {return Groups.Deception;} }

        public Deception(int strength, int intelligence, int speed, int endurance, int rank, int courage, int firepower, int skill) : base(strength, intelligence, speed, endurance, rank, courage, firepower, skill)
        {
        }
    }
}