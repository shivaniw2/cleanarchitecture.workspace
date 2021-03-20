using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Application.Common.Interfaces;
using Workspace.Application.Workspace.Model;

namespace Workspace.Application.Workspace.Interface
{
    public interface IWorkspaceRepository : IRepository<WorkspaceDto>
    {
        string GenerateId();
        Task<IEnumerable<WorkspaceDto>> GetAllWorkspaces();
        Task CreateWorkspace(WorkspaceDto workspaceDto);
        Task UpdateWorkspace(WorkspaceDto workspaceDto);
    }
}
