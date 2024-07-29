using CrudApi.Core.Application.Interfaces.Repositories;
using CrudApi.Infrastructured.Persistence.Context;
using CrudApi.Infrastructured.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Infrastructured.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddLayerPersistence (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CrudSql"),
                    m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
            });
            #region Repository
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));
            services.AddTransient<IClientRepository, ClientRepository>();
            #endregion
        }
    }
}
