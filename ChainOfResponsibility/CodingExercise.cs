using System;
using System.Linq;
using System.Collections.Generic;

namespace ChainOfResponsibility.Coding.Exercise
{
    public enum State
    {
        Attack,
        Defense
    }

    public class StateQuery
    {
        public State State;
        public int Value;
    }

    public abstract class Creature
    {
        protected readonly int baseAttack;
        protected readonly int baseDefense;
        protected readonly Game game;

        public Creature(Game game, int baseAttack, int baseDefense)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
            this.baseDefense = baseDefense;
            this.baseAttack = baseAttack;

        }
        public virtual int Attack { get; set; }
        public virtual int Defense { get; set; }
        public abstract void Query(object sender, StateQuery query);

    }

    public class Goblin : Creature
    {
        public Goblin(Game game)
            : base(game: game, baseAttack: 1, baseDefense: 1)
        {

        }

        public Goblin(Game game, int baseAttack, int baseDefense)
            : base(game, baseAttack, baseDefense)
        { }

        public override int Attack
        {
            get
            {
                var query = new StateQuery() { State = State.Attack };
                foreach (var creature in game.Creatures)
                {
                    creature.Query(this, query);
                }
                return query.Value;
            }
        }

        public override int Defense
        {
            get
            {
                var query = new StateQuery() { State = State.Defense };

                foreach (var creature in game.Creatures)
                {
                    creature.Query(this, query);
                }
                return query.Value;
            }
        }

        public override void Query(object sender, StateQuery query)
        {
            if (ReferenceEquals(sender, this))
            {
                switch (query.State)
                {
                    case State.Attack:
                        query.Value += baseAttack;
                        break;
                    case State.Defense:
                        query.Value += baseDefense;
                        break;
                }
            }
            else
            {
                if (query.State == State.Defense)
                    query.Value++;
            }
        }
    }

    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game)
            : base(game: game, baseAttack: 3, baseDefense: 3)
        {

        }

        public override void Query(object sender, StateQuery query)
        {
            if (!ReferenceEquals(sender, this) && query.State == State.Attack)
            {
                query.Value++;
            }
            else
            {
                base.Query(sender, query);
            }
        }
    }

    public class Game
    {
        public IList<Creature> Creatures;

        public Game()
        {
            Creatures = new List<Creature>();
        }
    }

}
