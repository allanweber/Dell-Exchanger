using AutoMapper;
using Exchanger.Domain.Dtos;
using Exchanger.Domain.Entities;

namespace Exchanger.Infrastructure.Mappers
{
    public class EntitiesToDto: Profile
    {
        public EntitiesToDto()
        {
            this.CreateMap<Project, ProjectDto>();

            this.CreateMap<Assignment, AssignmentDto>();

            //New
            this.CreateMap<Coin, CoinDto>();
        }
    }
}
