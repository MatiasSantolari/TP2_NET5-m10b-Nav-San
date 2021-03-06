using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        private ComisionAdapter _ComisionData;

        public ComisionAdapter ComisionData
        {
            get { return _ComisionData; }
            set { _ComisionData = value; }
        }
        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public Comision GetOne(int id)
        {
            return ComisionData.GetOne(id);
        }

        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();

        }

        public void Save(Comision comi)
        {
            ComisionData.Save(comi);
        }

        public void Delete(int id)
        {
            ComisionData.Delete(id);
        }

        public List<Comision> GetComisiones(int id)
        {
            return ComisionData.GetComisiones(id);
        }

        public List<Curso> GetCursos(int id)
        {
            return ComisionData.GetCursos(id);
        }
    }
}
