using System.ComponentModel;

namespace DatilClientLibrary
{
    public class Emisor
    {

        /// <summary>Número de RUC de 13 caracteres</summary>
        private string ruc;

        /// <summary>Número de RUC de 13 caracteres</summary>
        public string Ruc
        {

            get { return ruc; }

            set
            {
                Validator.MaxLength(value, 300);
                ruc = value;
            }
        }

        /// <summary>Razón social.</summary>
        private string razonSocial;

        /// <summary>Razón social. Máximo 300 caracteres</summary>
        public string RazonSocial {
            get { return razonSocial; }
            set {
                Validator.MaxLength(value, 300);
                razonSocial = value;
            }
        }

        /// <summary> Nombre comercial</summary>
        private string nombreComercial;

        /// <summary>Nombre comercial. Máximo 300 caracteres</summary>
        public string NombreComercial
        {
            get { return nombreComercial; }
            set
            {
                Validator.MaxLength(value, 300);
                nombreComercial = value;
            }
        }

        /// <summary>Dirección registrada en el SRI</summary>
        private string direccion;

        /// <summary>Dirección registrada en el SRI.Máximo 300 caracteres</summary>
        [DefaultValue("")]
        public string Direccion {
            get { return direccion; }
            set {
                Validator.MaxLength(value, 300);
                direccion = value;
            }
        }

        /// <summary>Número de resolución. En blanco si no es contribuyente especial.</summary>
        public string ContribuyenteEspecial { get; set; }

        /// <summary>Obligado o no a llevar contabilidad</summary>
        public bool ObligadoContabilidad { get; set; }

        /// <summary>Establecimiento que emite la factura.</summary>
        /// <see cref="Establecimiento"/>
        public Establecimiento Establecimiento { get; set; }

        /// <summary>Construir un nuevo emisor</summary>
        public Emisor(string Ruc,
            string RazonSocial,
            string NombreComercial,
            string Direccion,
            string ContribuyenteEspecial,
            bool ObligadoContabilidad,
            Establecimiento Establecimiento)
        {

            this.Ruc = Ruc;
            this.RazonSocial = RazonSocial;
            this.NombreComercial = NombreComercial;
            this.Direccion = Direccion;
            this.ContribuyenteEspecial = ContribuyenteEspecial;
            this.ObligadoContabilidad = ObligadoContabilidad;
            this.Establecimiento = Establecimiento;
        }


    }
}
