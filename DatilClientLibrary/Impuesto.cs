﻿using System.ComponentModel;

namespace DatilClientLibrary
{
    public class Impuesto
    {


        /// <summary>Código del tipo de impuesto</summary>
        public string Codigo { get; set; }

        /// <summary>Código del procentaje del tipo de impuesto</summary>
        public string CodigoPorcentaje { get; set; }

        /// <summary>Base imponible</summary>
        public double BaseImponible { get; set; }

        /// <summary>Valor del total</summary>
        public double Valor { get; set; }



        /// <summary> Construir un impuesto con tarifa</summary>
        public Impuesto(string Codigo,
            string CodigoPorcentaje,
            double BaseImponible,
            double Valor)
        {
            this.Codigo = Codigo;
            this.CodigoPorcentaje = CodigoPorcentaje;
            this.BaseImponible = BaseImponible;
            this.Valor = Valor;
        }


    }
}