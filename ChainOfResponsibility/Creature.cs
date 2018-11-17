using System;
using static System.Console;

namespace ChainOfResponsibility
{
    public class Creature
    {
        public string Name;
        public int Attack;
        public int Defense;

        public Creature(string name, int attack, int defense)
        {
            this.Defense = defense;
            this.Attack = attack;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense},";
        }
    }

    public class CreatureModifier
    {
        protected Creature creature;
        protected CreatureModifier next;    // linked list

        public CreatureModifier(Creature creature)
        {
            this.creature = creature ?? throw new ArgumentNullException(nameof(creature));
        }

        public void Add(CreatureModifier creatureModifier)
        {
            if (next != null) next.Add(creatureModifier);
            else next = creatureModifier;
        }

        public virtual void Handle() => next?.Handle();
    }

    public class NoBonusesModifier : CreatureModifier
    {
        public NoBonusesModifier(Creature creature) : base(creature) { }

        public override void Handle()
        {
            // nothing to do to prevent traversing the linked list.
        }
    }

    public class DoubleAttackModifier : CreatureModifier
    {
        public DoubleAttackModifier(Creature creature) : base(creature) { }

        public override void Handle()
        {
            WriteLine($"Doubling {creature.Name}'s attack");
            creature.Attack *= 2;
            base.Handle();
        }
    }

    public class IncreasedDefenseModifier : CreatureModifier
    {
        public IncreasedDefenseModifier(Creature creature) : base(creature) { }

        public override void Handle()
        {
            WriteLine($"Increasing {creature.Name}'s defense");
            creature.Defense += 3;
        }
    }
}