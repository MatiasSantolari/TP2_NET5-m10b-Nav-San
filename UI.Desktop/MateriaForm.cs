using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class MateriaForm : Form
    {
        public int UsuarioID { get; set; }

        public MateriaForm(int id)
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
            UsuarioID = id;
        }
        public void Listar()
        {
            // MateriaLogic ul = new MateriaLogic();
            // this.dgvMaterias.DataSource = ul.GetAll();


            try
            {

                MateriaLogic mat = new MateriaLogic();
                PlanLogic pla = new PlanLogic();


                var materias = mat.GetAll();
                var planes = pla.GetAll();

                var mater = (from m in materias
                             join p in planes on m.IdPlan equals p.ID
                             select (m, p.DescPlan)).ToList();

                DataTable dataTable1 = new DataTable();
                dataTable1.TableName = "Materias";
                dataTable1.Columns.Add("DescMateria");
                dataTable1.Columns.Add("HsSemanales");
                dataTable1.Columns.Add("HsTotales");
                dataTable1.Columns.Add("DescPlan");
                foreach (var ma in mater)
                {
                    dataTable1.Rows.Add(ma.m.DescMateria, ma.m.HsSemanales, ma.m.HsTotales, ma.DescPlan);
                }
                
                var dtResultado = dataTable1.Rows.Cast<DataRow>().Where(row => !Array.TrueForAll(row.ItemArray, value => { return value.ToString().Length == 0; }));
                dataTable1 = dtResultado.CopyToDataTable();

                this.dgvMaterias.DataSource = dataTable1;
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Error al recuperar las materias");
                Exception ExcepcionManejada = new Exception("Error al recuperar las materias", fe);
                throw ExcepcionManejada;
            }


        }
        private void MateriasForm_Load(object sender, EventArgs e)
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
            MateriaDesktop mat = new MateriaDesktop(ModoForm.Alta);
            mat.ShowDialog();
            this.Lista();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop mat = new MateriaDesktop(id, ModoForm.Modificacion);
            mat.ShowDialog();
            this.Lista();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop mat = new MateriaDesktop(id, ModoForm.Baja);
            mat.ShowDialog();
            this.Lista();
        }

        private void Lista()
        {
            UsuarioLogic ul = new UsuarioLogic();
            Persona per = ul.GetPersona(UsuarioID);
            if (per.TipoPersona.ToString() == "Admin")
            {
                this.Listar();
            }
            else
            {
                this.Listar();
                //dgvPlanes.Visible = true;
                tsbNuevo.Visible = false;
                tsbEditar.Visible = false;
                tsbEliminar.Visible = false;

            }
        }
    }
}
