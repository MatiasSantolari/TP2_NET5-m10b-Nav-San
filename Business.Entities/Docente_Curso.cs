using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Docente_Curso : BusinessEntity
    {
        private cargos _cargo;
        private int _id_curso;
        private int _id_docente;
        public enum cargos
        {
            Profesor = 1,
            Auxiliar = 2
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
        public int IDDocente
        {
            get
            {
                return _id_docente;
            }
            set
            {
                _id_docente = value;
            }
        }

        public cargos Cargo
        {
            get
            {
                return _cargo;
            }
            set
            {
                _cargo = value;
            }
        }
    }
}
