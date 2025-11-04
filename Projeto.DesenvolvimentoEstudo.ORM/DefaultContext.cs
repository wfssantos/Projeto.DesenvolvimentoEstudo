using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;
using System.Reflection;

namespace Projeto.DesenvolvimentoEstudo.ORM;

/// <summary>
/// Set Context 
/// </summary>
public class DefaultContext : DbContext
{
    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyAddress> CompaniesAddresses { get; set; }
    public DbSet<CompanyEmail> CompaniesEmails { get; set; }
    public DbSet<CompanyPhone> CompaniesPhones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}

/// <summary>
/// Set Startup Context - Development
/// </summary>
public class StartDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseNpgsql(
            connectionString,
            b => b.MigrationsAssembly("Projeto.DesenvolvimentoEstudo.ORM")
        );

        return new DefaultContext(builder.Options);
    }
}
