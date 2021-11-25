using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Modulo : BusinessEntity
    {
        private string _desc_modulo;
        private string _ejecuta;
        public string DescModulo
        {
            get
            {
                return _desc_modulo;
            }
            set
            {
                _desc_modulo = value;
            }
        }
        public string Ejecuta
        {
            get
            {
                return _ejecuta;
            }
            set
            {
                _ejecuta = value;
            }
        }
    }
}
