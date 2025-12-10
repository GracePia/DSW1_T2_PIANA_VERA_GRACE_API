using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Persistence.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loans");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.StudentName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(l => l.LoanDate)
                .IsRequired();

            builder.Property(l => l.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(l => l.CreatedAt)
                .IsRequired();

            // Relación Book - Loan
            builder.HasOne<Book>()
                   .WithMany()
                   .HasForeignKey(l => l.BookId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
