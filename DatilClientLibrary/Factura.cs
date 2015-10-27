using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public Total Total { get; set; }
        public Dictionary<string,string> InformacionAdicional { get; set; }

        /// <summary>Número de secuencia de la factura.</summary>
        public string Secuencial { get; set; }

        /// <summary>Código ISO de la moneda.</summary>
        [DefaultValue("USD")]
        public string Moneda { get; set; }

        ///<summary>Fecha de emisión de la factura.</summary>
        public DateTime FechaEmision { get; set; }

        ///<summary>Número de guía de remisión asociada a esta factura en formato 001-002-000000003 ([0-9]{3}-[0-9]{3}-[0-9]{9})</summary>
        public string GuiaRemision { get; set; }

        ///<summary>Pruebas: 1.Producción 2..</summary>
        [DefaultValue(1)]
        public int Ambiente { get; set; }

        ///<summary>Emisión normal: 1.  Emisión por indisponibilidad: 2</summary>
        [DefaultValue(1)]
        public int TipoEmision { get; set; }

        ///<summary>Versión del formato de comprobantes electrónicos de SRI. Si no se especifica, se utilizará la última revisión del formato implementada.</summary>
        public string Version { get; set; }

        ///<summary>La clave de acceso representa un identificador único del comprobante.Si esta información no es provista, Dátil la generará.</summary>
        public string ClaveAcceso { get; set; }

        /*public String body = @"{
                ""ambiente"":1,
                ""tipo_emision"":1,
                ""secuencial"":148,
                ""fecha_emision"":""2015-02-28T11:28:56.782Z"",
                ""emisor"":{
                  ""ruc"":""0910000000001"",
                  ""obligado_contabilidad"":true,
                  ""contribuyente_especial"":""12345"",
                  ""nombre_comercial"":""XYZ Corp"",
                  ""razon_social"":""XYZ Corporación S.A."",
                  ""direccion"":""Av. Primera 234 y calle 5ta"",
                  ""establecimiento"":{
                    ""punto_emision"":""002"",
                    ""codigo"":""001"",
                    ""direccion"":""Av. Primera 234 y calle 5ta""
                  }
                },
                ""moneda"":""USD"",
                ""informacion_adicional"":{
                  ""Tiempo de entrega"":""5 días""
                },
                ""totales"":{
                  ""total_sin_impuestos"":4359.54,
                  ""impuestos"":[
                    {
                      ""base_imponible"":0.0,
                      ""valor"":0.0,
                      ""codigo"":""2"",
                      ""codigo_porcentaje"":""0""
                    },
                    {
                      ""base_imponible"":4359.54,
                      ""valor"":523.14,
                      ""codigo"":""2"",
                      ""codigo_porcentaje"":""2""
                    }
                  ],
                  ""importe_total"":4882.68,
                  ""propina"":0.0,
                  ""descuento"":0.0
                },
                ""comprador"":{
                  ""email"":""juan.perez@xyz.com"",
                  ""identificacion"":""0987654321"",
                  ""tipo_identificacion"":""05"",
                  ""razon_social"":""Juan Pérez"",
                  ""direccion"":""Calle única Numero 987"",
                  ""telefono"":""046029400""
                },
                ""items"":[
                  {
                    ""cantidad"":622.0,
                    ""codigo_principal"": ""ZNC"",
                    ""codigo_auxiliar"": ""050"",
                    ""precio_unitario"": 7.01,
                    ""descripcion"": ""Zanahoria granel  50 Kg."",
                    ""precio_total_sin_impuestos"": 4360.22,
                    ""impuestos"": [
                      {
                        ""base_imponible"":4359.54,
                        ""valor"":523.14,
                        ""tarifa"":12.0,
                        ""codigo"":""2"",
                        ""codigo_porcentaje"":""2""
                      }
                    ],
                    ""detalles_adicionales"": {
                      ""Peso"":""5000.0000""
                    },
                    ""descuento"": 0.0
                  }
                ]
              }";
              */
        public String GetInfo(RequestOptions requestOptions)
        {
            var apiRequest = new ApiRequest(requestOptions);
            return apiRequest.SendRequest();
           
        }
        

        public String Enviar(RequestOptions requestOptions)
        {
            var json = JsonConvert.SerializeObject(this);
            Console.WriteLine(json);
            return "";
            // ToString("yyyy-MM-dd HH':'mm':'ss")
            //var apiRequest = new ApiRequest(requestOptions);
            //return apiRequest.SendRequest(body);
        }

        

    }
}
