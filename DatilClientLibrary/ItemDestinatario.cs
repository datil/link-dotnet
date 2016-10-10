using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DatilClientLibrary
{
    /// <summary>
    /// Clase del Item que le pertenece al destinatario de una guía de remisión
    /// </summary>
    /// <see cref="Destinatario"/>
    /// <see cref="GuiaDeRemision"/>
    /// 
    public class ItemDestinatario
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
            set
            {
                Validator.MaxLength(value, 25);
                codigoAuxiliar = value;
            }
        }

        /// <summary>Descripción del ítem</summary>
        public string Descripcion { get; set; }

        /// <summary>Cantidad adquirida del ítem</summary>
        public double Cantidad { get; set; }

        /// <summary> Detalles adicionales del ítem </summary>
        /// <remarks>Diccionario de datos de carácter adicional</remarks>
        /// <example>{ "marca": "Ferrari", "chasis": "UANEI832-NAU101"}</example>
        public Dictionary<string, string> DetallesAdicionales { get; set; }

        /// <summary>Construir un item</summary>
        public ItemDestinatario(string CodigoPrincipal,
            string CodigoAuxiliar,
            string Descripcion,
            double Cantidad)
        {
            this.CodigoPrincipal = CodigoPrincipal;
            this.CodigoAuxiliar = CodigoAuxiliar ;
            this.Descripcion = Descripcion;
            this.Cantidad = Cantidad;
        }
    }
}
