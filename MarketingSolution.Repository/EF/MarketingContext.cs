using MarketingSolution.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketingSolution.Repository.EF
{
    public class MarketingContext: DbContext
    {
        public MarketingContext():base("MarketingConnSt")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Receiver> Receivers { get; set; }

        public DbSet<EmailTemplate> EmailTemplates { get; set; }
    }
}
