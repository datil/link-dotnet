using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    /// <summary>
    /// Retención en la factura.
    /// 
    /// Caso específico de Retenciones en la Comercializadores / Distribuidores 
    /// de derivados del Petróleo y Retención presuntiva de IVA a los Editores,
    /// Distribuidores y Voceadores que participan en la comercialización de 
    /// periódicos y/o revistas.
    /// </summary>
    public class RetencionFactura
    {
        /// <summary>Código del tipo de impuesto para la retención en la factura.</summary>
        public string TipoImpuesto { get; set; }

        /// <summary>Código del porcentaje del impuesto.</summary>
        public string CodigoPorcentaje { get; set; }

        /// <summary>Porcentaje actual del impuesto. Máximo 3 enteros y 2 decimales.</summary>
        public double Tarifa { get; set; }

        /// <summary>Valor del impuesto. Máximo 12 enteros y 2 decimales.</summary>
        public double Valor { get; set; }

        /// <summary>Construir Retención en la factura</summary>
        public RetencionFactura(string TipoImpuesto,
            string CodigoPorcentaje,
            double Tarifa,
            double Valor)
        {
            this.TipoImpuesto = TipoImpuesto;
            this.CodigoPorcentaje = CodigoPorcentaje;
            this.Tarifa = Tarifa;
            this.Valor = Valor;
        }
    }
}
