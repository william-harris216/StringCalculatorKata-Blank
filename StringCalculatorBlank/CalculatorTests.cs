using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StringCalculatorBlank
{
    public class CalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            var calculator = new StringCalculator();

            int answer = calculator.Add("");

            Assert.Equal(0, answer);
        }
    }
}
