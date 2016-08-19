using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    /// <summary>
    /// Métodos de Pago de la factura
    /// </summary>
    /// <see cref="Factura"/>
    public class MetodoPago
    {
        /// <summary
        /// >Medio de pago según la documentación del API de Dátil 
        /// http://developers.datil.co/#tipos-de-forma-de-pago
        /// </summary>
        public string Medio { get; set; }

        /// <summary> Total del pago </summary>
        public double Total { get; set; }

        ///<summary>Propiedades adicionales del pago</summary>
        public Dictionary<string,string> Propiedades { get; set; }

        /// <summary>Constructor del objeto MetodoPago</summary>
        public MetodoPago(string Medio, double Total)
        {
            this.Propiedades = null;
            this.Medio = Medio;
            this.Total = Total;
        }
    }
}
