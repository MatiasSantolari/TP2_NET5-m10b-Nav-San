using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Alumnos_Inscripciones : BusinessEntity
    {
        private int _id_alumno;
        private int _id_curso;
        private string _condicion;
        private int _nota;

        public int IDAlumno
        {
            get
            {
                return _id_alumno;
            }
            set
            {
                _id_alumno = value;
            }
        }
        public int IDCurso
        {
            get
            {
                return _id_curso;
            }
            set
            {
                _id_curso = value;
            }
        }
        public string Condicion
        {
            get
            {
                return _condicion;
            }
            set
            {
                _condicion = value;
            }
        }
        public int Nota
        {
            get
            {
                return _nota;
            }
            set
            {
                _nota = value;
            }
        }
    }
}
