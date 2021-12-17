using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private int _id_plan;
        private string _desc_comision;
        private Anios _anio_especialidad;

        public int IDPlan
        {
            get
            {
                return _id_plan;
            }
            set
            {
                _id_plan = value;
            }
        }
        public string DescComision
        {
            get
            {
                return _desc_comision;
            }
            set
            {
                _desc_comision = value;
            }
        }
        public Anios AnioEspecialidad
        {
            get
            {
                return _anio_especialidad;
            }
            set
            {
                _anio_especialidad = value;
            }
        }
        public enum Anios
        {
            Primero = 1,
            Segundo = 2,
            Tercero = 3,
            Cuarto = 4,
            Quinto = 5,
            Sexto = 6
        }
    }
}
