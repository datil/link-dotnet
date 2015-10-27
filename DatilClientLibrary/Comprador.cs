using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    public class Comprador
    {

        /// <summary> Valores para el tipo de identificación </summary>
        private readonly string[] identificationTypes = { "04", "05", "06", "07", "08", "09" };

        /// <summary> Razón social del comprador. Máximo 300 caracteres. </summary>
        public string RazonSocial { get; set; }

        /// <summary>  De 5 a 20 caracteres.  </summary>
        public string Identificacion { get; set; }

        /// <summary> Tipos de identificación </summary>
        private string tipoIdentificacion;

        /// <summary> Tipos de identificación </summary>
        /// <remarks>
        ///  RUC                          04
        ///  CEDULA                       05
        ///  PASAPORTE                    06
        ///  VENTA A CONSUMIDOR FINAL    *07
        ///  IDENTIFICACION DELEXTERIOR  *08
        ///  PLACA                        09
        /// </remarks>
        public string TipoIdentificacion
        {
            get { return tipoIdentificacion; }

            set
            {
                if (Array.FindAll(identificationTypes, s => s.Equals(value)).Length == 0)
                {
                    throw new NoValidAttributeException(string.Format("Tipo de Identificación no válido: {0}", value));
                }
                else
                {
                    tipoIdentificacion = value;
                }
            }
        }

        /// <summary> Correo electrónico del cliente. </summary>
        private string email;

        /// <summary> Correo electrónico del cliente. </summary>
        public string Email
        {
            get { return email; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    email = "";
                }
                else
                {
                    bool isEmail = Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                    if (isEmail)
                    {
                        email = value;
                    }
                    else
                    {
                        throw new NoValidAttributeException(string.Format("Email no válido: {0}", value));
                    }
                }

            }
        }

        /// <summary> Dirección del cliente. </summary>
        public string Direccion { get; set; }

        /// <summary> Teléfono del cliente. </summary>
        public string Telefono { get; set; }

        /// <summary> Construir un nuevo comprador. </summary>
        public Comprador(string RazonSocial,
            string Identificacion,
            string TipoIdentificacion,
            string Email = "",
            string Direccion = "",
            string Telefono = "")
        {

            this.RazonSocial = RazonSocial;
            this.Identificacion = Identificacion;
            this.Email = Email;
            this.TipoIdentificacion = TipoIdentificacion;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
        }
    }
}
