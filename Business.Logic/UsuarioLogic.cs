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
        public void Delete(int ID) => UsuarioData.Delete(ID);


    }
}
