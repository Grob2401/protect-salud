using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LNCIIUPrincipal
    {
        public static List<ENCIIUPrincipal> ObtenerCIIUPrincipal()
        {
            return new ADCIUUPrincipal().ObtenerTodosPrincipal();
        }

        public static ENCIIUPrincipal ObtenerPrincipalUno(string CodigoGrupoCIIU)
        {
            return (new ADCIUUPrincipal()).ObtenerPrincipalUno(CodigoGrupoCIIU);
        }
    }

    public class LNCIIUEspecifica
    {
        public static List<ENCIIUEspecifica> ObtenerCIIUEspecifica(string idGrupo)
        {
            return new ADCIUUEspecifica().ObtenerTodosEspecifica(idGrupo);
        }

        public static ENCIIUEspecifica ObtenerEspecificaUno(string CodigoGrupoCIIU, string CodigoCIIU)
        {
            return (new ADCIUUEspecifica()).ObtenerEspecificaUno(CodigoGrupoCIIU, CodigoCIIU);
        }
    }
}
