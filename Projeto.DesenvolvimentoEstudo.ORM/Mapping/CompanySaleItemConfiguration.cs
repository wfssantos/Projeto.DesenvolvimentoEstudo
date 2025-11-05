using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;

namespace Projeto.DesenvolvimentoEstudo.ORM.Mapping;

public class CompanySaleItemConfiguration : IEntityTypeConfiguration<CompanySaleItem>
{
    public void Configure(EntityTypeBuilder<CompanySaleItem> builder)
    {
        builder.ToTable("CompanySalesItens");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Quantity).IsRequired();
        builder.Property(u => u.Discount);

        builder.HasOne(ca => ca.CompanySale)
              .WithMany(c => c.CompanySaleItem)
              .HasForeignKey(ca => ca.CompanySaleId)
              .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ca => ca.CompanyProduct)
              .WithMany(c => c.CompanySaleItem)
              .HasForeignKey(ca => ca.CompanyProductId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
