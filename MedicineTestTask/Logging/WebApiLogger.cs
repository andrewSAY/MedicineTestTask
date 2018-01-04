using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using MedicineTestTask.Interfaces;
using NLog;

namespace MedicineTestTask.Logging
{
    public class WebApiLogger : ICommonLogger
    {
        private Logger _logger = LogManager.GetLogger("WebApiLogger");
        public void Error(string message)
        {
            _logger.Log(LogLevel.Error, null, new CultureInfo("ru-ru"), message);
        }

        public void Error(string message, Exception exception)
        {
            _logger.Log(LogLevel.Error, exception, new CultureInfo("ru-ru"), message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warning(string message)
        {
            _logger.Warn(message);
        }
    }
}