using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Workspace.Application.Common.Interfaces;
using Workspace.Application.Workspace.Interface;
using Workspace.Application.Workspace.Model;
using Workspace.Domain.Enum;

namespace Workspace.Application.Workspace.Commands.UpdateWorkspace
{
    public class UpdateWorkspaceCommand : IRequest<WorkspaceResponse>
    {
        public string ID { get; set; }
        public string WorkspaceName { get; set; }
        public string Location { get; set; }
        public List<string> Attibutes { get; private set; }
        public WorkspaceType WorkspaceType { get; set; }
        public string Status { get; set; }
    }
    public class UpdateWorkspaceCommandHandler : IRequestHandler<UpdateWorkspaceCommand, WorkspaceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IWorkspaceRepository _repository;
        public UpdateWorkspaceCommandHandler(IMapper mapper, IWorkspaceRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<WorkspaceResponse> Handle(UpdateWorkspaceCommand request, CancellationToken cancellationToken)
        {
            WorkspaceDto workspaceDto = _mapper.Map<WorkspaceDto>(request);
            await _repository.UpdateWorkspace(workspaceDto);
            return new WorkspaceResponse() { Id = workspaceDto.ID };
        }
    }
}
