using System;
using System.Collections.Generic;
using System.Text;
using Stateless;
using static System.Console;

namespace State
{
    class Program
    {
        public static bool ParentsNotWatching { get; private set; }

        public enum Health
        {
            NonReproductive,
            Pregnant,
            Reproductive
        }

        public enum Activity
        {
            GiveBirth,
            ReachPuberty,
            HaveAbortion,
            HaveUnprotectedSex,
            Historectomy
        }
        static void Main(string[] args)
        {
            var machine = new StateMachine<Health, Activity>(Health.NonReproductive);
            machine.Configure(Health.NonReproductive)
                .Permit(Activity.ReachPuberty, Health.Reproductive);

            machine = new StateMachine<Health, Activity>(Health.NonReproductive);
            machine.Configure(Health.NonReproductive)
                .Permit(Activity.ReachPuberty, Health.Reproductive);
            machine.Configure(Health.Reproductive)
                .Permit(Activity.Historectomy, Health.NonReproductive)
                .PermitIf(Activity.HaveUnprotectedSex, Health.Pregnant,
                () => ParentsNotWatching);
            machine.Configure(Health.Pregnant)
                .Permit(Activity.GiveBirth, Health.Reproductive)
                .Permit(Activity.HaveAbortion, Health.Reproductive);
        }
    }
}
