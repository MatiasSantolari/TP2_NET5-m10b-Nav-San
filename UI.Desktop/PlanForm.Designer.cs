
namespace UI.Desktop
{
    partial class PlanForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanForm));
            this.tcPlanes = new System.Windows.Forms.ToolStripContainer();
            this.tlPlanes = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPlanes = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.tsPlanes = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tcPlanes.ContentPanel.SuspendLayout();
            this.tcPlanes.TopToolStripPanel.SuspendLayout();
            this.tcPlanes.SuspendLayout();
            this.tlPlanes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).BeginInit();
            this.tsPlanes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPlanes
            // 
            // 
            // tcPlanes.ContentPanel
            // 
            this.tcPlanes.ContentPanel.Controls.Add(this.tlPlanes);
            this.tcPlanes.ContentPanel.Size = new System.Drawing.Size(483, 268);
            this.tcPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPlanes.Location = new System.Drawing.Point(0, 0);
            this.tcPlanes.Name = "tcPlanes";
            this.tcPlanes.Size = new System.Drawing.Size(483, 293);
            this.tcPlanes.TabIndex = 0;
            this.tcPlanes.Text = "toolStripContainer1";
            // 
            // tcPlanes.TopToolStripPanel
            // 
            this.tcPlanes.TopToolStripPanel.Controls.Add(this.tsPlanes);
            // 
            // tlPlanes
            // 
            this.tlPlanes.ColumnCount = 2;
            this.tlPlanes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPlanes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPlanes.Controls.Add(this.dgvPlanes, 0, 0);
            this.tlPlanes.Controls.Add(this.btnSalir, 1, 1);
            this.tlPlanes.Controls.Add(this.btnActualizar, 0, 1);
            this.tlPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPlanes.Location = new System.Drawing.Point(0, 0);
            this.tlPlanes.Name = "tlPlanes";
            this.tlPlanes.RowCount = 2;
            this.tlPlanes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPlanes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlPlanes.Size = new System.Drawing.Size(483, 268);
            this.tlPlanes.TabIndex = 0;
            // 
            // dgvPlanes
            // 
            this.dgvPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Descripcion,
            this.Especialidad});
            this.tlPlanes.SetColumnSpan(this.dgvPlanes, 2);
            this.dgvPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlanes.Location = new System.Drawing.Point(3, 3);
            this.dgvPlanes.Name = "dgvPlanes";
            this.dgvPlanes.ReadOnly = true;
            this.dgvPlanes.Size = new System.Drawing.Size(477, 233);
            this.dgvPlanes.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "DescPlan";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Especialidad
            // 
            this.Especialidad.DataPropertyName = "IdEspecialidad";
            this.Especialidad.HeaderText = "Especialidad";
            this.Especialidad.Name = "Especialidad";
            this.Especialidad.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(405, 242);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(321, 242);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(78, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // tsPlanes
            // 
            this.tsPlanes.Dock = System.Windows.Forms.DockStyle.None;
            this.tsPlanes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsPlanes.Location = new System.Drawing.Point(3, 0);
            this.tsPlanes.Name = "tsPlanes";
            this.tsPlanes.Size = new System.Drawing.Size(112, 25);
            this.tsPlanes.TabIndex = 0;
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
            this.tsbEliminar.Text = "toolStripButton3";
            this.tsbEliminar.ToolTipText = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // PlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 293);
            this.Controls.Add(this.tcPlanes);
            this.Name = "PlanForm";
            this.Text = "PlanForm";
            this.Load += new System.EventHandler(this.PlanForm_Load);
            this.tcPlanes.ContentPanel.ResumeLayout(false);
            this.tcPlanes.TopToolStripPanel.ResumeLayout(false);
            this.tcPlanes.TopToolStripPanel.PerformLayout();
            this.tcPlanes.ResumeLayout(false);
            this.tcPlanes.PerformLayout();
            this.tlPlanes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanes)).EndInit();
            this.tsPlanes.ResumeLayout(false);
            this.tsPlanes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcPlanes;
        private System.Windows.Forms.TableLayoutPanel tlPlanes;
        private System.Windows.Forms.DataGridView dgvPlanes;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ToolStrip tsPlanes;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Especialidad;
    }
}