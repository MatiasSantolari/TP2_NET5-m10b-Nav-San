using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    class ComisionAdapter:Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Comisiones> _Comisiones;

        private static List<Comisiones> Comisiones
        {
            get
            {
                if (_Comisiones == null)
                {
                    _Comisiones = new List<Comisiones>();
                    Comisiones com;
                    com = new Comisiones();
                    com.ID = 1;
                    com.State = BusinessEntity.States.Unmodified;
                    com.AnioEspecialidad = 2021;
                    com.DescComision = "1K1";
                    com.IDPlan = 1;
                    _Comisiones.Add(com);

                    com = new Comisiones();
                    com.ID = 2;
                    com.State = BusinessEntity.States.Unmodified;
                    com.AnioEspecialidad = 2021;
                    com.DescComision = "1K2";
                    com.IDPlan = 2;
                    _Comisiones.Add(com);

                    com = new Comisiones();
                    com.ID = 3;
                    com.State = BusinessEntity.States.Unmodified;
                    com.AnioEspecialidad = 2020;
                    com.DescComision = "3K1";
                    com.IDPlan = 3;
                    _Comisiones.Add(com);

                }
                return _Comisiones;
            }
        }
        #endregion

        public List<Comisiones> GetAll()
        {
            return new List<Comisiones>(Comisiones);
        }

        public Comisiones GetOne(int ID)
        {
            return Comisiones.Find(delegate (Comisiones com) { return com.ID == ID; });
        }

        public void Delete(int ID)
        {
            Comisiones.Remove(this.GetOne(ID));
        }

        public void Save(Comisiones comisiones)
        {
            if (comisiones.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Comisiones com in Comisiones)
                {
                    if (com.ID > NextID)
                    {
                        NextID = com.ID;
                    }
                }
                comisiones.ID = NextID + 1;
                Comisiones.Add(comisiones);
            }
            else if (comisiones.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comisiones.ID);
            }
            else if (comisiones.State == BusinessEntity.States.Modified)
            {
                Comisiones[Comisiones.FindIndex(delegate (Comisiones c) { return c.ID == comisiones.ID; })] = comisiones;
            }
            comisiones.State = BusinessEntity.States.Unmodified;
        }
    }
}
