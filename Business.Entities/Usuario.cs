using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        private string _nombre_usuario;
        private string _clave;
        private string _nombre;
        private string _apellido;
        private string _email;
        private bool _habilitado;
        private int _id_persona;
        
        public int IDPersona
        {
            get
            {
                return _id_persona;
            }
            set
            {
                _id_persona = value;
            }
        }


        public string NombreUsuario
        {
            get
            {
                return _nombre_usuario;
            }
            set
            {
                _nombre_usuario = value;
            }
        }
        public string Clave
        {
            get
            {
                return _clave;
            }
            set
            {
                _clave= value;
            }
        }
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }
        public string Apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public bool Habilitado
        {
            get
            {
                return _habilitado;
            }
            set
            {
                _habilitado = value;
            }
        }
    }
}
