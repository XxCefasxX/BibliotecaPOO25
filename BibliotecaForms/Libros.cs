using System;
using System.Windows.Forms;

namespace BibliotecaForms
{
    public partial class Libros : Form
    {
        public Libros()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string titulo = tb_titulo.Text;
            string fecha = tb_fecha.Text;
            int paginas = Convert.ToInt32(tb_paginas.Text);
            int autor = Convert.ToInt32(tb_autor.Text);
            int categoria = Convert.ToInt32(tb_categoria.Text);
            int editorial = Convert.ToInt32(tb_editorial.Text);

            RepositorioLibros repLibros = new RepositorioLibros();
            repLibros.RegistrarLibro(titulo, fecha, paginas, autor, categoria, editorial);
            tb_titulo.Text = "";
            tb_paginas.Text = "";
            tb_autor.Text = "";
            tb_categoria.Text = "";
            tb_editorial.Text = "";
            tb_fecha.Text = "";

            gv_libros.DataSource = repLibros.ObtenerDatos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RepositorioLibros repLibros = new RepositorioLibros();
            gv_libros.DataSource = repLibros.ObtenerDatos();

            RepositorioCategorias repCat = new RepositorioCategorias();
            cmb_categorias.DataSource = repCat.ObtenerDatos();
            cmb_categorias.DisplayMember = "Nombre";
            cmb_categorias.ValueMember = "ID";
        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {
            string titulo = tb_buscar.Text;
            int idcat =Convert.ToInt32( cmb_categorias.SelectedValue);

            RepositorioLibros repLibros =
                new RepositorioLibros();
            gv_libros.DataSource =
                repLibros.BuscarTitulo(titulo,idcat);
        }
    }   
}
