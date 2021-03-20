using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Workspace.Application.Workspace.Commands.CreateWorkspace;
using Workspace.Application.Workspace.Commands.DeleteWorkspace;
using Workspace.Application.Workspace.Commands.UpdateWorkspace;
using Workspace.Application.Workspace.Queries;

namespace Workspace.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkspaceController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public WorkspaceController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllWorkspacesQuery();
            var result = await _mediator.Send(query);
            return new OkObjectResult(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Domain.Entity.Workspace workspace)
        {
            var createCommand = _mapper.Map<CreateWorkspaceCommand>(workspace);
            var result = await _mediator.Send(createCommand);
            return new OkObjectResult(result);

        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Domain.Entity.Workspace workspace)
        {
            var updateCommand = _mapper.Map<UpdateWorkspaceCommand>(workspace);
            var result = await _mediator.Send(updateCommand);
            return new OkObjectResult(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            Domain.Entity.Workspace workspace = new Domain.Entity.Workspace() { ID = id };
            var deleteCommand = _mapper.Map<DeleteWorkspaceCommand>(workspace);
            var result = await _mediator.Send(deleteCommand);
            return new OkObjectResult(result);
        }
    }
}
