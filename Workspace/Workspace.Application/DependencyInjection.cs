using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using FluentValidation;
using Workspace.Application.Common.Behaviours;

namespace Workspace.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddMediatR(Assembly.GetExecutingAssembly());
            serviceDescriptors.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceDescriptors.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            serviceDescriptors.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            return serviceDescriptors;
        }
    }
}
