
using ApiScp.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiScp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adicionar configuração de variáveis de ambiente
            builder.Configuration.AddEnvironmentVariables();

            // Adicionar arquivos de configuração
            var env = builder.Environment;
            builder.Configuration
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                   .AddEnvironmentVariables();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //string de conexão com o bd
            string sqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(sqlConnection));

            //Configurando CORS para poder usar de forma livre
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigin", builder =>
            //    {
            //        builder.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            //    });
            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.


            app.UseSwagger();
            app.UseSwaggerUI();

            //usar o cors
            //app.UseCors("AllowSpecificOrigin"); 

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
