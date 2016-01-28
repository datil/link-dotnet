using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>Suma de los descuentos de cada ítem.</summary>
        public double Descuento { get; set; }

        /// <summary>Listado de impuestos, no necesita incluir tarifa.</summary>
        public List<Impuesto> Impuestos { get; set; }

        /// <summary>Construir totales de una factura</summary>
        public TotalesNotaDeCredito(double TotalSinImpuestos,
            double ImporteTotal,
            double Descuento)

        {
            this.TotalSinImpuestos = TotalSinImpuestos;
            this.ImporteTotal = ImporteTotal;
            this.Descuento = Descuento;

        }
    }
}
