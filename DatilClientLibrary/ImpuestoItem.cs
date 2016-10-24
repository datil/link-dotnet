using System.ComponentModel;

namespace DatilClientLibrary
{
    /// <summary>
    /// Clase del impuesto del item.
    /// </summary>
    ///  <see cref="Item"/>
    public class ImpuestoItem : Impuesto
    {

        /// <summary> Construir un impuesto con tarifa</summary>
        public ImpuestoItem(string Codigo,
            string CodigoPorcentaje,
            double BaseImponible,
            double Valor,
            double Tarifa) : base(Codigo, CodigoPorcentaje, BaseImponible, Valor)
        {
            this.Tarifa = Tarifa;
        }

       
    }
}