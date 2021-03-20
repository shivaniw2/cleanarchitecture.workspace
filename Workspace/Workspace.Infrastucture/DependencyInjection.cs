using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Workspace.Application.Common.Interfaces;
using Workspace.Application.Workspace.Interface;
using Workspace.Infrastucture.Persistence.Cosmos;
using Workspace.Infrastucture.Persistence.Cosmos.Configuration;
using Workspace.Infrastucture.Persistence.Cosmos.Implementation;

namespace Workspace.Infrastucture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastuctureDependencies(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            var settings = new CosmoDBSettings();
            configuration.Bind(nameof(CosmoDBSettings), settings);
            serviceDescriptors.AddCosmosDbDependency(settings);

            serviceDescriptors.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
            return serviceDescriptors;
        }
    }
}
