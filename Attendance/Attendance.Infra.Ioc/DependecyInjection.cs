using Attendance.Application.Interfaces;
using Attendance.Application.Mappings;
using Attendance.Application.Services;
using Attendance.Domain.Account;
using Attendance.Domain.Interfaces;
using Attendance.Infra.Data.Context;
using Attendance.Infra.Data.Identity;
using Attendance.Infra.Data.Repositories;
using Attendance.Infra.Integration;
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
            string connectionString = configuration["ConnectionStrings"];

            options.UseMySQL(connectionString);
        });

        // Configurar AutoMapper
        services.AddAutoMapper(typeof(DomainToDtoMappingProfile).Assembly);

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAnyOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        // Registrar repositórios e serviços
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticateAsync, AuthenticateService>();
        services.AddScoped<IAmazonSnsService, AmazonSnsService>();
        services.AddScoped<IAmazonSns, AmazonSns>();

        return services;
    }
}
