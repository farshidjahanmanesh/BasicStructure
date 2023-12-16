using Loan.Core.Domain.Entities;
using Loan.Framework.Commons.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Loan.InfraLoan.Persistence.Contexts
{
    public class LoanDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public LoanDbContext(DbContextOptions<LoanDbContext> configs) : base(configs)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreateDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        item.Entity.LastModifedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
