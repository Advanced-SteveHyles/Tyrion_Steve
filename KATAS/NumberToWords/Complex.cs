using Xunit;

namespace NumberToWords
{
    public class Complex
    {
        //[Fact]
        //public void OneDollarAndACentReturnsr()
        //{
        //    var number = "1.01 $";
        //var x = new NumberToWords(number);

        //Assert.Equal("One Dollar And One Cent", x.Convert());
        //}

        //[Fact]
        //public void OneDollarAndACentReturnsr()
        //{
        //    var number = "1.01 $";
        //    var x = new NumberToWords(number);

        //    Assert.Equal("One Dollar And One Cent", x.Convert());
        //}

        //[Fact]
        //public void OnePoundAndAPenceReturnsr()
        //{
        //    var number = "1.01 £";
        //    var x = new NumberToWords(number);

        //    Assert.Equal("One Pound And One Pence", x.Convert());
        //}


        [Fact]
        public void FinalTest()
        {
            var number = "745.00 $";
            var x = new NumberToWords(number);

            Assert.Equal("Seven hundred and forty five dollars", x.Convert());
        }
    }
}