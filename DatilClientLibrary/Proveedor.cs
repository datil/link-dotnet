using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    /// <summary>
    ///  Clase del proveedor
    /// </summary>
    public class Proveedor : Comprador
    {
        /// <summary>
        /// Construir un nuevo proveedor
        /// </summary>
        public Proveedor(string RazonSocial,
            string Identificacion,
            string TipoIdentificacion,
            string Email = "",
            string Direccion = "",
            string Telefono = "") : base(RazonSocial,
                Identificacion, TipoIdentificacion,
                Email, Direccion, Telefono)
        {
            base.RazonSocial = RazonSocial;
            base.Identificacion = Identificacion;
            base.Email = Email;
            base.TipoIdentificacion = TipoIdentificacion;
            base.Direccion = Direccion;
            base.Telefono = Telefono;
        }
    }
}
