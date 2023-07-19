using FonRadar.Infrastructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FonRadar.Infrastructure.Persistence.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.InvoiceNumber)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(p => p.TermDate)
                   .IsRequired();

            builder.Property(p => p.BuyerTaxId)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(p => p.SupplierTaxId)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(p => p.InvoiceCost)
                   .HasPrecision(18, 4)
                   .IsRequired();

            builder.Property(p => p.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("timezone('utc', now())");

            builder.HasOne(p => p.Buyer)
                   .WithMany(p => p.BuyerInvoice)
                   .HasForeignKey(p => p.BuyerId);

            builder.HasOne(p => p.Supplier)
                   .WithMany(p => p.SupplierInvoice)
                   .HasForeignKey(p => p.SupplierId);

            builder.ToTable("Invoice");
        }
    }
}