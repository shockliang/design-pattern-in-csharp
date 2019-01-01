using System;
using System.Linq;
using System.Collections.Generic;

namespace Mediator.Coding.Exercise
{
    public class Participant
    {
        public int Value { get; set; }
        private readonly Mediator mediator;

        public Participant(Mediator mediator)
        {
            this.mediator = mediator;
            this.mediator.Join(this);
        }

        public void Say(int n)
        {
            mediator.Broadcast(this, n);
        }
    }

    public class Mediator
    {
        private List<Participant> participants = new List<Participant>();

        public void Join(Participant participant) => participants.Add(participant);

        public void Broadcast(Participant self, int value)
        {
            participants
                .Where(p => p != self)
                .ToList()
                .ForEach(p => p.Value = value);
        }
    }
}