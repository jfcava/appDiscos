using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace conexionDB
{
    public partial class Form1 : Form
    {
        private List<Disco> listaDiscos;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Disco seleccionado = new Disco();
            seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagenTapa);
        }

        private void cargar()
        {
            DiscoNegocio negocio = new DiscoNegocio();

            listaDiscos = negocio.listar();
            dgvDiscos.DataSource = listaDiscos;
            dgvDiscos.Columns["UrlImagenTapa"].Visible = false;

            cargarImagen(listaDiscos[0].UrlImagenTapa);
        }

        public void cargarImagen(string url)
        {
            try
            {
                pbPortada.Load(url);
            }
            catch (Exception)
            {
                pbPortada.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoDisco nuevoDisco = new frmNuevoDisco();
            nuevoDisco.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Disco seleccionado =(Disco)dgvDiscos.CurrentRow.DataBoundItem;

            frmNuevoDisco modificado = new frmNuevoDisco(seleccionado);
            modificado.ShowDialog();
            cargar();
        }
    }
}
