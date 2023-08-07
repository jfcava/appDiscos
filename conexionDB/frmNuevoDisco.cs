using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;

namespace conexionDB
{
    public partial class frmNuevoDisco : Form
    {
        private Disco disco = null;
        public frmNuevoDisco()
        {
            InitializeComponent();
        }

        public frmNuevoDisco(Disco nuevo)
        {
            InitializeComponent();
            disco = nuevo;
            Text = "Modificar Disco";
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            DiscoNegocio negocio = new DiscoNegocio();

            try
            {
                if (disco == null)
                    disco = new Disco();

                disco.Titulo = txtTitulo.Text;
                disco.FechaLanzamiento = dtpFechaLanzamiento.Value;
                disco.CantidadCanciones = int.Parse(txtCantidadCanciones.Text);
                disco.UrlImagenTapa = txtUrlImagen.Text;
                disco.Estilo = (Estilo)cbEstilo.SelectedItem;
                disco.TipoEdicion = (TipoEdicion)cboTipoEdicion.SelectedItem;

                if (disco.Id != 0)
                {
                    negocio.modificar(disco);
                    MessageBox.Show("Modificado exitosamente.");
                }
                else
                {
                    negocio.agregar(disco);
                    MessageBox.Show("Agregado exitosamente.");
                }

                Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmNuevoDisco_Load(object sender, EventArgs e)
        {
            EstiloNegocio negocio = new EstiloNegocio();
            EdicionNegocio edicion = new EdicionNegocio();

            cbEstilo.DataSource = negocio.listar();

            //PRECARGAR COMBOBOX CON DATOS DE UN OBJETO PARA MODIFICAR
            //Con valueMember y DisplayMember puedo darle un dato 'escondido' y se utiliza como (CLAVE), valuemember
            //Y un dato que quiero que se muestre, que en este caso es la descripcion. (VALOR)
            cbEstilo.ValueMember = "Id";
            cbEstilo.DisplayMember = "Descripcion";
            cboTipoEdicion.DataSource = edicion.listar();
            cboTipoEdicion.ValueMember = "Id";
            cboTipoEdicion.DisplayMember = "Descripcion";

            if (disco != null)
            {
                txtTitulo.Text = disco.Titulo;
                txtCantidadCanciones.Text = disco.CantidadCanciones.ToString();
                txtUrlImagen.Text = disco.UrlImagenTapa;
                cargarImagen(disco.UrlImagenTapa);
                cbEstilo.SelectedValue = disco.Estilo.Id;
                cboTipoEdicion.SelectedValue = disco.TipoEdicion.Id;

            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }

        private void cargarImagen(string url)
        {
            try
            {
                pbNuevoDisco.Load(url);
            }
            catch (Exception)
            {
                pbNuevoDisco.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }
        }
    }
}
