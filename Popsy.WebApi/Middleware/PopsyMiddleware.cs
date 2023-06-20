using System.Net;

using Popsy;
using Popsy.Enums;

namespace GT.Popsy.Middleware
{
    /// <summary>
    /// Middleware para manejo de excepciones.
    /// </summary>
    public sealed class PopsyMiddleware
    {
        /// <summary>Deleado de <see cref="RequestDelegate"/></summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor de la clase PopsyMiddleware.
        /// </summary>
        /// <param name="next">Delegate para continuar el procesamiento de la solicitud Http.</param>
        public PopsyMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        /// <summary>
        /// Método Invoke para invocar el middleware.
        /// </summary>
        /// <param name="context">HttpContext actual.</param>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                await ExceptionHandle(context, e).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Manejo de excepciones.
        /// </summary>
        /// <param name="context">HttpContext actual.</param>
        /// <param name="exception">Excepción lanzada.</param>
        /// <returns>Task representando la operación asincrónica.</returns>
        private Task ExceptionHandle(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "text/plain";
            context.Response.StatusCode = (Int32)GetHttpStatusCode(exception as PopsyException);
            return context.Response.WriteAsync(exception.Message);
        }

        /// <summary>
        /// Obtiene el HttpStatusCode basado en la PopsyException.
        /// </summary>
        /// <param name="exception">Instancia de PopsyException.</param>
        /// <returns>HttpStatusCode correspondiente.</returns>
        private static HttpStatusCode GetHttpStatusCode(PopsyException? exception)
            => exception?.ErrorSource switch
            {
                ErrorSource.Proceso => HttpStatusCode.BadRequest,
                ErrorSource.Servidor => HttpStatusCode.InternalServerError,
                ErrorSource.NoEncontrado => HttpStatusCode.NotFound,
                _ => HttpStatusCode.InternalServerError,
            };
    }
}
