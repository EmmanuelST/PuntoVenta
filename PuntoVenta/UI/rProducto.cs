using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVenta.UI
{
    public partial class rProducto : Form
    {
        public rProducto()
        {
            InitializeComponent();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        public Producto LlenarClase()
        {
            Producto producto = new Producto()
            {
                IdProducto = (int)IdnumericUpDown.Value,
                Descripcion = NombretextBox.Text,
                Precio = (float)PrecionumericUpDown.Value,
                Cantidad = (float)CantidadnumericUpDown.Value,
                Fabricante = FabricantetextBox.Text
            };

            return producto;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Producto producto = LlenarClase();
            RepositorioBase<Producto> db = new RepositorioBase<Producto>();

            try
            {
                if(db.Guardar(producto))
                {
                    Limpiar();
                    MessageBox.Show("Guardado correctamente");
                }else
                {
                    Limpiar();
                    MessageBox.Show("No se pudo guardar");
                }

                
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show("Hubo un error");
            }


            
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            PrecionumericUpDown.Value = 0;
            CantidadnumericUpDown.Value = 0;
            FabricantetextBox.Text = string.Empty;
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Producto> db = new RepositorioBase<Producto>();
            Producto producto = new Producto();

            if(IdnumericUpDown.Value == 0)
            {
                MessageBox.Show("Debe colocar un Id");
                return;
            }

            try
            {
                producto = LlenarClase();

                if(db.Elimimar(producto.IdProducto))
                {
                    MessageBox.Show("Eliminado");
                }else
                {
                    MessageBox.Show("NO se pudo eliminar");
                }


            }catch(Exception)
            {
                MessageBox.Show("Hubo un error");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RepositorioBase<Producto> db = new RepositorioBase<Producto>();
            Producto producto = new Producto();

            if(IdnumericUpDown.Value == 0)
            {
                MessageBox.Show("Debe colocar un Id");
            }

            try
            {
                producto = db.Buscar((int)IdnumericUpDown.Value);
                LlenarFormulario(producto);
            }
            catch (Exception)
            {
                MessageBox.Show("NO se pudo encontrar");
            }

        }
        private void LlenarFormulario(Producto producto)
        {
            try
            {
                IdnumericUpDown.Value = producto.IdProducto;
                NombretextBox.Text = producto.Descripcion;
                PrecionumericUpDown.Value = (decimal)producto.Precio;
                CantidadnumericUpDown.Value = (decimal)producto.Cantidad;
                FabricantetextBox.Text = producto.Fabricante;
            }
            catch(Exception)
            {

            }
            
        }
    }
}
