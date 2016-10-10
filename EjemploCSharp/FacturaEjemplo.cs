using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatilClientLibrary;
using System.Globalization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace EjemploCSharp
{
    class FacturaEjemplo
    {
        static void Main_(string[] args)
        {
            
            string datilApiFacturaUrl = "https://link.datil.co/invoices/";

            // Credenciales del requerimiento
            string myApiKey = "xxxx";
            string myPassword = "xxxx";

            // Crear requerimiento
            var requestOptions = new RequestOptions();
            requestOptions.ApiKey = myApiKey;
            requestOptions.Password = myPassword;
            requestOptions.Url = datilApiFacturaUrl + "issue";
        
            // Información del comprador (Obligatorio)
            Comprador comprador = new Comprador("Juan Pérez", "0989898921001", "04", "juan.perez@xyz.com", "Calle única Numero 987", "046029400");
           
            // Información del establecimiento (Obligatorio)
            Establecimiento establecimiento = new Establecimiento("001", "002", "Av. Primera 234 y calle 5ta");

            // Información del emisor. Necesita de un Establecimiento. (Obligatorio)
            Emisor emisor = new Emisor("0910000000001", "GUGA S.A. ", "XYZ Corp", "Av.Primera 234 y calle 5ta",  "12345", true, establecimiento);

            // Detalle de la factura y sus impuestos. (Obligatorio)
            var items = new List<Item>();
            Item item = new Item("ZNC","050","Zanahoria granel 50 Kg.",622.0, 7.01,4360.22,0.0);
            item.PrecioSinSubsidio = 600.0;
            var detallesAdicionales = new Dictionary<string, string>();
            detallesAdicionales.Add("Peso", "5000"); //  agregar más detalles al item de ser necesario
            item.DetallesAdicionales = detallesAdicionales;
            var impuestos = new List<ImpuestoItem>();
            impuestos.Add(new ImpuestoItem("2","2",4359.54, 523.14, 12.0));  // agregar más impuestos al item de ser necesario
            item.Impuestos = impuestos;
            items.Add(item); //agregar más items a la lista de ser necesario

            // Total de la factura con sus impuestos. (Obligatorio)       
            var totales = new TotalesFactura(4359.54, 4882.68,0.0, 0.0);
            totales.TotalSubsidio = 22.00;
            var impuestosDeTotal = new List<Impuesto>();    
            impuestosDeTotal.Add(new Impuesto("2","0", 0.0,0.0));
            impuestosDeTotal.Add(new Impuesto("2", "2", 4359.54, 523.14)); // agregar más impuestos a la lista de ser necesario.
            totales.Impuestos = impuestosDeTotal;

            // Retenciones en la factura
            /*      Caso específico de Retenciones en la Comercializadores / Distribuidores 
                    de derivados del Petróleo y Retención presuntiva de IVA a los Editores, 
                    Distribuidores y Voceadores que participan en la comercialización 
                    de periódicos y/ o revistas.
            */
             var retenciones = new List<RetencionFactura>();
            RetencionFactura retencion = new RetencionFactura("4", "327", 0.20, 0.13);
            retenciones.Add(retencion);
            RetencionFactura retencion2 = new RetencionFactura("4", "327", 0.20, 0.13);
            retenciones.Add(retencion2);

            // Creación del objeto factura
            Factura factura = new Factura();

            // Cabecera de la factura
            factura.Secuencial = "1613";
            factura.Moneda = "USD";
            factura.Ambiente = 1;
            factura.TipoEmision = 1;

            DateTime today = DateTime.Today;
            var offset = TimeZoneInfo.Local.GetUtcOffset(today);
            factura.FechaEmision = new DateTimeOffset(today, offset);
            //factura.Version =
            //factura.ClaveAcceso = 
            //factura.GuiaRemision =

            // Completar informaciòn de la factura
            factura.Emisor = emisor;            
            factura.Comprador = comprador;            
            factura.Totales = totales;            
            factura.Items = items;
            factura.Retenciones = retenciones;

            // Valores de retención de IVA y de Renta (Opcionales)
            factura.ValorRetIva = 2.0;
            factura.ValorRetRenta = 0.10;

            //Métodos de pago  (Obligatorio)
                // Ejemplo de pagos sin propiedades adicionales
            factura.Pagos.Add(new MetodoPago("efectivo",  12.0));
            factura.Pagos.Add(new MetodoPago("transferencia_otro_banco", 8.0));
                // Ejemplo de pago con propiedades adicionales
            var pagoConDetalle = new MetodoPago("tarjeta_credito_nacional", 60.0);
            pagoConDetalle.Propiedades = new Dictionary<string, string>();
            pagoConDetalle.Propiedades.Add("Tipo tarjeta", "Visa");
            pagoConDetalle.Propiedades.Add("Diferido", "3 meses");
            factura.Pagos.Add(pagoConDetalle);

            // Credito otorgado al cliente (Opcional)
            var montoCredito = 10.50;
                // Crédito a 30 días a partir de la fecha de emisión. Formato 'yyyy-mm-dd'
            var fechaVencimientoCredito = factura.FechaEmision.Date.AddDays(30).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            factura.Credito = new CreditoFactura(montoCredito, fechaVencimientoCredito);
            
            // Informaciòn adicional de la factura (Opcional)
            var infoAdicionalFactura = new Dictionary<string, string>();
            infoAdicionalFactura.Add("Tiempo de entrega", "5 días");
            factura.InformacionAdicional = infoAdicionalFactura;

            Console.WriteLine(factura.toJson());
            
            // Enviar factura
            var respuesta = factura.Enviar(requestOptions);
            Console.WriteLine("RESPUESTA:" + respuesta);
            
            // Obtener el id externo, para luego consultar el estado
            JObject json = JObject.Parse(respuesta);
            string idExterno = (string)json["id"];
            Console.WriteLine("ID EXTERNO: " + idExterno); //5832e2c370414663a1bea71938a65bf0
          
            // Consultar estado de la factura
            var requestOptions2 = new RequestOptions();
            requestOptions2.ApiKey = myApiKey;
            requestOptions2.Password = myPassword;
            requestOptions2.Url = datilApiFacturaUrl + idExterno;
            respuesta = Factura.Consultar(requestOptions2);
            json = JObject.Parse(respuesta);
            string estado = (string)json["estado"];
            Console.WriteLine("ESTADO: " + estado); // RECIBIDO
            
            
        }
    }
}


