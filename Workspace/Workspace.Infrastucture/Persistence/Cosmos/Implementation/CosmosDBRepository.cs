using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Application.Common.Interfaces;
using Workspace.Domain.Common;
using Workspace.Infrastucture.Persistence.Cosmos.Interface;

namespace Workspace.Infrastucture.Persistence.Cosmos.Implementation
{
    public abstract class CosmosDBRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Container _container;
        public CosmosDBRepository(ICosmosDbContainer cosmosDbContainer)
        {
            _container = cosmosDbContainer.GetContainer(ContainerName);
        }

        #region CRUD operations
        public async Task<IEnumerable<T>> GetItemsAsync(string query)
        {
            FeedIterator<T> resultSetIterator = _container.GetItemQueryIterator<T>(new QueryDefinition(query));
            List<T> results = new List<T>();
            while (resultSetIterator.HasMoreResults)
            {
                FeedResponse<T> response = await resultSetIterator.ReadNextAsync();

                results.AddRange(response.ToList());
            }
            return results;

        }

        public async Task<T> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<T> response = await _container.ReadItemAsync<T>(id, ResolvePartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }
        public async Task AddItemAsync(T item)
        {
            await _container.CreateItemAsync<T>(item, ResolvePartitionKey(item.ID));
        }

        public async Task UpdateItemAsync(string id, T item)
        {
            await _container.UpsertItemAsync(item, ResolvePartitionKey(id));
        }
        public async Task DeleteItemAsync(string id)
        {
            await _container.DeleteItemAsync<T>(id, ResolvePartitionKey(id));
        }
        #endregion

        #region abstract methods
        public abstract string ContainerName { get; }
        public abstract string PKValue(string id);
        public abstract PartitionKey ResolvePartitionKey(string id);
        #endregion

    }
}
