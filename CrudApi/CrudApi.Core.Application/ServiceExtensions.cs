using CrudApi.Core.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Core.Application
{
    public static class ServiceExtensions
    {
        public static void AddLayerApplication(this IServiceCollection services)
        {
            // Este método obtiene la referencia al ensamblado que contiene el código
            // que se está ejecutando actualmente. En este contexto, se refiere al
            // ensamblado donde se encuentra la llamada a AddAutoMapper.
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        }
    }
}
