using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ModuloUsuarioLogic : BusinessLogic
    {
        private ModuloUsuarioAdapter _muData;
        public ModuloUsuarioAdapter MuData
        {
            get { return _muData; }
            set { _muData = value; }
        }
        public ModuloUsuarioLogic()
        {
            MuData = new ModuloUsuarioAdapter();
        }

        public ModuloUsuario GetOne(int id)
        {
            return MuData.GetOne(id);
        }

        public List<ModuloUsuario> GetAll()
        {
            return MuData.GetAll();

        }

        public void Save(ModuloUsuario m)
        {
            MuData.Save(m);
        }

        public void Delete(int id)
        {
            MuData.Delete(id);
        }
    }
}
