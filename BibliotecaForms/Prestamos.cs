using BibliotecaForms.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaForms
{
    public partial class Prestamos : Form
    {
        public Prestamos()
        {
            InitializeComponent();
        }

        private void Prestamos_Load(object sender, EventArgs e)
        {
            RepositorioLibros repLibros = new RepositorioLibros();
            cmb_libro.DataSource = repLibros.ObtenerDatos();

            cmb_libro.DisplayMember = "Titulo";
            cmb_libro.ValueMember = "ID";


            RepositorioClientes repClientes = new RepositorioClientes();
            cmb_cliente.DataSource = repClientes.ObtenerDatos();

            cmb_cliente.DisplayMember = "Nombre";
            cmb_cliente.ValueMember = "ID";


            RepositorioPrestamos repPrestamos = new RepositorioPrestamos();
            gv_prestamos.DataSource = repPrestamos.ObtenerDatos();
        }

        private void bt_aceptar_Click(object sender, EventArgs e)
        {
            Prestamo prestamo = new Prestamo
            {
                IDCliente=Convert.ToInt32(cmb_cliente.SelectedValue),
                IDLibro= Convert.ToInt32(cmb_libro.SelectedValue),
                FechaPrestamo =DateTime.Now,
                FechaDev=Convert.ToDateTime("1900-01-01 00:00")
            };

            RepositorioPrestamos repPrestamos = new RepositorioPrestamos();
            repPrestamos.RegistrarPrestamo(prestamo);
            gv_prestamos.DataSource = repPrestamos.ObtenerDatos();
        }

        private void gv_prestamos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //al hacer clic en la celda o fila preguntar si desea realizar la davolucion
            // se mostrara un mensaaje que haga la pregunta y de opcion de o no
            //si da en si se actualizara la fehca de devolucion del prestamo,
            //si da no solo se cieerra el mensaje y todo sigue igual

            int rowindex = e.RowIndex;
            int id = Convert.ToInt32(gv_prestamos.Rows[rowindex].Cells["ID"].Value.ToString());
            string libro = gv_prestamos.Rows[rowindex].Cells["libro"].Value.ToString();
            string cliente = gv_prestamos.Rows[rowindex].Cells["cliente"].Value.ToString();
            MessageBox.Show($"Desea realizar la devolucion dle libro{libro} del cliente {cliente}");

            RepositorioPrestamos repPrestamos = new RepositorioPrestamos();
            repPrestamos.RealizarDevolucion(id);


            //cuando el libro no se ha devuelto mostrar en blanco o guiones la fecha dev
            //agregar un checkbox en la ventana de prestamos para mostrar u ocultar las devoluciones
            //agregar buscador en los prestamos
        }
    }
}
