using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorBlank
{
    public class StringCalculator
    {

        ILogger _logger;
        IWebService _webService;

        public StringCalculator(ILogger logger, IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }

        public int Add(string numbers)
        {
            if (numbers == "") { return 0; }
            var result =  numbers.Split(',').Select(int.Parse).Sum();
            
            try
            {
                _logger.Write(result.ToString());
            }
            catch (LoggerException ex)
            {
                _webService.LogError(ex.Message);
            }
            
            return result;
        }
    }
}
