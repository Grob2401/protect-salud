using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class ENTarjeta
    {
        public int IdClienteTarjetas { get; set; }
        public string CodigoCliente { get; set; }
        public string CodigoMarcaTarjeta { get; set; }
        public string NumeroTarjeta { get; set; }
        public DateTime FechaVencimientoTarjeta { get; set; }
        public string Token { get; set; }
        public string Estado { get; set; }
        public DateTime FechaVencimientoToken { get; set; }
        public DateTime InicioVigencia { get; set; }
        public DateTime FinVigencia { get; set; }
        public string NombreTarjeta { get; set; }
        public string mesFinVigencia { get; set; }
        public string anioFinVigencia { get; set; }
        public string titularTarjeta { get; set; }

    }
}

