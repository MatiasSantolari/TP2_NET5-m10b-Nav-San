using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;
using static System.Console;

namespace UI.Consola
{
    public class Usuarios
    {
        private UsuarioLogic _usuario_negocio;
        public UsuarioLogic UsuarioNegocio
        {
            get
            {
                return _usuario_negocio;
            }
            set
            {
                _usuario_negocio = value;
            }
        }
        public void Menu()
        {
            WriteLine("1 - Listado General");
            WriteLine("2 - Consulta");
            WriteLine("3 - Agregar");
            WriteLine("4 - Modificar");
            WriteLine("5 - Eliminar");
            WriteLine("6 - Salir");
            int resp = int.Parse(ReadLine());

            switch (resp)
            {
                case 1:
                    this.ListadoGeneral();
                    break;
                case 2:
                    this.Consultar();
                    break;
                case 3:
                    this.Agregar();
                    break;
                case 4:
                    this.Modificar();
                    break;
                case 5:
                    this.Eliminar();
                    break;

            }

        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach(Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }
        public void MostrarDatos(Usuario usr)
        {
            WriteLine("Usuario: {0}", usr.ID);
            WriteLine("\t\tNombre: {0}", usr.Nombre);
            WriteLine("\t\tApellido: {0}", usr.Apellido);
            WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            WriteLine("\t\tClave: {0}", usr.Clave);
            WriteLine("\t\tEmail: {0}", usr.Email);
            WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            //\t dentro de un strng representa un TAB
            WriteLine();
        }
        public void Consultar()
        {
            Clear();
            Write("Ingrese el ID del usuario a consultar");
            int ID = int.Parse(ReadLine());
            this.MostrarDatos(UsuarioNegocio.GetOne(ID));
        }
        public void Agregar()
        {

        }
        public void Modificar()
        {

        }
        public void Eliminar()
        {

        }
    }
}
