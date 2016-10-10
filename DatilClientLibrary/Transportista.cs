using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    /// <summary>
    /// Clase del transportista de un producto o servicio en la guía de remisión.
    /// </summary>
    public class Transportista : Comprador
    {


        /// <summary>Placa del transporte</summary>
        public string Placa { get; set; }

        /// <summary> Construir un impuesto con tarifa</summary>
        public Transportista(string RazonSocial,
            string Identificacion,
            string TipoIdentificacion,
            string Email = "",
            string Direccion = "",
            string Telefono = "", 
            string Placa = "") : base(RazonSocial, Identificacion, TipoIdentificacion, Email, Direccion, Telefono)
        {
            this.Placa = Placa;
        }
    }
}
