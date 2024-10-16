using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{

    /// <summary>
    /// Clase de la retención v2
    /// </summary>
    public class RetencionATS
    {
        /// <summary>Número de secuencia de la retención.</summary>
        public string Secuencia { get; set; }

        ///<summary>Fecha de emisión de la retención.</summary>
        public DateTimeOffset FechaEmision { get; set; }
        // ToString("yyyy-MM-dd HH':'mm':'ss")

        ///<summary>Pruebas: 1.Producción 2..</summary>
        public int Ambiente { get; set; }

        ///<summary>Emisión normal: 1.  Emisión por indisponibilidad: 2</summary>
        public int TipoEmision { get; set; }
        
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
        /// Información adicional de la retención.
        /// </summary>
        public List<InformacionAdicional> InfoAdicional { get; set; }
        
        ///<summary>
        /// Documentos de Soporte
        /// </summary>
        public List<DocumentoSoporte> DocumentosSoporte { get; set; }
        
        ///<summary>
        /// Tipo de sujeto retenido
        /// </summary>
        public string TipoSujetoRetenido { get; set; }
        
        
        ///<summary>
        /// Sujeto retenido
        /// </summary>
        public Comprador Sujeto { get; set; }
      
        
        /// <summary>
        /// Construir una nueva Retención.
        /// </summary>
        public RetencionATS()
        {
            
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
