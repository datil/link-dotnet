using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatilClientLibrary;
using Newtonsoft.Json.Linq;

namespace EjemploCSharp
{
    class NotaDeCreditoEjemplo
    {
        static void Main_(string[] args)
        {

            string datilApiNotaCreditoUrl = "https://link.datil.co/credit-notes/";

            // Credenciales del requerimiento
            string myApiKey = "xxxx";
            string myPassword = "xxxx";

            // Crear requerimiento
            var requestOptions = new RequestOptions();
            requestOptions.ApiKey = myApiKey;
            requestOptions.Password = myPassword;
            requestOptions.Url = datilApiNotaCreditoUrl + "issue";

            // Información del comprador 
            Comprador comprador = new Comprador("Juan Pérez", "0989898921001", "04", "juan.perez@xyz.com", "Calle única Numero 987", "046029400");

            // Información del establecimiento 
            Establecimiento establecimiento = new Establecimiento("001", "002", "Av. Primera 234 y calle 5ta");

            // Información del emisor. Necesita de un Establecimiento.
            Emisor emisor = new Emisor("0910000000001", "GUGA S.A. ", "XYZ Corp", "Av.Primera 234 y calle 5ta", "12345", true, establecimiento);

            // Detalle de la nota de crédito y sus impuestos.
            var items = new List<Item>();
            Item item = new Item("ZNC", "050", "Zanahoria granel 50 Kg.", 622.0, 7.01, 4360.22, 0.0);
            var detallesAdicionales = new Dictionary<string, string>();
            detallesAdicionales.Add("Peso", "5000"); //  agregar más detalles al item de ser necesario
            item.DetallesAdicionales = detallesAdicionales;
            var impuestos = new List<ImpuestoItem>();
            impuestos.Add(new ImpuestoItem("2", "2", 4359.54, 523.14, 12.0));  // agregar más impuestos al item de ser necesario
            item.Impuestos = impuestos;
            items.Add(item); //agregar más items a la lista de ser necesario

            // Total de la nota de crédito con sus impuestos, no necesita propina.          
            var totales = new TotalesNotaDeCredito(4359.54, 4882.68);
            var impuestosDeTotal = new List<Impuesto>();
            impuestosDeTotal.Add(new Impuesto("2", "0", 0.0, 0.0));
            impuestosDeTotal.Add(new Impuesto("2", "2", 4359.54, 523.14)); // agregar más impuestos a la lista de ser necesario.
            totales.Impuestos = impuestosDeTotal;

            // Crear nota de crédito 
            NotaDeCredito notaDeCredito = new NotaDeCredito();
            // Cabecera
            notaDeCredito.Secuencial = "610";
            notaDeCredito.Moneda = "USD";

            DateTime today = DateTime.Today;
            var offset = TimeZoneInfo.Local.GetUtcOffset(today);
            notaDeCredito.FechaEmision = new DateTimeOffset(today, offset);
            notaDeCredito.Ambiente = 1;
            notaDeCredito.TipoEmision = 1;
            notaDeCredito.FechaEmisionDocumentoModificado = new DateTimeOffset(today, offset);
            notaDeCredito.NumeroDocumentoModificado = "001-001-000012345";
            notaDeCredito.TipoDocumentoModificado = "01";
            notaDeCredito.Motivo = "Devolución";

            //notaDeCredito.Version =
            //notaDeCredito.ClaveAcceso = 

            // Informaciòn de la nota de crédito
            notaDeCredito.Emisor = emisor;
            notaDeCredito.Comprador = comprador;
            notaDeCredito.Totales = totales;
            notaDeCredito.Items = items;

            // Informaciòn adicional
            var infoAdicionalFactura = new Dictionary<string, string>();
            infoAdicionalFactura.Add("Tiempo de entrega", "5 días");
            notaDeCredito.InformacionAdicional = infoAdicionalFactura;

            // Enviar nota de crédito
            var respuesta = notaDeCredito.Enviar(requestOptions);
            Console.WriteLine("RESPUESTA:" + respuesta);


            // Obtener el id externo, para luego consultar el estado
            JObject json = JObject.Parse(respuesta);
            string idExterno = (string)json["id"];
            Console.WriteLine("ID EXTERNO: " + idExterno); //5832e2c370414663a1bea71938a65bf0

            //Consultar estado de la nota de crédito
            var requestOptions2 = new RequestOptions();
            requestOptions2.ApiKey = myApiKey;
            requestOptions2.Password = myPassword;
            requestOptions2.Url = datilApiNotaCreditoUrl + idExterno;
            respuesta = NotaDeCredito.Consultar(requestOptions2);
            json = JObject.Parse(respuesta);
            string estado = (string)json["estado"];
            Console.WriteLine("ESTADO: " + estado); // RECIBIDO


        }
    }
}

