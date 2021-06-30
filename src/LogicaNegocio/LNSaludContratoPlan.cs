using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{

    public class LNSaludContratoPlan
    {
        public static List<ENSaludContratoPlan> ObtenerTodos(string CodigoCliente, string CodigoContrato)
        {
            return new ADSaludContratoPlan().ObtenerTodos(CodigoCliente, CodigoContrato);
        }

        public static bool Insertar(ENSaludContratoPlan oENSaludContratoPlan)
        {
            return (new ADSaludContratoPlan()).Insertar(oENSaludContratoPlan);
        }

        public static bool Actualizar(ENSaludContratoPlan oENSaludContratoPlan)
        {
            return (new ADSaludContratoPlan()).Actualizar(oENSaludContratoPlan);
        }

        public static bool Eliminar(string contrato)
        {
            return (new ADSaludContratoPlan()).Eliminar(contrato);
        }

        public static ENSaludContratoPlan ObtenerUno(DateTime FechaInicioContratoPlan)
        {
            return (new ADSaludContratoPlan()).ObtenerUno(FechaInicioContratoPlan);
        }
    }
}

