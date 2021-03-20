using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Workspace.Application.Common.Interfaces;
using Workspace.Application.Workspace.Interface;
using Workspace.Application.Workspace.Model;

namespace Workspace.Application.Workspace.Commands.DeleteWorkspace
{
    public class DeleteWorkspaceCommand : IRequest<WorkspaceResponse>
    {
        public string Id { get; set; }
    }
    public class DeleteWorkspaceCommandHandler : IRequestHandler<DeleteWorkspaceCommand, WorkspaceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IWorkspaceRepository _repository;
        public DeleteWorkspaceCommandHandler(IMapper mapper, IWorkspaceRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<WorkspaceResponse> Handle(DeleteWorkspaceCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteItemAsync(request.Id);
            return new WorkspaceResponse() { Id = request.Id };
        }
    }
}
