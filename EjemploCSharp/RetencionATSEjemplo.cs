using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatilClientLibrary;
using Newtonsoft.Json.Linq;

namespace EjemploCSharp
{
    class RetencionATSEjemplo
    {
        static void Main(string[] args)
        {

            string datilApiRetencionUrl = "https://link.datil.co/ats-retentions/";

            // Credenciales del requerimiento
            string myApiKey = "xxxx";
            string myPassword = "xxxx";
            
            // Crear requerimiento
            var requestOptions = new RequestOptions();
            requestOptions.ApiKey = myApiKey;
            requestOptions.Password = myPassword;
            requestOptions.Url = datilApiRetencionUrl + "issue";

            // Crear retención
            RetencionATS retencionAts = new RetencionATS();

            // Cabecera de la retención
            retencionAts.Secuencia = "610";

            DateTime today = DateTime.Today;
            var offset = TimeZoneInfo.Local.GetUtcOffset(today);
            retencionAts.FechaEmision = new DateTimeOffset(today, offset);

            retencionAts.Ambiente = 1;

            retencionAts.TipoEmision = 1;

            retencionAts.PeriodoFiscal = "09/2016";
            
            // Información del establecimiento 
            Establecimiento establecimiento = new Establecimiento("001", "002", "Av. Primera 234 y calle 5ta");
            
            // Información del emisor. Necesita de un Establecimiento.
            Emisor emisor = new Emisor("0910000000001", "GUGA S.A. ", "XYZ Corp", "Av.Primera 234 y calle 5ta", "12345", true, establecimiento);
            retencionAts.Emisor = emisor;
            
            // Información del sujeto retenido 
            Comprador sujetoRetenido = new Comprador("Juan Pérez", "0989898921001", "04", "juan.perez@xyz.com", "Calle única Numero 987", "046029400");
            retencionAts.Sujeto = sujetoRetenido;
            
            retencionAts.TipoSujetoRetenido = "01";

            // Documentos de soporte
            DocumentoSoporte documentoSoporte = new DocumentoSoporte();
            documentoSoporte.CodigoSustento = "10";
            documentoSoporte.TipoDocumento = "41";
            documentoSoporte.Numero = "002-004-000248967";
            documentoSoporte.FechaEmision = new DateTimeOffset(today, offset);
            documentoSoporte.FechaRegistroContable = new DateTimeOffset(today, offset);
            documentoSoporte.NumeroAutorizacion = "1234567890";
            documentoSoporte.TipoPago = "01";
            documentoSoporte.TotalSinImpuestos = "84.04";
            documentoSoporte.Total = "88.34";
            documentoSoporte.TipoRegimenFiscal = "01";
            documentoSoporte.Pais = "AR";
            documentoSoporte.AplicaConvenio = true;
            documentoSoporte.PagoExterior = true;
            documentoSoporte.PagoRegimenFiscal = true;
             
            Impuesto impuesto = new Impuesto("2", "2", 18.09, 2.17);
            impuesto.Tarifa = 12.00;
            List<Impuesto> impuestos = new List<Impuesto>();
            impuestos.Add(impuesto);
            documentoSoporte.Impuestos = impuestos;
            
            
            ImpuestoRetenidoRetencionATS impuestoRetenido = new ImpuestoRetenidoRetencionATS();
            impuestoRetenido.Codigo = "2";
            impuestoRetenido.CodigoPorcentaje = "10";
            impuestoRetenido.Tarifa = 20.00;
            impuestoRetenido.BaseImponible = 2.17;
            impuestoRetenido.ValorRetenido = 0.43;
            
            
            ImpuestoRetenidoRetencionATS impuestoRetenido2 = new ImpuestoRetenidoRetencionATS();
            impuestoRetenido2.Codigo = "1";
            impuestoRetenido2.CodigoPorcentaje = "327";
            impuestoRetenido2.BaseImponible = 18.09;
            impuestoRetenido2.Tarifa = 0;
            impuestoRetenido2.ValorRetenido = 0.00;
            
            // Dividendos
            Dividendo dividendo = new Dividendo();
            dividendo.FechaPago = new DateTimeOffset(today, offset);
            dividendo.ImpuestoRenta = 0.21;
            dividendo.AnnioFiscal = 2022;
            
            List<Dividendo> dividendos = new List<Dividendo>();
            dividendos.Add(dividendo);
            impuestoRetenido2.Dividendos = dividendos;
            
            // Retenciones
            List<ImpuestoRetenidoRetencionATS> impuestosRetenidos = new List<ImpuestoRetenidoRetencionATS>();
            impuestosRetenidos.Add(impuestoRetenido);
            impuestosRetenidos.Add(impuestoRetenido2);
            documentoSoporte.Retenciones = impuestosRetenidos;
            
            //Reembolso
            
            Reembolso soporteReembolso = new Reembolso();
            soporteReembolso.Codigo = "41";
            soporteReembolso.Subtotal = 300.00;
            soporteReembolso.Total = 300.00;
            soporteReembolso.TotalImpuestos = 0.00;
            
            // Documentos reembolso
            
            DocumentoReembolso documentoReembolso = new DocumentoReembolso();
            documentoReembolso.CodigoEstablecimiento = "002";
            documentoReembolso.CodigoPuntoEmision = "003";
            documentoReembolso.FechaEmision = new DateTimeOffset(today, offset);
            documentoReembolso.PaisOrigenProveedor = "EC";
            documentoReembolso.IdentificacionProveedor = "0910000000001";
            documentoReembolso.TipoIdentificacionProveedor = "04";
            documentoReembolso.NumeroAutorizacion = "1234567890";
            documentoReembolso.Secuencia = 2132;
            documentoReembolso.Tipo = "01";
            documentoReembolso.TipoProveedor = "02";
            //
            Impuesto impuestoDocumento = new Impuesto("2", "2", 18.09, 2.17);
            impuestoDocumento.Tarifa = 12.00;
            List<Impuesto> impuestosDocumento = new List<Impuesto>();
            impuestosDocumento.Add(impuestoDocumento);
            documentoReembolso.Impuestos = impuestosDocumento;
            
            List<DocumentoReembolso> documentos = new List<DocumentoReembolso>();
            documentos.Add(documentoReembolso);
            soporteReembolso.Documentos = documentos;



            documentoSoporte.Reembolso = soporteReembolso;
            
            
            List<DocumentoSoporte> documentosSoporte = new List<DocumentoSoporte>();
            documentosSoporte.Add(documentoSoporte);
            retencionAts.DocumentosSoporte = documentosSoporte;
            
            
            // Información adicional
            InformacionAdicional informacionAdicional = new InformacionAdicional("Tiempo de entrega", "5 días");
            List<InformacionAdicional> informacionesAdicionales = new List<InformacionAdicional>();
            informacionesAdicionales.Add(informacionAdicional);
            retencionAts.InfoAdicional = informacionesAdicionales;
            
            
            //Enviar retención
            var respuesta = retencionAts.Enviar(requestOptions);
            Console.WriteLine("RESPUESTA:" + respuesta);

            // Obtener el id externo, para luego consultar el estado
            JObject json = JObject.Parse(respuesta);
            string idExterno = (string)json["id"];
            Console.WriteLine("ID EXTERNO: " + idExterno); //5832e2c370414663a1bea71938a65bf0
            
        }
    }
}
