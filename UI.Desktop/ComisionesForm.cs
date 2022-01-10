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

        public ComisionesForm(int id)
        {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
            UsuarioId = id;
        }
        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            PlanLogic pl = new PlanLogic();

            var comisiones = cl.GetAll();
            var planes = pl.GetAll();

            var compl = (from c in comisiones
                         join p in planes on c.IDPlan equals p.ID
                         select(c.ID, c.DescComision, c.AnioEspecialidad, p.DescPlan)).ToList();

            DataTable dataTable = new DataTable();
            dataTable.TableName = "Comision";
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Descripcion");
            dataTable.Columns.Add("Anio");
            dataTable.Columns.Add("Plan");
            foreach (var c in compl)
            {
                dataTable.Rows.Add(c.ID, c.DescComision, c.AnioEspecialidad, c.DescPlan);
            }

            this.dgvComisiones.DataSource = dataTable;
            dgvComisiones.AllowUserToAddRows = false;
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
                this.Listar(UsuarioId);
                tsbNuevo.Visible = false;
                tsbEditar.Visible = false;
                tsbEliminar.Visible = false;
                
            }
        }

        public void Listar(int id)
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
            this.Lista();
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
            int ind = dgvComisiones.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = dgvComisiones.Rows[ind];
            int ID = Convert.ToInt32(dataGridViewRow.Cells["ID"].Value);
            ComisionesDesktop editar = new ComisionesDesktop(ID, ModoForm.Modificacion);
            editar.ShowDialog();
            this.Lista();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ind = dgvComisiones.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = dgvComisiones.Rows[ind];
            int ID = Convert.ToInt32(dataGridViewRow.Cells["ID"].Value);
            ComisionesDesktop editar = new ComisionesDesktop(ID, ModoForm.Baja);
            editar.ShowDialog();
            this.Lista();
        }
    }
}
