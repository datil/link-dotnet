using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{
    public class InformacionAdicional
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public InformacionAdicional(
            string Nombre,
            string Descripcion
        )
        {
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
        }
    }
}