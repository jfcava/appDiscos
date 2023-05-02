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
        private Disco nuevo = null;
        public frmNuevoDisco()
        {
            InitializeComponent();
        }

        public frmNuevoDisco(Disco nuevo)
        {
            InitializeComponent();
            this.nuevo = nuevo;
            Text = "Modificar Disco";
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Disco nuevoDisco = new Disco();
            DiscoNegocio negocio = new DiscoNegocio();            

            try
            {
                nuevoDisco.Titulo = txtTitulo.Text;
                nuevoDisco.FechaLanzamiento = dtpFechaLanzamiento.Value;
                nuevoDisco.CantidadCanciones = int.Parse(txtCantidadCanciones.Text);
                nuevoDisco.UrlImagenTapa = txtUrlImagen.Text;
                nuevoDisco.Estilo = (Estilo)cbEstilo.SelectedItem;
                nuevoDisco.TipoEdicion = (TipoEdicion)cboTipoEdicion.SelectedItem;

                negocio.agregar(nuevoDisco);
                MessageBox.Show("Agregado exitosamente.");
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

            if(nuevo != null)
            {
                txtTitulo.Text = nuevo.Titulo;
                txtCantidadCanciones.Text = nuevo.CantidadCanciones.ToString();
                txtUrlImagen.Text = nuevo.UrlImagenTapa;
                cargarImagen(nuevo.UrlImagenTapa);
                cbEstilo.SelectedValue = nuevo.Estilo.Id;
                cboTipoEdicion.SelectedValue = nuevo.TipoEdicion.Id;
                  
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
