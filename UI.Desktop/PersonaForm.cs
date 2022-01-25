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
    public partial class PersonaForm : Form
    {
        public int UsuarioID { get; set; }
        public PersonaForm(int id)
        {
            InitializeComponent();
            this.dgvPersonas.AutoGenerateColumns = false;
            UsuarioID = id;
        }
        public void Listar()
        {
            /*try
            {
                UsuarioLogic ul = new UsuarioLogic();
                Persona per = ul.GetPersona(UsuarioID);

                PersonaLogic pl = new PersonaLogic();
                if (per.TipoPersona.ToString() == "Admin")
                {
                    
                    this.dgvPersonas.DataSource = pl.GetAll();
                    
                }
                else
                {
                    List<Persona> listaPers = new List<Persona>();
                    listaPers.Add(pl.GetOne(per.ID));
                    this.dgvPersonas.DataSource = listaPers;
                    tsbNuevo.Visible = false;
                    tsbEditar.Visible = false;
                    tsbEliminar.Visible = false;

                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Error al recuperar la lista de personas");
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", fe);
                throw ExcepcionManejada;
            }*/

            try
            {
                UsuarioLogic ul = new UsuarioLogic();
                Persona per = ul.GetPersona(UsuarioID);
                if (per.TipoPersona.ToString() == "Admin")
                {
                    PlanLogic pla = new PlanLogic();
                    PersonaLogic ple = new PersonaLogic();


                    var personas = ple.GetAll();
                    var planes = pla.GetAll();

                    var pers = (from pe in personas
                                join pl in planes on pe.IdPlan equals pl.ID
                                select (pe, pl.DescPlan)).ToList();

                    DataTable dataTable1 = new DataTable();
                    dataTable1.TableName = "Personas";
                    dataTable1.Columns.Add("ID");
                    dataTable1.Columns.Add("Nombre");
                    dataTable1.Columns.Add("Apellido");
                    dataTable1.Columns.Add("Direccion");
                    dataTable1.Columns.Add("Email");
                    dataTable1.Columns.Add("Telefono");
                    dataTable1.Columns.Add("FechaNac");
                    dataTable1.Columns.Add("Legajo");
                    dataTable1.Columns.Add("TipoPersona");
                    dataTable1.Columns.Add("DescPlan");
                    foreach (var perso in pers)
                    {
                        dataTable1.Rows.Add(perso.pe.ID, perso.pe.Nombre, perso.pe.Apellido, perso.pe.Direccion, perso.pe.Email, perso.pe.Telefono, perso.pe.FechaNac, perso.pe.Legajo, perso.pe.TipoPersona, perso.DescPlan);
                    }

                    this.dgvPersonas.DataSource = dataTable1;
                    dgvPersonas.AllowUserToAddRows = false;
                }
                else
                {
                    PlanLogic pla = new PlanLogic();
                    PersonaLogic pel = new PersonaLogic();

                    var planes = pla.GetAll();
                    var personas = pel.GetAll();

                    var pers = (from p in personas
                                join pl in planes on p.IdPlan equals pl.ID
                                where p.ID == per.ID
                                select (p, pl.DescPlan)).ToList();

                    DataTable dataTable1 = new DataTable();
                    dataTable1.TableName = "Personas";
                    dataTable1.Columns.Add("ID");
                    dataTable1.Columns.Add("Nombre");
                    dataTable1.Columns.Add("Apellido");
                    dataTable1.Columns.Add("Direccion");
                    dataTable1.Columns.Add("Email");
                    dataTable1.Columns.Add("Telefono");
                    dataTable1.Columns.Add("FechaNac");
                    dataTable1.Columns.Add("Legajo");
                    dataTable1.Columns.Add("TipoPersona");
                    dataTable1.Columns.Add("DescPlan");
                    foreach (var perso in pers)
                    {
                        dataTable1.Rows.Add(perso.p.ID, perso.p.Nombre, perso.p.Apellido, perso.p.Direccion, perso.p.Email, perso.p.Telefono, perso.p.FechaNac, perso.p.Legajo, perso.p.TipoPersona, perso.DescPlan);
                    }

                    this.dgvPersonas.DataSource = dataTable1;
                    dgvPersonas.AllowUserToAddRows = false;
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Error al recuperar las Personas");
                Exception ExcepcionManejada = new Exception("Error al recuperar las Personas", fe);
                throw ExcepcionManejada;
            }
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
                tsbNuevo.Visible = false;
                tsbEditar.Visible = false;
                tsbEliminar.Visible = false;

            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaDesktop per = new PersonaDesktop(ModoForm.Alta);
            per.ShowDialog();
            this.Lista();
        }

        private void PersonaForm_Load(object sender, EventArgs e)
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ind = dgvPersonas.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = dgvPersonas.Rows[ind];
            int ID = Convert.ToInt32(dataGridViewRow.Cells["ID"].Value);
            PersonaDesktop editar = new PersonaDesktop(ID, ModoForm.Modificacion);
            editar.ShowDialog();
            this.Lista();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ind = dgvPersonas.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = dgvPersonas.Rows[ind];
            int ID = Convert.ToInt32(dataGridViewRow.Cells["ID"].Value);

            UsuarioLogic us = new UsuarioLogic();

            var usarios = us.GetAll();

            var usu = (from c in usarios
                       where c.IDPersona == ID
                       select c.ID).ToList();

            if (usu.Count == 0)
            {
                PersonaDesktop eliminar = new PersonaDesktop(ID, ModoForm.Baja);
                eliminar.ShowDialog();
            }
            else
            {
                MessageBox.Show("La persona está siendo utilizada en otros datos. Primero elimine sus dependencias.");
            }
            this.Lista();
        }
    }
}
