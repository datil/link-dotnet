using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatilClientLibrary
{    
     /// <summary>
     /// Clase del Item que le pertenece a la nota de débito.
     /// </summary>
     /// <see cref="NotaDeDebito"/>
    public class ItemNotaDeDebito
    {
        /// <summary> Motivo. Ejemplo: Interés por mora </summary>
        public string Motivo { get; set; }

        /// <summary>  Valor.  </summary>
        public double Valor { get; set; }

        /// <summary>Construir un item</summary>
        public ItemNotaDeDebito(string Motivo, double Valor)
        {
            this.Motivo = Motivo;
            this.Valor = Valor;

        }
    }
}
