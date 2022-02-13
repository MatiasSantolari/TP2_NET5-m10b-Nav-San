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
                Alumno_InscripcionAdapter alumnos_InscripcionesData = new Alumno_InscripcionAdapter();
                List<Alumnos_Inscripciones> inscripciones = alumnos_InscripcionesData.GetAll();
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

        public bool ValidaDocente(Docente_Curso doc)
        {
            try
            {
                Docente_CursoAdapter dca = new Docente_CursoAdapter();
                List<Docente_Curso> docentes = dca.GetAll();
                foreach (var dc in docentes)
                {
                    if (dc.IDDocente == doc.IDDocente && dc.IDCurso == doc.IDCurso && dc.Cargo == doc.Cargo)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al realizar la inscripción del alumno", ex);
                throw ExcepcionManejada;
            }
        }

        public bool ValidaCurso(Curso cursoAct)
        {
            try
            {
                CursoAdapter cursoAdapter = new CursoAdapter();
                List<Curso> cursos = cursoAdapter.GetAll();
                foreach (var cur in cursos)
                {
                    if (cur.IDComision == cursoAct.IDComision && cur.IDMateria == cursoAct.IDMateria && cur.AnioCalendario == cursoAct.AnioCalendario)
                    {
                        return false;
                    }
                }

                //Alumnos_InscripcionesData.Insert(ali);
                return true;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al realizar el curso", ex);
                throw ExcepcionManejada;
            }
        }
        public bool ValidaComision(Comision comAct)
        {
            try
            {
                ComisionAdapter comisionAdapter = new ComisionAdapter();
                List<Comision> comisiones = comisionAdapter.GetAll();
                foreach (var cur in comisiones)
                {
                    if (cur.DescComision == comAct.DescComision && cur.AnioEspecialidad == comAct.AnioEspecialidad && cur.IDPlan == comAct.IDPlan)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al realizar el curso", ex);
                throw ExcepcionManejada;
            }
        }

        public bool ValidaPersona(Persona persona)
        {
            try
            {
                PersonaAdapter adapter = new PersonaAdapter();
                List<Persona> personas = adapter.GetAll();
                foreach (var per in personas)
                {
                    if (per.Email == persona.Email)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al realizar el curso", ex);
                throw ExcepcionManejada;
            }
        }
        public bool ValidaPlan(Plan plan)
        {
            try
            {
                PlanesAdapter pa = new PlanesAdapter();
                List<Plan> planes = pa.GetAll();
                foreach (var p in planes)
                {
                    if (p.DescPlan == plan.DescPlan && p.IdEspecialidad == plan.IdEspecialidad)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al realizar el curso", ex);
                throw ExcepcionManejada;
            }
        }

        public bool ValidaMateria(Materia matAct)
        {
            try
            {
                MateriaAdapter materiaAdapter = new MateriaAdapter();
                List<Materia> materias = materiaAdapter.GetAll();
                foreach (var mat in materias)
                {
                    if (mat.DescMateria == matAct.DescMateria && mat.IdPlan == matAct.IdPlan)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al realizar la materia", ex);
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
        public bool ValidaFloat(String nro)
        {
            /*esta validacion la pense asi: 
             * primero el usuario ingresa el string y antes de convertirlo en float 
             * validamos que el string tenga la forma que queremos
            */

            try
            {
                float i = new float();
                bool result = float.TryParse(nro, out i); //ahora i vale ese nro
                return result;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al validar el numero ingresado", ex);
                throw ExcepcionManejada;
            }


        }

        // Validaciones con respecto a los Delete

        public bool ValidaBorradoEspecialidad(Especialidad e)  //Especialidad
        {
            try
            {
                bool rta = false;
                //los planes a los que consultaremos si estan usando la especialidad
                PlanLogic pl = new PlanLogic();
                List<Plan> listaPlan = new List<Plan>();
                listaPlan = pl.GetAll();

                foreach (var plan in listaPlan)
                {
                    if (plan.IdEspecialidad == e.ID)
                    {
                        rta=true;
                        break;
                    }
                }
                //vemos si aparecio alguna coincidencia o no
                if (rta == false) { return false; }
                else { return true; }
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("No se logró validar la integridad con la base de datos, intentelo mas tarde", ex);
                throw ExcepcionManejada;
            }
        }

        public bool ValidaBorradoPlan(Plan p)  //Plan
        {
            try
            {
                bool rta = false;
                //las materias a las que consultaremos si estan usando el plan
                MateriaLogic ml = new MateriaLogic();
                List<Materia> listaMaterias = new List<Materia>();
                listaMaterias = ml.GetAll();

                foreach (var mat in listaMaterias)
                {
                    if (mat.IdPlan == p.ID)
                    {
                        rta = true;
                        break;
                    }
                }

                //las comisiones a las que consultaremos si estan usando el plan
                ComisionLogic cl = new ComisionLogic();
                List<Comision> listaComisiones = new List<Comision>();
                listaComisiones = cl.GetAll();

                foreach (var com in listaComisiones)
                {
                    if (com.IDPlan == p.ID)
                    {
                        rta = true;
                        break;
                    }
                }

                //las personas a las que consultaremos si estan usando el plan
                PersonaLogic pl = new PersonaLogic();
                List<Persona> listaPersonas = new List<Persona>();
                listaPersonas = pl.GetAll();

                foreach (var per in listaPersonas)
                {
                    if (per.IdPlan == p.ID)
                    {
                        rta = true;
                        break;
                    }
                }
                //vemos si aparecio alguna coincidencia o no
                if (rta == false) { return false; }
                else { return true; }
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("No se logró validar la integridad con la base de datos, intentelo mas tarde", ex);
                throw ExcepcionManejada;
            }
        }

        public bool ValidaBorradoMateria(Materia m)  //Materia
        {
            try
            {
                bool rta = false;
                //los cursos a los que consultaremos si estan usando la materia
                CursoLogic cl = new CursoLogic();
                List<Curso> listaCursos = new List<Curso>();
                listaCursos = cl.GetAll();

                foreach (var cur in listaCursos)
                {
                    if (cur.IDMateria == m.ID)
                    {
                        rta = true;
                        break;
                    }
                }
                //vemos si aparecio alguna coincidencia o no
                if (rta == false) { return false; }
                else { return true; }
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("No se logró validar la integridad con la base de datos, intentelo mas tarde", ex);
                throw ExcepcionManejada;
            }
        }

        public bool ValidaBorradoCurso(Curso c)  //Curso
        {
            try
            {
                bool rta = false;
                //las inscripciones de alumnos a las que consultaremos si estan usando el curso
                Alumnos_InscripcionesLogic al = new Alumnos_InscripcionesLogic();
                List<Alumnos_Inscripciones> listaAluIns = new List<Alumnos_Inscripciones>();
                listaAluIns = al.GetAll();

                foreach (var ai in listaAluIns)
                {
                    if (ai.IDCurso == c.ID)
                    {
                        rta = true;
                        break;
                    }
                }

                //los cursos de docentes a los que consultaremos si estan usando el curso
                Docente_CursoLogic dl = new Docente_CursoLogic();
                List<Docente_Curso> listaDocCur = new List<Docente_Curso>();
                listaDocCur = dl.GetAll();

                foreach (var dc in listaDocCur)
                {
                    if (dc.IDCurso == c.ID)
                    {
                        rta = true;
                        break;
                    }
                }
                //vemos si aparecio alguna coincidencia o no
                if (rta == false) { return false; }
                else { return true; }
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("No se logró validar la integridad con la base de datos, intentelo mas tarde", ex);
                throw ExcepcionManejada;
            }
        }

        public bool ValidaBorradoComision(Comision c)  //Comision
        {
            try
            {
                bool rta = false;
                //los cursos a los que consultaremos si estan usando la comision
                CursoLogic cl = new CursoLogic();
                List<Curso> listaCursos = new List<Curso>();
                listaCursos = cl.GetAll();

                foreach (var cur in listaCursos)
                {
                    if (cur.IDComision == c.ID)
                    {
                        rta = true;
                        break;
                    }
                }
                //vemos si aparecio alguna coincidencia o no
                if (rta == false) { return false; }
                else { return true; }
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("No se logró validar la integridad con la base de datos, intentelo mas tarde", ex);
                throw ExcepcionManejada;
            }
        }

        public bool ValidaBorradoUsuario(Usuario u)  //Usuario
        {
            try
            {
                bool rta = false;
                //los cursos de docentes a los que consultaremos si estan usando al usuario
                Docente_CursoLogic dcl = new Docente_CursoLogic();
                List<Docente_Curso> listaDocCur = new List<Docente_Curso>();
                listaDocCur = dcl.GetAll();

                foreach (var dc in listaDocCur)
                {
                    if (dc.IDDocente == u.IDPersona)
                    {
                        rta = true;
                        break;
                    }
                }
                //las inscripciones de alumnos a los que consultaremos si estan usando al usuario
                Alumnos_InscripcionesLogic ail = new Alumnos_InscripcionesLogic();
                List<Alumnos_Inscripciones> listaAluIns = new List<Alumnos_Inscripciones>();
                listaAluIns = ail.GetAll();

                foreach (var ai in listaAluIns)
                {
                    if (ai.IDAlumno == u.IDPersona)
                    {
                        rta = true;
                        break;
                    }
                }
                //vemos si aparecio alguna coincidencia o no
                if (rta == false) { return false; }
                else { return true; }
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("No se logró validar la integridad con la base de datos, intentelo mas tarde", ex);
                throw ExcepcionManejada;
            }
        }

    }
}
