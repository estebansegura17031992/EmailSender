using EmailSender.Helpers;
using EmailSender.Models;
using EmailSenderDAO;
using EmailSenderDAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
            //1. Envio de Correo con Sendgrid
            EmailHelper emailHelper = new EmailHelper();
            await emailHelper.SendGeneralEmail(email.Email, email.Subject, email.Body);

            //2. Almacenar datos del correo
            Mail mail = new Mail();
            mail.ToEmail = email.Email;
            mail.Subject = email.Subject;
            mail.Body = email.Body;
            mail.SendDate = DateTime.Today;
            mail.Status = 1;

            Repository repository = new Repository();
            repository.SaveEmail(mail);
            return Json(email);
        }
    }
}