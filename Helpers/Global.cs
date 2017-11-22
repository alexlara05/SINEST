using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using SINEST.Context;

namespace SINEST.Helpers
{
    public static class Global_Helper
    {
        /// <summary>
        /// Verifica si las variables de sesión del Usuario están creadas, Si existen (El Usuario Está Logueado) Retorna True
        /// </summary>
        /// <returns>true</returns>
        public static bool ifLoggedIn()
        {
            if (HttpContext.Current.Session["LoggedUserID"] != null && HttpContext.Current.Session["LoggedUserRoleID"] != null && HttpContext.Current.Session["LoggedUserRoleName"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public static void enviarEmail(MailAddress enviarDesde, MailAddress enviarA, string asunto, string cuerpoMensaje, string direccionRespuesta, bool enviarComoHtml)
        //{
        //    using (var db = new SinestContext())
        //    {
        //        var globalConfig = db.ConfiguracionGlobal.FirstOrDefault();

        //        var mensaje = new MailMessage();

        //        mensaje.From = enviarDesde;
        //        mensaje.ReplyToList.Add(direccionRespuesta);
        //        mensaje.Subject = asunto;

        //        mensaje.Body = cuerpoMensaje;
        //        mensaje.To.Add(enviarA);
        //        mensaje.IsBodyHtml = enviarComoHtml;

        //        var smtp = new SmtpClient();
        //        smtp.Host = globalConfig.Host;
        //        smtp.Port = globalConfig.Puerto;
        //        smtp.EnableSsl = globalConfig.Ssl;
        //        smtp.UseDefaultCredentials = globalConfig.DefaultCredentials;
        //        smtp.Credentials = new System.Net.NetworkCredential(globalConfig.UsuarioEmail, globalConfig.PasswordEmail);
        //        smtp.Send(mensaje);
        //    }

        //}
    }
}
