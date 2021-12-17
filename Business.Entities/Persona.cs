using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private string _email;
        private string _telefono;
        private DateTime _fecha_nac;
        private int _legajo;
        private TipoPersonas _tipo_persona;
        private int _id_plan;

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

        public string Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
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
        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
            }
        }
        public DateTime FechaNac
        {
            get
            {
                return _fecha_nac;
            }
            set
            {
                _fecha_nac = value;
            }
        }

        public int Legajo
        {
            get
            {
                return _legajo;
            }
            set
            {
                _legajo = value;
            }
        }
        public TipoPersonas TipoPersona
        {
            get
            {
                return _tipo_persona;
            }
            set
            {
                _tipo_persona = value;
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
        public enum TipoPersonas
        {
            Admin = 0,
            Docente = 1,
            Alumno = 2
        }
    }
}

