using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exchanger.Domain.Entities;
using Exchanger.Domain.Repositories;
using Exchanger.Framework.Repositories;

namespace Exchanger.Infrastructure.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public IAssignmentRepository AssignmentRepository { get; }

        public ProjectRepository(PrincipalDbContext dbContext, IAssignmentRepository assignmentRepository)
            : base(dbContext)
        {
            this.AssignmentRepository = assignmentRepository;
        }

        public override async Task<List<Project>> GetAllAsync()
        {
            return await this.Query().OrderBy(p => p.Id).ToListAsync();
        }

        public override async Task DeleteAsync(Project entity)
        {
            var tasks = await this.AssignmentRepository.GetAllByProject(entity.Id);

            tasks.ToList().ForEach(task => this.AssignmentRepository.DeleteAsync(task));

            await base.DeleteAsync(entity);
        }
    }
}
