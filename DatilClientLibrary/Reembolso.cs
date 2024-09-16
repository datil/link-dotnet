using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace DatilClientLibrary
{
    public class Reembolso
    {
        /// <summary>
        /// Código del tipo de documento de reembolso equivalente a 41
        /// </summary>
        public string Codigo { get; set; }
        
        public List<DocumentoReembolso> Documentos { get; set; }
        
        /// <summary>
        /// Sumatoria de los subtotales de los documentos.
        /// </summary>
        public double Subtotal { get; set; }
        
        /// <summary>
        /// Sumatoria de los totales de impuestos de los documentos
        /// </summary>
        public double TotalImpuestos { get; set; }
        
        
        /// <summary>
        /// Subtotal más total de impuestos
        /// </summary>
        public double Total { get; set; }
        
        public Reembolso(){
            Documentos = new List<DocumentoReembolso>();
        }

    }
    
    public class DocumentoReembolso
    {
        /// <summary>
        /// Código de 3 caracteres del establecimiento donde se emite el documento.
        /// </summary>
        public string CodigoEstablecimiento { get; set; }

        /// <summary>
        /// Código de 3 caracteres del punto de emisión del documento.
        /// </summary>
        public string CodigoPuntoEmision { get; set; }

        /// <summary>
        /// Número de secuencia del documento, entre 1 y 999999999.
        /// </summary>
        public int Secuencia { get; set; }

        /// <summary>
        /// Fecha de emisión del documento en formato AAAA-MM-DDHoraZonaHoraria según ISO8601.
        /// </summary>
        public DateTimeOffset FechaEmision { get; set; }

        /// <summary>
        /// Identificación del proveedor, entre 5 y 20 caracteres.
        /// </summary>
        public string IdentificacionProveedor { get; set; }

        /// <summary>
        /// Tipo de identificación del proveedor, según una tabla de tipos de identificación.
        /// </summary>
        public string TipoIdentificacionProveedor { get; set; }

        /// <summary>
        /// Lista de objetos Impuesto, que representan los impuestos totales del documento.
        /// </summary>
        public List<Impuesto> Impuestos { get; set; }

        /// <summary>
        /// Número de autorización del documento, debe tener 10, 37 o 49 caracteres.
        /// </summary>
        public string NumeroAutorizacion { get; set; }

        /// <summary>
        /// Código de 2 caracteres del país de origen del proveedor, según ISO_3166.
        /// </summary>
        public string PaisOrigenProveedor { get; set; }

        /// <summary>
        /// Código del tipo de documento.
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Código del tipo de proveedor de reembolso.
        /// </summary>
        public string TipoProveedor { get; set; }

        /// <summary>
        /// Constructor que inicializa la lista de impuestos.
        /// </summary>
        public DocumentoReembolso()
        {
            Impuestos = new List<Impuesto>();
        }

        
    }
    
 
   

}