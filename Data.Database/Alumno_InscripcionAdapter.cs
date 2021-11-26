using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    class Alumno_InscripcionAdapter: Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Alumnos_Inscripciones> _Alumnos_Inscripciones;

        private static List<Alumnos_Inscripciones> Alumnos_Inscripciones
        {
            get
            {
                if (_Alumnos_Inscripciones == null)
                {
                    _Alumnos_Inscripciones = new List<Alumnos_Inscripciones>();
                    Alumnos_Inscripciones al_insc;
                    al_insc = new Alumnos_Inscripciones();
                    al_insc.ID = 1;
                    al_insc.State = BusinessEntity.States.Unmodified;
                    al_insc.IDAlumno = 1;
                    al_insc.IDCurso = 1;
                    al_insc.Nota = 9;
                    _Alumnos_Inscripciones.Add(al_insc);

                    al_insc = new Alumnos_Inscripciones();
                    al_insc.ID = 2;
                    al_insc.State = BusinessEntity.States.Unmodified;
                    al_insc.IDAlumno = 2;
                    al_insc.IDCurso = 2;
                    al_insc.Nota = 8;
                    _Alumnos_Inscripciones.Add(al_insc);

                    al_insc = new Alumnos_Inscripciones();
                    al_insc.ID = 3;
                    al_insc.State = BusinessEntity.States.Unmodified;
                    al_insc.IDAlumno = 3;
                    al_insc.IDCurso = 1;
                    al_insc.Nota = 7;
                    _Alumnos_Inscripciones.Add(al_insc);

                }
                return _Alumnos_Inscripciones;
            }
        }
        #endregion

        public List<Alumnos_Inscripciones> GetAll()
        {
            return new List<Alumnos_Inscripciones>(Alumnos_Inscripciones);
        }

        public Alumnos_Inscripciones GetOne(int ID)
        {
            return Alumnos_Inscripciones.Find(delegate (Alumnos_Inscripciones ai) { return ai.ID == ID; });
        }

        public void Delete(int ID)
        {
            Alumnos_Inscripciones.Remove(this.GetOne(ID));
        }

        public void Save(Alumnos_Inscripciones alumnos_inscripciones)
        {
            if (alumnos_inscripciones.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Alumnos_Inscripciones alinsc in Alumnos_Inscripciones)
                {
                    if (alinsc.ID > NextID)
                    {
                        NextID = alinsc.ID;
                    }
                }
                alumnos_inscripciones.ID = NextID + 1;
                Alumnos_Inscripciones.Add(alumnos_inscripciones);
            }
            else if (alumnos_inscripciones.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alumnos_inscripciones.ID);
            }
            else if (alumnos_inscripciones.State == BusinessEntity.States.Modified)
            {
                Alumnos_Inscripciones[Alumnos_Inscripciones.FindIndex(delegate (Alumnos_Inscripciones alinsc) { return alinsc.ID == alumnos_inscripciones.ID; })] = alumnos_inscripciones;
            }
            alumnos_inscripciones.State = BusinessEntity.States.Unmodified;
        }
    }
}
