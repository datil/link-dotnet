using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    public class Buyer 
    {
        /*
            Información del Comprador:

            Mandatory attributes:
                RazonSocial 
                Identificacion
                TipoIdentificacion
            
            Optional attributes:
                Email
                Direccion
                Telefono
            
            
        */
        public readonly string[] identificationTypes = { "04", "05", "06", "07", "08", "09" };

        private string _tipoIdentificacion;

        private string _email;

        public string RazonSocial { get; set; }

        public string Identificacion { get; set; }

        public string TipoIdentificacion {
            get { return this.TipoIdentificacion; }

            set {

                /*
                TipoIdentificacion meaning
                RUC                         04
                CEDULA                      05
                PASAPORTE                   06
                VENTA A CONSUMIDOR FINAL    *07
                IDENTIFICACION DELEXTERIOR  *08
                PLACA                       09
                */

                
                if (Array.FindAll(identificationTypes, s => s.Equals(value)).Length == 0)
                {
                    throw new NoValidAttributeException(string.Format("Tipo de Identificación Incorrecto: {0}", value));
                }
                else {
                    _tipoIdentificacion = value;
                }
            }
        }

        public string Email
        {
            get { return _email; }

            set {
                if (string.IsNullOrEmpty(value))
                {
                    _email = "";
                }
                else
                {
                    bool isEmail = Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                    if (isEmail)
                    {
                        _email = value;
                    }
                    else
                    {
                        throw new NoValidAttributeException(string.Format("Email no válido: {0}", value));
                    }             
                }

            }
        }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public Buyer(string RazonSocial,
            string Identificacion, 
            string TipoIdentificacion, 
            string Email = "", 
            string Direccion = "",
            string Telefono = "") {

            this.RazonSocial = RazonSocial;
            this.Identificacion = Identificacion;
            this.Email = Email;
            this.TipoIdentificacion = TipoIdentificacion;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
        }
    }
}
