﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatilClientLibrary
{
    /// <summary>
    /// Clase de los totales de una nota de crédito.
    /// </summary>
    ///<see cref="NotaDeCredito"/>
    public class TotalesNotaDeCredito : TotalesDeNota
    {

        /// <summary>Construir totales de una nota de crédito</summary>
        public TotalesNotaDeCredito(double TotalSinImpuestos,
            double ImporteTotal) : base(TotalSinImpuestos, ImporteTotal)
        {
                
        }

    }
}
