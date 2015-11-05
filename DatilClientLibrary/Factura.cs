﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Serialization.ContractResolverExtentions;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Clases para crear comprobantes
/// </summary>
namespace DatilClientLibrary
{


    /// <summary>
    /// Clase de la factura
    /// </summary>
    public class Factura
    {

        /// <summary>
        /// Emisor (persona natural o jurídica) del producto o servicio que consta en la factura.
        /// </summary>
        /// <see cref="Emisor"/>
        public Emisor Emisor { get; set; }

        /// <summary>
        /// Comprador del producto o servicio que consta en la factura.
        /// </summary>
        /// <see cref="Comprador"/>
        public Comprador Comprador { get; set; }

        /// <summary>
        /// Lista de items detallados en la factura.
        /// </summary>
        /// <see cref="Item"/>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Totales de la factura.
        /// </summary>
        /// <see cref="Total"/>
        public Total Totales { get; set; }

        /// <summary>
        /// Información adicional de la factura.
        /// </summary>
        public Dictionary<string,string> InformacionAdicional { get; set; }

        /// <summary>Número de secuencia de la factura.</summary>
        public string Secuencial { get; set; }

        /// <summary>Código ISO de la moneda.</summary>
        public string Moneda { get; set; }

        ///<summary>Fecha de emisión de la factura.</summary>
        public DateTime FechaEmision { get; set; }
        // ToString("yyyy-MM-dd HH':'mm':'ss")

        ///<summary>Número de guía de remisión asociada a esta factura en formato 001-002-000000003 ([0-9]{3}-[0-9]{3}-[0-9]{9})</summary>
        public string GuiaRemision { get; set; }

        ///<summary>Pruebas: 1.Producción 2..</summary>
        public int Ambiente { get; set; }

        ///<summary>Emisión normal: 1.  Emisión por indisponibilidad: 2</summary>
        public int TipoEmision { get; set; }

        ///<summary>Versión del formato de comprobantes electrónicos de SRI. Si no se especifica, se utilizará la última revisión del formato implementada.</summary>
        public string Version { get; set; }

        ///<summary>La clave de acceso representa un identificador único del comprobante.Si esta información no es provista, Dátil la generará.</summary>
        public string ClaveAcceso { get; set; }

        /// <summary>
        /// Construir una nueva Factura.
        /// </summary>
        public Factura()
        {
            GuiaRemision = null;
            Version = "1.0.0";
            TipoEmision = 1;
            Ambiente = 1;
            Moneda = "USD";
            ClaveAcceso = null; 

        }
        
        /// <summary>
        /// Consultar información de la factura previamente enviada.
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <returns>Información de la factura enviada</returns>
        public static string Consultar(RequestOptions requestOptions)
        {
            var apiRequest = new ApiRequest(requestOptions);
            return apiRequest.SendRequest();
           
        }
        
        
        /// <summary>
        /// Enviar información de la factura para generarla electrónicamente.
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <returns>Información de la factura enviada</returns>
        public String Enviar(RequestOptions requestOptions)
        {

            var jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new SnakeCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore

            };
            var json = JsonConvert.SerializeObject(this, jsonSettings);
            var apiRequest = new ApiRequest(requestOptions);
            return apiRequest.SendRequest(json);
        }

        

    }
}
