using MarketingSolution.Models;
using MarketingSolution.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketingSolution.EmailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailSendTask emailSendTask = new EmailSendTask();

            MarketingContext marketingContext = new MarketingContext();
            List<Receiver> receivers = new List<Receiver>();
            try
            {
                receivers = marketingContext.Receivers.Where(x=>x.IsProcessed==false).ToList<Receiver>();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            foreach(var rec in receivers)
            {
                emailSendTask.SendToReceivers(rec);
            }
            
        }
    }
}
