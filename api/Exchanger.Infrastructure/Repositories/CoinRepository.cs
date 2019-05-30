using Microsoft.EntityFrameworkCore;
using Exchanger.Domain.Entities;
using Exchanger.Domain.Repositories;
using Exchanger.Framework.Repositories;

namespace Exchanger.Infrastructure.Repositories
{
    public class CoinRepository : Repository<Coin>, ICoinRepository
    {
        public CoinRepository(PrincipalDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
