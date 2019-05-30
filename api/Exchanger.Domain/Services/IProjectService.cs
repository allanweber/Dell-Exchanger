using System.Threading.Tasks;
using Exchanger.Domain.Dtos;
using Exchanger.Framework.Services;

namespace Exchanger.Domain.Services
{
    public interface IProjectService: IService
    {
        Task<ProjectStatusDto> GetProjectStatus(int projectId);
    }
}
