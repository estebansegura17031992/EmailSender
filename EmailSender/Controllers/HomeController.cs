using EmailSenderDAO;
using EmailSenderDAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}