using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class LNUsuario
    {
        public static List<ENUsuario> ObtenerTodos()
        {
            return new ADUsuario().ObtenerTodos();
        }
        public static ENUsuario ObtenerUno(int Id)
        {
            return new ADUsuario().ObtenerUno(Id);
        }
        public static bool Insertar(ENUsuario oENUsuaruo)
        {
            return (new ADUsuario()).Insertar(oENUsuaruo);
        }

        public static bool Actualizar(ENUsuario oENUsuaruo)
        {
            return (new ADUsuario()).Actualizar(oENUsuaruo);
        }

        public static ENUsuario ObtenerPorCorreoElectronico(string usuario)
        {
            return new ADUsuario().ObtenerPorCorreoElectronico(usuario);
        }

        public static bool Eliminar(int Id)
        {
            return (new ADUsuario()).Eliminar(Id);
        }
    }
}
