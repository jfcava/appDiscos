﻿using dominio;
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
using System.IO;
using System.Configuration;

namespace conexionDB
{
    public partial class frmNuevoDisco : Form
    {
        private Disco disco = null;
        private OpenFileDialog archivo = null;
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

                if (archivo != null && !(txtUrlImagen.Text.ToUpper().Contains("HTTP")));
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["carpeta-imagen"] + archivo.SafeFileName);


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

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png";
            if(archivo.ShowDialog() == DialogResult.OK)
            {
                txtUrlImagen.Text = archivo.FileName;
                cargarImagen(archivo.FileName);

                //Guardo la imagen que cargo, y la guardo en otra carpeta.
                //Para utilizar la clase File se debe usar el using System.IO

                //File.Copy(archivo.FileName, ConfigurationManager.AppSettings["carpeta-imagen"] + archivo.SafeFileName);
                //ESTO ME LO LLEVO PARA CUANDO HACE CLICK EN Agregar!!

                //Para utilizar las configuracion creadas en App.config, ConfigurationManager.AppSettings["carpeta-imagen"],
                //debo agregar la referencia System.Configuration dentro de Assemblies
            }
        }
    }
}
