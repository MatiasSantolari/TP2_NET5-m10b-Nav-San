using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    class CursosAdapter:Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Cursos> _Cursos;

        private static List<Cursos> Cursos
        {
            get
            {
                if (_Cursos == null)
                {
                    _Cursos = new List<Cursos>();
                    Cursos cur;
                    cur = new Cursos();
                    cur.ID = 1;
                    cur.State = BusinessEntity.States.Unmodified;
                    cur.AnioCalendario = 2021;
                    cur.Cupo = 40;
                    cur.IDComision = 1;
                    cur.IDMateria = 1;
                    _Cursos.Add(cur);

                    cur = new Cursos();
                    cur.ID = 2;
                    cur.State = BusinessEntity.States.Unmodified;
                    cur.AnioCalendario = 2021;
                    cur.Cupo = 435;
                    cur.IDComision = 1;
                    cur.IDMateria = 2;
                    _Cursos.Add(cur);

                    cur = new Cursos();
                    cur.ID = 3;
                    cur.State = BusinessEntity.States.Unmodified;
                    cur.AnioCalendario = 2021;
                    cur.Cupo = 450;
                    cur.IDComision = 2;
                    cur.IDMateria = 1;
                    _Cursos.Add(cur);

                }
                return _Cursos;
            }
        }
        #endregion

        public List<Cursos> GetAll()
        {
            return new List<Cursos>(Cursos);
        }

        public Cursos GetOne(int ID)
        {
            return Cursos.Find(delegate (Cursos c) { return c.ID == ID; });
        }

        public void Delete(int ID)
        {
            Cursos.Remove(this.GetOne(ID));
        }

        public void Save(Cursos cursos)
        {
            if (cursos.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Cursos cur in Cursos)
                {
                    if (cur.ID > NextID)
                    {
                        NextID = cur.ID;
                    }
                }
                cursos.ID = NextID + 1;
                Cursos.Add(cursos);
            }
            else if (cursos.State == BusinessEntity.States.Deleted)
            {
                this.Delete(cursos.ID);
            }
            else if (cursos.State == BusinessEntity.States.Modified)
            {
                Cursos[Cursos.FindIndex(delegate (Cursos c) { return c.ID == cursos.ID; })] = cursos;
            }
            cursos.State = BusinessEntity.States.Unmodified;
        }
    }
}
