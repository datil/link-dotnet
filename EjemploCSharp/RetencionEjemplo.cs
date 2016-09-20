using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatilClientLibrary;
using Newtonsoft.Json.Linq;

namespace EjemploCSharp
{
    class RetencionEjemplo
    {
        static void Main_(string[] args)
        {

            string datilApiRetencionUrl = "https://link.datil.co/retentions/";

            // Credenciales del requerimiento
            string myApiKey = "xxxx";
            string myPassword = "xxxx";

            // Crear requerimiento
            var requestOptions = new RequestOptions();
            requestOptions.ApiKey = myApiKey;
            requestOptions.Password = myPassword;
            requestOptions.Url = datilApiRetencionUrl + "issue";

            // Crear retención
            Retencion retencion = new Retencion();

            // Cabecera de la retención
            retencion.Secuencial = "610";

            DateTime today = DateTime.Today;
            var offset = TimeZoneInfo.Local.GetUtcOffset(today);
            retencion.FechaEmision = new DateTimeOffset(today, offset);

            retencion.Ambiente = 1;

            retencion.TipoEmision = 1;

            retencion.PeriodoFiscal = "09/2016";

            //retencion.Version =

            //retencion.ClaveAcceso = 

            // Información del sujeto retenido 
            Comprador sujetoRetenido = new Comprador("Juan Pérez", "0989898921001", "04", "juan.perez@xyz.com", "Calle única Numero 987", "046029400");
            retencion.Sujeto = sujetoRetenido;

            // Información del establecimiento 
            Establecimiento establecimiento = new Establecimiento("001", "002", "Av. Primera 234 y calle 5ta");

            // Información del emisor. Necesita de un Establecimiento.
            Emisor emisor = new Emisor("0910000000001", "GUGA S.A. ", "XYZ Corp", "Av.Primera 234 y calle 5ta", "12345", true, establecimiento);
            retencion.Emisor = emisor;

            // Impuestos de la retención.
            var impuestos = new List<ItemRetencion>();
            ItemRetencion impuesto = new ItemRetencion("2", "3", 14, 4359.54, 610.36, new DateTimeOffset(today, offset), "001-002-000000123", "01");
            impuestos.Add(impuesto);  // agregar más impuestos a la retenciòn  de ser necesario
            retencion.items = impuestos;
            
            // Información adicional
            var infoAdicionalRetencion = new Dictionary<string, string>();
            infoAdicionalRetencion.Add("Tiempo de entrega", "5 días");
            retencion.InformacionAdicional = infoAdicionalRetencion;

            // Enviar retención
            var respuesta = retencion.Enviar(requestOptions);
            Console.WriteLine("RESPUESTA:" + respuesta);

            // Obtener el id externo, para luego consultar el estado
            JObject json = JObject.Parse(respuesta);
            string idExterno = (string)json["id"];
            Console.WriteLine("ID EXTERNO: " + idExterno); //5832e2c370414663a1bea71938a65bf0

            //Consultar estado de la retención
            var requestOptions2 = new RequestOptions();
            requestOptions2.ApiKey = myApiKey;
            requestOptions2.Password = myPassword;
            requestOptions2.Url = datilApiRetencionUrl + idExterno;
            respuesta = Retencion.Consultar(requestOptions2);
            json = JObject.Parse(respuesta);
            string estado = (string)json["estado"];
            Console.WriteLine("ESTADO: " + estado); // RECIBIDO
        }
    }
}
