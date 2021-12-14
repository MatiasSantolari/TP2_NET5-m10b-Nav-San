using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using System.Data;
using System.Data.SqlClient;



namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic   
    {
        private UsuarioAdapter _usuario_data;

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

        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }
        
        public Usuario GetOne(int ID) => UsuarioData.GetOne(ID);

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public void Save(Usuario usuario) => UsuarioData.Save(usuario);
        public void SavePlus(Usuario usuario, int idPersona) => UsuarioData.SavePlus(usuario, idPersona);
        public void Delete(int ID) => UsuarioData.Delete(ID);

        public Persona GetPersona(int id)
        {
            return UsuarioData.GetPersona(id);
        }

        public Persona BuscaPersonaxNombApeEm(string Nombre, string Apellido, string Email)
        {
            return UsuarioData.BuscaPersonaxNombApeEm(Nombre, Apellido, Email);
        }
        public void CargarIDPersona(Usuario usuario, int id)
        {
            UsuarioData.CargarIDPersona(usuario, id);
        }
        public void ActualizarPersona(Usuario usuario, int id)
        {
            UsuarioData.ActualizarPersona(usuario, id);
        }

    }
}
