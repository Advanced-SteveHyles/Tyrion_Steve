﻿using System.Security.Policy;
using BowlingGame.Code;
using Xunit;

namespace BowlingGame
{
    //http://butunclebob.com/ArticleS.UncleBob.TheBowlingGameKata

    public class BowlingGameTests
    {
        private readonly Game _game;

        public BowlingGameTests()
        {
            _game = new Game();
        }

        [Fact]
        public void InitialScoreIsZero()
        {            
            Assert.Equal(0, _game.Score());
        }

        [Fact]
        public void WhenAllNoPinsAreKnockedDownInEntireGameScoreIsZero()
        {
            RollMany(20, 0);

            Assert.Equal(0, _game.Score());
        }

        private void RollMany(int throws, int pinsKnockedOver)
        {
            for (int i = 0; i < throws; i++)
                _game.Roll(pinsKnockedOver);
        }

        [Fact]
        public void WhenOnlyOnesAreRolledScoreIs20()
        {         
            RollMany(20, 1);

            Assert.Equal(20, _game.Score());
        }

        [Fact]
        public void TestOneSpare()
        {
            RollSpare();
            _game.Roll(3);
            RollMany(17,0);
            Assert.Equal(16, _game.Score());
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        [Fact]
        public void TestOneStrike()
        {
            RollStrike(); 
            _game.Roll(3);
            _game.Roll(4);
            RollMany(16, 0);
            Assert.Equal(24, _game.Score());
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }

        [Fact]
        public void TestPerfectGame()
        {
            RollMany(12,10);
            Assert.Equal(300, _game.Score());
        }
    }
}