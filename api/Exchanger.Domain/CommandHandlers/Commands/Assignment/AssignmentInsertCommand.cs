using MediatR;
using System;
using Exchanger.Framework.CommandHandlers;

namespace Exchanger.Domain.CommandHandlers.Commands.Assignment
{
    public class AssignmentInsertCommand: IRequest<ICommandResult>
    {
        public string Description { get; set; }

        public string User { get; set; }

        public string DueDate { get; set; }

        public bool Completed { get; set; }

        public int ProjectId { get; set; }
    }
}
