using Application.Commands.Accrual;
using Application.Common.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();

builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<AccrualCommandHandler>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddHttpClient<ICurrencyRepository, CurrencyRepository>(client =>
{
    client.BaseAddress = new Uri("https://api.exchangeratesapi.io/v1/");
});
builder.Services.AddScoped<ICurrencyRepository>(provider =>
{
    var httpClient = provider.GetRequiredService<HttpClient>();
    var configuration = provider.GetRequiredService<IConfiguration>();

    var apiUrl = configuration["CurrencyApi:Url"];
    var apiKey = configuration["CurrencyApi:ApiKey"];

    return new CurrencyRepository(httpClient, apiUrl, apiKey);
});

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
