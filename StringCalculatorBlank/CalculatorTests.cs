using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StringCalculatorBlank
{
    public class CalculatorTests
    {

        StringCalculator calculator;

        public CalculatorTests()
        {
            calculator = new StringCalculator(new Mock<ILogger>().Object, new Mock<IWebService>().Object);
        }
        [Fact]
        public void EmptyStringReturnsZero()
        {

            int answer = calculator.Add("");

            Assert.Equal(0, answer);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("10", 10)]
        public void SingleDigit(string numbers, int expected)
        {

            var result = calculator.Add(numbers);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("5,5", 10)]
        [InlineData("100,8", 108)]
        public void TwoDigits(string numbers, int expected)
        {

            var result = calculator.Add(numbers);

            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("1,2,3,4,5,6,7,8,9", 45)]
        public void Arbitrary(string numbers, int expected)
        {
 

            var result = calculator.Add(numbers);

            Assert.Equal(expected, result);
        }



    }
}
