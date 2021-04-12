using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using Utilitarios;

namespace Excepciones
{
    public class ManejoExcepciones : Exception
    {
        private Exception _oException;
        private SqlException _oSQLException;
        private string _oExceptionMessage;
        private int _oExceptionError;

        public new string Message { get; private set; }

        public ManejoExcepciones() : base()
        {
            this._oException = new Exception();
        }
        public ManejoExcepciones(string strMessage)
        {
            this._oException = new Exception();
            this.Message = strMessage;
        }
        public ManejoExcepciones(int intError)
        {
            this._oException = new Exception();
            this._oExceptionError = intError;
            this.ShowCustomMessage(this._oExceptionError);
        }

        public ManejoExcepciones(Exception ex)
        {
            this._oSQLException = (SqlException)ex;
            this._oException = new Exception();
            this._oExceptionMessage = ex.Message;
            switch (this._oSQLException.Number)
            {
                case 50000:
                    {
                        if (int.TryParse(this._oSQLException.Message, out _oExceptionError))
                        {
                            this._oExceptionError = Convert.ToInt32(this._oSQLException.Message);
                            this.ShowCustomMessage(this._oExceptionError);
                        }
                        else
                            this.Message = this._oSQLException.Message;
                        break;

                    }

                default:
                    {
                        this._oExceptionError = this._oSQLException.Number;
                        this.ShowSQLMessage(this._oExceptionError, this._oSQLException);
                        break;

                    }
            }
        }



        private void ShowCustomMessage(int intError)
        {
            const string MensajeSistema = "Mensaje Sistema: ";
            switch (intError)
            {
                case 500100:
                    {
                        Message = MensajeSistema + "Los parámetros enviados son inválidos.";
                        break;

                    }

                case 500101:
                    {
                        Message = MensajeSistema + "Fila seleccionada inválida.";
                        break;

                    }

                case 500102:
                    {
                        Message = MensajeSistema + "Fecha es obligatoria.";
                        break;

                    }

                case 500103:
                    {
                        Message = MensajeSistema + "No puede elegir una fecha menor a la de hoy dia.";
                        break;

                    }

                case 500104:
                    {
                        Message = MensajeSistema + "Fecha inválida.";
                        break;

                    }

                case 500105:
                    {
                        Message = MensajeSistema + "Debe seleccionar una fecha.";
                        break;

                    }

                case 500106:
                    {
                        Message = MensajeSistema + "Ha ocurrido un error en el sistema. Favor de intentar de nuevo.";
                        break;

                    }

                case 500201:
                    {
                        Message = MensajeSistema + "Los datos del médico no han sido encontrados.";
                        break;

                    }

                case 500202:
                    {
                        Message = MensajeSistema + "Debe seleccionar un archivo.";
                        break;

                    }

                case 500203:
                    {
                        Message = MensajeSistema + "Error al subir el titulo profesional, debido a que no cumple con el formato especificado: Extension " + ExtensionArchivos.Archivo.ToUpper() + " y Menor a " + ConfigurationManager.AppSettings["TamañoTituloProfesional"] + "Kb.";
                        break;

                    }

                case 500204:
                    {
                        Message = MensajeSistema + "Error al subir la imágen, debido a que no cumple con el formato especificado: Extension " + ExtensionArchivos.Imagen.ToUpper() + " y Menor a " + ConfigurationManager.AppSettings["ValoresAppSettings.TamañoImagen"] + "Kb.";
                        break;

                    }

                case 500205:
                    {
                        Message = MensajeSistema + "Los datos del hijo no han sido encontrados.";
                        break;

                    }

                case 500206:
                    {
                        Message = MensajeSistema + "Debe ingresar un número en el campo Honorarios";
                        break;

                    }

                case 500207:
                    {
                        Message = MensajeSistema + "No existe un médico asignado a esa secretaria";
                        break;

                    }

                case 500208:
                    {
                        Message = MensajeSistema + "Médico seleccionado no cuenta con disponibilidades asignadas.";
                        break;

                    }

                case 500209:
                    {
                        Message = MensajeSistema + "Error al eliminar la disponibilidad debido a que Usted tiene citas asignadas en ese rango de horas.";
                        break;

                    }

                case 500210:
                    {
                        Message = MensajeSistema + "Esa disponibilidad ya está asignada a uno de sus consultorios.";
                        break;

                    }

                case 500211:
                    {
                        Message = MensajeSistema + "Ya existe esa disponibilidad para ese turno en el sistema. Si desea cambiarlo favor de buscarlo y actualizarlo.";
                        break;

                    }

                case 500212:
                    {
                        Message = MensajeSistema + "Esa disponibilidad ya está asignada a uno de sus consultorios.";
                        break;

                    }

                case 500213:
                    {
                        Message = MensajeSistema + "No se puede eliminar estas disponibilidades debido a que existen citas asignadas en ese rango de fechas.";
                        break;

                    }

                case 500214:
                    {
                        Message = MensajeSistema + "Opcion deshabilitada. Debe ingresar sus datos personales.";
                        break;

                    }

                case 500215:
                    {
                        Message = MensajeSistema + "Opcion deshabilitada. Debe ingresar los datos personales del médico.";
                        break;

                    }

                case 500216:
                    {
                        Message = MensajeSistema + "Debe ingresar por lo menos algun dato de su información académcia.";
                        break;

                    }

                case 500217:
                    {
                        Message = MensajeSistema + "No existe ningún título profesional a eliminar.";
                        break;

                    }

                case 500218:
                    {
                        Message = MensajeSistema + "Fecha de término no puede ser menor o igual a la fecha de inicio.";
                        break;

                    }

                case 500219:
                    {
                        Message = MensajeSistema + "No existe ningúna imágen a eliminar.";
                        break;

                    }

                case 500220:
                    {
                        Message = MensajeSistema + "Fecha de Pre-Grado no puede ser mayor que la de hoy día.";
                        break;

                    }

                case 500221:
                    {
                        Message = MensajeSistema + "Fecha de Post-Grado no puede ser mayor que la de hoy día.";
                        break;

                    }

                case 500222:
                    {
                        Message = MensajeSistema + "Fecha de Actualización no puede ser mayor que la de hoy día.";
                        break;

                    }

                case 500223:
                    {
                        Message = MensajeSistema + "Fecha de Publicación no puede ser mayor que la de hoy día.";
                        break;

                    }

                case 500224:
                    {
                        Message = MensajeSistema + "Fecha de Conferencia no puede ser mayor que la de hoy día.";
                        break;

                    }

                case 500225:
                    {
                        Message = MensajeSistema + "Fecha de Nacimiento no puede ser mayor que la de hoy día.";
                        break;

                    }

                case 500226:
                    {
                        Message = MensajeSistema + "Fecha de Nacimiento no puede ser mayor que la de hoy día.";
                        break;

                    }

                case 500227:
                    {
                        Message = MensajeSistema + "Error al asociar al médico con el proveedor.";
                        break;

                    }

                case 500251:
                    {
                        Message = MensajeSistema + "Los datos del asegurado no han sido encontrados.";
                        break;

                    }

                case 500252:
                    {
                        Message = MensajeSistema + "Error al afiliar a la persona. Intente de nuevo.";
                        break;

                    }

                case 500301:
                    {
                        Message = MensajeSistema + "Los datos del consultorio no han sido encontrados.";
                        break;

                    }

                case 500302:
                    {
                        Message = MensajeSistema + "No existen motivos de inasistencia. Favor de contactarse con el administrador del sistema.";
                        break;

                    }

                case 500303:
                    {
                        Message = MensajeSistema + "No existe la cita seleccionada.";
                        break;

                    }

                case 500304:
                    {
                        Message = MensajeSistema + "No existe un consultorio relacionado a dicho médico para la fecha de la cita seleccionada.";
                        break;

                    }

                case 500305:
                    {
                        Message = MensajeSistema + "No se puede realizar el cambio debido a que existen citas asignadas a ese turno.";
                        break;

                    }

                case 500306:
                    {
                        Message = MensajeSistema + "Usted no puede eliminar la cita debido a que ésta ya ha sido confirmada. Favor de comunicarse con el médico para anularla.";
                        break;

                    }

                case 500307:
                    {
                        Message = MensajeSistema + "Usted no puede eliminar la cita debido a que el estado de la cita es Libre.";
                        break;

                    }

                case 500308:
                    {
                        Message = MensajeSistema + "Usted no tiene los permisos necesarios para ver la informacion de la cita seleccionada.";
                        break;

                    }

                case 500309:
                    {
                        Message = MensajeSistema + "Usted no puede eliminar una cita cuya fecha es menor a la de hoy dia.";
                        break;

                    }

                case 500310:
                    {
                        Message = MensajeSistema + "Debe ingresar un número de contacto para poder confirmar la cita.";
                        break;

                    }

                case 500311:
                    {
                        Message = MensajeSistema + "No puede solicitar una cita cuya fecha sea menor a la de hoy dia.";
                        break;

                    }

                case 500312:
                    {
                        Message = MensajeSistema + "Usted no puede eliminar la cita debido a que el estado de la cita es Atendido.";
                        break;

                    }

                case 500313:
                    {
                        Message = MensajeSistema + "Usted no puede eliminar la cita debido a que el estado de la cita es Con Inasistencia.";
                        break;

                    }

                case 500351:
                    {
                        Message = MensajeSistema + "No existe ningún consultorio asignado al médico seleccionado. Favor de agregar consultorios.";
                        break;

                    }

                case 500352:
                    {
                        Message = MensajeSistema + "No existe ningún mapa a mostrar.";
                        break;

                    }

                case 500353:
                    {
                        Message = MensajeSistema + "No se han encontrado los turnos. Favor de contactarse con el administrador del sistema.";
                        break;

                    }

                case 500354:
                    {
                        Message = MensajeSistema + "Turno Mañana: Fecha de Inicio no puede ser mayor que la fecha fin.";
                        break;

                    }

                case 500355:
                    {
                        Message = MensajeSistema + "Turno Tarde: Fecha de Inicio no puede ser mayor que la fecha fin.";
                        break;

                    }

                case 500356:
                    {
                        Message = MensajeSistema + "Fecha inicio no puede ser mayor a fecha fin.";
                        break;

                    }

                case 500357:
                    {
                        Message = MensajeSistema + "Fecha inicio no puede ser mayor o igual a fecha fin.";
                        break;

                    }

                case 500358:
                    {
                        Message = MensajeSistema + "Debe seleccionar un consultorio";
                        break;

                    }

                case 500359:
                    {
                        Message = MensajeSistema + "Usted no tiene ningún consultorio aprobado.";
                        break;

                    }

                case 500360:
                    {
                        Message = MensajeSistema + "No se ha encontrado los datos del consultorio.";
                        break;

                    }

                case 500361:
                    {
                        Message = MensajeSistema + "No se encontró la fecha inicio del consultorio.";
                        break;

                    }

                case 500362:
                    {
                        Message = MensajeSistema + "Debe ingresar un número de contacto para solicitar la cita.";
                        break;

                    }

                case 500363:
                    {
                        Message = MensajeSistema + "No se puede eliminar este consultorio debido a que existen citas asignadas a dicho consultorio.";
                        break;

                    }

                case 500364:
                    {
                        Message = MensajeSistema + "Error al crear el usuario de la secretaria. Favor de intentar de nuevo. Si el problema continúa, favor de contactarse con el administrador del sistema.";
                        break;

                    }

                case 500365:
                    {
                        Message = MensajeSistema + "Usted no puede buscar las disponibilidades de fechas pasadas. Fecha de inicio debe de ser mayor a la siguiente fecha: " + DateTime.Now.Date.ToShortDateString();
                        break;

                    }

                case 500366:
                    {
                        Message = MensajeSistema + "Usted no puede eliminar disponibilidades con fechas pasadas. Fecha de inicio debe de ser mayor a la siguiente fecha: " + DateTime.Now.Date.ToShortDateString();
                        break;

                    }

                case 500367:
                    {
                        Message = MensajeSistema + "Usted no puede ingresar disponibilidades con fechas pasadas. Fecha de inicio debe de ser mayor a la siguiente fecha: " + DateTime.Now.Date.ToShortDateString();
                        break;

                    }

                case 500368:
                    {
                        Message = MensajeSistema + "Debe indicar un turno para ingresar la disponibilidad.";
                        break;

                    }

                case 500369:
                    {
                        Message = MensajeSistema + "No existe ningún consultorio asignado su médico.";
                        break;

                    }

                case 500451:
                    {
                        Message = MensajeSistema + "Los datos de los perfiles no han sido encontrados.";
                        break;

                    }

                case 500452:
                    {
                        Message = MensajeSistema + "Los datos de las especialidades no han sido encontradas";
                        break;

                    }

                case 500551:
                    {
                        Message = MensajeSistema + "No existe ningún usuario asignado para dicho consultorio.";
                        break;

                    }

                case 500552:
                    {
                        Message = MensajeSistema + "Los datos del usuario no han sido encontrados.";
                        break;

                    }

                case 500553:
                    {
                        Message = MensajeSistema + "Error al enviar el correo electrónico. Favor de intentar de nuevo dentro de 30 minutos.";
                        break;

                    }

                case 500554:
                    {
                        Message = MensajeSistema + "Error al enviar los datos de su cuenta a su correo electrónico. Favor de contactarse con el administrador del sistema para generarle una nueva contraseña.";
                        break;

                    }

                case 500555:
                    {
                        Message = MensajeSistema + "Su cuenta no ha sido activada. Para activar su cuenta: Favor de revisar su correo electrónico y hacer click al link indicado y/o contactarse con el administrador del sistema para su activación.";
                        break;

                    }

                case 500556:
                    {
                        Message = MensajeSistema + "Su cuenta ha sido bloqueada debido a que se hicieron muchos intentos fallidos. Favor de contactarse con el administrador del sistema para desbloquear su cuenta.";
                        break;

                    }

                case 500557:
                    {
                        Message = MensajeSistema + "Su cuenta ha sido bloqueada. Favor de contactarse con el administrador del sistema para desbloquear su cuenta y solicitar una nueva contraseña.";
                        break;

                    }

                case 500558:
                    {
                        Message = MensajeSistema + "Se ha pasado un codigo inválido por la url.";
                        break;

                    }

                case 500559:
                    {
                        Message = MensajeSistema + "Usuario no ha sido encontrado en nuestra base de datos. Intente de nuevo, si el error continua favor de contactarse con el administrador del sistema.";
                        break;

                    }

                case 500560:
                    {
                        Message = MensajeSistema + "Los datos del usuario de la secretaria no han sido encontrados.";
                        break;

                    }

                case 500561:
                    {
                        Message = MensajeSistema + "Correo electrónico inválido.";
                        break;

                    }

                case 500562:
                    {
                        Message = MensajeSistema + "Respuesta secreta inválida.";
                        break;

                    }

                case 500563:
                    {
                        Message = MensajeSistema + "Usted ha ingresado un correo electrónico inválido. Favor de contactarse con el administrador del sistema para generarle una nueva contraseña.";
                        break;

                    }

                case 500564:
                    {
                        Message = MensajeSistema + "Usted no ha seleccionado ningún perfil.";
                        break;

                    }

                case 500565:
                    {
                        Message = MensajeSistema + "Correo electrónico ya esta siendo usado. Favor de ingresar otro.";
                        break;

                    }

                case 500585:
                    {
                        Message = MensajeSistema + "Usuario ya esta siendo usado. Favor de ingresar otro.";
                        break;

                    }

                case 500594:
                    {
                        Message = MensajeSistema + "Ingresar una respuesta secreta válida.";
                        break;

                    }

                case 500595:
                    {
                        Message = MensajeSistema + "Correo electrónico inválido.";
                        break;

                    }

                case 500566:
                    {
                        Message = MensajeSistema + "Longitud mínima de la Contraseña: {0}. Caracteres no-alfanuméricos: {1}.";
                        break;

                    }

                case 500567:
                    {
                        Message = MensajeSistema + "Ingresar una pregunta secreta válida.";
                        break;

                    }

                case 500568:
                    {
                        Message = MensajeSistema + "La cuenta no ha sido creada. Favor de intentar de nuevo.";
                        break;

                    }

                case 500569:
                    {
                        Message = MensajeSistema + "Ingresar un usuario válido.";
                        break;

                    }

                case 500570:
                    {
                        Message = MensajeSistema + "Contraseñas no coinciden.";
                        break;

                    }

                case 500571:
                    {
                        Message = MensajeSistema + "Nueva Contraseña es obligatoria.";
                        break;

                    }

                case 500572:
                    {
                        Message = MensajeSistema + "Contraseña actual es obligatoria.";
                        break;

                    }

                case 500601:
                    {
                        Message = MensajeSistema + "No se han encontrado los datos de la adscripción.";
                        break;

                    }

                case 500602:
                    {
                        Message = MensajeSistema + "No se ha encontrado los datos del médico de la adscripción.";
                        break;

                    }

                case 500603:
                    {
                        Message = MensajeSistema + "No se ha encontrado los datos del plan de la adscripción.";
                        break;

                    }

                default:
                    {
                        Message = MensajeSistema + _oExceptionMessage;
                        break;

                    }
            }
        }

        private void ShowSQLMessage(int intError, SqlException ex)
        {
            const string MensajeSistema = "Mensaje SQL Server: ";
            switch (intError)
            {
                case 208:
                case 11:
                    {
                        Message = MensajeSistema + ex.Procedure + " en la linea: " + ex.LineNumber.ToString() + " - Detalles: " + ex.Message;
                        break;

                    }

                case 17:
                case 4060:
                    {
                        Message = MensajeSistema + "No se puede establecer conexion con la Base de Datos. Detalles: " + ex.Message;
                        break;

                    }

                case 547:
                    {
                        Message = MensajeSistema + "Conflicto con la clave foranea. Detalles: " + ex.Message;
                        break;

                    }

                case 2812:
                    {
                        Message = MensajeSistema + "Procedimiento almacenado incorrecto. Detalles: " + ex.Message;
                        break;
                    }

                case 2601:
                    {
                        Message = MensajeSistema + "Problema con el indice unique. Detalles: " + ex.Message;
                        break;

                    }

                default:
                    {
                        Message = MensajeSistema + ex.Message;
                        break;
                    }
            }
        }
    }
}
