using Exchanger.Domain.Dtos;
using Exchanger.Framework.CommandHandlers;
using MediatR;

namespace Exchanger.Domain.CommandHandlers.Commands.Coin
{
    public class CoinInsertCommand: IRequest<ICommandResult>
    {
        public CoinDto[] coins { get; set; }
    }
}
