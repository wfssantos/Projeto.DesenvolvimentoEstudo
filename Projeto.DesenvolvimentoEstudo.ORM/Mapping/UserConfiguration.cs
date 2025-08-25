using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;

namespace Projeto.DesenvolvimentoEstudo.ORM.Mapping;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    /// <summary>
    /// Configure Users table
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);

        builder.Property(u => u.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        // TODO: implement roles
        //builder.Property(u => u.Role)
        //    .HasConversion<string>()
        //    .HasMaxLength(20);
    }
}
