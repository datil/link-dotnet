using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    /// <summary>
    /// Crédito otorgado al cliente en una factura
    /// </summary>
    /// <see cref="Factura"/>
    public class CreditoFactura
    {
        /// <summary> Fecha de vencimiento del crédito </summary>
        public string FechaVencimiento { get; set; }

        /// <summary> Monto del crédito otorgado </summary>
        public double Monto { get; set; }

        /// <summary> Constructor del objeto CreditoFactura </summary>
        public  CreditoFactura(double Monto, string FechaVencimiento)
        {
            this.Monto = Monto;
            this.FechaVencimiento = FechaVencimiento;
        }

    }
}
