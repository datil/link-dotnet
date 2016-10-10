using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DatilClientLibrary
{

    /// <summary>
    /// Clase de la guía de remisión
    /// </summary>
    public class GuiaDeRemision
    {

        /// <summary>
        /// Emisor (persona natural o jurídica) del producto o servicio que consta en guía de remisión.
        /// </summary>
        /// <see cref="Emisor"/>
        public Emisor Emisor { get; set; }

        /// <summary>
        /// Transportista del producto o servicio que consta en guía de remisión.
        /// </summary>
        /// <see cref="Transportista"/>
        public Transportista Transportista { get; set; }

        /// <summary>
        /// Destinatario 
        /// </summary>
        /// <see cref="Destinatario"/>
        public List<Destinatario> Destinatarios { get; set; }

        /// <summary>
        /// Información adicional de guía de remisión.
        /// </summary>
        public Dictionary<string, string> InformacionAdicional { get; set; }

        /// <summary>Número de secuencia de guía de remisión.</summary>
        public string Secuencial { get; set; }

        ///<summary>Fecha de inicio de transporte.</summary>
        public DateTimeOffset FechaInicioTransporte { get; set; }
        // ToString("yyyy-MM-dd HH':'mm':'ss")

        ///<summary>Fecha de fin de transporte.</summary>
        public DateTimeOffset FechaFinTransporte { get; set; }
        // ToString("yyyy-MM-dd HH':'mm':'ss")

        ///<summary>Direccion de partida.</summary>
        public string DireccionPartida { get; set; }
        // ToString("yyyy-MM-dd HH':'mm':'ss")

        ///<summary>Pruebas: 1.Producción 2..</summary>
        public int Ambiente { get; set; }

        ///<summary>Emisión normal: 1.  Emisión por indisponibilidad: 2</summary>
        public int TipoEmision { get; set; }

        ///<summary>Versión del formato de comprobantes electrónicos de SRI. Si no se especifica, se utilizará la última revisión del formato implementada.</summary>
        public string Version { get; set; }

        ///<summary>La clave de acceso representa un identificador único del comprobante.Si esta información no es provista, Dátil la generará.</summary>
        public string ClaveAcceso { get; set; }

        /// <summary>
        /// Construir una nueva Guía de remisión.
        /// </summary>
        public GuiaDeRemision()
        {
            Version = "1.0.0";
            TipoEmision = 1;
            Ambiente = 1;
            ClaveAcceso = null;
        }

        /// <summary>
        /// Consultar información de guía de remisión previamente enviada.
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <returns>Información de guía de remisión enviada</returns>
        public static string Consultar(RequestOptions requestOptions)
        {
            Console.WriteLine("Consultando Guía de Remisión");
            var apiRequest = new ApiRequest(requestOptions);
            return apiRequest.Get();

        }

        /// <summary>
        /// Convert object GuiaDeRemision to a json representation
        /// </summary>
        /// <returns>The json representation</returns>
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
        /// Enviar información de guía de remisión para generarla electrónicamente.
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <returns>Información de guía de remisión enviada</returns>
        public String Enviar(RequestOptions requestOptions)
        {
            Console.WriteLine("Enviando guía de remisión");

            var apiRequest = new ApiRequest(requestOptions);
            return apiRequest.Post(this.toJson());
        }



    }
}
