using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public string Codigo { get; set; }

        /// <summary>Código del porcentaje del impuesto.</summary>
        public string CodigoPorcentaje { get; set; }

        /// <summary>Porcentaje actual del impuesto. Máximo 3 enteros y 2 decimales.</summary>
        public double Porcentaje { get; set; }

        /// <summary>Valor del impuesto. Máximo 12 enteros y 2 decimales.</summary>
        public double Valor { get; set; }

        /// <summary>Construir Retención en la factura</summary>
        public RetencionFactura(string Codigo,
            string CodigoPorcentaje,
            double Porcentaje,
            double Valor)
        {
            this.Codigo = Codigo;
            this.CodigoPorcentaje = CodigoPorcentaje;
            this.Porcentaje = Porcentaje;
            this.Valor = Valor;
        }
    }
}
