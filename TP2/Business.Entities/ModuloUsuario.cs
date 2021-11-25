using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class ModuloUsuario : BusinessEntity
    {
        private int _id_modulo;
        private int _id_usuario;
        private bool _permite_alta;
        private bool _permite_baja;
        private bool _permite_modificacion;
        private bool _permite_consulta;

        public int IdModulo
        {
            get
            {
                return _id_modulo;
            }
            set
            {
                _id_modulo = value;
            }
        }
        public int IdUsuario
        {
            get
            {
                return _id_usuario;
            }
            set
            {
                _id_usuario= value;
            }
        }
        public bool PermiteBaja
        {
            get
            {
                return _permite_baja;
            }
            set
            {
                _permite_baja = value;
            }
        }
        public bool PermiteAlta
        {
            get
            {
                return _permite_alta;
            }
            set
            {
                _permite_alta = value;
            }
        }
        public bool PermiteModificacion
        {
            get
            {
                return _permite_modificacion;
            }
            set
            {
                _permite_modificacion = value;
            }
        }
        public bool PermiteConsulta
        {
            get
            {
                return _permite_consulta;
            }
            set
            {
                _permite_consulta = value;
            }
        }
    }
}
