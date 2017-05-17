namespace Battling
{
    public abstract class Transformer
    {
        public enum Groups
        {
            Autobot,
            Deception
        }

        public abstract Groups Group { get; }

     }
}