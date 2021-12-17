using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    public class PersonaAdapter:Adapter
    {

        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlConnection);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona p = new Persona();
                    p.ID = (int)drPersonas["id_persona"];
                    p.Nombre = (string)drPersonas["nombre"];
                    p.Apellido = (string)drPersonas["apellido"];
                    p.Direccion = (string)drPersonas["direccion"];
                    p.Email = (string)drPersonas["email"];
                    p.Telefono = (string)drPersonas["telefono"];
                    p.FechaNac = (DateTime)drPersonas["fecha_nac"];
                    p.Legajo = (int)drPersonas["legajo"];
                    p.TipoPersona = (Persona.TipoPersonas)(int)drPersonas["tipo_persona"];
                    p.IdPlan = (int)drPersonas["id_plan"];
                    personas.Add(p);
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }

        public Persona GetOne(int ID)
        {
            Persona p = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("Select * from personas where id_persona = @id", sqlConnection);
                cmdPersona.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersona = cmdPersona.ExecuteReader();
                if (drPersona.Read())
                {
                    p.ID = (int)drPersona["id_persona"];
                    p.Nombre = (string)drPersona["nombre"];
                    p.Apellido = (string)drPersona["apellido"];
                    p.Direccion = (string)drPersona["direccion"];
                    p.Email = (string)drPersona["email"];
                    p.Telefono = (string)drPersona["telefono"];
                    p.FechaNac = (DateTime)drPersona["fecha_nac"];
                    p.Legajo = (int)drPersona["legajo"];
                    p.TipoPersona = (Persona.TipoPersonas)(int)drPersona["tipo_persona"];
                    p.IdPlan = (int)drPersona["id_plan"];
                }
                drPersona.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la persona", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return p;
        }
        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE personas SET nombre=@nombre, apellido=@apellido, direccion=@direccion, email=@email, telefono=@telefono, fecha_nac=@fecha_nac, legajo=@legajo, tipo_persona=@tipo_persona, id_plan=@id_plan, = where id_persona=@id", sqlConnection);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNac;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IdPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception er = new Exception("Error al actualizar los datos de la persona", e);
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
                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona=@id", sqlConnection);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Persona p)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into personas(nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan) " +
                "Values(@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan)", sqlConnection);
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = p.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = p.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = p.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = p.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = p.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = p.FechaNac;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = p.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = p.TipoPersona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = p.IdPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Persona p)
        {
            if (p.State == BusinessEntity.States.Deleted)
            {
                this.Delete(p.ID);
            }
            else if (p.State == BusinessEntity.States.New)
            {
                this.Insert(p);
            }
            else if (p.State == BusinessEntity.States.Modified)
            {
                this.Update(p);
            }
            p.State = BusinessEntity.States.Unmodified;
        }

        public List<Persona> GetProfesores()
        {
            List<Persona> profesores = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand(
                    "select * from personas where tipo_persona = 1", sqlConnection); //como param del nuevo command pasamos el objConeccion y el command.text
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona p = new Persona();
                    p.ID = (int)drPersonas["id_persona"];
                    p.Nombre = (string)drPersonas["nombre"];
                    p.Apellido = (string)drPersonas["apellido"];
                    p.Direccion = (string)drPersonas["direccion"];
                    p.Email = (string)drPersonas["email"];
                    p.Telefono = (string)drPersonas["telefono"];
                    p.FechaNac = (DateTime)drPersonas["fecha_nac"];
                    p.Legajo = (int)drPersonas["legajo"];
                    p.TipoPersona = (Persona.TipoPersonas)drPersonas["tipo_persona"];
                    p.IdPlan = (int)drPersonas["id_plan"];
                    profesores.Add(p);
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de profesores", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return profesores;
        }

        public List<Persona> GetPersonasXTipo(Persona.TipoPersonas tipoPersona)
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("select *,pl.desc_plan from personas pe inner join planes pl on pl.id_plan=pe.id_plan where pe.tipo_persona = @tipo", sqlConnection);
                cmdGetAll.Parameters.Add("@tipo", SqlDbType.Int).Value = tipoPersona;
                SqlDataReader drPersonas = cmdGetAll.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.FechaNac = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.IdPlan = (int)drPersonas["id_plan"];

                    personas.Add(per);
                }
                drPersonas.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los datos de las Personas", ex);

                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }

        public Persona GetOne(string nom, string cont)
        {
            Persona per = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("select *, desc_plan from personas pe inner join planes p on p.id_plan = pe.id_plan inner join usuarios us on pe.id_persona = us.id_persona where us.nombre_usuario = @nom and us.clave =@contra", sqlConnection);
                cmdPersona.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nom;
                cmdPersona.Parameters.Add("@contra", SqlDbType.VarChar).Value = cont;
                SqlDataReader drPersonas = cmdPersona.ExecuteReader();
                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.FechaNac = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.IdPlan = (int)drPersonas["id_plan"];
                    per.Telefono = (string)drPersonas["telefono"];
                    switch ((int)drPersonas["tipo_persona"])
                    {
                        case 0:
                            per.TipoPersona = Persona.TipoPersonas.Admin;
                            break;

                        case 1:
                            per.TipoPersona = Persona.TipoPersonas.Docente;
                            break;

                        case 2:
                            per.TipoPersona = Persona.TipoPersonas.Alumno;
                            break;
                    }
                }
                drPersonas.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la persona", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return per;
        }

    }
}
