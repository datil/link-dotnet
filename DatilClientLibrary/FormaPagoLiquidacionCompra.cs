using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    public class FormaPagoLiquidacionCompra
    {
        /// <summary>
        /// Medio de pago según la documentación del API de Dátil 
        /// http://developers.datil.co/#tipos-de-forma-de-pago
        /// </summary>
        private string unidadDeTiempo;
        private string delPlazo;

        /// <summary> Código del tipo de forma de pago. Es Requerido </summary>
        public string FormaPago { get; set; }

        /// <summary> Total del pago </summary>
        public double Total { get; set; }

        /// <summary> Máximo 10 caracteres. </summary>
        public string UnidadTiempo
        {
            get => unidadDeTiempo;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length > 10)
                    {
                        throw new Exception("Máximo 10 caracteres.");
                    }
                }
                unidadDeTiempo = value;
            }
        }

        /// <summary> Máximo 14 caracteres. </summary>
        public string plazo
        {
            get => delPlazo;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length > 14)
                    {
                        throw new Exception("Máximo 14 caracteres.");
                    }
                }
                delPlazo = value;
            }
        }

        ///<summary>Propiedades adicionales del pago</summary>
        public Dictionary<string, string> Propiedades { get; set; }

        /// <summary>Constructor del objeto MetodoPago</summary>
        public FormaPagoLiquidacionCompra(string FormaDePago, double Total)
        {
            this.Propiedades = null;
            this.FormaPago = FormaDePago;
            this.Total = Total;
        }
    }
}
