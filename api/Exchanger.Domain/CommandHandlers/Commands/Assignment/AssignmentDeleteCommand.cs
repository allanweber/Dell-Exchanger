using MediatR;
using Exchanger.Framework.CommandHandlers;
using Exchanger.Framework.Entities;

namespace Exchanger.Domain.CommandHandlers.Commands.Assignment
{
    public class AssignmentDeleteCommand : BaseEntity, IRequest<ICommandResult>
    {
    }
}
