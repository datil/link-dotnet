using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    using System;

    /// <summary>
    /// Clase de la excepción creada cuando un atributo de la librería no es válido.
    /// </summary>
    public class NoValidAttributeException : Exception
    {

        /// <summary>
        /// Construir una excepción de validación de atributo.
        /// </summary>
        public NoValidAttributeException()
        {
        }


        /// <summary>
        /// Construir una excepción de validación de atributo con un mensaje de error.
        /// </summary>
        public NoValidAttributeException(string message)
            : base(message)
        {
        }


        /// <summary>
        /// Construir una excepción de validación de atributo con un mensaje de error.
        /// </summary>
        public NoValidAttributeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
