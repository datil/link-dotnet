using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatilClientLibrary;
using Newtonsoft.Json.Linq;

namespace EjemploCSharp
{
    class GuiaDeRemisionEjemplo
    {
        static void Main(string[] args)
        {

            string datilApiGuiaRemisionUrl = "https://link.datil.co/waybills/";

            // Credenciales del requerimiento
            string myApiKey = "xxxx";
            string myPassword = "xxxx";

            // Crear requerimiento
            var requestOptions = new RequestOptions();
            requestOptions.ApiKey = myApiKey;
            requestOptions.Password = myPassword;
            requestOptions.Url = datilApiGuiaRemisionUrl + "issue";

            // Información del establecimiento del emisor de la guìa de remisión
            Establecimiento establecimiento = new Establecimiento("001", "002", "Av. Primera 234 y calle 5ta");

            // Información del emisor. Necesita de un Establecimiento.
            Emisor emisor = new Emisor("0910000000001", "GUGA S.A. ", "XYZ Corp", "Av.Primera 234 y calle 5ta", "12345", true, establecimiento);

            // Información del transportista 
            Transportista transportista = new Transportista("Juan Pérez", "0989898921001", "04", "juan.perez@xyz.com", "Calle única Numero 987", "046029400");

            // Crear guía de remisión
            GuiaDeRemision guiaDeRemision = new GuiaDeRemision();

            // Cabecera de la guía de remisión
            guiaDeRemision.Secuencial = "610";
            DateTime today = DateTime.Today;
            var offset = TimeZoneInfo.Local.GetUtcOffset(today);
            guiaDeRemision.FechaInicioTransporte = new DateTimeOffset(today, offset);
            guiaDeRemision.FechaFinTransporte = new DateTimeOffset(today, offset);
            guiaDeRemision.DireccionPartida = "Kennedy Norte - Torres del Norte";
            guiaDeRemision.Ambiente = 1;
            guiaDeRemision.TipoEmision = 1;

            // Lista de Destinatarios (1 para el ejemplo)
            var destinatarios = new List<Destinatario>();
            var destinatario = new Destinatario("Andrade Hnos", "0933442233", "Av. de las Americas");
            destinatario.MotivoTraslado = "Entrega";

            destinatario.TipoIdentificacion = "05";
            destinatario.FechaEmisionDocumentoSustento = new DateTimeOffset(today, offset);
            destinatario.NumeroDocumentoSustento = "001-001-000000324";
            destinatario.NumeroAutorizacionDocumentoSustento = "2609201612325309921238470010843106733";
            destinatario.TipoDocumentoSustento = "01";
            destinatario.Ruta = "Av. Perimetral - Av. de las Americas";
            destinatario.DocumentoAduaneroUnico = "123122343";
            destinatario.CodigoEstablecimientoDestino = "002";
            destinatario.Email = "a@example.com";
            destinatario.Telefono = "043343434";

            // Lista de items del destinatario (1 para el ejemplo)
            var itemsDestinatario = new List<ItemDestinatario>();
            var itemDestinatario = new ItemDestinatario("ZNC", "050", "Zanahoria granel 50 Kg.", 4.0);
            itemsDestinatario.Add(itemDestinatario);
            destinatario.Items = itemsDestinatario;
            destinatarios.Add(destinatario);

            //guiaDeRemision.Version =
            //guiaDeRemision.ClaveAcceso = 

            // Informaciòn de la guía de remisión
            guiaDeRemision.Emisor = emisor;
            guiaDeRemision.Transportista = transportista;
            guiaDeRemision.Destinatarios = destinatarios;

            // Informaciòn adicional
            var infoAdicionalGuiaDeRemision = new Dictionary<string, string>();
            infoAdicionalGuiaDeRemision.Add("Via", "terrestre");
            guiaDeRemision.InformacionAdicional = infoAdicionalGuiaDeRemision;

            // Enviar guía de remisión
            var respuesta = guiaDeRemision.Enviar(requestOptions);
            Console.WriteLine("RESPUESTA:" + respuesta);

            // Obtener el id externo, para luego consultar el estado
            JObject json = JObject.Parse(respuesta);
            string idExterno = (string)json["id"];
            Console.WriteLine("ID EXTERNO: " + idExterno); //5832e2c370414663a1bea71938a65bf0

            //Consultar estado de la guía de remisión
            var requestOptions2 = new RequestOptions();
            requestOptions2.ApiKey = myApiKey;
            requestOptions2.Password = myPassword;
            requestOptions2.Url = datilApiGuiaRemisionUrl + idExterno;
            respuesta = GuiaDeRemision.Consultar(requestOptions2);
            json = JObject.Parse(respuesta);
            string estado = (string)json["estado"];
            Console.WriteLine("ESTADO: " + estado); // RECIBIDO


        }
    }
}

