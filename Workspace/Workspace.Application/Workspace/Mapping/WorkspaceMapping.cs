using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Application.Workspace.Commands.CreateWorkspace;
using Workspace.Application.Workspace.Commands.DeleteWorkspace;
using Workspace.Application.Workspace.Commands.UpdateWorkspace;
using Workspace.Application.Workspace.Model;

namespace Workspace.Application.Workspace.Mapping
{
    public class WorkspaceMapping : Profile
    {
        public WorkspaceMapping()
        {
            CreateMap<Domain.Entity.Workspace, WorkspaceDto>();
            CreateMap<WorkspaceDto, Domain.Entity.Workspace>();

            CreateMap<Domain.Entity.Workspace, CreateWorkspaceCommand>(); //Controller
            CreateMap<CreateWorkspaceCommand, Domain.Entity.Workspace>(); //Handler
            CreateMap<CreateWorkspaceCommand, WorkspaceDto>();

            CreateMap<Domain.Entity.Workspace, UpdateWorkspaceCommand > ();
            CreateMap<UpdateWorkspaceCommand, Domain.Entity.Workspace > ();
            CreateMap<UpdateWorkspaceCommand, WorkspaceDto>();

            CreateMap<Domain.Entity.Workspace, DeleteWorkspaceCommand>(); 
            CreateMap<DeleteWorkspaceCommand, Domain.Entity.Workspace>();
        }
    }
}
