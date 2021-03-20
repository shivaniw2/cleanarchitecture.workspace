using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Infrastucture.Persistence.Cosmos.Configuration;
using Workspace.Infrastucture.Persistence.Cosmos.Interface;

namespace Workspace.Infrastucture.Persistence.Cosmos.Implementation
{
    public class CosmosDbContainer : ICosmosDbContainer
    {
        private readonly CosmosClient _cosmosClient;
        private readonly CosmoDBSettings _cosmosSettings;
        public CosmosDbContainer(CosmosClient cosmosClient, CosmoDBSettings cosmoDBSettings)
        {
            _cosmosClient = cosmosClient;
            _cosmosSettings = cosmoDBSettings;
        }
        public Container GetContainer(string containerName)
        {
            if (Convert.ToBoolean(_cosmosSettings.Containers?.Any(x => x.Name == containerName)))
            {
                Container container = _cosmosClient.GetContainer(_cosmosSettings.DatabaseName, containerName);
                //((Microsoft.Azure.Cosmos.ContainerCore)container).LinkUri
                return container;
            }
            else
            {
                throw new Exception("Container does not exist.");
            }
        }
    }
}
