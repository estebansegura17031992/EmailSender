using EmailSenderDAO.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
namespace EmailSenderDAO
{
    public class Repository
    {
        SqlConnection connectionContext = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionEmailSenderDB"].ConnectionString);

        public List<Mail> GetMails()
        {
            string sql = "SELECT Id, ToEmail, SendDate, Subject, Status, Body FROM Mail";
            List<Mail> mails = new List<Mail>();

            mails = connectionContext.Query<Mail>(sql).ToList();
            return mails;
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