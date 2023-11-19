using Attendance.Application.Interfaces;
using Attendance.Application.Mappings;
using Attendance.Application.Services;
using Attendance.Domain.Account;
using Attendance.Domain.Interfaces;
using Attendance.Infra.Data.Context;
using Attendance.Infra.Data.Identity;
using Attendance.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Attendance.Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Configurar o contexto do banco de dados
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
        });

        // Configurar AutoMapper
        services.AddAutoMapper(typeof(DomainToDtoMappingProfile).Assembly);

        // Registrar repositórios e serviços
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticateAsync, AuthenticateService>();

        // Aplicar migrações se as tabelas ainda não existirem
        using (var serviceProvider = services.BuildServiceProvider())
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Verificar se as migrações são necessárias
                if (!dbContext.Database.GetAppliedMigrations().Any())
                {
                    // Aplicar migrações
                    dbContext.Database.Migrate();
                }
            }
        }

        return services;
    }
}
