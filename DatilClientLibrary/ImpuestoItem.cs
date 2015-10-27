using System.ComponentModel;

namespace DatilClientLibrary
{
    public class ImpuestoItem : Impuesto
    {


      
        /// <summary> actual del impuesto expresado por un número entre 0.0 y 100.0</summary>
        public double Tarifa { get; set; }


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