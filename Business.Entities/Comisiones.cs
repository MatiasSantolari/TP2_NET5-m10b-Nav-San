using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comisiones : BusinessEntity
    {
        private int _id_plan;
        private string _desc_comision;
        private int _anio_especialidad;

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
        public int AnioEspecialidad
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
    }
}
