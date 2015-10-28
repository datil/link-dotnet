using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    /// <summary>
    /// Clase con métodos para validar propiedades.
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Valida que una variable tenga una longitud máxima.
        /// </summary>
        /// <param name="Value">variable a validar</param>
        /// <param name="MaxLength">Longitud máxima</param>
        public static void MaxLength(string Value, int MaxLength )
        {
            if(Value.Length > MaxLength)
            {
                throw new NoValidAttributeException(string.Format("Longitud no válida: {0}", Value));
            }
        }

        /// <summary>
        /// Valida que una variable tenga una longitud especifica.
        /// </summary>
        /// <param name="Value">Variable a validar</param>
        /// <param name="Length">Longitud específica</param>
        public static void SameLength(string Value, int Length)
        {
            if (Value.Length != Length)
            {
                throw new NoValidAttributeException(string.Format("Longitud no válida: {0}", Value));
            }
        }
    }
}
