using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class ComisionesForm : Form
    {
        public int UsuarioId { get; set; }

        public ComisionesForm()
        {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;

        }
        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            this.dgvComisiones.DataSource = cl.GetAll();
        }
        private void Lista()
        {
            UsuarioLogic ul = new UsuarioLogic();
            Persona per = ul.GetPersona(UsuarioId);
            if (per.TipoPersona.ToString() == "Admin")
            {
                this.Listar();
            }
            else
            {
                tsbNuevo.Visible = false;
                tsbEditar.Visible = false;
                tsbEliminar.Visible = false;
                ListarComisionesUsuario(UsuarioId);
            }
        }

        public void ListarComisionesUsuario(int id)
        {
            try
            {
                ComisionLogic comi = new ComisionLogic();
                this.dgvComisiones.DataSource = comi.GetComisiones(id);
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Error al recuperar la lista de Comisiones");
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Comisiones", fe);
                throw ExcepcionManejada;
            }
        }

        private void ComisionesForm_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Lista();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionesDesktop cd = new ComisionesDesktop();
            cd.ShowDialog();
            Lista();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionesDesktop us = new ComisionesDesktop(id, ModoForm.Modificacion);
            us.ShowDialog();
            Lista();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionesDesktop us = new ComisionesDesktop(id, ModoForm.Baja);
            us.ShowDialog();
            Lista();
        }
    }
}
