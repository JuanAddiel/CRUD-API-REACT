using AutoMapper;
using CrudApi.Core.Application.Interfaces;
using CrudApi.Infrastructured.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Infrastructured.Shared
{
    public static class ServiceExtensions
    {
        public static void AddLayerShared(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
