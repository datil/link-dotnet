using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    /// <summary>
    /// Destinatario de los productos detallados en la guía de remisión.
    /// </summary>
    public class Destinatario
    {          
        ///<summary>Razón social del destinatario.</summary>
        public String RazonSocial { get; set; }

        ///<summary>Identificación del destinatario.</summary>
        public String Identificacion { get; set; }

        ///<summary>Tipo de identificación del destinatario.</summary>
        public String TipoIdentificacion { get; set; }

        ///<summary>Email del destinatario.</summary>
        public String Email { get; set; }

        ///<summary>Dirección del destinatario.</summary>
        public String Direccion { get; set; }

        ///<summary>Teléfono del destinatario.</summary>
        public String Telefono { get; set; }

        ///<summary>Fecha de emisión del documento sustento, generalmente la factura.</summary>
        public DateTimeOffset FechaEmisionDocumentoSustento { get; set; }
        // ToString("yyyy-MM-dd HH':'mm':'ss")

        ///<summary>Número del documento sustento.</summary>
        public String NumeroDocumentoSustento { get; set; }

        ///<summary>Número de autorización del documento sustento.</summary>
        public String NumeroAutorizacionDocumentoSustento { get; set; }

        ///<summary>Tipo del documento sustento.</summary>
        public String TipoDocumentoSustento { get; set; }

        ///<summary>Motivo del traslado</summary>
        public String MotivoTraslado { get; set; }

        ///<summary>Ruta del traslado</summary>
        public String Ruta { get; set; }

        ///<summary>Documento aduanero único</summary>
        public String DocumentoAduaneroUnico { get; set; }

        ///<summary> Código del Establecimiento del destino del traslado</summary>
        public String CodigoEstablecimientoDestino { get; set; }

        /// <summary>
        /// Lista de items detallados en guía de remisión.
        /// </summary>
        /// <see cref="ItemDestinatario"/>
        public List<ItemDestinatario> Items { get; set; }

        /// <summary> Construir un impuesto con tarifa</summary>
        public Destinatario(string RazonSocial,
            string Identificacion,
            string Direccion
            )
        {
            this.RazonSocial = RazonSocial;
            this.Identificacion = Identificacion;
            this.Direccion = Direccion;
        }
    }
}
