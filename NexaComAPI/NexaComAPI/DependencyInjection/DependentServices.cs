using App.ApplicationLayer.Implementation;
using App.ApplicationLayer.Interface;
using App.DataAccessLayer.Entities;
using App.ServiceLayer.Implementation;
using App.ServiceLayer.Interface;
using App.ServiceLayer.IRepository;
using App.ServiceLayer.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NexaComAPI.Helpers.Automappers;

namespace NexaComAPI.DependencyInjection
{
    public static class DependentServices
    {
        public static IServiceCollection AddBusinessDependencies(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            return services;
        }

        public static IServiceCollection AddServiceDependencies(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
        public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddTransient<IApplicationDBContext>(provider => provider.GetService<ApplicationDbContext>());
            return services;
        }
        public static IServiceCollection AddMapperDependencies(this IServiceCollection services,
          IConfiguration configuration)
        {
            var mapperConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
