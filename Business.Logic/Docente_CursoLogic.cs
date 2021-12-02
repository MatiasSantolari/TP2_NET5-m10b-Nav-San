using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class Docente_CursoLogic : BusinessLogic
    {
        public Docente_CursoAdapter docenteCursoData { get; set; }

        public Docente_CursoLogic()
        {
            docenteCursoData = new Docente_CursoAdapter();
        }

        public Docente_Curso GetOne(int id)
        {
            return docenteCursoData.GetOne(id);
        }

        public List<Docente_Curso> GetAll()
        {
            return docenteCursoData.GetAll();
        }

        public void Save(Docente_Curso dc)
        {
            docenteCursoData.Save(dc);
        }

        public void Delete(int id)
        {
            docenteCursoData.Delete(id);
        }


        public Curso BuscarCurso(int idMateria, int idComision)
        {
            return docenteCursoData.BuscarCurso(idMateria, idComision);
        }
    }
}
