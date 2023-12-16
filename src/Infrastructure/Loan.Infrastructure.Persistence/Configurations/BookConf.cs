using Loan.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loan.Infrastructure.Persistence.Configurations
{
    public class BookConf : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(c => c.Title).IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.AuthorName).IsRequired()
                .HasMaxLength(200);
        }
    }
}
