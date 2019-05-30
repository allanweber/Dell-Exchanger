using Exchanger.Framework.CommandHandlers;
using MediatR;

namespace Exchanger.Domain.CommandHandlers.Commands.Project
{
    public class ProjectInsertCommand: IRequest<ICommandResult>
    {
        public string Name { get; set; }
    }
}
