using Microsoft.EntityFrameworkCore;
using Projeto.DesenvolvimentoEstudo.Application;
using Projeto.DesenvolvimentoEstudo.IoC;
using Projeto.DesenvolvimentoEstudo.ORM;
using Projeto.DesenvolvimentoEstudo.ORM.DefaultTestData;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDependencies();
//// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();

// Customize the application configuration
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(cfg => {
    cfg.AddMaps(typeof(ApplicationLayer).Assembly);
    cfg.AddMaps(typeof(Program).Assembly);
});
builder.Services.AddMediatR(cfg => { 
    cfg.RegisterServicesFromAssemblies(typeof(ApplicationLayer).Assembly, typeof(Program).Assembly); 
});
builder.Services.AddDbContext<DefaultContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Projeto.DesenvolvimentoEstudo.ORM")
    )
);

var app = builder.Build();

// Apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DefaultContext>();
    db.Database.Migrate();

    if (app.Environment.IsDevelopment()) new SeedData().Development(db);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
