using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;
using System.Reflection.Emit;

namespace Projeto.DesenvolvimentoEstudo.ORM.Mapping;

public class CompanyAddressConfiguration : IEntityTypeConfiguration<CompanyAddress>
{
    public void Configure(EntityTypeBuilder<CompanyAddress> builder)
    {
        builder.ToTable("CompanyAddresses");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Address).IsRequired().HasMaxLength(255);
        builder.Property(u => u.City).HasMaxLength(100);
        builder.Property(u => u.Country).HasMaxLength(100);
        builder.Property(u => u.Code).HasMaxLength(100);

        builder.HasOne(ca => ca.Company)
               .WithMany(c => c.Addresses)
               .HasForeignKey(ca => ca.CompanyId)
               .OnDelete(DeleteBehavior.Cascade);

       
    }
}
