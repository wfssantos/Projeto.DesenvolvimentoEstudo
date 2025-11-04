using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;

namespace Projeto.DesenvolvimentoEstudo.ORM.Mapping;

public class CompanyEmailConfiguration : IEntityTypeConfiguration<CompanyEmail>
{
    public void Configure(EntityTypeBuilder<CompanyEmail> builder)
    {
        builder.ToTable("CompanyEmails");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Contact).HasMaxLength(100);

        builder.HasOne(ca => ca.Company)
               .WithMany(c => c.Emails)
               .HasForeignKey(ca => ca.CompanyId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
