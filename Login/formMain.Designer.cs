
namespace Login
{
    partial class formMain
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
            this.mnsPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsPrincipal
            // 
            this.mnsPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchivo});
            this.mnsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnsPrincipal.Name = "mnsPrincipal";
            this.mnsPrincipal.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.mnsPrincipal.Size = new System.Drawing.Size(533, 24);
            this.mnsPrincipal.TabIndex = 1;
            this.mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            this.mnuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSalir});
            this.mnuArchivo.Name = "mnuArchivo";
            this.mnuArchivo.Size = new System.Drawing.Size(60, 22);
            this.mnuArchivo.Text = "Archivo";
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(96, 22);
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.mnsPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsPrincipal;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "formMain";
            this.Text = "Academia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formMain_Load);
            this.mnsPrincipal.ResumeLayout(false);
            this.mnsPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivo;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
    }
}