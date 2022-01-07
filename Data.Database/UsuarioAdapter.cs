using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", sqlConnection);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];
                    usuarios.Add(usr);
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("Select * from usuarios where id_usuario = @id", sqlConnection);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];
                }
                drUsuarios.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }
        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE usuarios SET nombre_usuario=@nombre_usuario, clave=@clave, habilitado=@habilitado, nombre=@nombre, apellido=@apellido, email=@email " +
                    "where id_usuario=@id", sqlConnection);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception er = new Exception("Error al actualizar los datos de usuario", e);
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
                //abrimos la conexi�n
                this.OpenConnection();

                //creamos la sentencia sql y asignamos un valor al par�metro
                SqlCommand cmdDelete = new SqlCommand("delete usuarios where id_usuario=@id", sqlConnection);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into usuarios(nombre_usuario,clave,habilitado,nombre,apellido,email) " +
                "Values(@nombre_usuario,@clave,@habilitado,@nombre,@apellido,@email) ", sqlConnection);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }

        public void SavePlus(Usuario usuario, int idPersona)
        {
            if (usuario.State == BusinessEntity.States.New)
            {
                this.CargarIDPersona(usuario, idPersona);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.ActualizarPersona(usuario, idPersona);
            }
        }

        public Persona GetPersona(int id)
        {
            Persona p = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdBuscaPersona = new SqlCommand(
                    "select p.id_persona,p.nombre,p.apellido,direccion,p.email,telefono,fecha_nac,legajo,tipo_persona,id_plan from usuarios u " +
                    "inner join personas p on p.id_persona=u.id_persona " +
                    "where id_usuario= @id", sqlConnection);
                cmdBuscaPersona.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drPersona = cmdBuscaPersona.ExecuteReader();
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
                    p.TipoPersona = (Persona.TipoPersonas)drPersona["tipo_persona"];
                    p.IdPlan = (int)drPersona["id_plan"];
                }
                drPersona.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return p;
        }

        public Persona BuscaPersonaxNombApeEm(string Nombre, string Apellido, string Email)
        {
            Persona per = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("Select * from personas where nombre= @nombre and apellido=@apellido and email=@email", sqlConnection);
                cmdPersonas.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Nombre;
                cmdPersonas.Parameters.Add("@apellido", SqlDbType.VarChar).Value = Apellido;
                cmdPersonas.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;


                SqlDataReader drUsuarios = cmdPersonas.ExecuteReader();
                if (drUsuarios.Read())
                {
                    per.ID = (int)drUsuarios["id_persona"];
                    per.Nombre = (string)drUsuarios["nombre"];
                    per.Apellido = (string)drUsuarios["apellido"];
                    per.Direccion = (string)drUsuarios["direccion"];
                    per.Email = (string)drUsuarios["email"];
                    per.Telefono = (string)drUsuarios["telefono"];
                    per.FechaNac = (DateTime)drUsuarios["fecha_nac"];
                    per.Legajo = (int)drUsuarios["legajo"];
                    per.TipoPersona = (Persona.TipoPersonas)(int)drUsuarios["tipo_persona"];
                    per.IdPlan = (int)drUsuarios["id_plan"];
                }
                drUsuarios.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return per;
        }

        public void CargarIDPersona(Usuario usuario, int idPersona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into usuarios(nombre_usuario,clave,habilitado,nombre,apellido,email,id_persona) " +
                "Values(@nombre_usuario,@clave,@habilitado,@nombre,@apellido,@email,@id_persona) ", sqlConnection);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = idPersona;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void ActualizarPersona(Usuario usuario, int idPersona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE usuarios SET nombre_usuario=@nombre_usuario, clave=@clave, habilitado=@habilitado, nombre=@nombre, apellido=@apellido, email=@email, id_persona=@id_persona " +
                    "where id_usuario=@id", sqlConnection);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = idPersona;
                cmdSave.ExecuteNonQuery();

                SqlCommand cmdSave2 = new SqlCommand(
                    "UPDATE personas SET nombre=@nombre, apellido=@apellido, email=@email " +
                    "where id_persona=@id_persona ", sqlConnection);
                cmdSave2.Parameters.Add("@id_persona", SqlDbType.Int).Value = idPersona;
                cmdSave2.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave2.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave2.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave2.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception er = new Exception("Error al actualizar los datos de usuario", e);
                throw er;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public bool Autenticar(string usuario, string contrasenia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdAutenticar = new SqlCommand("select * from usuarios where nombre_usuario = @usuario and clave = @contrasenia", sqlConnection);
                cmdAutenticar.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = usuario;
                cmdAutenticar.Parameters.Add("@contrasenia", SqlDbType.NVarChar).Value = contrasenia;
                SqlDataReader drAutenticacion = cmdAutenticar.ExecuteReader();
                return drAutenticacion.Read();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos para iniciar sesion", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
