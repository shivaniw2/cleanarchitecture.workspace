using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Application.Workspace.Commands.UpdateWorkspace
{
    public class UpdateWorkspaceCommandValidator : AbstractValidator<UpdateWorkspaceCommand>
    {
        public UpdateWorkspaceCommandValidator()
        {
            RuleFor(x => x.Location).MaximumLength(20);
            RuleFor(x => x.WorkspaceName).MaximumLength(20);
            RuleFor(x => x.WorkspaceType).IsInEnum();
        }
    }
}
