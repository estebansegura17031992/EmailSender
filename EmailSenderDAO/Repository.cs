using EmailSenderDAO.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
namespace EmailSenderDAO
{
    public class Repository
    {
        SqlConnection connectionContext = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionEmailSenderDB"].ConnectionString);

        public List<Mail> GetMails()
        {
            List<Mail> mails = new List<Mail>();

            mails = connectionContext.Query<Mail>("SELECT Id, ToEmail, SendDate, Subject, Status, Body FROM Mail").ToList();
            return mails;
        }
    }
}