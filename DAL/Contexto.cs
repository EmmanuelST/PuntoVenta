using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Producto>Producto { get; set; }
        public DbSet<Factura>Factura { get; set; }
        public DbSet<DetalleFactura>DetalleFactura { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
