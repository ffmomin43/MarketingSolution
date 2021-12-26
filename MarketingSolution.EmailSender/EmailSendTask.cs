using MarketingSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using MarketingSolution.Repository.EF;

namespace MarketingSolution.EmailSender
{
    public class EmailSendTask
    {
        private MarketingContext context;
        public EmailSendTask()
        {
            context = new MarketingContext();
        }

        public void SendToReceivers(Receiver receiver)
        {

            var emailBody = context.EmailTemplates.Where(x => x.Id == 1).SingleOrDefault().TemplateHtml;


            using (MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], receiver.Email))
            {
                try
                {
                    mm.Subject = "test Email subject";
                    mm.Body = emailBody;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ConfigurationManager.AppSettings["Host"];
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"]);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                    Console.WriteLine("Sending Email......");
                    smtp.Send(mm);
                    Console.WriteLine($"Email Sent to {receiver.Email}");
                    receiver.IsProcessed = true;
                    context.Entry<Receiver>(receiver).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }
                
                
            }
        }
    }
}
