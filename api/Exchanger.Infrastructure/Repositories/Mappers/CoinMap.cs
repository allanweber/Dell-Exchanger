using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Exchanger.Domain.Entities;

namespace Exchanger.Infrastructure.Repositories.Mappers
{
    public class CoinMap : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.ToTable(nameof(Coin));
        }
    }
}
