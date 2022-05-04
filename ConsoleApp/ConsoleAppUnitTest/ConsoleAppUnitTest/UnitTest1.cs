using Xunit;
using FizzBuzz;
namespace ConsoleAppUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange           
            string fizz, buzz, fizzbuzz, i = string.Empty;

            //Act
            fizz = Program.DisplayFizzBuzz(9);
            buzz = Program.DisplayFizzBuzz(10);
            fizzbuzz = Program.DisplayFizzBuzz(15);
            i = Program.DisplayFizzBuzz(4);

            //Assert
            Assert.Equal("Fizz", fizz);
            Assert.Equal("Buzz", buzz);
            Assert.Equal("FizzBuzz", fizzbuzz);
            Assert.Equal("4", i);
        }
    }
}