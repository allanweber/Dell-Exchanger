using MediatR;
using Exchanger.Framework.CommandHandlers;
using Exchanger.Framework.Entities;

namespace Exchanger.Domain.CommandHandlers.Commands.Project
{
    public class ProjectUpdateCommand: BaseEntity, IRequest<ICommandResult>
    {
        public string Name { get; set; }
    }
}
