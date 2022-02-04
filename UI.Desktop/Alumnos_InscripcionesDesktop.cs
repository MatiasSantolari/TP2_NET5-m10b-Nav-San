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
    public partial class Alumnos_InscripcionesDesktop : ApplicationForm
    {
        public Alumnos_InscripcionesDesktop()
        {
            InitializeComponent();
            PersonaLogic p = new PersonaLogic();
            cbxAlumno.DataSource = p.GetPersonasXTipo(Persona.TipoPersonas.Alumno);
            cbxAlumno.DisplayMember = "Nombre";
            cbxAlumno.ValueMember = "ID";

            MateriaLogic materia = new MateriaLogic();
            cbxMateria.DataSource = materia.GetAll();
            cbxMateria.DisplayMember = "DescMateria";
            cbxMateria.ValueMember = "ID";

        }

        public Alumnos_InscripcionesDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public Alumnos_InscripcionesDesktop(int ID, ModoForm modo) : this()
        {
            Alumnos_InscripcionesLogic ali = new Alumnos_InscripcionesLogic();

            Modo = modo;

            AlIActual = ali.GetOne(ID);
            MapearDeDatos();
        }

        public Alumnos_Inscripciones AlIActual { get; set; }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.AlIActual.ID.ToString();
            this.txtCondicion.Text = this.AlIActual.Condicion.ToString();
            this.txtNota.Text = this.AlIActual.Nota.ToString();
            this.cbxAlumno.SelectedValue = this.AlIActual.IDAlumno;
            CursoLogic cl = new CursoLogic();
            Curso c = cl.GetOne(AlIActual.IDCurso);
            this.cbxMateria.SelectedValue = c.IDMateria;
            List<Comision> com = cl.GetComisionesXMateria(c.IDMateria);
            cbxComision.Enabled = true;
            cbxComision.DataSource = com;
            cbxComision.DisplayMember = "DescComision";
            cbxComision.ValueMember = "ID";

            this.cbxComision.SelectedValue = c.IDComision;
            

            switch (Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }

        }

        public override void MapearADatos()
        {
            int idMateria, idComision;
            Alumnos_InscripcionesLogic ail = new Alumnos_InscripcionesLogic();
            Validaciones val = new Validaciones();

            switch (Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";


                    Alumnos_Inscripciones Ali = new Alumnos_Inscripciones();
                    AlIActual = Ali;
                    int id = 0;
                    this.AlIActual.ID = id;
                    this.AlIActual.IDAlumno = int.Parse(this.cbxAlumno.SelectedValue.ToString());

                    idMateria = (int)cbxMateria.SelectedValue;
                    idComision = (int)cbxComision.SelectedValue;

                    this.AlIActual.IDCurso = ail.GetCurso(idMateria, idComision).ID;
                    

                    this.AlIActual.Condicion = this.txtCondicion.Text;
                    
                    if (this.txtNota.Text.Length == 0) 
                        { this.AlIActual.Nota = 0; }
                    else 
                        { this.AlIActual.Nota = int.Parse(this.txtNota.Text); }

                    if (val.ValidaInscripcion(AlIActual) == true)
                    {
                        CursoLogic cl = new CursoLogic();
                        cl.ActualizaCupo(cl.GetOne(AlIActual.IDCurso));
                        AlIActual.State = BusinessEntity.States.New;
                    }
                    else
                    {
                        MessageBox.Show("El alumno ya se encuentra inscripto a esta materia.");
                        AlIActual.State = BusinessEntity.States.Unmodified;
                    }
                    break;
                    

                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    Alumnos_Inscripciones Uss = new Alumnos_Inscripciones();
                    AlIActual = Uss;
                    this.AlIActual.ID= int.Parse(this.txtID.Text);
                    this.AlIActual.IDAlumno = int.Parse(this.cbxAlumno.SelectedValue.ToString());
                    
                    idMateria = (int)cbxMateria.SelectedValue;
                    idComision = (int)cbxComision.SelectedValue;

                    this.AlIActual.IDCurso = ail.GetCurso(idMateria, idComision).ID;
                    this.AlIActual.Nota = int.Parse(this.txtNota.Text);
                    this.AlIActual.Condicion = this.txtCondicion.Text;

                    if (val.ValidaInscripcion(AlIActual) == true)
                    {
                        AlIActual.State = BusinessEntity.States.Modified;
                    }
                    else
                    {
                        MessageBox.Show("El alumno ya se encuentra inscripto a esta materia.");
                        AlIActual.State = BusinessEntity.States.Unmodified;
                    } 
                    
                    break;

                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    AlIActual.State = BusinessEntity.States.Deleted;
                    break;

                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    AlIActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            Alumnos_InscripcionesLogic ail = new Alumnos_InscripcionesLogic();
            ail.Save(AlIActual);
        }

        public override bool Validar()
        {

            //bool b2 = string.IsNullOrEmpty(this.txtID.Text);
            bool b1 = cbxComision.Enabled;
            bool b5 = string.IsNullOrEmpty(this.txtCondicion.Text);
            
            

            if (b1 == false || b5 == true)
            {
                this.Notificar("Por favor, rellenar los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            else
            {
                return true;
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Validaciones validaciones = new Validaciones();

            if (validaciones.ValidaInteger(txtNota.Text) && int.Parse(txtNota.Text) >= 0 && int.Parse(txtNota.Text) < 11)
            {
                bool b = this.Validar();
                if (b == true)
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }
            else
            {
                txtNota.ForeColor = Color.Red;
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxMateria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CursoLogic cl = new CursoLogic();
            List<Comision> com = cl.GetComisionesXMateria(Int32.Parse(this.cbxMateria.SelectedValue.ToString()));
            if (com.Any())
            {
                cbxComision.Enabled = true;
                cbxComision.DataSource = com;
                cbxComision.DisplayMember = "DescComision";
                cbxComision.ValueMember = "ID";
                
            }
            else
            {
                cbxComision.Enabled = false;
            }
            
        }

        private void cbxMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /*private void cbxMateria_ValueMemberChanged(object sender, EventArgs e)
        {
            CursoLogic cl = new CursoLogic();
            
            cbxComision.Visible = true;
            ComisionLogic comision = new ComisionLogic();
            cbxComision.DataSource = cl.GetComisionesXMateria(Int32.Parse(this.cbxAlumno.SelectedValue.ToString()));
            cbxComision.DisplayMember = "DescComision";
            cbxComision.ValueMember = "ID";
        }*/


    }
}
