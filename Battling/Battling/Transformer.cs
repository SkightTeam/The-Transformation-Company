using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Battling
{
    public abstract class Transformer
    {
        public enum Groups
        {
            Autobot,
            Deception
        }

        protected Transformer(string name, int strength, int intelligence, int speed, int endurance, int rank, int courage, int firepower, int skill)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Speed = speed;
            Endurance = endurance;
            Rank = rank;
            Courage = courage;
            Firepower = firepower;
            Skill = skill;
        }

        public string Name { get; private set; }
        public abstract Groups Group { get; }
        public int Strength { get; private set; }
        public int Intelligence { get; private set; }
        public int Speed { get; private set; }
        public int Endurance { get; private set; }
        public int Rank { get; private set; }
        public int Courage { get; private set; }
        public int Firepower { get; private set; }
        public int Skill { get; private set; }

        public static Transformer Create(string name, char group, int strength, int intelligence, int speed, int endurance,
            int rank, int courage, int firepower, int skill)
        {
            switch (group)
            {
                case 'A':
                    return new Autobot(name,strength, intelligence,speed,endurance,rank,courage,firepower,skill);
                    break;
                case 'D':
                    return new Deception(name,strength, intelligence, speed, endurance, rank, courage, firepower, skill);
            }
            throw new ArgumentOutOfRangeException(nameof(group),group,$"Group {group} is not acceptable.");
        }
     }
}