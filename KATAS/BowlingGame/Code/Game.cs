using System;
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
            var frameIndex = 0;

            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    currentScore += 10 + StrikeBonus(frameIndex);
                    frameIndex += 1;
                }
                else if (IsSpare(frameIndex)) 
                {
                    currentScore += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    currentScore += SumOfRollsInFrame(frameIndex);
                    frameIndex += 2;
                }

                
            }


            return currentScore;
        }

        private int SumOfRollsInFrame(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private int SpareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private bool IsStrike(int roll)
        {
            return rolls[roll] == 10;
        }

        private bool IsSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
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