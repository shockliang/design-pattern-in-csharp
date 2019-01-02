using System;

namespace Observer.Coding.Exercise
{
    public class Game
    {
        // remember - no fields or properties!
        public event EventHandler RatJoinEvent;
        public event EventHandler RatDeadEvent;
        public event EventHandler<Rat> NotifyRatEvent;

        public void TriggerRatJoin(object sender)
        {
            RatJoinEvent?.Invoke(sender, EventArgs.Empty);
        }

        public void TriggerRatDead(object sender)
        {
            RatDeadEvent?.Invoke(sender, EventArgs.Empty);
        }

        public void NotifyRat(object sender, Rat whichRat)
        {
            NotifyRatEvent?.Invoke(sender, whichRat);
        }

    }

    public class Rat : IDisposable
    {
        public int Attack = 1;
        private readonly Game game;

        public Rat(Game game)
        {
            this.game = game;
            game.RatJoinEvent += (sender, args) =>
            {
                if (sender != this)
                {
                    Attack++;
                    game.NotifyRat(this, (Rat)sender);
                }
            };

            game.NotifyRatEvent += (sender, args) =>
            {
                if (args == this)
                    Attack++;
            };

            game.RatDeadEvent += (sender, args) =>
             {
                 Attack--;
             };

            game.TriggerRatJoin(this);
        }

        public void Dispose()
        {
            game.TriggerRatDead(this);
        }
    }
}

