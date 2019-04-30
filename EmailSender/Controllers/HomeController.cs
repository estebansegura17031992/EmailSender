using EmailSender.Helpers;
using EmailSender.Models;
using EmailSenderDAO;
using EmailSenderDAO.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EmailSender.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Historial()
        {
            return View();
        }
        public ActionResult GetMails()
        {
            Repository repository = new Repository();
            List<Mail> mails = new List<Mail>();
            mails = repository.GetMails();

            return Json(mails, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> SendEmail(EmailModel email)
        {
            try
            {
                //1. Envio de Correo con Sendgrid
                EmailHelper emailHelper = new EmailHelper();
                ResponseHelper response = await emailHelper.SendGeneralEmail(email.Email, email.Subject, email.Body);

                if (response.Result)
                {
                    //2. Almacenar datos del correo
                    Mail mail = new Mail();
                    mail.ToEmail = email.Email;
                    mail.Subject = email.Subject;
                    mail.Body = email.Body;
                    mail.SendDate = DateTime.Now;
                    mail.Status = 1;

                    Repository repository = new Repository();
                    repository.SaveEmail(mail);
                    return Json(response);
                }
                else
                {
                    return Json(response);
                }
            } catch(Exception ex)
            {
                return Json(new ResponseHelper
                {
                    Result = false,
                    Status = 500,
                    Message = ex.InnerException.Message
                });
            }
            
        }
    }
}