using Popsy.Enums;

namespace Popsy
{
    /// <summary>
    /// Clase de excepción personalizada para el proyecto Popsy.
    /// </summary>
    public class PopsyException : Exception
    {
        /// <summary>
        /// Obtiene el código de estado HTTP asociado a la excepción.
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Obtiene o establece la fuente del error asociada a la excepción.
        /// </summary>
        public ErrorSource ErrorSource { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de error asociado a la excepción.
        /// </summary>
        public ErrorType ErrorType { get; set; }

        /// <summary>
        /// Crea una nueva instancia de la clase PopsyException con el tipo de error especificado.
        /// </summary>
        /// <param name="errorType">Tipo de error.</param>
        /// <param name="errorSource">Fuente del error (valor predeterminado: ErrorSource.Servidor).</param>
        public PopsyException(ErrorType errorType, ErrorSource errorSource = ErrorSource.Servidor)
            : base(errorType.ToString())
        {
            ErrorType = errorType;
            ErrorSource = errorSource;
        }

        /// <summary>
        /// Crea una nueva instancia de la clase PopsyException con el tipo de error especificado.
        /// </summary>
        /// <param name="errorType">Tipo de error.</param>
        /// <param name="errorSource">Fuente del error (valor predeterminado: ErrorSource.Servidor).</param>
        public PopsyException(String errorMessage, ErrorSource errorSource = ErrorSource.Servidor)
            : base(errorMessage)
        {
            ErrorSource = errorSource;
        }
    }
}
