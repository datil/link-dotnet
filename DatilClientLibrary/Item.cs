using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DatilClientLibrary
{
    /// <summary>
    /// Clase del Item que le pertenece a un comprobante.
    /// </summary>
    /// <see cref="Factura"/>
    public class Item
    {


        /// <summary>Código alfanumérico de uso del comercio</summary>
        private string codigoPrincipal;

        /// <summary>Código alfanumérico de uso del comercio.Máximo 25 caracteres.</summary>
        public string CodigoPrincipal
        {
            get { return codigoPrincipal; }
            set
            {
                Validator.MaxLength(value, 25);
                codigoPrincipal = value;
            }
        }

        /// <summary>Código alfanumérico de uso del comercio</summary>
        private string codigoAuxiliar;

        /// <summary>Código alfanumérico de uso del comercio.Máximo 25 caracteres.</summary>
        public string CodigoAuxiliar
        {
            get { return codigoAuxiliar; }
            set {
                Validator.MaxLength(value, 25);
                codigoAuxiliar = value;
            }
        }

        /// <summary>Precio sin subsidio</summary>
        public double? PrecioSinSubsidio { get; set; }

        /// <summary>Descripción del ítem</summary>
        public string Descripcion { get; set; }

        /// <summary>Cantidad adquirida del ítem</summary>
        public double Cantidad { get; set; }

        /// <summary>Descripción del ítem</summary>
        public double PrecioUnitario { get; set; }

        /// <summary>Precio del ítem antes de aplicar impuestos </summary>
        /// <remarks> Se obtiene multiplicando la cantidad por el precio_unitario </remarks>
        public double PrecioTotalSinImpuestos { get; set; }

        /// <summary>Descuento aplicado al ítem</summary>
        public double Descuento { get; set; }

        /// <summary> Impuestos aplicado al ítem </summary>
        private List<ImpuestoItem> impuestos;

        /// <summary> Impuestos aplicado al ítem </summary>
        /// <see cref="ImpuestoItem"/>
        public List<ImpuestoItem> Impuestos {
            get {
                return impuestos;
            }
            set {
                
                foreach (var impuesto in value)
                {
                    if (String.IsNullOrEmpty(System.Convert.ToString(impuesto.Tarifa)))
                    {
                        throw new NoValidAttributeException(string.Format("Tarifa sin definir"));

                    }
                }
                impuestos = value;

            }
        }

        /// <summary> Detalles adicionales del ítem </summary>
        /// <remarks>Diccionario de datos de carácter adicional</remarks>
        /// <example>{ "marca": "Ferrari", "chasis": "UANEI832-NAU101"}</example>
        public Dictionary<string, string> DetallesAdicionales { get; set; }

        /// <summary>Construir un item</summary>
        public Item(string CodigoPrincipal,
            string CodigoAuxiliar,
            string Descripcion, 
            double Cantidad,
            double PrecioUnitario,
            double PrecioTotalSinImpuestos, 
            double Descuento)
        {
            this.CodigoPrincipal = CodigoPrincipal;
            this.CodigoAuxiliar = CodigoAuxiliar;
            this.Descripcion = Descripcion;
            this.Cantidad = Cantidad;
            this.PrecioUnitario = PrecioUnitario;
            this.PrecioTotalSinImpuestos = PrecioTotalSinImpuestos;
            this.Descuento = Descuento;
        }


        

    }
}
