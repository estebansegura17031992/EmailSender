using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailSenderDAO.Entities
{
    public class Mail
    {
        public int Id { get; set; }
        public string ToEmail { get; set; }
        public DateTime SendDate { get; set; }
        public string Subject { get; set; }
        public int Status { get; set; }
        public string Body { get; set; }

    }
}