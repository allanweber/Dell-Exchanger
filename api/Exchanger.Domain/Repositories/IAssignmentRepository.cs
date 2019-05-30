using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exchanger.Domain.Entities;
using Exchanger.Framework.Repositories;

namespace Exchanger.Domain.Repositories
{
    public interface IAssignmentRepository: IRepository<Assignment>
    {
        Task<IEnumerable<Assignment>> GetAllByProject(int projectId);

        Task<DateTime> DoneAssignment(int assignmentId);

        Task<long> CountByProject(int projectId);

        Task<long> CountCompletedByProject(int projectId);

        Task<long> CountLateByProject(int projectId);
    }
}
