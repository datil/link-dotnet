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
    /// Clase de la nota de débito
    /// </summary>
    public class NotaDeDebito
    {

        /// <summary>
        /// Emisor (persona natural o jurídica) del producto o servicio que consta en la nota de débito.
        /// </summary>
        /// <see cref="Emisor"/>
        public Emisor Emisor { get; set; }

        /// <summary>
        /// Comprador del producto o servicio que consta en la nota de débito.
        /// </summary>
        /// <see cref="Comprador"/>
        public Comprador Comprador { get; set; }

        /// <summary>
        /// Lista de items detallados en la nota de débito.
        /// </summary>
        /// <see cref="Item"/>
        public List<ItemNotaDeDebito> Items { get; set; }

        /// <summary>
        /// Totales de la nota de débito.
        /// </summary>
        /// <see cref="TotalesNotaDeDebito"/>
        public TotalesNotaDeDebito Totales { get; set; }

        /// <summary>
        /// Información adicional de la nota de débito.
        /// </summary>
        public Dictionary<string, string> InformacionAdicional { get; set; }

        /// <summary>Número de secuencia de la nota de débito.</summary>
        public string Secuencial { get; set; }

        ///<summary>Fecha de emisión de la nota de débito.</summary>
        public DateTimeOffset FechaEmision { get; set; }
        // ToString("yyyy-MM-dd HH':'mm':'ss")

        ///<summary>Fecha de emisión del documento modificado.</summary>
        public DateTimeOffset FechaEmisionDocumentoModificado { get; set; }
        // ToString("yyyy-MM-dd HH':'mm':'ss")

        ///<summary>Número del documento modificado.</summary>
        public string NumeroDocumentoModificado { get; set; }

        ///<summary>Tipo del documento modificado.
        ///     http://datil.github.io/link-docs/#tipos-de-documentos
        ///</summary>
        public string TipoDocumentoModificado { get; set; }

        ///<summary>Pruebas: 1.Producción 2..</summary>
        public int Ambiente { get; set; }

        ///<summary>Emisión normal: 1.  Emisión por indisponibilidad: 2</summary>
        public int TipoEmision { get; set; }

        ///<summary>Versión del formato de comprobantes electrónicos de SRI. Si no se especifica, se utilizará la última revisión del formato implementada.</summary>
        public string Version { get; set; }

        ///<summary>La clave de acceso representa un identificador único del comprobante.Si esta información no es provista, Dátil la generará.</summary>
        public string ClaveAcceso { get; set; }



        /// <summary>
        /// Construir una nueva nota de débito.
        /// </summary>
        public NotaDeDebito()
        {
            Version = "1.0.0";
            TipoEmision = 1;
            Ambiente = 1;
            ClaveAcceso = null;
        }

        /// <summary>
        /// Consultar información de la nota de débito previamente enviada.
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <returns>Información de la nota de débito enviada</returns>
        public static string Consultar(RequestOptions requestOptions)
        {
            Console.WriteLine("Consultando nota de débito");
            var apiRequest = new ApiRequest(requestOptions);
            return apiRequest.Get();

        }


        /// <summary>
        /// Enviar información de la nota de débito para generarla electrónicamente.
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <returns>Información de la nota de débito enviada</returns>
        public String Enviar(RequestOptions requestOptions)
        {
            Console.WriteLine("Enviando nota de débito");
            var jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new SnakeCaseContractResolver(),
                NullValueHandling = NullValueHandling.Ignore

            };
            var json = JsonConvert.SerializeObject(this, jsonSettings);
            var apiRequest = new ApiRequest(requestOptions);
            return apiRequest.Post(json);
        }



    }
}
