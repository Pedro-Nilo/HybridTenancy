using Hybrid.Tenancy.Api.Database.Repositories;
using Hybrid.Tenancy.Api.Interfaces;
using Hybrid.Tenancy.Api.Middleware;
using Hybrid.Tenancy.Api.Models.Commom;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMultitenancy<AppTenant, AppTenantMiddleware>();

builder.Services.AddSingleton<IMongoClient>(provider => {
    var username = builder.Configuration["MongoDb:Username"];
    var password = Uri.EscapeDataString(builder.Configuration["MongoDb:Password"]);
    var connectionString = string.Format(builder.Configuration["MongoDb:ConnectionString"], username, password);

    return new MongoClient(connectionString);
});

builder.Services.AddTransient<ICustomerRepository>(provider => {
    var mongoClient = provider.GetService<IMongoClient>();
    var appTenant = provider.GetService<AppTenant>();

    if (appTenant is null)
    {
        throw new InvalidOperationException("Tenant ID of company is required");
    }

    var database = appTenant.RegisterNumber.ToString();

    return new CustomerRepository(mongoClient, database, "customer");
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMultitenancy<AppTenant>();

app.UseAuthorization();

app.MapControllers();

app.Run();
