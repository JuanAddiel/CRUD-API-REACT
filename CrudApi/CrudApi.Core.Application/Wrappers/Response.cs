using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Core.Application.Wrappers
{
    public class Response<T>
    {
        //Esta clase la utilizamos para poder enviar respuesta al cliente
        //Podemos ver las respuestas que se enviaran verificando las siguientes propiedades
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        //Tenemos 3 constructores uno sin parametros y los demas con parametros añadidos
        public Response() { }
        //Este es cuando la respuesta esta perfecta es decir que no hubo error de validation
        public Response(T data, string message = null) 
        { 
            Succeeded = true;
            Message = message;
            Data = data;
        }
        //Pero esta es cuendo tenemos un error de validation
        public Response(string message)
        {
            Succeeded = false;
            Message = message;

        }

    }
}
