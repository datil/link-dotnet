using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatilClientLibrary
{
    /// <summary>
    /// Clase de los totales de una nota de débito.
    /// </summary>
    ///<see cref="NotaDeDebito"/>
    public class TotalesNotaDeDebito : TotalesDeNota
    {

        /// <summary>Construir totales de una nota de crédito</summary>
        public TotalesNotaDeDebito(double TotalSinImpuestos,
            double ImporteTotal) : base(TotalSinImpuestos, ImporteTotal)
        {

        }

    }
}
