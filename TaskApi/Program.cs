using Application;
using Application.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"), b => b.MigrationsAssembly("TaskApi"))
);




builder.Services.AddMediatR(o => o.RegisterServicesFromAssemblies(typeof(Program).Assembly));
builder.Services.AddApplication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICompanyRepository,CompanyRepository>();
builder.Services.AddScoped<IBrunchRepository,BrunchRepository>();
builder.Services.AddScoped<IProductionLogRepository,ProductionLogRepository>();
builder.Services.AddScoped<IDistributionLogRepository, DistributionLogRepository>();

var app = builder.Build();

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
