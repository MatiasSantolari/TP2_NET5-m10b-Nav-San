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
    public class ModuloUsuarioAdapter: Adapter
    {

        public List<ModuloUsuario> GetAll()
        {
            List<ModuloUsuario> modsUs = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModsUs = new SqlCommand("select * from modulos_usuarios", sqlConnection);
                SqlDataReader drModsUs = cmdModsUs.ExecuteReader();
                while (drModsUs.Read())
                {
                    ModuloUsuario mu = new ModuloUsuario();
                    mu.ID = (int)drModsUs["id_modulo_usuario"];
                    mu.IdModulo = (int)drModsUs["id_modulo"];
                    mu.IdUsuario = (int)drModsUs["id_usuario"];
                    mu.PermiteAlta = (bool)drModsUs["alta"];
                    mu.PermiteBaja = (bool)drModsUs["baja"];
                    mu.PermiteConsulta = (bool)drModsUs["consulta"];
                    mu.PermiteModificacion= (bool)drModsUs["modificacion"];
                    modsUs.Add(mu);
                }
                drModsUs.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de modulos_usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modsUs;
        }

        public ModuloUsuario GetOne(int ID)
        {
            ModuloUsuario mu = new ModuloUsuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModsUs = new SqlCommand("Select * from modulos_usuarios where id_modulo_usuario = @id", sqlConnection);
                cmdModsUs.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModsUs = cmdModsUs.ExecuteReader();
                if (drModsUs.Read())
                {
                    mu.ID = (int)drModsUs["id_modulo_usuario"];
                    mu.IdModulo = (int)drModsUs["id_modulo"];
                    mu.IdUsuario = (int)drModsUs["id_usuario"];
                    mu.PermiteAlta = (bool)drModsUs["alta"];
                    mu.PermiteBaja = (bool)drModsUs["baja"];
                    mu.PermiteConsulta = (bool)drModsUs["consulta"];
                    mu.PermiteModificacion = (bool)drModsUs["modificacion"];
                }
                drModsUs.Close();
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del modulo_usuario", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mu;
        }
        protected void Update(ModuloUsuario mu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE modulos_usuarios SET id_modulo=@id_modulo, id_usuario=@id_usuario, alta=@alta, baja=@baja, modificacion=@modificacion, consulta=@consulta where id_modulo_usuario=@id", sqlConnection);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = mu.ID;
                cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = mu.IdModulo;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = mu.IdUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.TinyInt).Value = mu.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.TinyInt).Value = mu.PermiteBaja;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.TinyInt).Value = mu.PermiteModificacion;
                cmdSave.Parameters.Add("@consulta", SqlDbType.TinyInt).Value = mu.PermiteConsulta;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Exception er = new Exception("Error al actualizar los datos del modulo_usuario", e);
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
                SqlCommand cmdDelete = new SqlCommand("delete modulos_usuarios where id_modulo_usuario=@id", sqlConnection);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el modulo_usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(ModuloUsuario mu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                "insert into modulos_usuarios(id_modulo,id_usuario,alta,baja,modificacion,consulta) " +
                "Values(@id_modulo,@id_usuario,@alta,@baja,@modificacion,@consulta)", sqlConnection);
                cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = mu.IdModulo;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = mu.IdUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.TinyInt).Value = mu.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.TinyInt).Value = mu.PermiteBaja;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.TinyInt).Value = mu.PermiteModificacion;
                cmdSave.Parameters.Add("@consulta", SqlDbType.TinyInt).Value = mu.PermiteConsulta;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear modulo_usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(ModuloUsuario mu)
        {
            if (mu.State == BusinessEntity.States.Deleted)
            {
                this.Delete(mu.ID);
            }
            else if (mu.State == BusinessEntity.States.New)
            {
                this.Insert(mu);
            }
            else if (mu.State == BusinessEntity.States.Modified)
            {
                this.Update(mu);
            }
            mu.State = BusinessEntity.States.Unmodified;
        }

    }
}
