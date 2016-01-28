using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatilClientLibrary;
using Newtonsoft.Json.Linq;

namespace CustomerExample
{
    class Program
    {
        static void Main(string[] args)
        {

            string datilApiFacturaUrl = "http://192.168.100.103:8080/invoices/";

            // Credenciales del requerimiento
            var requestOptions = new RequestOptions();
            requestOptions.ApiKey = "02eb20fef14142a5985a3409e2190d58";
            requestOptions.Password = "Edra102080";
            requestOptions.Url = datilApiFacturaUrl + "issue";

            // Información del comprador 
            Comprador comprador = new Comprador("Juan Pérez", "0989898921001", "04", "juan.perez@xyz.com", "Calle única Numero 987", "046029400");

            // Información del establecimiento 
            Establecimiento establecimiento = new Establecimiento("001", "002", "Av. Primera 234 y calle 5ta");

            // Información del emisor. Necesita de un Establecimiento.
            Emisor emisor = new Emisor("0910000000001", "GUGA S.A. ", "XYZ Corp", "Av.Primera 234 y calle 5ta", "12345", true, establecimiento);

            // Detalle de la factura y sus impuestos.
            var items = new List<Item>();
            Item item = new Item("ZNC", "050", "Zanahoria granel 50 Kg.", 622.0, 7.01, 4360.22, 0.0);
            var detallesAdicionales = new Dictionary<string, string>();
            detallesAdicionales.Add("Peso", "5000"); //  agregar más detalles al item de ser necesario
            item.DetallesAdicionales = detallesAdicionales;
            var impuestos = new List<ImpuestoItem>();
            impuestos.Add(new ImpuestoItem("2", "2", 4359.54, 523.14, 12.0));  // agregar más impuestos al item de ser necesario
            item.Impuestos = impuestos;
            items.Add(item); //agregar más items a la lista de ser necesario

            // Total de la factura con sus impuestos.          
            var totales = new Total(4359.54, 4882.68, 0.0, 0.0);
            var impuestosDeTotal = new List<Impuesto>();
            impuestosDeTotal.Add(new Impuesto("2", "0", 0.0, 0.0));
            impuestosDeTotal.Add(new Impuesto("2", "2", 4359.54, 523.14)); // agregar más impuestos a la lista de ser necesario.
            totales.Impuestos = impuestosDeTotal;

            // Crear factura 
            Factura factura = new Factura();
            // Cabecera
            factura.Secuencial = "610";
            factura.Moneda = "USD";

            DateTime today = DateTime.Today;
            var offset = TimeZoneInfo.Local.GetUtcOffset(today);
            factura.FechaEmision = new DateTimeOffset(today, offset);

            //factura.FechaEmision = DateTime.Today;
            Console.WriteLine(factura.FechaEmision);
            factura.Ambiente = 1;
            factura.TipoEmision = 1;
            //factura.Version =
            //factura.ClaveAcceso = 
            //factura.GuiaRemision =
            // Informaciòn de la factura
            factura.Emisor = emisor;
            factura.Comprador = comprador;
            factura.Totales = totales;
            factura.Items = items;
            // Informaciòn adicional
            var infoAdicionalFactura = new Dictionary<string, string>();
            infoAdicionalFactura.Add("Tiempo de entrega", "5 días");
            factura.InformacionAdicional = infoAdicionalFactura;

            // Enviar factura
            var respuesta = factura.Enviar(requestOptions);
            Console.WriteLine("RESPUESTA:" + respuesta);

            /*
              // Obtener el id externo, para luego consultar el estado
              JObject json = JObject.Parse(respuesta);
              string idExterno = (string)json["id"];
              Console.WriteLine("ID EXTERNO: " + idExterno); //5832e2c370414663a1bea71938a65bf0
          */
            // Consultar estado de la factura
            /*var requestOptions2 = new RequestOptions();
            requestOptions2.ApiKey = "02eb20fef14142a5985a3409e2190d58";
            requestOptions2.Password = "Edra102080";
            requestOptions2.Url = datilApiFacturaUrl + idExterno;
            respuesta = Factura.Consultar(requestOptions2);
            json = JObject.Parse(respuesta);
            string estado = (string)json["estado"];
            Console.WriteLine("ESTADO: " + estado); // RECIBIDO
            */


            /*
                requestOptions.Url = datilApiFacturaUrl + idExterno;
                respuesta = Factura.Consultar(requestOptions);
                json = JObject.Parse(respuesta);
                string estado = (string)json["estado"];
                Console.WriteLine("ESTADO: " + estado); // RECIBIDO
            */

        }
    }
}


