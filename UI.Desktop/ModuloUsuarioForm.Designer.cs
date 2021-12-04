
namespace UI.Desktop
{
    partial class ModuloUsuarioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuloUsuarioForm));
            this.tcModulosUsuarios = new System.Windows.Forms.ToolStripContainer();
            this.tlModulosUsuarios = new System.Windows.Forms.TableLayoutPanel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvModulosUsuarios = new System.Windows.Forms.DataGridView();
            this.tsModulosUsuarios = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Baja = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Modificacion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Consulta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tcModulosUsuarios.ContentPanel.SuspendLayout();
            this.tcModulosUsuarios.TopToolStripPanel.SuspendLayout();
            this.tcModulosUsuarios.SuspendLayout();
            this.tlModulosUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulosUsuarios)).BeginInit();
            this.tsModulosUsuarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcModulosUsuarios
            // 
            // 
            // tcModulosUsuarios.ContentPanel
            // 
            this.tcModulosUsuarios.ContentPanel.Controls.Add(this.tlModulosUsuarios);
            this.tcModulosUsuarios.ContentPanel.Size = new System.Drawing.Size(716, 298);
            this.tcModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcModulosUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tcModulosUsuarios.Name = "tcModulosUsuarios";
            this.tcModulosUsuarios.Size = new System.Drawing.Size(716, 323);
            this.tcModulosUsuarios.TabIndex = 0;
            this.tcModulosUsuarios.Text = "toolStripContainer1";
            // 
            // tcModulosUsuarios.TopToolStripPanel
            // 
            this.tcModulosUsuarios.TopToolStripPanel.Controls.Add(this.tsModulosUsuarios);
            // 
            // tlModulosUsuarios
            // 
            this.tlModulosUsuarios.ColumnCount = 2;
            this.tlModulosUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlModulosUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlModulosUsuarios.Controls.Add(this.btnActualizar, 0, 1);
            this.tlModulosUsuarios.Controls.Add(this.btnSalir, 1, 1);
            this.tlModulosUsuarios.Controls.Add(this.dgvModulosUsuarios, 0, 0);
            this.tlModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlModulosUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tlModulosUsuarios.Name = "tlModulosUsuarios";
            this.tlModulosUsuarios.RowCount = 2;
            this.tlModulosUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlModulosUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlModulosUsuarios.Size = new System.Drawing.Size(716, 298);
            this.tlModulosUsuarios.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(557, 272);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(638, 272);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvModulosUsuarios
            // 
            this.dgvModulosUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModulosUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Modulo,
            this.Usuario,
            this.Alta,
            this.Baja,
            this.Modificacion,
            this.Consulta});
            this.tlModulosUsuarios.SetColumnSpan(this.dgvModulosUsuarios, 2);
            this.dgvModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvModulosUsuarios.Location = new System.Drawing.Point(3, 3);
            this.dgvModulosUsuarios.Name = "dgvModulosUsuarios";
            this.dgvModulosUsuarios.Size = new System.Drawing.Size(710, 263);
            this.dgvModulosUsuarios.TabIndex = 2;
            // 
            // tsModulosUsuarios
            // 
            this.tsModulosUsuarios.Dock = System.Windows.Forms.DockStyle.None;
            this.tsModulosUsuarios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsModulosUsuarios.Location = new System.Drawing.Point(3, 0);
            this.tsModulosUsuarios.Name = "tsModulosUsuarios";
            this.tsModulosUsuarios.Size = new System.Drawing.Size(81, 25);
            this.tsModulosUsuarios.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
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
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
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
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.ToolTipText = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Modulo
            // 
            this.Modulo.DataPropertyName = "IdModulo";
            this.Modulo.HeaderText = "Modulo";
            this.Modulo.Name = "Modulo";
            this.Modulo.ReadOnly = true;
            // 
            // Usuario
            // 
            this.Usuario.DataPropertyName = "IdUsuario";
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            // 
            // Alta
            // 
            this.Alta.DataPropertyName = "PermiteAlta";
            this.Alta.HeaderText = "Alta";
            this.Alta.Name = "Alta";
            this.Alta.ReadOnly = true;
            // 
            // Baja
            // 
            this.Baja.DataPropertyName = "PermiteBaja";
            this.Baja.HeaderText = "Baja";
            this.Baja.Name = "Baja";
            this.Baja.ReadOnly = true;
            // 
            // Modificacion
            // 
            this.Modificacion.DataPropertyName = "PermiteModificacion";
            this.Modificacion.HeaderText = "Modificacion";
            this.Modificacion.Name = "Modificacion";
            this.Modificacion.ReadOnly = true;
            // 
            // Consulta
            // 
            this.Consulta.DataPropertyName = "PermiteConsulta";
            this.Consulta.HeaderText = "Consulta";
            this.Consulta.Name = "Consulta";
            this.Consulta.ReadOnly = true;
            // 
            // ModuloUsuarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 323);
            this.Controls.Add(this.tcModulosUsuarios);
            this.Name = "ModuloUsuarioForm";
            this.Text = "ModuloUsuarioForm";
            this.Load += new System.EventHandler(this.ModuloUsuarioForm_Load);
            this.tcModulosUsuarios.ContentPanel.ResumeLayout(false);
            this.tcModulosUsuarios.TopToolStripPanel.ResumeLayout(false);
            this.tcModulosUsuarios.TopToolStripPanel.PerformLayout();
            this.tcModulosUsuarios.ResumeLayout(false);
            this.tcModulosUsuarios.PerformLayout();
            this.tlModulosUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulosUsuarios)).EndInit();
            this.tsModulosUsuarios.ResumeLayout(false);
            this.tsModulosUsuarios.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcModulosUsuarios;
        private System.Windows.Forms.ToolStrip tsModulosUsuarios;
        private System.Windows.Forms.TableLayoutPanel tlModulosUsuarios;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvModulosUsuarios;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Alta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Baja;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Modificacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Consulta;
    }
}