using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public float Cantidad { get; set; }
        public float Precio { get; set; }
        public string Fabricante { get; set; }

        public Producto()
        {
            IdProducto = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
            Precio = 0;
            Fabricante = string.Empty;
        }

    }
}
