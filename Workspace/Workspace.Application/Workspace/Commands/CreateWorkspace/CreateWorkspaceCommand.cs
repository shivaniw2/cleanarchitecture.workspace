using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Workspace.Application.Common.Interfaces;
using Workspace.Application.Workspace.Interface;
using Workspace.Application.Workspace.Model;
using Workspace.Domain.Enum;

namespace Workspace.Application.Workspace.Commands.CreateWorkspace
{
    public class CreateWorkspaceCommand : IRequest<WorkspaceResponse>
    {
        public string ID { get; set; }
        public string WorkspaceName { get; set; }
        public string Location { get; set; }
        public List<string> Attibutes { get; private set; }
        public WorkspaceType WorkspaceType { get; set; }
        public string Status { get; set; }
    }
    public class CreateWorkspaceCommandHandler : IRequestHandler<CreateWorkspaceCommand, WorkspaceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IWorkspaceRepository _repository;
        public CreateWorkspaceCommandHandler(IMapper mapper, IWorkspaceRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<WorkspaceResponse> Handle(CreateWorkspaceCommand request, CancellationToken cancellationToken)
        {
            request.ID = _repository.GenerateId();
            WorkspaceDto workspace = _mapper.Map<WorkspaceDto>(request);
            await _repository.CreateWorkspace(workspace);
            return new WorkspaceResponse() { Id = workspace.ID };
        }
    }
}
