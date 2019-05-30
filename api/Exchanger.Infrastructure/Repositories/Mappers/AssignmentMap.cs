using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Exchanger.Domain.Entities;

namespace Exchanger.Infrastructure.Repositories.Mappers
{
    public class AssignmentMap : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.ToTable(nameof(Assignment));
        }
    }
}
