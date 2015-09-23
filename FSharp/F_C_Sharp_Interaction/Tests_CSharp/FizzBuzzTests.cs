using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FizzBuzz_FSharp;

namespace Tests_CSharp
{
    //http://codingdojo.org/cgi-bin/index.pl?KataFizzBuzz

    public class FizzBuzzTests
    {
        private readonly FixBuzzController _fizzBuzzController;

        public FizzBuzzTests()
        {
            _fizzBuzzController = new FixBuzzController();
        }

        [Fact]
        public void ZeroReturnsFizzBuzz()
        {
            Assert.Equal("FizzBuzz",  _fizzBuzzController.PlayFizBuzz(0));
            //Assert.Equal("FizzBuzz",  _fizzBuzzController.PlayFizBuzz(0));
        }


        [Fact]
        public void OneReturnsOne()
        {
            Assert.Equal("1", _fizzBuzzController.PlayFizBuzz(1)); ;
        }

        [Fact]
        public void TwoReturnsTwo()
        {
            Assert.Equal("2", _fizzBuzzController.PlayFizBuzz(2)); ;
        }

        [Fact]
        public void ThreeReturnsFizz()
        {
            var actual = (_fizzBuzzController.PlayFizBuzz(3)); ;
            Assert.Equal("Fizz", actual);
        }

        [Fact]
        public void ThirteenReturnsFizz()
        {
            var actual = (_fizzBuzzController.PlayFizBuzz(13)); ;
            Assert.Equal("Fizz", actual);
        }

        [Fact]
        public void FiftyFiveReturnsBuzz()
        {
            var actual = (_fizzBuzzController.PlayFizBuzz(55)); ;
            Assert.Equal("Buzz", actual);
        }
    }
}
