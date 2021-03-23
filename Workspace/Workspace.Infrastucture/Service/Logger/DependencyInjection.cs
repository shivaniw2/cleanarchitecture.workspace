using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Workspace.Application.Common.Interfaces;

namespace Workspace.Infrastucture.Service.Logger
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLogger(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            serviceDescriptors.AddSingleton(typeof(ILoggerAdapter<>), typeof(Logger<>));
            serviceDescriptors.AddSingleton<ILogger>(Log.Logger);
            return serviceDescriptors;
        }
    }
}