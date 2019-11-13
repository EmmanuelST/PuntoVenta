using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioFactura : RepositorioBase<Factura>
    {
        Contexto db;
        public override bool Guardar(Factura entity)
        {
            bool paso = false;
            db = new Contexto();
            RepositorioBase<Producto> dbP = new RepositorioBase<Producto>();
            Producto producto = new Producto();

            foreach(var item in entity.Detalles)
            {
                producto = dbP.Buscar(item.IdProducto);
                producto.Cantidad -= item.Cantidad;
                dbP.Modificar(producto);

            }
           

            try
            {
                db.Factura.Add(entity);
                paso = db.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }


            return paso;
        }

        public override Factura Buscar(int id)
        {
            db = new Contexto();

            Factura factura = new Factura();

            try
            {
                
                factura = db.Factura.Find(id);
                
                
                factura.Detalles.Count();


            }catch(Exception)
            {
                

            }

            return factura;
        }


        public override bool Elimimar(int id)
        {
            bool paso = false;
            db = new Contexto();
            RepositorioBase<Producto> dbP = new RepositorioBase<Producto>();

            try
            {
                Factura factura = Buscar(id);
                Producto producto = new Producto();

                foreach(var item in factura.Detalles)
                {
                    producto = dbP.Buscar(item.IdProducto);
                    producto.Cantidad += item.Cantidad;
                    dbP.Modificar(producto);
                }

                db.Entry(factura).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;



            }catch(Exception)
            {
                throw;

            }

            return paso;
        }
    }
}
