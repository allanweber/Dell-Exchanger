using Microsoft.EntityFrameworkCore;
using Exchanger.Framework.Extensions;

namespace Exchanger.Framework.Repositories
{
    public class PrincipalDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public PrincipalDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration();

            base.OnModelCreating(modelBuilder);
        }
    }
}
