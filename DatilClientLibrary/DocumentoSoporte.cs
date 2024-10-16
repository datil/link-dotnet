using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DatilClientLibrary
{
    public class DocumentoSoporte

    {

        /// <summary>Codigo de sustento</summary>
        /// 
        public string CodigoSustento { get; set; }

        ///<summary>Tipo de documento de sustento</summary>
        ///
        public string TipoDocumento { get; set; }

        ///<summary>Numero de documento de sustento</summary>
        ///
        public string Numero { get; set; }

        ///<summary>Fecha de emision del documento de sustento</summary>
        ///
        public DateTimeOffset FechaEmision { get; set; }

        ///<summary>Fecha de registro contable</summary>
        ///
        public DateTimeOffset FechaRegistroContable { get; set; }

        ///<summary>Numero de autorizacion</summary>
        ///
        public string NumeroAutorizacion { get; set; }

        ///<summary>Tipo de pago</summary>
        ///
        public string TipoPago { get; set; }

        ///<summary> Total sin impuestos</summary>
        ///
        public string TotalSinImpuestos { get; set; }

        ///<summary>Valor total</summary>
        ///
        public string Total { get; set; }


        ///<summary>Tipo de regimen fiscal</summary>
        ///
        public string TipoRegimenFiscal { get; set; }

        ///<summary>Pais </summary>
        ///
        public string Pais { get; set; }

        ///<summary> Aplica convenio de pago</summary>
        ///
        public bool AplicaConvenio { get; set; }

        ///<summary>
        /// Si el pago realizado al exterior aplica retención (Requerido si la identificación del sujeto retenido es Identificación del exterior)
        /// </summary>
        public bool PagoExterior { get; set; }


        ///<summary> Pago regimen fiscal</summary>
        ///
        public bool PagoRegimenFiscal { get; set; }


        ///<summary> Impuestos totales del documento</summary>
        ///
        public List<Impuesto> Impuestos { get; set; }

        /// <summary>
        /// Listado de impuestos retenidos
        /// </summary>
        public List<ImpuestoRetenidoRetencionATS> Retenciones { get; set; }

        /// <summary>
        /// Información de reembolso.
        /// </summary>
        public Reembolso Reembolso { get; set; }


        ///<summary> Información de los pagos</summary>
        ///
        public List<PagoDocumentoSoporte> Pagos { get; set; }


        /// <summary>
        ///  Constructor que inicia un DocumentoSoporte
        /// </summary>
        public DocumentoSoporte()
        {
            Impuestos = new List<Impuesto>();
            Retenciones = new List<ImpuestoRetenidoRetencionATS>();
            Pagos = new List<PagoDocumentoSoporte>();




        }
    }
    public class PagoDocumentoSoporte
    {
        /// <summary>
        /// Código de forma de pago
        /// </summary>
        public string TipoPago { get; set; }
        
        
        /// <summary>
        /// Total de pago
        /// </summary>
        
        public string TotalPago { get; set; }
        
        public PagoDocumentoSoporte(
            string TipoPago,
            string TotalPago
        )
        {
            this.TipoPago = TipoPago;
            this.TotalPago = TotalPago;
        }
        
    }
    public class ImpuestoRetenidoRetencionATS
    {
        /// <summary>
        /// Código del tipo de impuesto para la retención en la factura.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Código del porcentaje del impuesto.
        /// </summary>
        public string CodigoPorcentaje { get; set; }

        /// <summary>
        /// Suma de las bases imponibles de cada item para el tipo de impuesto y porcentaje.
        /// </summary>
        public double BaseImponible { get; set; }

        /// <summary>
        /// Porcentaje actual del impuesto (hasta 2 cifras decimales).
        /// </summary>
        public double Tarifa { get; set; }

        /// <summary>
        /// Valor del impuesto retenido (hasta 2 cifras decimales).
        /// </summary>
        public double ValorRetenido { get; set; }

        /// <summary>
        /// Lista de objetos Dividendo que representan las participaciones en utilidades, excedentes, beneficios o similares.
        /// </summary>
        public List<Dividendo> Dividendos { get; set; }

        /// <summary>
        /// Constructor por defecto de la clase ImpuestosRetenidosEnRetencionATS.
        /// </summary>
        public ImpuestoRetenidoRetencionATS()
        {
            Dividendos = new List<Dividendo>();
        }
    }
    
    public class Dividendo
    {
        /// <summary>
        /// Fecha de pago en formato AAAA-MM-DDHoraZonaHoraria, según el estándar ISO8601.
        /// </summary>
        public DateTimeOffset FechaPago { get; set; }
        
        /// <summary>
        /// Impuesto a la Renta pagado por la sociedad correspondiente al dividendo.
        /// </summary>
        public double ImpuestoRenta { get; set; }
        
        /// <summary>
        /// Año fiscal en el que se generaron las utilidades atribuibles al dividendo.
        /// </summary>
        public int AnnioFiscal { get; set; }
        
        /// <summary>
        /// Constructor por defecto de la clase Dividendo.
        /// </summary>
        public Dividendo() {}
    }
}