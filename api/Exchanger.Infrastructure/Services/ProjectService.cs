using System;
using System.Threading.Tasks;
using Exchanger.Domain.Dtos;
using Exchanger.Domain.Repositories;
using Exchanger.Domain.Services;

namespace Exchanger.Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        public ProjectService(IAssignmentRepository assignmentRepository)
        {
            this.AssignmentRepository = assignmentRepository;
        }

        public IAssignmentRepository AssignmentRepository { get; }

        public async Task<ProjectStatusDto> GetProjectStatus(int projectId)
        {
            ProjectStatusDto dto = new ProjectStatusDto();

            dto.Total = await this.AssignmentRepository.CountByProject(projectId);
            dto.Completed = await this.AssignmentRepository.CountCompletedByProject(projectId);
            dto.Late = await this.AssignmentRepository.CountLateByProject(projectId);

            return dto;
        }
    }
}
