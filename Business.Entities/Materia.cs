using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private string _desc_materia;
        private int _hs_semanales;
        private int _hs_totales;
        private int _id_plan;
        
        public string DescMateria
        {
            get
            {
                return _desc_materia;
            }
            set
            {
                _desc_materia = value;
            }
        }

        public int HsSemanales
        {
            get
            {
                return _hs_semanales;
            }
            set
            {
                _hs_semanales = value;
            }
        }

        public int HsTotales
        {
            get
            {
                return _hs_totales;
            }
            set
            {
                _hs_totales = value;
            }
        }

        public int IdPlan
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
    }
}
