using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatilClientLibrary
{
    /// <summary>
    /// Clase de los totales de una Factura.
    /// </summary>
    ///<see cref="NotaDeCredito"/>
    public class TotalesNotaDeCredito
    {
        /// <summary>Total de la factura antes de aplicar impuestos.</summary>
        public double TotalSinImpuestos { get; set; }

        /// <summary>Total incluyendo impuestos.</summary>
        public double ImporteTotal { get; set; }

        /// <summary>Listado de impuestos, no necesita incluir tarifa.</summary>
        public List<Impuesto> Impuestos { get; set; }

        /// <summary>Construir totales de una factura</summary>
        public TotalesNotaDeCredito(double TotalSinImpuestos,
            double ImporteTotal)

        {
            this.TotalSinImpuestos = TotalSinImpuestos;
            this.ImporteTotal = ImporteTotal;

        }
    }
}
