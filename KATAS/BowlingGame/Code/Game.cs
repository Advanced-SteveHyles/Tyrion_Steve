using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace BowlingGame.Code
{
    public class Game
    {
        private readonly int[] rolls = new int[21];
       
        private int _currentRoll =0;

        public int Score()
        {
            var currentScore = 0;
            int roll = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (rolls[roll] + rolls[roll + 1] == 10) // spare
                {
                    currentScore += 10 + rolls[roll + 2];
                    roll += 2;
                }
                else
                {
                    currentScore += rolls[roll] + rolls[roll + 1];
                    roll += 2;
                }
            }


            return currentScore;
        }

        private int ProcessRound(int round)
        {
            var firstThrow = rolls[round];
            var secondThrow = rolls[round+1];

            if (firstThrow + secondThrow == 10)
            {
                
            }

            return firstThrow + secondThrow;
        }

        public bool WasRollCalled { get; set; }

        public void Roll(int pinsKnockedDown)
        {
            rolls[_currentRoll] = pinsKnockedDown;
            _currentRoll ++;
        }
    }
}