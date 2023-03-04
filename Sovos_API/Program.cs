using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using SovosCase.Repositories.Abstract;
using SovosCase.Repositories.Concrete;
using SovosCase.Services.Abstract;
using SovosCase.Services.Concrete;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./Logger/Log_Message.txt", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();


builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();


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
