using System;
using Serilog;
using Workspace.Application.Common.Interfaces;

namespace Workspace.Infrastucture.Service.Logger
{
    public class Logger<T>: ILoggerAdapter<T>
    {
        private readonly ILogger _logger;

        public Logger(ILogger logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.Information(message);
        }

        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        public void LogError(Exception ex, string message, params object[] args)
        {
            _logger.Error(ex, message, args);
        }
    }
}