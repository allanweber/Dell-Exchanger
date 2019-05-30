using Exchanger.Framework.Dtos;

namespace Exchanger.Domain.Dtos
{
    public class ProjectStatusDto: IDto
    {
        public long Completed { get; set; }

        public long Late { get; set; }

        public long Total { get; set; }
    }
}
