using System;
using GeoAlertaC.Application.Services;
using GeoAlertaC.Infrastructure.Context;
using GeoAlertaC.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Adiciona o CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });



        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AppDBContext>(options =>
        {
            var connectionString = Environment.GetEnvironmentVariable("CONEXAO_GS");
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("A variável de ambiente CONEXAO_GS não está definida.");

            options.UseMySQL(connectionString);
        });

        builder.Services.AddScoped<UsuarioService>();
        builder.Services.AddScoped<EnderecoService>();
        builder.Services.AddScoped<AlertaService>();



        builder.Services.AddAutoMapper(typeof(MappingProfile));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //Usa o CORSAdd commentMore actions
        app.UseCors("AllowAll");

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
