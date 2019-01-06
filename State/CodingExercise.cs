using System;
using System.Collections;
using System.Linq;

namespace State.Coding.Exercise
{
    public class CombinationLock
    {
        // you need to be changing this on user input
        public string Status;
        private readonly int[] combination;
        private int currentIdx = 0;

        public CombinationLock(int[] combination)
        {
            this.combination = combination;
            Status = "LOCKED";
        }


        public void EnterDigit(int digit)
        {
            if (!combination.Contains(digit))
            {
                Status = "ERROR";
                return;
            }

            if (combination[currentIdx] == digit)
            {
                Status = string.Join("", combination.Take(currentIdx + 1));
                if (currentIdx + 1 == combination.Length)
                {
                    Status = "OPEN";
                }
                else
                {
                    currentIdx++;
                }
            }
            else
            {
                Status = "ERROR";
            }
        }
    }
}