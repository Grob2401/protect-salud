using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{

    public class ENSaludAsegurados
    {

        public int RowNumber { get; set; }
        public string ApellidoMaterno { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidosNombres { get; set; }
        public string Asegurado { get; set; }
        public int CantidadCarnet { get; set; }
        public string Categoria { get; set; }
        public string Celular { get; set; }
        public string CodigoCentroCosto { get; set; }
        public string DescripcionCentroCosto { get; set; }
        public string CodigoCliente { get; set; }
        public string CodigoContrato { get; set; }
        public string CodigoPlan { get; set; }
        public string CodigoCotizacion { get; set; }
        public string CodigoDocumentoIdentidad { get; set; }
        public string DescripcionDocumentoIdentidad { get; set; }
        public string CodigoParentesco { get; set; }
        public string DescripcionParentesco { get; set; }
        public string CodigoSexo { get; set; }
        public string CodigoTipoTrabajador { get; set; }
        public string CodigoTitular { get; set; }
        public string CodigoTrabajador { get; set; }
        public string CodigoUbigeo { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string CodFechaAlta { get; set; }
        public DateTime FechaAlta { get; set; }
        public string CodFechaBaja { get; set; }
        public DateTime FechaBaja { get; set; }
        public DateTime FechaEmisionCarnet { get; set; }
        public DateTime FechaFinLatencia { get; set; }
        public DateTime FechaInicioLatencia { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime InicioVigencia { get; set; }
        public DateTime FinVigencia { get; set; }
        public DateTime FechaReemisionCarnet { get; set; }
        public string Nombres { get; set; }
        public string NumeroDocumentoIdentidad { get; set; }
        public string Peso { get; set; }
        public DateTime RegAddDate { get; set; }
        public string RegAddUser { get; set; }
        public DateTime RegEdtDate { get; set; }
        public string RegEdtUser { get; set; }
        public string SCTREstadoCivil { get; set; }
        public string SCTRMoneda { get; set; }
        public string SCTRPSCertificado { get; set; }
        public string SCTRSueldo { get; set; }
        public string SCTRTipoTrabajador { get; set; }
        public string Talla { get; set; }
        public string Telefono { get; set; }
        public string Edad { get; set; }
        public string Pais { get; set; }

        public string CodigoDpto { get; set; }
        public string DescripcionDpto { get; set; }
        public string CodigoProv { get; set; }
        public string DescripcionProv { get; set; }
        public string CodigoDist { get; set; }
        public string DescripcionDist { get; set; }
        public string CodigoVendedor { get; set; }
        //---
        public string CodigoMedico { get; set; }
        public DateTime FechaIniAdscrip { get; set; }
        public string PreExistCodigos { get; set; }
        public string PreExistOtros { get; set; }
        public string AppUserCodigo { get; set; }
        public string CodigoPlanOriginal { get; set; }
        public string CodigoTipoEstadoCivil { get; set; }

        public string CodigoTipoCliente { get; set; }
        public string RazonSocial { get; set; }
        public string RucDni { get; set; }


    }
}