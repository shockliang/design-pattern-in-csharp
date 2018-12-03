using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using static System.Console;

namespace Mediator
{
    public class Actor
    {
        protected EventBroker broker;
        public Actor(EventBroker broker)
        {
            this.broker = broker ?? throw new ArgumentNullException(nameof(broker));
        }
    }

    public class FootballPlayer : Actor
    {
        public string Name { get; set; }
        public int GoalsScored { get; set; } = 0;
        public FootballPlayer(EventBroker broker, string name)
            : base(broker)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.broker = broker ?? throw new ArgumentNullException(nameof(broker));

            broker.OfType<PlayerScoredEvent>()
                .Where(ps => !ps.Name.Equals(name))
                .Subscribe(ps => WriteLine($"{name}: Nicely doen, {ps.Name}! It's your {ps.GoalsScored} goal."));

            broker.OfType<PlayerSentoffEvent>()
                .Where(ps => !ps.Name.Equals(name))
                .Subscribe(ps => WriteLine($"{name}: See you in the lockers, {ps.Name}"));
        }

        public void Score()
        {
            GoalsScored++;
            broker.Publish(new PlayerScoredEvent { Name = Name, GoalsScored = GoalsScored });
        }

        public void AssaaultReferee()
        {
            broker.Publish(new PlayerSentoffEvent { Name = Name, Reason = "violence" });
        }
    }

    public class FootballCoach : Actor
    {
        public FootballCoach(EventBroker broker)
            : base(broker)
        {
            broker.OfType<PlayerScoredEvent>()
                .Subscribe(pe =>
                {
                    if (pe.GoalsScored < 3)
                        WriteLine($"Coach: Well done, {pe.Name}!");
                });

            broker.OfType<PlayerSentoffEvent>()
                .Subscribe(pe =>
                {
                    if (pe.Reason == "violence")
                        WriteLine($"Coach: How could you, {pe.Name}.");
                });
        }
    }

    public class PlayerEvent
    {
        public string Name { get; set; }
    }

    public class PlayerScoredEvent : PlayerEvent
    {
        public int GoalsScored { get; set; }
    }

    public class PlayerSentoffEvent : PlayerEvent
    {
        public string Reason { get; set; }
    }

    public class EventBroker : IObservable<PlayerEvent>
    {
        private Subject<PlayerEvent> subscriptions = new Subject<PlayerEvent>();

        public IDisposable Subscribe(IObserver<PlayerEvent> observer)
        {
            return subscriptions.Subscribe(observer);
        }

        public void Publish(PlayerEvent playerEvent)
        {
            subscriptions.OnNext(playerEvent);
        }
    }
}