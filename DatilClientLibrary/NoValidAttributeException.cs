using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    using System;

    public class NoValidAttributeException : Exception
    {
        public NoValidAttributeException()
        {
        }

        public NoValidAttributeException(string message)
            : base(message)
        {
        }

        public NoValidAttributeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
