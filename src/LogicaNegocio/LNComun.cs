using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LNComun
    {
        public static void m_sumador(int a, int b)
        {
            Console.WriteLine("(Metodo) La suma es " + (a + b));
        }

        #region Funciones
        public static int f_sumador(int a, int b)
        {
            int suma = a + b;
            return suma;
        }

        //Declaracion Metodo


        #endregion

        public static void Main(string[] args)
        {

            int a = 5;
            int b = 10;
            int suma = f_sumador(a, b); //llamada funcion
            Console.WriteLine("(Funcion) La suma es " + suma);
            m_sumador(a, b); //Llamada metodo
            Console.ReadLine();
        }

        //Declaracion Funcion


        #region Consultas Base de  Datos

        //public List<ENDatosError> dsEmitirIndividual(ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal)
        //{
        //    return new ADCommon().YSCTREmisionIndividual(oENSCTR_EmisionTemporal);

        //}


        public DataSet DSETEmitirIndividual(ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal)
        {
            return new ADCommon().SCTREmitirIndividual(oENSCTR_EmisionTemporal);
        }

        public List<ENDatosError> ListaEmitirIndividual(ENSCTR_EmisionTemporal oENSCTR_EmisionTemporal)
        {
            return new ADCommon().ListaSCTREmitirIndividual(oENSCTR_EmisionTemporal);

        }


        #endregion

    }
}
