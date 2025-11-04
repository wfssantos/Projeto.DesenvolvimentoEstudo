using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;

namespace Projeto.DesenvolvimentoEstudo.ORM.Mapping;

public class CompanySaleConfiguration : IEntityTypeConfiguration<CompanySale>
{
    public void Configure(EntityTypeBuilder<CompanySale> builder)
    {
        builder.ToTable("CompanySales");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        //builder.Property(u => u.SaleNumber).HasMaxLength(100).IsRequired();
        //builder.Property(u => u.Description).HasColumnType("nvarchar(max)").IsRequired();
        //builder.Property(u => u.Price).IsRequired();
        //builder.Property(u => u.StockQuantity).IsRequired();
        //builder.Property(u => u.CreatedAt).IsRequired();
        //builder.Property(u => u.UpdatedAt);
        //builder.Property(u => u.Status).IsRequired();

        builder.HasOne(ca => ca.Company)
              .WithMany(c => c.Sales)
              .HasForeignKey(ca => ca.CompanyId)
              .OnDelete(DeleteBehavior.Cascade);

        //builder.HasOne(ca => ca.UserId)
        //      .WithMany(c => c.Sales)
        //      .HasForeignKey(ca => ca.CompanyId)
        //      .OnDelete(DeleteBehavior.Cascade);

        //builder.HasOne(ca => ca.Id)
        //      .WithMany(c => c.Sales)
        //      .HasForeignKey(ca => ca.CompanyId)
        //      .OnDelete(DeleteBehavior.Cascade);
    }
}
