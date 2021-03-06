﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatilClientLibrary
{
    /// <summary>
    /// Clase de los totales de una Factura.
    /// </summary>
    ///<see cref="Factura"/>
    public class TotalesFactura
    {
        /// <summary>Total de la factura antes de aplicar impuestos.</summary>
        public double TotalSinImpuestos { get; set; }

        /// <summary>Total incluyendo impuestos.</summary>
        public double ImporteTotal { get; set; }

        /// <summary>Propina total, llamado también servicio.</summary>
        public double Propina { get; set; }

        /// <summary>Suma de los descuentos de cada ítem.</summary>
        public double Descuento { get; set; }

        /// <summary>Suma de los descuentos adicionales.</summary>
        public double? DescuentoAdicional { get; set; }

        /// <summary>Listado de impuestos, no necesita incluir tarifa.</summary>
        public List<Impuesto> Impuestos { get; set; }

        /// <summary>Valor total de subsidio</summary>
        public double? TotalSubsidio { get; set; }

        /// <summary>Construir totales de una factura</summary>
        public TotalesFactura(double TotalSinImpuestos,
            double ImporteTotal,
            double Propina,
            double Descuento)
            
        {
            this.TotalSinImpuestos = TotalSinImpuestos;
            this.ImporteTotal = ImporteTotal;
            this.Propina = Propina;
            this.Descuento = Descuento;

        }
    }
}
