using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class Alumnos_InscripcionesLogic : BusinessLogic
    {
        private Alumno_InscripcionAdapter _alumnos_inscripcionesData;
        public Alumno_InscripcionAdapter Alumnos_InscripcionesData
        {
            get { return _alumnos_inscripcionesData; }
            set { _alumnos_inscripcionesData = value; }
        }

        public Alumnos_InscripcionesLogic()
        {
            Alumnos_InscripcionesData = new Alumno_InscripcionAdapter();
        }

        public Alumnos_Inscripciones GetOne(int id)
        {
            return Alumnos_InscripcionesData.GetOne(id);
        }

        public List<Alumnos_Inscripciones> GetAll()
        {
            return Alumnos_InscripcionesData.GetAll();

        }

        public void Save(Alumnos_Inscripciones mat)
        {
            Alumnos_InscripcionesData.Save(mat);
        }

        public void Delete(int id)
        {
            Alumnos_InscripcionesData.Delete(id);
        }

        public Curso GetCurso(int idMateria, int idComision)
        {
            return Alumnos_InscripcionesData.GetCurso(idMateria, idComision);
        }
    }
}
