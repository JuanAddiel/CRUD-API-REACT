using CrudApi.Core.Application.Wrappers;
using FluentValidation;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Core.Application.Behaviours
{
    //IPipelineBehavior<TRequest, TResponse> que permite agregar comportamientos
    //adicionales antes o después de manejar una solicitud en un sistema de mediación.
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        //next: Un delegado que representa el siguiente manejador en la cadena de procesamiento.
        //request La solicitud que se va a validar.
        //Un token que se puede usar para cancelar la operación asincrónica.
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //Verifica si hay validadores en _validators utilizando Any().
            if (_validators.Any())
            {
                //Crea un ValidationContext<TRequest> utilizando la solicitud request.
                var context = new FluentValidation.ValidationContext<TRequest>(request);
                //Llama a ValidateAsync en cada validador de forma asincrónica, pasando el contexto de validación y el cancellationToken.
                var validationResults = await Task.WhenAll(_validators.Select(f => f.ValidateAsync(context, cancellationToken)));
                //Combina todos los resultados de validación y extrae los errores(failures) que no son nulos en una lista.
                var failures = validationResults.SelectMany(r=>r.Errors).Where(r=>r != null).ToList();
                //Si hay errores de validación (failures.Count != 0), lanza una ValidationException con los errores.
                if (failures.Count != 0)
                    throw new CrudApi.Core.Application.Exceptions.ValidationException(failures);
            }
            //Si no hay errores de validación, invoca el siguiente manejador en la cadena de procesamiento llamando next().
            return await next();
        }
    }
}
