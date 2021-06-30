using Bussiness.Intefaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerServiceSample
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfigurationExtension _IConfigurationExtension;
        public Worker(ILogger<Worker> logger,
                      IConfigurationExtension IConfigurationExtension)
        {
            _logger = logger;
            _IConfigurationExtension = IConfigurationExtension;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var login = _IConfigurationExtension.GetAppSettings("Login");
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
