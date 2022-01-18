using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class Validaciones
    {
        //aqui agregaremos toda funcion de validacion que se nos pueda ocurrir. fechas, mails, etc.
        private UsuarioAdapter _usuario_data;
        private Alumno_InscripcionAdapter _alumnos_inscripcionesData;

        public UsuarioAdapter UsuarioData
        {
            get
            {
                return _usuario_data;
            }
            set
            {
                _usuario_data = value;
            }
        }
        public Alumno_InscripcionAdapter Alumnos_InscripcionesData
        {
            get { return _alumnos_inscripcionesData; }
            set { _alumnos_inscripcionesData = value; }
        }





        public bool AutenticarUsuario(string nom_user, string contrasenia)
        {
            try
            {
                return this.UsuarioData.Autenticar(nom_user, contrasenia);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al autentificar", ex);
                throw ExcepcionManejada;
            }
        }



        public bool ValidaInscripcion(Alumnos_Inscripciones ali)
        {
            try
            {
                List<Alumnos_Inscripciones> inscripciones = Alumnos_InscripcionesData.GetAll();
                foreach (var ins in inscripciones)
                {
                    if (ins.IDAlumno == ali.IDAlumno && ins.IDCurso == ali.IDCurso)
                    {
                        return false;
                    }
                }

                //Alumnos_InscripcionesData.Insert(ali);
                return true;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al realizar la inscripción del alumno", ex);
                throw ExcepcionManejada;
            }
        }

    }
}
