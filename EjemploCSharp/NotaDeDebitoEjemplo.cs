using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatilClientLibrary;
using Newtonsoft.Json.Linq;

namespace EjemploCSharp
{
    class NotaDeDebitoEjemplo
    {
        static void Main(string[] args)
        {

            string datilApiNotaDebitoUrl = "https://link.datil.co/debit-notes/";

            // Credenciales del requerimiento
            string myApiKey = "xxxx";
            string myPassword = "xxxx";

            // Crear requerimiento
            var requestOptions = new RequestOptions();
            requestOptions.ApiKey = myApiKey;
            requestOptions.Password = myPassword;
            requestOptions.Url = datilApiNotaDebitoUrl + "issue";

            // Información del comprador 
            Comprador comprador = new Comprador("Juan Pérez", "0989898921001", "04", "juan.perez@xyz.com", "Calle única Numero 987", "046029400");

            // Información del establecimiento 
            Establecimiento establecimiento = new Establecimiento("001", "002", "Av. Primera 234 y calle 5ta");

            // Información del emisor. Necesita de un Establecimiento.
            Emisor emisor = new Emisor("0910000000001", "GUGA S.A. ", "XYZ Corp", "Av.Primera 234 y calle 5ta", "12345", true, establecimiento);

            // Detalle de la nota de débito y sus impuestos.
            var items = new List<ItemNotaDeDebito>();
            ItemNotaDeDebito item = new ItemNotaDeDebito("Interès por mora", 50.00);
            items.Add(item); //agregar más items a la lista de ser necesario

            // Total de la nota de débito con sus impuestos, no necesita propina.          
            var totales = new TotalesNotaDeDebito(4359.54, 4882.68);
            var impuestosDeTotal = new List<Impuesto>();
            Impuesto impuesto = new Impuesto("2", "0", 0.0, 0.0);
            impuesto.Tarifa = 0.00;
            impuestosDeTotal.Add(impuesto);
            totales.Impuestos = impuestosDeTotal; // agregar más impuestos a la lista de ser necesario.

            // Crear nota de débito 
            NotaDeDebito notaDeDebito = new NotaDeDebito();
            // Cabecera
            notaDeDebito.Secuencial = "610";

            DateTime today = DateTime.Today;
            var offset = TimeZoneInfo.Local.GetUtcOffset(today);
            notaDeDebito.FechaEmision = new DateTimeOffset(today, offset);
            notaDeDebito.Ambiente = 1;
            notaDeDebito.TipoEmision = 1;
            notaDeDebito.FechaEmisionDocumentoModificado = new DateTimeOffset(today, offset);
            notaDeDebito.NumeroDocumentoModificado = "001-001-000012345";
            notaDeDebito.TipoDocumentoModificado = "01";

            //notaDeDebito.Version =
            //notaDeDebito.ClaveAcceso = 

            // Informaciòn de la nota de débito
            notaDeDebito.Emisor = emisor;
            notaDeDebito.Comprador = comprador;
            notaDeDebito.Totales = totales;
            notaDeDebito.Items = items;

            // Informaciòn adicional
            var infoAdicionalFactura = new Dictionary<string, string>();
            infoAdicionalFactura.Add("Tiempo de entrega", "5 días");
            notaDeDebito.InformacionAdicional = infoAdicionalFactura;

            // Enviar nota de débito
            var respuesta = notaDeDebito.Enviar(requestOptions);
            Console.WriteLine("RESPUESTA:" + respuesta);


            // Obtener el id externo, para luego consultar el estado
            JObject json = JObject.Parse(respuesta);
            string idExterno = (string)json["id"];
            Console.WriteLine("ID EXTERNO: " + idExterno); //5832e2c370414663a1bea71938a65bf0

            //Consultar estado de la nota de débito
            var requestOptions2 = new RequestOptions();
            requestOptions2.ApiKey = myApiKey;
            requestOptions2.Password = myPassword;
            requestOptions2.Url = datilApiNotaDebitoUrl + idExterno;
            respuesta = NotaDeDebito.Consultar(requestOptions2);
            json = JObject.Parse(respuesta);
            string estado = (string)json["estado"];
            Console.WriteLine("ESTADO: " + estado); // RECIBIDO


        }
    }
}

