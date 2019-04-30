using System;
using System.Configuration;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
namespace EmailSender.Helpers
{
    public class EmailHelper
    {
        public async Task<ResponseHelper> SendGeneralEmail(string ToEmail, string Subject, string Body)
        {
            try
            {
                var apiKey = ConfigurationManager.AppSettings["ApiKeySendGRID"];
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("esteban.1703@hotmail.com", "Esteban Segura Beanvides SnowCapCR");
                var to = new EmailAddress(ToEmail, "Example User: " + ToEmail);
                var msg = MailHelper.CreateSingleEmail(from, to, Subject, Body, "");
                await client.SendEmailAsync(msg);

                ResponseHelper response = new ResponseHelper();
                response.Status = 200;
                response.Result = true;
                response.Message = "El correo fue enviado correctamente";

                return response;
                    
            } catch(Exception ex)
            {
                ResponseHelper response = new ResponseHelper();
                response.Status = 500;
                response.Result = false;
                response.Message = ex.InnerException.Message;

                return response;
            }
            
        }
    }
}