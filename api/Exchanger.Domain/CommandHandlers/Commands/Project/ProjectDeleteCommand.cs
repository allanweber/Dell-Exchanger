using MediatR;
using Exchanger.Framework.CommandHandlers;
using Exchanger.Framework.Entities;

namespace Exchanger.Domain.CommandHandlers.Commands.Project
{
    public class ProjectDeleteCommand: BaseEntity, IRequest<ICommandResult>
    {
    }
}
