using System;
using static System.Console;

namespace ChainOfResponsibility
{
    public class Creature
    {
        public string Name;
        private int attack;
        private int defense;

        private Game game;

        public Creature(Game game, string name, int attack, int defense)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
            this.defense = defense;
            this.attack = attack;
            this.Name = name;
        }

        public int Attack
        {
            get
            {
                var query = new Query(this.Name, Query.Argument.Attack, attack);
                game.PerformQuery(this, query);
                return query.Value;
            }
        }

        public int Defense
        {
            get
            {
                var query = new Query(this.Name, Query.Argument.Defense, defense);
                game.PerformQuery(this, query);
                return query.Value;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense},";
        }
    }

    public abstract class CreatureModifier : IDisposable
    {
        protected Game game;
        protected Creature creature;

        public CreatureModifier(Game game, Creature creature)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
            this.creature = creature ?? throw new ArgumentNullException(nameof(creature));
            game.Queries += Handle;
        }

        protected abstract void Handle(object sender, Query query);

        public void Dispose()
        {
            game.Queries -= Handle;
        }
    }

    public class DoubleAttackModifier : CreatureModifier
    {
        public DoubleAttackModifier(Game game, Creature creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, Query query)
        {
            if (query.CreatureName == creature.Name
                && query.WhatToQuery == Query.Argument.Attack)
            {
                query.Value *= 2;
            }
        }
    }

    public class IncreasedDefenseModifier : CreatureModifier
    {
        public IncreasedDefenseModifier(Game game, Creature creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, Query query)
        {
            if (query.CreatureName == creature.Name
               && query.WhatToQuery == Query.Argument.Defense)
            {
                query.Value += 3;
            }
        }
    }
}