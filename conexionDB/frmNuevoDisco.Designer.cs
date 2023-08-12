namespace conexionDB
{
    partial class frmNuevoDisco
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFechaLanzamiento = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtCantidadCanciones = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dtpFechaLanzamiento = new System.Windows.Forms.DateTimePicker();
            this.cbEstilo = new System.Windows.Forms.ComboBox();
            this.lblEstilo = new System.Windows.Forms.Label();
            this.lblTipoEdicion = new System.Windows.Forms.Label();
            this.cboTipoEdicion = new System.Windows.Forms.ComboBox();
            this.pbNuevoDisco = new System.Windows.Forms.PictureBox();
            this.txtUrlImagen = new System.Windows.Forms.TextBox();
            this.lblUrlImagen = new System.Windows.Forms.Label();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbNuevoDisco)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(87, 43);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(36, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Titulo:";
            // 
            // lblFechaLanzamiento
            // 
            this.lblFechaLanzamiento.AutoSize = true;
            this.lblFechaLanzamiento.Location = new System.Drawing.Point(20, 73);
            this.lblFechaLanzamiento.Name = "lblFechaLanzamiento";
            this.lblFechaLanzamiento.Size = new System.Drawing.Size(103, 13);
            this.lblFechaLanzamiento.TabIndex = 1;
            this.lblFechaLanzamiento.Text = "Fecha Lanzamiento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cantidad Canciones:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(129, 40);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(200, 20);
            this.txtTitulo.TabIndex = 0;
            // 
            // txtCantidadCanciones
            // 
            this.txtCantidadCanciones.Location = new System.Drawing.Point(129, 104);
            this.txtCantidadCanciones.Name = "txtCantidadCanciones";
            this.txtCantidadCanciones.Size = new System.Drawing.Size(200, 20);
            this.txtCantidadCanciones.TabIndex = 2;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(169, 251);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Aceptar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(254, 251);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtpFechaLanzamiento
            // 
            this.dtpFechaLanzamiento.Location = new System.Drawing.Point(129, 73);
            this.dtpFechaLanzamiento.Name = "dtpFechaLanzamiento";
            this.dtpFechaLanzamiento.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaLanzamiento.TabIndex = 1;
            // 
            // cbEstilo
            // 
            this.cbEstilo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstilo.FormattingEnabled = true;
            this.cbEstilo.Location = new System.Drawing.Point(129, 171);
            this.cbEstilo.Name = "cbEstilo";
            this.cbEstilo.Size = new System.Drawing.Size(200, 21);
            this.cbEstilo.TabIndex = 4;
            // 
            // lblEstilo
            // 
            this.lblEstilo.AutoSize = true;
            this.lblEstilo.Location = new System.Drawing.Point(88, 174);
            this.lblEstilo.Name = "lblEstilo";
            this.lblEstilo.Size = new System.Drawing.Size(35, 13);
            this.lblEstilo.TabIndex = 10;
            this.lblEstilo.Text = "Estilo:";
            // 
            // lblTipoEdicion
            // 
            this.lblTipoEdicion.AutoSize = true;
            this.lblTipoEdicion.Location = new System.Drawing.Point(39, 212);
            this.lblTipoEdicion.Name = "lblTipoEdicion";
            this.lblTipoEdicion.Size = new System.Drawing.Size(84, 13);
            this.lblTipoEdicion.TabIndex = 11;
            this.lblTipoEdicion.Text = "Tipo de Edicion:";
            // 
            // cboTipoEdicion
            // 
            this.cboTipoEdicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEdicion.FormattingEnabled = true;
            this.cboTipoEdicion.Location = new System.Drawing.Point(129, 209);
            this.cboTipoEdicion.Name = "cboTipoEdicion";
            this.cboTipoEdicion.Size = new System.Drawing.Size(200, 21);
            this.cboTipoEdicion.TabIndex = 5;
            // 
            // pbNuevoDisco
            // 
            this.pbNuevoDisco.Location = new System.Drawing.Point(378, 40);
            this.pbNuevoDisco.Name = "pbNuevoDisco";
            this.pbNuevoDisco.Size = new System.Drawing.Size(249, 231);
            this.pbNuevoDisco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNuevoDisco.TabIndex = 13;
            this.pbNuevoDisco.TabStop = false;
            // 
            // txtUrlImagen
            // 
            this.txtUrlImagen.Location = new System.Drawing.Point(129, 138);
            this.txtUrlImagen.Name = "txtUrlImagen";
            this.txtUrlImagen.Size = new System.Drawing.Size(200, 20);
            this.txtUrlImagen.TabIndex = 3;
            this.txtUrlImagen.Leave += new System.EventHandler(this.txtUrlImagen_Leave);
            // 
            // lblUrlImagen
            // 
            this.lblUrlImagen.AutoSize = true;
            this.lblUrlImagen.Location = new System.Drawing.Point(62, 141);
            this.lblUrlImagen.Name = "lblUrlImagen";
            this.lblUrlImagen.Size = new System.Drawing.Size(61, 13);
            this.lblUrlImagen.TabIndex = 15;
            this.lblUrlImagen.Text = "Url Imagen:";
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarImagen.Location = new System.Drawing.Point(335, 138);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(37, 21);
            this.btnAgregarImagen.TabIndex = 16;
            this.btnAgregarImagen.Text = "+";
            this.btnAgregarImagen.UseVisualStyleBackColor = true;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // frmNuevoDisco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 294);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.lblUrlImagen);
            this.Controls.Add(this.txtUrlImagen);
            this.Controls.Add(this.pbNuevoDisco);
            this.Controls.Add(this.cboTipoEdicion);
            this.Controls.Add(this.lblTipoEdicion);
            this.Controls.Add(this.lblEstilo);
            this.Controls.Add(this.cbEstilo);
            this.Controls.Add(this.dtpFechaLanzamiento);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtCantidadCanciones);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFechaLanzamiento);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmNuevoDisco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Disco";
            this.Load += new System.EventHandler(this.frmNuevoDisco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbNuevoDisco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFechaLanzamiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtCantidadCanciones;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DateTimePicker dtpFechaLanzamiento;
        private System.Windows.Forms.ComboBox cbEstilo;
        private System.Windows.Forms.Label lblEstilo;
        private System.Windows.Forms.Label lblTipoEdicion;
        private System.Windows.Forms.ComboBox cboTipoEdicion;
        private System.Windows.Forms.PictureBox pbNuevoDisco;
        private System.Windows.Forms.TextBox txtUrlImagen;
        private System.Windows.Forms.Label lblUrlImagen;
        private System.Windows.Forms.Button btnAgregarImagen;
    }
}