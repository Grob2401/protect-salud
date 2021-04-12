using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ENUsuario
    {
        public int int_IdUsuario { get; set; }
        public string var_Nombre { get; set; }
        public string var_Apellidos { get; set; }
        public string var_Mail { get; set; }
        public bool? bit_Sexo { get; set; }
        public int int_Estado { get; set; }
        public string var_Password { get; set; }
        public DateTime? dtm_FechaNacimiento { get; set; }
        public string var_DNI { get; set; }
        public DateTime? dtm_FechaRegistro { get; set; }
        public DateTime? dtm_FechaModificacion { get; set; }
    }
}
