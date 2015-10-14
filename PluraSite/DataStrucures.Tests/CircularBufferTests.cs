using DataStructures;
using Xunit;

namespace DataStrucures.Tests
{
    public class CircularBufferTests
    {
        [Fact]
        public void First_In_First_Out_When_Not_Full()
        {
            var buffer = new CircularBuffer(capacity: 3);
            var values = new[] { 1.0, 2.0,5.0};

            foreach (var value in values)
            {
                buffer.Write(value);
            }

            Assert.Equal(values[0], buffer.Read());
            Assert.Equal(values[1], buffer.Read());
            Assert.Equal(values[2], buffer.Read());
            Assert.True (buffer.isEmpty());
        }

        [Fact]
        public void Overwrite_when_more_than_Capacity()
        {
            var buffer = new CircularBuffer(capacity: 3);
            var values = new[] { 1.0, 2.0, 3.0, 4.0, 5.0 };

            foreach (var value in values)
            {
                buffer.Write(value);
            }
            
            
            Assert.True(buffer.isFull());
            Assert.Equal(values[2], buffer.Read());
            Assert.Equal(values[3], buffer.Read());
            Assert.Equal(values[4], buffer.Read());
            Assert.True(buffer.isEmpty());

        }

    }
}
