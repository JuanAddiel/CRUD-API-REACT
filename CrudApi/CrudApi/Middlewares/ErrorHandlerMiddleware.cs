using CrudApi.Core.Application.Exceptions;
using CrudApi.Core.Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace CrudApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>()
                {
                    Succeeded = false,
                    Message = error?.Message,
                };
                switch (error)
                {
                    case ApiException e:
                        //Custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case ValidationException e:
                        //Custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;

                        break;
                    case KeyNotFoundException e:
                        //Not Found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;

                        break;
                    default:
                        //Unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
