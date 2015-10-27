using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    public class Validator
    {
        public static void MaxLength(string Value, int MaxLength )
        {
            if(Value.Length > MaxLength)
            {
                throw new NoValidAttributeException(string.Format("Longitud no válida: {0}", Value));
            }
        }

        public static void SameLength(string Value, int Length)
        {
            if (Value.Length != Length)
            {
                throw new NoValidAttributeException(string.Format("Longitud no válida: {0}", Value));
            }
        }
    }
}
