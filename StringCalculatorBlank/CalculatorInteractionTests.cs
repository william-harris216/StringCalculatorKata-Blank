
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StringCalculatorBlank
{
    public class CalculatorInteractionTests
    {

        StringCalculator calculator;
        Mock<ILogger> logger;
        Mock<IWebService> webService;

        public CalculatorInteractionTests()
        {
            logger = new Mock<ILogger>();
            webService = new Mock<IWebService>();
            calculator = new StringCalculator(logger.Object, webService.Object);
         
           
        }

        [Theory]
        [InlineData("1,2", "3")]
        [InlineData("1,2,3,4,5,6,7,8,9", "45")]
        public void WritesToTheLogger(string numbers, string expected)
        {
            calculator.Add(numbers);


            logger.Verify(m => m.Write(expected));

        }

        [Theory]
        [InlineData("1", "1", "Could Not Log 1")]
        [InlineData("1,2", "3", "Could Not Log 3")]
        public void IfLoggerThrowsWebServiceIsCalled(string numbers, string expected, string message)
        {

            logger.Setup(m => m.Write(It.IsAny<string>())).Throws(new LoggerException($"Could Not Log {expected}"));
            
            calculator.Add(numbers);


            webService.Verify(w => w.LogError(message));

        }

        [Fact]
        public void WebServiceShouldNotBeCalledIfNoLoggerError()
        {
            calculator.Add("1");

            webService.Verify(w => w.LogError(It.IsAny<string>()), Times.Never);
        }

    }
}
