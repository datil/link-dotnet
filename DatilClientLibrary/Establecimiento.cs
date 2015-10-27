namespace DatilClientLibrary
{
    public class Establecimiento
    {

        /// <summary> Código numérico de 3 caracteres que representa al establecimiento.Ejemplo: 001 </summary>
        private string codigo;

        /// <summary> Código numérico de 3 caracteres que representa al establecimiento.Ejemplo: 001 </summary>
        public string Codigo
        {
            get { return codigo; }
            set
            {
                Validator.SameLength(value, 3);
                codigo = value;
            }
        }

        /// <summary> Dirección registrada en el SRI.Máximo 300 caracteres </summary>
        public string Direccion;

        /// <summary> Código numérico de 3 caracteres que representa al punto de emisión, o punto de venta. Ejemplo: 001 </summary>
        private string puntoEmision;

        /// <summary> Código numérico de 3 caracteres que representa al punto de emisión, o punto de venta. Ejemplo: 001 </summary>
        public string PuntoEmision
        {
            get { return puntoEmision; }
            set
            {
                Validator.SameLength(value, 3);
                puntoEmision = value;
                
            }
        }

        /// <summary> Construir un nuevo Establecimiento </summary>
        public Establecimiento(string Codigo,  string PuntoEmision, string Direccion)
        {
            this.Codigo = Codigo;
            this.PuntoEmision = PuntoEmision;
            this.Direccion = Direccion;

        }
    }
}