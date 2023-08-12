using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
            cboCampo.Items.Add("Titulo");
            cboCampo.Items.Add("Estilo");
            cboCampo.Items.Add("Nro Canciones");
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDiscos.CurrentRow != null)
            {
                Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlImagenTapa);
            }
        }

        private void cargar()
        {
            DiscoNegocio negocio = new DiscoNegocio();

            listaDiscos = negocio.listar();
            dgvDiscos.DataSource = listaDiscos;
            ocultarColumnas();


            cargarImagen(listaDiscos[0].UrlImagenTapa);
        }
        private void ocultarColumnas()
        {
            dgvDiscos.Columns["UrlImagenTapa"].Visible = false;
            dgvDiscos.Columns["Id"].Visible = false;
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
            Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;

            frmNuevoDisco modificado = new frmNuevoDisco(seleccionado);
            modificado.ShowDialog();
            cargar();
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Estás seguro de eliminarlo?", "Eliminando...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                DiscoNegocio negocio = new DiscoNegocio();
                Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;

                negocio.eliminar(seleccionado.Id);
                cargar();
            }
        }
        private bool validarFiltro()
        {
            //Valido si el comboBox de Campo, tiene algo seleccionado
            //Sin seleccion, los ComboBox tienen indice -1.

            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccioná un campo para buscar.");
                return true;
            }

            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccioná un criterio para buscar.");
                return true;
            }

            if (cboCampo.SelectedItem.ToString() == "Nro Canciones")
            {
                if (!(soloNumeros(txtFiltroAvanzado.Text)))
                {
                    MessageBox.Show("Por favor, ingresa solo números para filtrar.");
                    return true;
                }
            }
            return false;
        }

        private bool soloNumeros(string filtro)
        {
            foreach (char caracter in filtro)
            {
                if (char.IsNumber(caracter))
                    return true;
            }
            return false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();

            try
            {
                //Si se valida que no hay nada seleccionado, se dispara el MessageBox del metodo,
                //y con el return se corta la ejecucion.
                if (validarFiltro())
                    return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                dgvDiscos.DataSource = negocio.filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Disco> filtrada;
            string filtro = txtFiltro.Text;
            if (filtro.Length >= 3)
            {
                filtrada = listaDiscos.FindAll(x => x.Titulo.ToUpper().Contains(filtro.ToUpper()) || x.Estilo.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                dgvDiscos.DataSource = null;
                dgvDiscos.DataSource = filtrada;
                ocultarColumnas();
            }
            else if (filtro.Length == 0)
            {
                cargar();
            }
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();

            if (opcion == "Nro Canciones")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");

            }
        }
    }
}
