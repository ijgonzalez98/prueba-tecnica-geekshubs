using MediatR;
using PruebaGeeksHubs.API.Exceptions;
using PruebaGeeksHubs.Application.Features.Categorias.Queries.GetCategoriaById;
using PruebaGeeksHubs.Application.Mapping;
using PruebaGeeksHubs.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddMediatR(typeof(GetCategoriaByIdQuery).Assembly);
builder.Services.AddAutoMapper(typeof(GeneralProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
