using AutoMapper;
using Exchanger.Domain.CommandHandlers.Commands.Coin;
using Exchanger.Domain.Entities;
using Exchanger.Domain.Repositories;
using Exchanger.Framework.CommandHandlers;
using Exchanger.Framework.Specifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Exchanger.Domain.Specifications;

namespace Exchanger.Domain.CommandHandlers
{
    public class CoinCommandHandler :
        IRequestHandler<CoinInsertCommand, ICommandResult>
    {
        public CoinCommandHandler(IMapper mapper, ICoinRepository cointRepository)
        {
            this.Mapper = mapper;
            this.CoinRepository = cointRepository;
        }

        public IMapper Mapper { get; }
        public ICoinRepository CoinRepository { get; }

        public async Task<ICommandResult> Handle(CoinInsertCommand request, CancellationToken cancellationToken)
        {

            //TODO:Add service and process the array in the service

            var entity = this.Mapper.Map<ProjectInsertCommand, Project>(request);

            ICommandResult result = this.validate(entity);
            if (result.IsFailure) return result;

            await this.ProjectRepository.InsertAsync(entity);

            await this.ProjectRepository.CommitAsync();

            result.Result = entity.Id;

            return new SuccessResult(entity.Id);
        }

        
    }
}
