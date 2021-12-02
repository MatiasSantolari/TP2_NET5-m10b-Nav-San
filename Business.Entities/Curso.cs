using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private int _id_materia;
        private int _id_comision;
        private int _anio_calendario;
        private int _cupo;

        public int IDMateria
        {
            get
            {
                return _id_materia;
            }
            set
            {
                _id_materia = value;
            }
        }
        public int IDComision
        {
            get
            {
                return _id_comision;
            }
            set
            {
                _id_comision = value;
            }
        }
        public int AnioCalendario
        {
            get
            {
                return _anio_calendario;
            }
            set
            {
                _anio_calendario = value;
            }
        }
        public int Cupo
        {
            get
            {
                return _cupo;
            }
            set
            {
                _cupo = value;
            }
        }
    }
}
