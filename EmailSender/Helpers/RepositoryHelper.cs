using EmailSenderDAO.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System;
using EmailSender.Helpers;

namespace EmailSender.Helpers
{
    public class RepositoryHelper
    {
        SqlConnection connectionContext = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionEmailSenderDB"].ConnectionString);

        public ResponseHelperMails GetMails()
        {
            try
            {
                string sql = "SELECT Id, ToEmail, SendDate, Subject, Status, Body FROM Mail";
                List<Mail> mails = new List<Mail>();

                mails = connectionContext.Query<Mail>(sql).ToList();

                ResponseHelperMails response = new ResponseHelperMails();
                response.Status = 200;
                response.Message = "GetMails";
                response.Result = true;
                response.Mails = mails;

                return response;
            }
            catch(Exception ex)
            {
                ResponseHelperMails response = new ResponseHelperMails();
                response.Status = 500;
                response.Message = ex.Message;
                response.Result = false; ;

                return response;
            }
            
        }

        public List<Mail> GetMailsByFilter(string pSearchString, string SearchBy)
        {
            try
            {
                string sql = "";
                if (SearchBy == "email")
                    sql = "SELECT Id, ToEmail, SendDate, Subject, Status, Body FROM Mail WHERE ToEmail = @SearchString";
                else if (SearchBy == "subject")
                    sql = "SELECT Id, ToEmail, SendDate, Subject, Status, Body FROM Mail WHERE Subject = @SearchString";
                else
                    sql = "SELECT Id, ToEmail, SendDate, Subject, Status, Body FROM Mail WHERE SendDate = @SearchString";
                List<Mail> mails = new List<Mail>();

                mails = connectionContext.Query<Mail>(sql, new { SearchString = pSearchString }).ToList();
                return mails;
            }
            catch
            {
                return null;
            }
        }

        public int SaveEmail(Mail mail)
        {
            try
            {
                string sql = "INSERT INTO Mail(ToEmail,SendDate,Subject,Status,Body) VALUES(@ToEmail,@SendDate,@Subject,@Status,@Body)";
                int result = connectionContext.Execute(sql, mail);
                return result;
            } catch
            {
                return -1;
            }
            

        }
    }
}