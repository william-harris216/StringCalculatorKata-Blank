using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculatorBlank
{
    public class LoggerException : ApplicationException
    {
        public LoggerException(string message): base(message)
        {

        }
    }
}
