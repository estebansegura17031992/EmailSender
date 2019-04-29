using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;
namespace EmailSender.Helpers
{
    public class EmailHelper
    {
        public async Task SendGeneralEmail(string ToEmail, string Subject, string Body)
        {
            var apiKey = ConfigurationManager.AppSettings["ApiKeySendGRID"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("esteban.1703@hotmail.com", "Esteban Segura Beanvides SnowCapCR");
            var to = new EmailAddress(ToEmail, "Example User: "+ToEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, Subject, Body,"");
            var response = await client.SendEmailAsync(msg);
        }
    }
}