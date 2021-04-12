using System;
using System.Collections.Generic;
using System.Data.Common;
using AccesoDatos;
using Entidades;
using System.Data;
using System.Data.SqlClient;


namespace LogicaNegocio
{

    public class LNSCTR_EmisionTemporal
    {
        public static List<ENSCTR_EmisionTemporal> ObtenerTodos()
        {
            return new ADSCTR_EmisionTemporal().ObtenerTodos();
        }

        public static bool Insertar(ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal)
        {
            return (new ADSCTR_EmisionTemporal()).Insertar(oENSCTR_EmisionTemporal);
        }

        public static bool Actualizar(ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal)
        {
            return (new ADSCTR_EmisionTemporal()).Actualizar(oENSCTR_EmisionTemporal);
        }

        //public static List<ENDatosError> SCTREmisionIndividual(ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal)
        //{
        //    return new ADSCTR_EmisionTemporal().SCTREmisionIndividual(oENSCTR_EmisionTemporal);
        //}

        //public DataSet DSETEmitirIndividual(ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal)
        //{
        //    return new ADCommon().SCTREmitirIndividual(oENSCTR_EmisionTemporal);
        //}

        public static List<ENDatosError> ListaSCTREmitirIndividual(ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal)
        {
            return new ADCommon().ListaSCTREmitirIndividual(oENSCTR_EmisionTemporal);
        }

    }
}



