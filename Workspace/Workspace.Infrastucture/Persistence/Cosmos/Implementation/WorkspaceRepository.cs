using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Application.Workspace.Interface;
using Workspace.Application.Workspace.Model;
using Workspace.Domain.Enum;
using Workspace.Infrastucture.Persistence.Cosmos.Interface;

namespace Workspace.Infrastucture.Persistence.Cosmos.Implementation
{
    public class WorkspaceRepository: CosmosDBRepository<WorkspaceDto>, IWorkspaceRepository
    {
        public WorkspaceRepository(ICosmosDbContainer cosmosDbContainer) : base (cosmosDbContainer)
        {
        }
        public override string ContainerName => "resourcemanagercollection";

        public override string PKValue(string id) => $"resource_{id}";

        public override PartitionKey ResolvePartitionKey(string id)
        {
            return new PartitionKey(PKValue(id));
        }
        public string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }
        public async Task<IEnumerable<WorkspaceDto>> GetAllWorkspaces()
        {
            string query = $"SELECT C.id as ID, C.LocationName as Location, C.Attributes, C.Status, C.WorkspaceType, C.WorkspaceName  FROM C where C.DocumentType='{Convert.ToString(EntityType.Workspace)}'";
            var response = await GetItemsAsync(query);
            return response;
        }
        public async Task CreateWorkspace(WorkspaceDto workspaceDto)
        {
            workspaceDto.PK = PKValue(workspaceDto.ID);
            await AddItemAsync(workspaceDto);
        }
        public async Task UpdateWorkspace(WorkspaceDto workspaceDto)
        {
            workspaceDto.PK = PKValue(workspaceDto.ID);
            await UpdateItemAsync(workspaceDto.ID, workspaceDto);
        }

    }
}
