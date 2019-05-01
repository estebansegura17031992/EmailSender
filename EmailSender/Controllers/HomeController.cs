using EmailSender.Helpers;
using EmailSender.Models;
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
            try
            {
                RepositoryHelper repository = new RepositoryHelper();
                ResponseHelperMails response = repository.GetMails();

                return Json(response, JsonRequestBehavior.AllowGet);
            } catch(Exception ex)
            {
                ResponseHelper response = new ResponseHelper();
                response.Result = false;
                response.Status = 500;
                response.Message = ex.InnerException.Message;

                return Json(response, JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult GetMailsByFilter(string SearchString,string SearchBy)
        {
            RepositoryHelper repository = new RepositoryHelper();
            List<Mail> mails = new List<Mail>();
            mails = repository.GetMailsByFilter(SearchString, SearchBy);
            if(mails!=null)
                return Json(new ResponseHelperMails
                {
                    Result = true,
                    Status = 200,
                    Message = "Lista de correos",
                    Mails = mails
                }, JsonRequestBehavior.AllowGet);
            else
                return Json(new ResponseHelper
                {
                    Result = false,
                    Status = 500,
                    Message = "Error en la consulta"
                },JsonRequestBehavior.AllowGet);
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

                    RepositoryHelper repository = new RepositoryHelper();
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