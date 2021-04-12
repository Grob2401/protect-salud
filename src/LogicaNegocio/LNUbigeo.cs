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
    public class LNUbigeoDpto
    {
        public static List<ENUbigeoDpto> ObtenerDpto()
        {
            return new ADUbigeoDpto().ObtenerDpto();
        }


        public static ENUbigeoDpto ObtenerDptoUno(string CodigoDpto)
        {
            return (new ADUbigeoDpto()).ObtenerDptoUno(CodigoDpto);
        }
    }

    public class LNUbigeoProv
    {
        public static List<ENUbigeoProv> ObtenerProv(string idDpto)
        {
            return new ADUbigeoProv().ObtenerProv(idDpto);
        }

        public static ENUbigeoProv ObtenerProvUno(string CodigoDpto, string CodigoProv)
        {
            return (new ADUbigeoProv()).ObtenerProvUno(CodigoDpto, CodigoProv);
        }
    }

    public class LNUbigeoDist
    {
        public static List<ENUbigeoDist> ObtenerDist(string idDpto, string idProv)
        {
            return new ADUbigeoDist().ObtenerDist(idDpto,idProv);
        }

        public static ENUbigeoDist ObtenerDistUno(string CodigoDpto, string CodigoProv,string CodigoDist)
        {
            return (new ADUbigeoDist()).ObtenerDistUno(CodigoDpto, CodigoProv, CodigoDist);
        }
    }


    public class LNUbigeoCompleto
    {
        public static ENUbigeoCompleto ObtenerCompletoUno(string CodigoDpto, string CodigoProv, string CodigoDist)
        {
            return (new ADUbigeoCompleto()).ObtenerCompletoUno(CodigoDpto, CodigoProv, CodigoDist);
        }
    }


}
