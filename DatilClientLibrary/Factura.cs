using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Serialization.ContractResolverExtentions;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatilClientLibrary
{




    public class Factura
    {
        
        public Emisor Emisor { get; set; }
        public Comprador Comprador { get; set; }
        public List<Item> Items { get; set; }
        public Total Totales { get; set; }
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

        public Factura()
        {
            GuiaRemision = null;
            Version = "1.0.0";
            TipoEmision = 1;
            Ambiente = 1;
            Moneda = "USD";
            ClaveAcceso = null; 

        }
        
        /*public String GetInfo(RequestOptions requestOptions)
        {
            var apiRequest = new ApiRequest(requestOptions);
            return apiRequest.SendRequest();
           
        }
        */
        
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
