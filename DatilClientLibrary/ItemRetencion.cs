using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DatilClientLibrary
{
    /// <summary>
    /// Clase del impuesto del item.
    /// </summary>
    ///  <see cref="Item"/>
    public class ItemRetencion
    {


        /// <summary>Código del tipo de impuesto de la retención</summary>
        public string Codigo { get; set; }

        /// <summary>Código del procentaje del tipo de impuesto  de la retención</summary>
        public string CodigoPorcentaje { get; set; }

        /// <summary>Porcentaje</summary>
        public double Porcentaje { get; set; }

        /// <summary>Base imponible</summary>
        public double BaseImponible { get; set; }

        /// <summary>Valor retenido</summary>
        public double ValorRetenido { get; set; }

        ///<summary>Fecha de emisión del documento retenido.</summary>
        public DateTimeOffset FechaEmisionDocumentoSustento { get; set; }
        // ToString("yyyy-MM-dd HH':'mm':'ss")

        ///<summary>Número del documento sustento asociado a esta retención en formato 001-002-000000003 ([0-9]{3}-[0-9]{3}-[0-9]{9})</summary>
        public string NumeroDocumentoSustento { get; set; }

        ///<summary>Tipo del dodcumento sustento asociado a esta retención </summary>
        public string TipoDocumentoSustento { get; set; }

        /// <summary> Construir un impuesto con tarifa</summary>
        public ItemRetencion(string Codigo,
            string CodigoPorcentaje,
            double Porcentaje,
            double BaseImponible,
            double ValorRetenido,
            DateTimeOffset FechaEmisionDocumentoSustento,
            string NumeroDocumentoSustento,
            string TipoDocumentoSustento)
        {
            this.Codigo = Codigo;
            this.CodigoPorcentaje = CodigoPorcentaje;
            this.Porcentaje = Porcentaje;
            this.BaseImponible = BaseImponible;
            this.ValorRetenido = ValorRetenido;
            this.FechaEmisionDocumentoSustento = FechaEmisionDocumentoSustento;
            this.NumeroDocumentoSustento = NumeroDocumentoSustento;
            this.TipoDocumentoSustento = TipoDocumentoSustento;
        }
    }
}