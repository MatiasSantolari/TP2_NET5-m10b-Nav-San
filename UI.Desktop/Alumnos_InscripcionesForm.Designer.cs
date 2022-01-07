
namespace UI.Desktop
{
    partial class Alumnos_InscripcionesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alumnos_InscripcionesForm));
            this.tcAlumnos_Inscripciones = new System.Windows.Forms.ToolStripContainer();
            this.tlAlumnos_Inscipciones = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAlumnos_Inscipciones = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsAlumnos_Inscripciones = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.NombreAlumno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoAlumno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcAlumnos_Inscripciones.ContentPanel.SuspendLayout();
            this.tcAlumnos_Inscripciones.TopToolStripPanel.SuspendLayout();
            this.tcAlumnos_Inscripciones.SuspendLayout();
            this.tlAlumnos_Inscipciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos_Inscipciones)).BeginInit();
            this.tsAlumnos_Inscripciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcAlumnos_Inscripciones
            // 
            // 
            // tcAlumnos_Inscripciones.ContentPanel
            // 
            this.tcAlumnos_Inscripciones.ContentPanel.Controls.Add(this.tlAlumnos_Inscipciones);
            this.tcAlumnos_Inscripciones.ContentPanel.Size = new System.Drawing.Size(800, 416);
            this.tcAlumnos_Inscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcAlumnos_Inscripciones.Location = new System.Drawing.Point(0, 0);
            this.tcAlumnos_Inscripciones.Name = "tcAlumnos_Inscripciones";
            this.tcAlumnos_Inscripciones.Size = new System.Drawing.Size(800, 449);
            this.tcAlumnos_Inscripciones.TabIndex = 0;
            this.tcAlumnos_Inscripciones.Text = "toolStripContainer1";
            // 
            // tcAlumnos_Inscripciones.TopToolStripPanel
            // 
            this.tcAlumnos_Inscripciones.TopToolStripPanel.Controls.Add(this.tsAlumnos_Inscripciones);
            // 
            // tlAlumnos_Inscipciones
            // 
            this.tlAlumnos_Inscipciones.ColumnCount = 2;
            this.tlAlumnos_Inscipciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAlumnos_Inscipciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlAlumnos_Inscipciones.Controls.Add(this.dgvAlumnos_Inscipciones, 0, 0);
            this.tlAlumnos_Inscipciones.Controls.Add(this.btnActualizar, 0, 1);
            this.tlAlumnos_Inscipciones.Controls.Add(this.btnSalir, 1, 1);
            this.tlAlumnos_Inscipciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlAlumnos_Inscipciones.Location = new System.Drawing.Point(0, 0);
            this.tlAlumnos_Inscipciones.Name = "tlAlumnos_Inscipciones";
            this.tlAlumnos_Inscipciones.RowCount = 2;
            this.tlAlumnos_Inscipciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAlumnos_Inscipciones.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlAlumnos_Inscipciones.Size = new System.Drawing.Size(800, 416);
            this.tlAlumnos_Inscipciones.TabIndex = 0;
            // 
            // dgvAlumnos_Inscipciones
            // 
            this.dgvAlumnos_Inscipciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnos_Inscipciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreAlumno,
            this.ApellidoAlumno,
            this.Materia,
            this.Comision,
            this.Condicion,
            this.Nota});
            this.tlAlumnos_Inscipciones.SetColumnSpan(this.dgvAlumnos_Inscipciones, 2);
            this.dgvAlumnos_Inscipciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnos_Inscipciones.Location = new System.Drawing.Point(3, 3);
            this.dgvAlumnos_Inscipciones.Name = "dgvAlumnos_Inscipciones";
            this.dgvAlumnos_Inscipciones.RowHeadersWidth = 62;
            this.dgvAlumnos_Inscipciones.RowTemplate.Height = 28;
            this.dgvAlumnos_Inscipciones.Size = new System.Drawing.Size(794, 370);
            this.dgvAlumnos_Inscipciones.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(623, 379);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 34);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(722, 379);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 34);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsAlumnos_Inscripciones
            // 
            this.tsAlumnos_Inscripciones.Dock = System.Windows.Forms.DockStyle.None;
            this.tsAlumnos_Inscripciones.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsAlumnos_Inscripciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsAlumnos_Inscripciones.Location = new System.Drawing.Point(4, 0);
            this.tsAlumnos_Inscripciones.Name = "tsAlumnos_Inscripciones";
            this.tsAlumnos_Inscripciones.Size = new System.Drawing.Size(120, 33);
            this.tsAlumnos_Inscripciones.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(34, 28);
            this.tsbNuevo.Text = "toolStripButton1";
            this.tsbNuevo.ToolTipText = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(34, 28);
            this.tsbEditar.Text = "toolStripButton2";
            this.tsbEditar.ToolTipText = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(34, 28);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // NombreAlumno
            // 
            this.NombreAlumno.DataPropertyName = "Nombre Alumno";
            this.NombreAlumno.HeaderText = "Nombre ";
            this.NombreAlumno.MinimumWidth = 8;
            this.NombreAlumno.Name = "NombreAlumno";
            this.NombreAlumno.Width = 150;
            // 
            // ApellidoAlumno
            // 
            this.ApellidoAlumno.DataPropertyName = "Apellido Alumno";
            this.ApellidoAlumno.HeaderText = "Apellido";
            this.ApellidoAlumno.MinimumWidth = 8;
            this.ApellidoAlumno.Name = "ApellidoAlumno";
            this.ApellidoAlumno.Width = 150;
            // 
            // Materia
            // 
            this.Materia.DataPropertyName = "Materia";
            this.Materia.HeaderText = "Materia";
            this.Materia.MinimumWidth = 8;
            this.Materia.Name = "Materia";
            this.Materia.Width = 150;
            // 
            // Comision
            // 
            this.Comision.DataPropertyName = "Comision";
            this.Comision.HeaderText = "Comision";
            this.Comision.MinimumWidth = 8;
            this.Comision.Name = "Comision";
            this.Comision.Width = 150;
            // 
            // Condicion
            // 
            this.Condicion.DataPropertyName = "Condicion";
            this.Condicion.HeaderText = "Condicion";
            this.Condicion.MinimumWidth = 8;
            this.Condicion.Name = "Condicion";
            this.Condicion.Width = 150;
            // 
            // Nota
            // 
            this.Nota.DataPropertyName = "Nota";
            this.Nota.HeaderText = "Nota";
            this.Nota.MinimumWidth = 8;
            this.Nota.Name = "Nota";
            this.Nota.Width = 150;
            // 
            // Alumnos_InscripcionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.tcAlumnos_Inscripciones);
            this.Name = "Alumnos_InscripcionesForm";
            this.Text = "Inscripciones de Alumnos";
            this.Load += new System.EventHandler(this.ListaAlumnos_Inscripciones_Load);
            this.tcAlumnos_Inscripciones.ContentPanel.ResumeLayout(false);
            this.tcAlumnos_Inscripciones.TopToolStripPanel.ResumeLayout(false);
            this.tcAlumnos_Inscripciones.TopToolStripPanel.PerformLayout();
            this.tcAlumnos_Inscripciones.ResumeLayout(false);
            this.tcAlumnos_Inscripciones.PerformLayout();
            this.tlAlumnos_Inscipciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos_Inscipciones)).EndInit();
            this.tsAlumnos_Inscripciones.ResumeLayout(false);
            this.tsAlumnos_Inscripciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcAlumnos_Inscripciones;
        private System.Windows.Forms.TableLayoutPanel tlAlumnos_Inscipciones;
        private System.Windows.Forms.DataGridView dgvAlumnos_Inscipciones;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tsAlumnos_Inscripciones;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreAlumno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoAlumno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nota;
    }
}