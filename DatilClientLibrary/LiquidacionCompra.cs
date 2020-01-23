using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    /// <summary>
    /// Clase de la Liquidación de compra
    /// </summary>
    public class LiquidacionCompra
    {
        /// <summary>
        /// Emisor (persona natural o jurídica) del producto o servicio que consta en la factura.
        /// </summary>
        /// <see cref="Emisor"/>
        public Emisor Emisor { get; set; }

        /// <summary>
        /// Comprador del producto o servicio que consta en la factura.
        /// </summary>
        /// <see cref="Proveedor"/>
        public Proveedor Proveedor { get; set; }

        /// <summary>
        /// Lista de items detallados en la factura.
        /// </summary>
        /// <see cref="Item"/>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Totales de la factura.
        /// </summary>
        /// <see cref="TotalesLiquidacion"/>
        public TotalesLiquidacion Totales { get; set; }


        /// <summary>
        /// Información adicional de la factura.
        /// </summary>
        public Dictionary<string, string> InformacionAdicional { get; set; }

        /// <summary>Número de secuencia de la factura.</summary>
        public string Secuencial { get; set; }

        /// <summary>Código ISO de la moneda.</summary>
        public string Moneda { get; set; }

        ///<summary>Fecha de emisión de la factura.</summary>
        public DateTimeOffset FechaEmision { get; set; }
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
        /// Métodos de Pago
        /// </summary>
        /// <see cref="FormaPagoLiquidacionCompra"/>
        public List<FormaPagoLiquidacionCompra> Pagos { get; set; }

        /// <summary>
        /// Información de máquina fiscal.
        /// </summary>
        /// <see cref="MaquinaFiscalLiquidacionCompra"/>
        public MaquinaFiscalLiquidacionCompra MaquinaFiscal { get; set; }


        /// <summary>
        /// Construir una nueva Factura.
        /// </summary>
        public LiquidacionCompra()
        {
            GuiaRemision = null;
            Version = "1.0.0";
            TipoEmision = 1;
            Ambiente = 1;
            Moneda = "USD";
            ClaveAcceso = null;
            Pagos = new List<FormaPagoLiquidacionCompra>();

        }

        /// <summary>
        /// Consultar información de la factura previamente enviada.
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <returns>Información de la factura enviada</returns>
        public static string Consultar(RequestOptions requestOptions)
        {
            Console.WriteLine("Consultando Liquidación");
            var apiRequest = new ApiRequest(requestOptions);
            return apiRequest.Get();

        }

        /// <summary>
        /// Convert object Factura to a json representation
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
        /// Enviar información de la factura para generarla electrónicamente.
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <returns>Información de la factura enviada</returns>
        public String Enviar(RequestOptions requestOptions)
        {
            Console.WriteLine("Enviando Liquidación");

            var apiRequest = new ApiRequest(requestOptions);
            return apiRequest.Post(this.toJson());
        }
    }

}
