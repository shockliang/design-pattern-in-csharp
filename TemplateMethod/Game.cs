using System;
using static System.Console;

namespace TemplateMethod
{
    public abstract class Game
    {

        protected int currentPlayer;
        protected readonly int numberOfPlayers;

        protected abstract bool HaveWinner { get; }
        protected abstract int WinningPlayer { get; }

        protected Game(int numberOfPlayers)
        {
            this.numberOfPlayers = numberOfPlayers;
        }

        public void Run()
        {
            Start();
            while (!HaveWinner)
            {
                TakeTurn();
            }
            WriteLine($"Player {WinningPlayer} wins.");
        }

        protected abstract void Start();
        protected abstract void TakeTurn();
    }

    public class Chess : Game
    {
        private int turn = 1;
        private int maxTurns = 10;

        protected override bool HaveWinner => turn == maxTurns;

        protected override int WinningPlayer => currentPlayer;

        public Chess() : base(2)
        {
        }

        protected override void Start()
        {
            WriteLine($"Starting a game of chess with {numberOfPlayers} players.");
        }

        protected override void TakeTurn()
        {
            WriteLine($"Turn {turn++} taken by player {currentPlayer}.");
            currentPlayer = (currentPlayer + 1) % numberOfPlayers;
        }
    }
}