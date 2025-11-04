using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;

namespace Projeto.DesenvolvimentoEstudo.ORM.Mapping;

public class CompanySaleItemConfiguration : IEntityTypeConfiguration<CompanySaleItem>
{
    public void Configure(EntityTypeBuilder<CompanySaleItem> builder)
    {

    }
}
