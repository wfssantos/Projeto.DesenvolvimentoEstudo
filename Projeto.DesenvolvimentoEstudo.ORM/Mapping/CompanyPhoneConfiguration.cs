using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;

namespace Projeto.DesenvolvimentoEstudo.ORM.Mapping;

public class CompanyPhoneConfiguration : IEntityTypeConfiguration<CompanyPhone>
{
    public void Configure(EntityTypeBuilder<CompanyPhone> builder)
    {
        builder.ToTable("CompanyPhones");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Phone).IsRequired();
        builder.Property(u => u.Contact).HasMaxLength(100);
        builder.Property(u => u.Type).HasMaxLength(100);

        builder.HasOne(ca => ca.Company)
              .WithMany(c => c.Phones)
              .HasForeignKey(ca => ca.CompanyId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
