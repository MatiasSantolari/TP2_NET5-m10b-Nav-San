using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter:Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Curso> _Cursos;

        private static List<Curso> Cursos
        {
            get
            {
                if (_Cursos == null)
                {
                    _Cursos = new List<Curso>();
                    Curso cur;
                    cur = new Curso();
                    cur.ID = 1;
                    cur.State = BusinessEntity.States.Unmodified;
                    cur.AnioCalendario = 2021;
                    cur.Cupo = 40;
                    cur.IDComision = 1;
                    cur.IDMateria = 1;
                    _Cursos.Add(cur);

                    cur = new Curso();
                    cur.ID = 2;
                    cur.State = BusinessEntity.States.Unmodified;
                    cur.AnioCalendario = 2021;
                    cur.Cupo = 435;
                    cur.IDComision = 1;
                    cur.IDMateria = 2;
                    _Cursos.Add(cur);

                    cur = new Curso();
                    cur.ID = 3;
                    cur.State = BusinessEntity.States.Unmodified;
                    cur.AnioCalendario = 2021;
                    cur.Cupo = 450;
                    cur.IDComision = 2;
                    cur.IDMateria = 1;
                    _Cursos.Add(cur);

                }
                return _Cursos;
            }
        }
        #endregion

        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos", sqlConnection);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cursos.Add(cur);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public Curso GetOne(int ID)
        {
            Curso cur = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("Select * from cursos where id_curso = @id", sqlConnection);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.IDComision = (int)drCursos["id_comision"];
                }
                drCursos.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del curso", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cur;
        }
        protected void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET anio_calendario=@anio_calendario, cupo=@cupo, id_materia=@id_materia, id_comision=@id_comision where id_curso=@id", sqlConnection);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception er = new Exception("Error al actualizar los datos del curso", e);
                throw er;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int ID)
        {
            try
            {
                //abrimos la conexión
                this.OpenConnection();

                //creamos la sentencia sql y asignamos un valor al parámetro
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso=@id", sqlConnection);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into cursos(anio_calendario, cupo, id_materia, id_comision) " +
                "Values(@anio_calendario, @cupo, @id_materia, @id_comision) ", sqlConnection);
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }

        public List<Docente_Curso> BuscaDocentesCurso(int idCurso)
        {
            List<Docente_Curso> DocentesCursos = new List<Docente_Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdBuscaDocenteCurso = new SqlCommand(
                    "select id_dictado,dc.id_curso,id_docente,cargo from cursos c " +
                    "inner join docentes_cursos dc on c.id_curso=dc.id_curso " +
                    "where c.id_curso=@id;", sqlConnection);
                cmdBuscaDocenteCurso.Parameters.Add("@id", SqlDbType.Int).Value = idCurso;
                SqlDataReader drDocentesCursos = cmdBuscaDocenteCurso.ExecuteReader();
                while (drDocentesCursos.Read())
                {
                    Docente_Curso dc = new Docente_Curso();
                    dc.ID = (int)drDocentesCursos["id_dictado"];
                    dc.IDCurso = (int)drDocentesCursos["id_curso"];
                    dc.IDDocente = (int)drDocentesCursos["id_docente"];
                    dc.Cargo = (Docente_Curso.cargos)drDocentesCursos["cargo"];
                    DocentesCursos.Add(dc);
                }
                drDocentesCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de docentes y cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return DocentesCursos;
        }
    }
}
