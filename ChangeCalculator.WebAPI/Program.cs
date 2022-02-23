using ChangeCalculator.Core.Domain;
using ChangeCalculator.Core.Domain.Currency;
using ChangeCalculator.Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IChangeCalculator, ChangeCalculatorService>();

// not a good real-world representation here, but interesting nonetheless!
builder.Services.AddSingleton<ICurrencyDenominations, EnglishPoundDenominations>();

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
