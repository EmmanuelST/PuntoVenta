using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    public class DetalleFactura 
    {
        [Key]
        public int IdDetalle {get;set;}
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public float Precio { get; set; }
        public float Cantidad { get; set; }
        public float SubTotal { get; set; }

        public DetalleFactura()
        {
            IdDetalle = 0;
            IdFactura = 0;
            IdProducto = 0;
            Precio = 0;
            Cantidad = 0;
            SubTotal = 0;
        }
    }
}
