using SisPet.Application.Interfaces;
using SisPet.Application.Mapper;
using SisPet.Application.Servicos;
using SisPet.Domain.Extensions;
using SisPet.Domain.Interfaces;
using SisPet.Infra.PessoaRepositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDapper(builder.Configuration);

builder.Services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddAutoMapper(typeof(MappingsProfile).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



