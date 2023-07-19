using FonRadar.Infrastructure.Domain.Entities;
using FonRadar.Infrastructure.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FonRadar.Infrastructure.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.InvoiceStatus).HasConversion(
                             v => v.ToString(),
                             v => (InvoiceStatus)Enum.Parse(typeof(InvoiceStatus), v));

            builder.Property(p => p.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("timezone('utc', now())");

            builder.HasOne(p => p.Invoice)
                   .WithOne(p => p.Payment)
                   .HasForeignKey<Payment>(p => p.InvoiceId)
                   .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(p => p.FinancialInstitution)
                   .WithMany(p => p.FinancialInstitutionPayment)
                   .HasForeignKey(p => p.FinancialInstitutionId);

            builder.ToTable("Payment");
        }
    }
}