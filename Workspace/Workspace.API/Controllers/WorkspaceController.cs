using System;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Serilog;
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
        private readonly ILogger _logger;
        public WorkspaceController(IMediator mediator, IMapper mapper, ILogger logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        /// Get Workpsace 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.Information("GetWorkspaces started");
            var query = new GetAllWorkspacesQuery();
            var result = await _mediator.Send(query);
            _logger.Information("GetWorkspaces ended");
            return new OkObjectResult(result);
        }
        
        /// <summary>
        /// Create Workspace
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Domain.Entity.Workspace workspace)
        {
            _logger.Information("CreateWorkspace started");
            var createCommand = _mapper.Map<CreateWorkspaceCommand>(workspace);
            _logger.Debug("CreateWorkspace command: "+JsonConvert.SerializeObject(createCommand));
            var result = await _mediator.Send(createCommand);
            _logger.Information("CreateWorkspace ended");
            return new OkObjectResult(result);

        }
        
        /// <summary>
        /// Update Workspace
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Domain.Entity.Workspace workspace)
        {
            _logger.Information("UpdateWorkspace started");
            var updateCommand = _mapper.Map<UpdateWorkspaceCommand>(workspace);
            _logger.Debug("UpdateWorkspace command: "+ JsonConvert.SerializeObject(updateCommand));
            var result = await _mediator.Send(updateCommand);
            _logger.Information("UpdateWorkspace ended");
            return new OkObjectResult(result);
        }
        
        /// <summary>
        /// Delete Workspace
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            _logger.Information("DeleteWorkspace started");
            Domain.Entity.Workspace workspace = new Domain.Entity.Workspace() { ID = id };
            var deleteCommand = _mapper.Map<DeleteWorkspaceCommand>(workspace);
            _logger.Information("DeleteWorkspace command: "+JsonConvert.SerializeObject(deleteCommand));
            var result = await _mediator.Send(deleteCommand);
            _logger.Information("DeleteWorkspace ended");
            return new OkObjectResult(result);
        }
    }
}
