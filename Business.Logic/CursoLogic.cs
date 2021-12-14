using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class CursoLogic
    {
        public CursoAdapter CursoData { get; set; }

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public Curso GetOne(int id)
        {
            return CursoData.GetOne(id);
        }

        public List<Curso> GetAll()
        {
            return CursoData.GetAll();

        }

        public void Save(Curso cur)
        {
            CursoData.Save(cur);
        }

        public void Delete(int id)
        {
            CursoData.Delete(id);
        }

        public List<Docente_Curso> GetDocentesCurso(int idCurso)
        {
            return CursoData.GetDocentesCurso(idCurso);
        }

        public List <Comision> GetComisionesXMateria(int idMateria)
        {
            return CursoData.GetComisionesXMateria(idMateria);
        }

        public void ActualizaCupo(int id)
        {
            CursoData.ActualizaCupo(id);        
        }
    }
}
