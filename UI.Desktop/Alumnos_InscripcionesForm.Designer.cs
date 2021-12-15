
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
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alumno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsAlumnos_Inscripciones = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
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
            this.tcAlumnos_Inscripciones.ContentPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tcAlumnos_Inscripciones.ContentPanel.Size = new System.Drawing.Size(533, 261);
            this.tcAlumnos_Inscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcAlumnos_Inscripciones.Location = new System.Drawing.Point(0, 0);
            this.tcAlumnos_Inscripciones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tcAlumnos_Inscripciones.Name = "tcAlumnos_Inscripciones";
            this.tcAlumnos_Inscripciones.Size = new System.Drawing.Size(533, 292);
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
            this.tlAlumnos_Inscipciones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlAlumnos_Inscipciones.Name = "tlAlumnos_Inscipciones";
            this.tlAlumnos_Inscipciones.RowCount = 2;
            this.tlAlumnos_Inscipciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlAlumnos_Inscipciones.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlAlumnos_Inscipciones.Size = new System.Drawing.Size(533, 261);
            this.tlAlumnos_Inscipciones.TabIndex = 0;
            // 
            // dgvAlumnos_Inscipciones
            // 
            this.dgvAlumnos_Inscipciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnos_Inscipciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Alumno,
            this.Curso,
            this.Condicion,
            this.Nota});
            this.tlAlumnos_Inscipciones.SetColumnSpan(this.dgvAlumnos_Inscipciones, 2);
            this.dgvAlumnos_Inscipciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnos_Inscipciones.Location = new System.Drawing.Point(2, 2);
            this.dgvAlumnos_Inscipciones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvAlumnos_Inscipciones.Name = "dgvAlumnos_Inscipciones";
            this.dgvAlumnos_Inscipciones.RowHeadersWidth = 62;
            this.dgvAlumnos_Inscipciones.RowTemplate.Height = 28;
            this.dgvAlumnos_Inscipciones.Size = new System.Drawing.Size(529, 231);
            this.dgvAlumnos_Inscipciones.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 150;
            // 
            // Alumno
            // 
            this.Alumno.DataPropertyName = "IDAlumno";
            this.Alumno.HeaderText = "Alumno";
            this.Alumno.MinimumWidth = 8;
            this.Alumno.Name = "Alumno";
            this.Alumno.Width = 150;
            // 
            // Curso
            // 
            this.Curso.DataPropertyName = "IDCurso";
            this.Curso.HeaderText = "Curso";
            this.Curso.MinimumWidth = 8;
            this.Curso.Name = "Curso";
            this.Curso.Width = 150;
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
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(415, 237);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(62, 22);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(481, 237);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(50, 22);
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
            this.tsAlumnos_Inscripciones.Size = new System.Drawing.Size(127, 31);
            this.tsAlumnos_Inscripciones.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(28, 28);
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
            this.tsbEditar.Size = new System.Drawing.Size(28, 28);
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
            this.tsbEliminar.Size = new System.Drawing.Size(28, 28);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // Alumnos_InscripcionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.tcAlumnos_Inscripciones);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alumno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Curso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nota;
    }
}