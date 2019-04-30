using EmailSenderDAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailSender.Helpers
{
    public class ResponseHelper
    {
        public bool Result { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }

    public class ResponseHelperMails: ResponseHelper
    {
        public List<Mail> Mails;
    }
}