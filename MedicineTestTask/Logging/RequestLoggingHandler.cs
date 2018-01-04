using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MedicineTestTask.Interfaces;

namespace MedicineTestTask.Logging
{
    /// <summary>
    /// Логирует все пользовательские обращения web api и ответы, сгенированные web api в ответ на эти запросы
    /// </summary>
    public class RequestLoggingHandler : DelegatingHandler
    {
        private ICommonLogger _logger;
        public RequestLoggingHandler(ICommonLogger logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request != null)
                _logger.Info(request.RequestUri.AbsoluteUri); 
            else
                _logger.Warning("An empty request");
            var requestResult = await base.SendAsync(request, cancellationToken);
            if (requestResult != null)
                _logger.Info($"A request completed with a code '{requestResult.StatusCode}'");
            else
                _logger.Warning("An empty response");

            return requestResult;
        }
    }
}