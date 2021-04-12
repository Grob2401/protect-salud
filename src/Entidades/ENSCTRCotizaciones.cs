using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
     public class ENSCTRCotizaciones
    {
        public string CodigoPerfil { get; set; }
        public string CodigoCotizacion { get; set; }
        public string CodigoCliente { get; set; }
        public string CodigoCIIU { get; set; }
        public string CodigoCorredor { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public int TiempoCobertura { get; set; }
        [Display(Name = "Moneda")]
        public string CodigoMoneda { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public string CodigoUsuarioRegistro { get; set; }
        public string CodigoEstado { get; set; }
        public DateTime FechaHoraModificacion { get; set; }
        public int IdCotizacion { get; set; }
        public double PorcentajeTasa { get; set; }
        public double PorcentajeCorredor { get; set; }
        public double ImportePrimaNeta { get; set; }
        public double ImporteDerechoEmision { get; set; }
        public double ImporteIGV { get; set; }
        public double ImportePrimaTotal { get; set; }
        public double PorcentajeDerechoEmision { get; set; }
        public double PorcentajeIGV { get; set; }
        public double PorcentajeTasaPension { get; set; }
        public double PorcentajeCorredorPension { get; set; }
        public double ImportePrimaNetaPension { get; set; }
        public double ImporteDerechoEmisionPension { get; set; }
        public double ImporteIGVPension { get; set; }
        public double ImportePrimaTotalPension { get; set; }
        public string Origen { get; set; }
        public string PorcentajeTasaPensionOpe { get; set; }
        public string PorcentajeCorredorPensionOpe { get; set; }
        public string PSPoliza { get; set; }
        public string UbigeoRiesgo { get; set; }
        public string GrupoCIIU { get; set; }
        public string PrimaManual { get; set; }
        public string CodigoEjecutivo { get; set; }
        public string CodigoBrokerAsociado { get; set; }
        public string NroFacturacion { get; set; }
        public string EstadoFacturacion { get; set; }
        public string CodigoRenovacion { get; set; }
        public string EstadoRegistaroTXT { get; set; }
        public string CodigoSede { get; set; }

        [Display(Name = "RUC")]
        public string EmpresaRUC { get; set; }
        [Display(Name = "Razon_Social")]
        public string EmpresaNombre { get; set; }
        public string DescripcionCIIU { get; set; }
        public string DescripcionCorredor { get; set; }
        public string CodigoContrato { get; set; }
        public string ProcesoResultado { get; set; }
        public string ProcesoMensaje { get; set; }
        public string DescripcionEstado { get; set; }
        public string Direccion { get; set; }
        public string Ubigeo { get; set; }

        public string CodigoDpto { get; set; }
        public string DescripcionDpto { get; set; }
        public string CodigoProv { get; set; }
        public string DescripcionProv { get; set; }
        public string CodigoDist { get; set; }
        public string DescripcionDist { get; set; }


        public string CodigoDptoR { get; set; }
        public string DescripcionDptoR { get; set; }
        public string CodigoProvR { get; set; }
        public string DescripcionProvR { get; set; }
        public string CodigoDistR { get; set; }
        public string DescripcionDistR { get; set; }

        public DateTime? dtm_FechaInicio { get; set; }
        public DateTime? dtm_FechaFin { get; set; }

        public string DetCodigoCotizacionAdm { get; set; }
        public string DetItemAdm { get; set; }
        public string DetCodigoTipoEmpleadoAdm { get; set; }
        public double DetImporteDerechoEmisionAdm { get; set; }
        public double DetImporteDerechoEmisionPensionAdm { get; set; }
        public double DetImporteIGVAdm { get; set; }
        public double DetImporteIGVPensionAdm { get; set; }
        public double DetImportePrimaNetaAdm { get; set; }
        public double DetImportePrimaNetaPensionAdm { get; set; }
        public double DetImportePrimaTotalAdm { get; set; }
        public double DetImportePrimaTotalPensionAdm { get; set; }
        public double DetMontoPlanillaAdm { get; set; }
        public int DetNumeroTrabajadoresAdm { get; set; }
        public double DetPorcentajeCorredorAdm { get; set; }
        public double DetPorcentajeCorredorPensionAdm { get; set; }
        public double DetPorcentajeTasaAdm { get; set; }
        public double DetPorcentajeTasaPensionAdm { get; set; }

        public string DetCodigoCotizacionOpe { get; set; }
        public string DetItemOpe { get; set; }
        public string DetCodigoTipoEmpleadoOpe { get; set; }
        public double DetImporteDerechoEmisionOpe { get; set; }
        public double DetImporteDerechoEmisionPensionOpe { get; set; }
        public double DetImporteIGVOpe { get; set; }
        public double DetImporteIGVPensionOpe { get; set; }
        public double DetImportePrimaNetaOpe { get; set; }
        public double DetImportePrimaNetaPensionOpe { get; set; }
        public double DetImportePrimaTotalOpe { get; set; }
        public double DetImportePrimaTotalPensionOpe { get; set; }

        public double DetMontoPlanillaOpe { get; set; }

        public int DetNumeroTrabajadoresOpe { get; set; }
        public double DetPorcentajeCorredorOpe { get; set; }
        public double DetPorcentajeTasaOpe { get; set; }
        public double DetPorcentajeTasaPensionOpe { get; set; }
        public double DetPorcentajeCorredorPensionOpe { get; set; }

    }


    public class ENRespuestaCotizacion
    {
        public double ImportePrimaNeta { get; set; }
        public double ImporteDerechoEmision { get; set; }
        public double ImporteIGV { get; set; }
        public double ImportePrimaTotal { get; set; }
        public double PorcentajeTasa { get; set; }
        public double PorcentajeCorredor { get; set; }
    }

    public class Employee
    {
        public string Name
        {
            get;
            set;
        }
        public string Designation
        {
            get;
            set;
        }
        public string Location
        {
            get;
            set;
        }
        public string ImportePrima
        {   get; 
            set; 
        }
    }




    public class ENDatosEmitir
    {
        public string CodigoCotizacion { get; set; }
        public string EmpresaRUC { get; set; }
        public string EmpresaNombre { get; set; }
    }
}
