using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Entidades;

namespace Entidades
{
    public class Factura 
    {
        [Key]
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }

        public List<DetalleFactura> Detalles { get; set; }



        public Factura()
        {
            IdFactura = 0;
            Fecha = DateTime.Now;
            Total = 0;
            Detalles = new List<DetalleFactura>();
        }


    }
}
