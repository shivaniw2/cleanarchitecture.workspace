using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Infrastucture.Persistence.Cosmos.Configuration;
using Workspace.Infrastucture.Persistence.Cosmos.Implementation;
using Workspace.Infrastucture.Persistence.Cosmos.Interface;

namespace Workspace.Infrastucture.Persistence.Cosmos
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCosmosDbDependency(this IServiceCollection collection, CosmoDBSettings cosmoDBSettings)
        {
            var cosmosClient = new CosmosClient(cosmoDBSettings.EndPointUrl, cosmoDBSettings.PrimaryKey);
            var cosmosDbContainer= new CosmosDbContainer(cosmosClient, cosmoDBSettings);
            collection.AddSingleton<ICosmosDbContainer>(cosmosDbContainer);
            return collection;
        }
    }
}
