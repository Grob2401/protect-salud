using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//'Entidades.ENUbigeoDpto' no contiene una propiedad con el nombre 'CodigoDpto'.'

namespace Entidades
{
    public class ENUbigeoDpto
    {
        public string CodigoDpto { get; set; }
        public string DescripcionDpto { get; set; }
    }

    public class ENUbigeoProv
    {
        public string CodigoProv { get; set; }
        public string DescripcionProv { get; set; }
    }
    public class ENUbigeoDist
    {
        public string CodigoDist { get; set; }
        public string DescripcionDist { get; set; }
    }

    public class ENUbigeoCompleto
    {
        public string CodigoDpto { get; set; }
        public string DescripcionDpto { get; set; }
        public string CodigoProv { get; set; }
        public string DescripcionProv { get; set; }
        public string CodigoDist { get; set; }
        public string DescripcionDist { get; set; }
    }





}
