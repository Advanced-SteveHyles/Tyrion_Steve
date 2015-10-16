using System;
using Xunit;

namespace TestsAsDemos
{
    public class ActionFuncPredicateConverter
    {
        private int _result;

        public int Result
        {
            get { return _result; }
            set { _result = value; }
        }

        [Fact]
        public void Actions()
        {
            Result = 0;

            Action<int> a = (x) =>
            {
                _result = x;         
            };

            a(10);

            Assert.Equal(10, Result);

            a = ActionB;

            a(10);

            Assert.Equal(19, Result);
        }

        private void ActionB(int x)
        {
            Result = 9 + x;
        }

        [Fact]
        void Func()
        {
            Func<int, int> a = (x) => x;

            var funcResult = a(10);

            Assert.Equal(10, funcResult);

            a = FuncB;

            funcResult = a(10);

            Assert.Equal(19, funcResult);
        }

        private int  FuncB(int x)
        {
            return 9 + x;
        }

        [Fact]
        void Predicate()
        {
            Predicate<int> Test = (x)=> x == 10;

            Assert.True(Test(10));
            Assert.False(Test(19));

            Test = PredicateB;         

            Assert.True(Test(19));
        }

        bool PredicateB(int x)
        {
            return x == 19;
        }


        [Fact]
        public void Converter()
        {
            Converter<int, bool> converter;
            converter = x => { return x == 10; };

            Assert.True(converter(10));
            Assert.False(converter(19));

            converter = ConverterB;

            Assert.True(converter(19));
            Assert.False(converter(10));
            
        }

        private bool ConverterB(int x)
        {
            return x == 19;
        }
    }
}
