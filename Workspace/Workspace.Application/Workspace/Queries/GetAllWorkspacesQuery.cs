using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Workspace.Application.Common.Interfaces;
using Workspace.Application.Workspace.Interface;

namespace Workspace.Application.Workspace.Queries
{
    public class GetAllWorkspacesQuery : IRequest<List<Domain.Entity.Workspace>>
    {
        public GetAllWorkspacesQuery()
        {

        }
    }

    public class GetAllWorkspacesQueryHandler : IRequestHandler<GetAllWorkspacesQuery, List<Domain.Entity.Workspace>>
    {
        private readonly IMapper _mapper;
        private readonly IWorkspaceRepository _repository;
        public GetAllWorkspacesQueryHandler(IMapper mapper, IWorkspaceRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async  Task<List<Domain.Entity.Workspace>> Handle(GetAllWorkspacesQuery request, CancellationToken cancellationToken)
        {
            var workspaceResult = await _repository.GetAllWorkspaces();
            var workspaceList = _mapper.Map<IEnumerable<Domain.Entity.Workspace>>(workspaceResult);
            return workspaceList?.ToList();
        }
    }
}
