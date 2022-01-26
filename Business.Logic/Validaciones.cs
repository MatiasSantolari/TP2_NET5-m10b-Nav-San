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


        //Sin probar

        public bool ValidaMail(String mail)
        {
            try
            {
                bool rta = new bool();
                rta = mail.Contains("@") && mail.Contains(".com");
                return rta;

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al validar el mail ingresado", ex);
                throw ExcepcionManejada;
            }
        }

        public bool ValidaFecha(String fecha)
        {
            /*esta validacion la pense asi: 
             * primero el usuario ingresa el string y antes de convertirlo en datetime 
             * validamos que el string tenga la forma que queremos
            */

            try 
            {
                DateTime i = new DateTime();
                bool result = DateTime.TryParse(fecha, out i); //ahora i vale ese datetime
                return result;

                /*tambien podria validar mas que la sintaxis, ejemplo que la fecha ingresada 
                sea mayor a la actual pero creo que eso no era siempre asi, veré si es 
                necesario en algun momento y de ser el caso haré una validacion extra 
                que ademas valide que la fecha sea posterior a hoy
                */
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al validar la fecha ingresada", ex);
                throw ExcepcionManejada;
            }


        }

        public bool ValidaInteger(String nro)
        {
            /*esta validacion la pense asi: 
             * primero el usuario ingresa el string y antes de convertirlo en int 
             * validamos que el string tenga la forma que queremos
            */

            try
            {
                int i = new int();
                bool result = int.TryParse(nro, out i); //ahora i vale ese nro
                return result;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al validar el numero ingresado", ex);
                throw ExcepcionManejada;
            }


        }

    }
}
