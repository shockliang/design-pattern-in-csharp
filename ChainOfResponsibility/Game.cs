using System;

namespace ChainOfResponsibility
{
    public class Game
    {
        public event EventHandler<Query> Queries;

        public void PerformQuery(object sender, Query query)
        {
            Queries?.Invoke(sender, query);
        }
    }

    public class Query
    {
        public string CreatureName;

        public enum Argument
        {
            Attack,
            Defense
        }

        public Argument WhatToQuery;

        public int Value;

        public Query(string creatureName, Argument whatToQuery, int value)
        {
            CreatureName = creatureName ?? throw new ArgumentNullException(nameof(creatureName));
            WhatToQuery = whatToQuery;
            Value = value;
        }
    }
}