using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Application.Workspace.Commands.CreateWorkspace
{
    public class CreateWorkspaceCommandValidator : AbstractValidator<CreateWorkspaceCommand>
    {
        public CreateWorkspaceCommandValidator()
        {
            RuleFor(x => x.Location).NotNull().NotEmpty().MaximumLength(20);
            RuleFor(x => x.WorkspaceName).NotEmpty().NotNull().MaximumLength(20);
            RuleFor(x => x.WorkspaceType).NotNull().NotEmpty().IsInEnum();
        }
    }
}
