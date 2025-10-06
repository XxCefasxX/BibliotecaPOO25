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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void bt_libros_Click(object sender, EventArgs e)
        {
            Libros libs= new Libros();
            libs.Show();
        }

        private void bt_autores_Click(object sender, EventArgs e)
        {
            Autores auts= new Autores();
            auts.Show();
        }

        private void bt_categorias_Click(object sender, EventArgs e)
        {
            Categorias categorias= new Categorias();
            categorias.Show();
        }

        private void bt_editorlaes_Click(object sender, EventArgs e)
        {
            Editoriales eds = new Editoriales();
            eds.Show();
        }

        private void t_prestamos_Click(object sender, EventArgs e)
        {
            Prestamos prs = new Prestamos();
            prs.Show();
        }
    }
}
