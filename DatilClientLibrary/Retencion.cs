using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    public class Retencion
    {
        /// <summary>Número de secuencia de la retención.</summary>
        public string Secuencial { get; set; }

        ///<summary>Fecha de emisión de la retención.</summary>
        public DateTimeOffset FechaEmision { get; set; }
        // ToString("yyyy-MM-dd HH':'mm':'ss")

        ///<summary>Pruebas: 1.Producción 2..</summary>
        public int Ambiente { get; set; }

        ///<summary>Emisión normal: 1.  Emisión por indisponibilidad: 2</summary>
        public int TipoEmision { get; set; }

        ///<summary>Versión del formato de comprobantes electrónicos de SRI. Si no se especifica, se utilizará la última revisión del formato implementada.</summary>
        public string Version { get; set; }

        ///<summary>La clave de acceso representa un identificador único del comprobante.Si esta información no es provista, Dátil la generará.</summary>
        public string ClaveAcceso { get; set; }

        ///<summary>Periodo fiscal, en el formato MM/AAAA. Ejemplo: 09/2016</summary>
        public string PeriodoFiscal { get; set; }


        /// <summary>
        /// Emisor (persona natural o jurídica) del producto o servicio que consta en la retención.
        /// </summary>
        /// <see cref="Emisor"/>
        public Emisor Emisor { get; set; }

        /// <summary>
        /// Comprador del producto o servicio que consta en la retención.
        /// </summary>
        /// <see cref="Comprador"/>
        public Comprador Sujeto { get; set; }

        /// <summary>
        /// Lista de impuestos detallados en la retención.
        /// </summary>
        /// <see cref="ItemRetencion"/>
        public List<ItemRetencion> items { get; set; }

        /// <summary>
        /// Información adicional de la retención.
        /// </summary>
        public Dictionary<string, string> InformacionAdicional { get; set; }


        /// <summary>
        /// Construir una nueva Retención.
        /// </summary>
        public Retencion()
        {
            Version = "1.0.0";
            TipoEmision = 1;
            Ambiente = 1;
            ClaveAcceso = null;
        }

        /// <summary>
        /// Consultar información de la retencíón previamente enviada.
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <returns>Información de la retención enviada</returns>
        public static string Consultar(RequestOptions requestOptions)
        {
            Console.WriteLine("Consultando Retención");
            var apiRequest = new ApiRequest(requestOptions);
            return apiRequest.Get();

        }

        /// <summary>
        /// Convertir el objeto Retención a una representaciòn json
        /// </summary>
        /// <returns>La representación Json</returns>
        public string toJson()
        {
            var jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new SnakeCaseContractResolver(),
                NullValueHandling = NullValueHandling.Ignore

            };
            var json = JsonConvert.SerializeObject(this, jsonSettings);
            return json;
        }


        /// <summary>
        /// Enviar información de la retención para generarla electrónicamente.
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <returns>Información de la retención enviada</returns>
        public String Enviar(RequestOptions requestOptions)
        {
            Console.WriteLine("Enviando retención");

            var apiRequest = new ApiRequest(requestOptions);
            return apiRequest.Post(this.toJson());
        }
    }
}
