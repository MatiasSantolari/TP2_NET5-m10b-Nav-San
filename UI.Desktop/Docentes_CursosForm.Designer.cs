
namespace UI.Desktop
{
    partial class Docentes_CursosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Docentes_CursosForm));
            this.tscDocentes_Cursos = new System.Windows.Forms.ToolStripContainer();
            this.tlDocentes_Cursos = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDocentes_Cursos = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Docente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsDocentes_Cursos = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tscDocentes_Cursos.ContentPanel.SuspendLayout();
            this.tscDocentes_Cursos.TopToolStripPanel.SuspendLayout();
            this.tscDocentes_Cursos.SuspendLayout();
            this.tlDocentes_Cursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocentes_Cursos)).BeginInit();
            this.tsDocentes_Cursos.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscDocentes_Cursos
            // 
            // 
            // tscDocentes_Cursos.ContentPanel
            // 
            this.tscDocentes_Cursos.ContentPanel.Controls.Add(this.tlDocentes_Cursos);
            this.tscDocentes_Cursos.ContentPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tscDocentes_Cursos.ContentPanel.Size = new System.Drawing.Size(533, 261);
            this.tscDocentes_Cursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscDocentes_Cursos.Location = new System.Drawing.Point(0, 0);
            this.tscDocentes_Cursos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tscDocentes_Cursos.Name = "tscDocentes_Cursos";
            this.tscDocentes_Cursos.Size = new System.Drawing.Size(533, 292);
            this.tscDocentes_Cursos.TabIndex = 0;
            this.tscDocentes_Cursos.Text = "toolStripContainer1";
            // 
            // tscDocentes_Cursos.TopToolStripPanel
            // 
            this.tscDocentes_Cursos.TopToolStripPanel.Controls.Add(this.tsDocentes_Cursos);
            // 
            // tlDocentes_Cursos
            // 
            this.tlDocentes_Cursos.ColumnCount = 2;
            this.tlDocentes_Cursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDocentes_Cursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlDocentes_Cursos.Controls.Add(this.dgvDocentes_Cursos, 0, 0);
            this.tlDocentes_Cursos.Controls.Add(this.btnActualizar, 0, 1);
            this.tlDocentes_Cursos.Controls.Add(this.btnSalir, 1, 1);
            this.tlDocentes_Cursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDocentes_Cursos.Location = new System.Drawing.Point(0, 0);
            this.tlDocentes_Cursos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlDocentes_Cursos.Name = "tlDocentes_Cursos";
            this.tlDocentes_Cursos.RowCount = 2;
            this.tlDocentes_Cursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDocentes_Cursos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlDocentes_Cursos.Size = new System.Drawing.Size(533, 261);
            this.tlDocentes_Cursos.TabIndex = 0;
            // 
            // dgvDocentes_Cursos
            // 
            this.dgvDocentes_Cursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocentes_Cursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Curso,
            this.Docente,
            this.Cargo});
            this.tlDocentes_Cursos.SetColumnSpan(this.dgvDocentes_Cursos, 2);
            this.dgvDocentes_Cursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocentes_Cursos.Location = new System.Drawing.Point(2, 2);
            this.dgvDocentes_Cursos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDocentes_Cursos.Name = "dgvDocentes_Cursos";
            this.dgvDocentes_Cursos.RowHeadersWidth = 62;
            this.dgvDocentes_Cursos.RowTemplate.Height = 28;
            this.dgvDocentes_Cursos.Size = new System.Drawing.Size(529, 232);
            this.dgvDocentes_Cursos.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.Width = 150;
            // 
            // Curso
            // 
            this.Curso.DataPropertyName = "IDCurso";
            this.Curso.HeaderText = "Curso";
            this.Curso.MinimumWidth = 8;
            this.Curso.Name = "Curso";
            this.Curso.Width = 150;
            // 
            // Docente
            // 
            this.Docente.DataPropertyName = "IDDocente";
            this.Docente.HeaderText = "Docente";
            this.Docente.MinimumWidth = 8;
            this.Docente.Name = "Docente";
            this.Docente.Width = 150;
            // 
            // Cargo
            // 
            this.Cargo.DataPropertyName = "Cargo";
            this.Cargo.HeaderText = "Cargo";
            this.Cargo.MinimumWidth = 8;
            this.Cargo.Name = "Cargo";
            this.Cargo.Width = 150;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(401, 238);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(61, 21);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(466, 238);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(65, 21);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsDocentes_Cursos
            // 
            this.tsDocentes_Cursos.Dock = System.Windows.Forms.DockStyle.None;
            this.tsDocentes_Cursos.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsDocentes_Cursos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsDocentes_Cursos.Location = new System.Drawing.Point(4, 0);
            this.tsDocentes_Cursos.Name = "tsDocentes_Cursos";
            this.tsDocentes_Cursos.Size = new System.Drawing.Size(127, 31);
            this.tsDocentes_Cursos.TabIndex = 0;
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
            this.tsbEditar.Text = "toolStripButton1";
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
            this.tsbEliminar.Text = "toolStripButton1";
            this.tsbEliminar.ToolTipText = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // Docentes_CursosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.tscDocentes_Cursos);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Docentes_CursosForm";
            this.Text = "Docentes_CursosForm";
            this.Load += new System.EventHandler(this.Docentes_CursosForm_Load);
            this.tscDocentes_Cursos.ContentPanel.ResumeLayout(false);
            this.tscDocentes_Cursos.TopToolStripPanel.ResumeLayout(false);
            this.tscDocentes_Cursos.TopToolStripPanel.PerformLayout();
            this.tscDocentes_Cursos.ResumeLayout(false);
            this.tscDocentes_Cursos.PerformLayout();
            this.tlDocentes_Cursos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocentes_Cursos)).EndInit();
            this.tsDocentes_Cursos.ResumeLayout(false);
            this.tsDocentes_Cursos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscDocentes_Cursos;
        private System.Windows.Forms.TableLayoutPanel tlDocentes_Cursos;
        private System.Windows.Forms.DataGridView dgvDocentes_Cursos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tsDocentes_Cursos;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Curso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Docente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cargo;
    }
}