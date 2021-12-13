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
            try
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
            }
        }
        private void Lista()
        {
            this.Listar();
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
            int id = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            PersonaDesktop per = new PersonaDesktop(id, ModoForm.Modificacion);
            per.ShowDialog();
            this.Lista();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            PersonaDesktop per = new PersonaDesktop(id, ModoForm.Baja);
            per.ShowDialog();
            this.Lista();
        }
    }
}
