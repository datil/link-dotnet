using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatilClientLibrary;

namespace CustomerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            
            /*
            * Credenciales del requerimiento
            */

            var requestOptions = new RequestOptions();
            requestOptions.ApiKey = "XXXX";
            requestOptions.Password = "XXXX";
            requestOptions.Url = "http://link.datil.co/invoices/issue";
        
            /*
            * Información del comprador 
            */

            Comprador comprador = new Comprador("Juan Pérez",
                "0989898921001",
                "04",
                "juan.perez@xyz.com",
                "Calle única Numero 987",
                "046029400");


            /*
            * Información del emisor 
            */

            Establecimiento establecimiento = new Establecimiento("002", "001", "Av. Primera 234 y calle 5ta");

            Emisor emisor = new Emisor("0910000000001", 
                  "XYZ Corporación S.A.",
                  "XYZ Corp", 
                  "Av.Primera 234 y calle 5ta",
                  "12345",
                  true,
                  establecimiento);

            /*
            * Detalle de la factura y sus impuestos.
            */

            var items = new List<Item>();

            Item item = new Item("ZNC","050","Zanahoria granel 50 Kg.",622.0, 7.01,4360.22,0.0);

            var detallesAdicionales = new Dictionary<string, string>();
            detallesAdicionales.Add("Peso", "5000");
            //  agregar más detalles al item de ser necesario
            item.DetallesAdicionales = detallesAdicionales;

            var impuestos = new List<ImpuestoItem>();
            impuestos.Add(new ImpuestoItem("2","2",4359.54, 523.14, 12.0)); 
            // agregar más impuestos al item de ser necesario
            item.Impuestos = impuestos;
                
            items.Add(item);
            //agregar más items a la lista de ser necesario


            /*
            * Total de la factura con sus impuestos.
            */

            var totales = new Total(4359.54, 4882.68,0.0,0.0);
        
            var impuestosDeTotal = new List<Impuesto>();
            impuestosDeTotal.Add(new Impuesto("2","0", 0.0,0.0));
            impuestosDeTotal.Add(new Impuesto("2", "2", 4359.54, 523.14));
            // agregar más impuestos a la lista de ser necesario.
            totales.Impuestos = impuestosDeTotal;

            /*
            * Crear factura y agregar información
            */

            Factura factura = new Factura();
            factura.Emisor = emisor;            
            factura.Comprador = comprador;            
            factura.Totales = totales;            
            factura.Items = items;
            
            var infoAdicionalFactura = new Dictionary<string, string>();
            infoAdicionalFactura.Add("Tiempo de entrega", "5 días");
            factura.InformacionAdicional = infoAdicionalFactura;
            
            factura.Secuencial = "148";
            factura.Moneda = "USD";
            factura.FechaEmision = DateTime.Today;
            //factura.GuiaRemision =
            factura.Ambiente = 1;
            factura.TipoEmision = 1;
            //factura.Version =
            //factura.ClaveAcceso = 
            
            // Enviar factura
            var respuesta = factura.Enviar(requestOptions);
            Console.WriteLine(respuesta);
     
        }
    }
}


