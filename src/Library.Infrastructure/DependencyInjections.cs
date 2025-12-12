using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Library.Infrastructure.Persistence.Context;
using Library.Infrastructure.Persistence.Repositories;
using Library.Domain.Ports.Out;

namespace Library.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var host = Environment.GetEnvironmentVariable("DB_SERVER");
            var port = Environment.GetEnvironmentVariable("DB_PORT");
            var database = Environment.GetEnvironmentVariable("DB_NAME");
            var user = Environment.GetEnvironmentVariable("DB_USER");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            var connectionString =
                $"Server={host};Port={port};Database={database};User={user};Password={password};";

            Console.WriteLine($"[MYSQL] ConnectionString => {connectionString}");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    connectionString,
                    new MySqlServerVersion(new Version(8, 0, 0))
                )
            );

           
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();

            return services;
        }
    }
}
