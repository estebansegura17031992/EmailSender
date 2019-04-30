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