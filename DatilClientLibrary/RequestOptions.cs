using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{

    /// <summary>
    /// Clase con opciones de requerimientos al API de Dátil.
    /// </summary>
    public class RequestOptions
    {
        /// <summary>
        /// Clave del Api de Dátil. Obtenida del panel de administración de Dátil http://app.datil.co
        /// </summary>
        public String ApiKey { get; set; }

        /// <summary>
        /// Clave de certificado de firma. Debe ser proporcionada por Dátil.
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// Url para consumir el servicio de Dátil. Varía de acuerdo al tipo de comprobante a procesar.
        /// </summary>
        public String Url { get; set; }
    }
}
