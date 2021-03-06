using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class ComisionAdapter:Adapter
    {
        

        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones", sqlConnection);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision com = new Comision();
                    com.ID = (int)drComisiones["id_comision"];
                    com.DescComision = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (Comision.Anios)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];
                    comisiones.Add(com);

                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();

            }
            return comisiones;
        }

        public Comision GetOne(int ID)
        {
            Comision com = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("Select * from comisiones where id_comision = @id", sqlConnection);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdUsuarios.ExecuteReader();
                if (drComisiones.Read())
                {
                    com.ID = (int)drComisiones["id_comision"];
                    com.DescComision = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (Comision.Anios)drComisiones["anio_especialidad"];
                    com.IDPlan = (int)drComisiones["id_plan"];
                }
                drComisiones.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la comision", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return com;
        }
        protected void Update(Comision comi)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision=@desc_comision, anio_especialidad=@anio_especialidad, id_plan=@id_plan where id_comision=@id", sqlConnection);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comi.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comi.DescComision;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comi.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comi.IDPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception er = new Exception("Error al recuperar los datos de Comisiones", e);
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
                SqlCommand cmdDelete =
                new SqlCommand("delete comisiones where id_comision=@id", sqlConnection);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Comision comi)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into comisiones(desc_comision,anio_especialidad,id_plan) " +
                "Values(@desc_comision,@anio_especialidad,@id_plan)", sqlConnection);
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comi.DescComision;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comi.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comi.IDPlan;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comi)
        {
            if (comi.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comi.ID);
            }
            else if (comi.State == BusinessEntity.States.New)
            {
                this.Insert(comi);
            }
            else if (comi.State == BusinessEntity.States.Modified)
            {
                this.Update(comi);
            }
            comi.State = BusinessEntity.States.Unmodified;
        }

        public List<Comision> GetComisiones(int id)
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand(
                    "select co.id_comision,desc_comision,anio_especialidad,co.id_plan from usuarios u " +
                    "inner join personas p on p.id_persona = u.id_persona " +
                    "inner join docentes_cursos dc on dc.id_docente=p.id_persona " +
                    "inner join cursos c on c.id_curso = dc.id_curso " +
                    "inner join comisiones co on co.id_comision=c.id_comision " +
                    "where id_usuario = @id", sqlConnection);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision c = new Comision();
                    c.ID = (int)drComisiones["id_comision"];
                    c.DescComision = (string)drComisiones["desc_comision"];
                    c.AnioEspecialidad = (Comision.Anios)drComisiones["anio_especialidad"];
                    c.IDPlan = (int)drComisiones["id_plan"];
                    comisiones.Add(c);

                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de Comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }

        public List<Curso> GetCursos(int id)
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdBuscaCursos = new SqlCommand(
                    "select * from comisiones co " +
                    "inner join cursos c on co.id_comision=c.id_comision " +
                    "where co.id_comision=@id;", sqlConnection);
                cmdBuscaCursos.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drCursos = cmdBuscaCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    Curso c = new Curso();
                    c.ID = (int)drCursos["id_curso"];
                    c.IDMateria = (int)drCursos["id_materia"];
                    c.IDComision = (int)drCursos["id_comision"];
                    c.AnioCalendario = (int)drCursos["anio_calendario"];
                    c.Cupo = (int)drCursos["cupo"];
                    cursos.Add(c);
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
            return cursos;
        }
    }
}
