using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic: BusinessLogic
    {
        private PersonaAdapter _PersonaData;

        public PersonaAdapter PersonaData
        {
            get
            {
                return _PersonaData;
            }
            set
            {
                _PersonaData = value;
            }
        }

        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
            //creamos una instancia de PersonaAdapter y la asignamos a una variable/atributo de tipo PersonaAdapter.
        }
        public Persona GetOne(int id)
        {
            return PersonaData.GetOne(id);
        }

        public List<Persona> GetAll()
        {
            return PersonaData.GetAll();

        }

        public void Save(Persona perso)
        {
            PersonaData.Save(perso);
        }

        public void Delete(int id)
        {
            PersonaData.Delete(id);
        }

        public List<Persona> GetProfesores()
        {
            return PersonaData.GetProfesores();
        }

        public List<Persona> GetPersonasXTipo(Persona.TipoPersonas tipo_persona)
        {
            try
            {
                return this.PersonaData.GetPersonasXTipo(tipo_persona);
            }
            catch (Exception ex)
            {

                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de personas por tipo", ex);
                throw ExcepcionManejada;
            }
        }

        public Persona GetOne(string usr, string contra)
        {
            try
            {
                return this.PersonaData.GetOne(usr, contra);
            }
            catch (Exception ex)
            {

                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de personas por tipo", ex);
                throw ExcepcionManejada;
            }
        }
    }
}
