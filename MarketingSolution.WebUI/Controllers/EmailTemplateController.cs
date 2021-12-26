using MarketingSolution.Models;
using MarketingSolution.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketingSolution.WebUI.Controllers
{
    public class EmailTemplateController : Controller
    {

        MarketingContext marketingContext;
        public EmailTemplateController()
        {
            marketingContext = new MarketingContext();
        }

        // GET: EmailTemplate
        public ActionResult Index()
        {
            var simgleTemplateObject = marketingContext.EmailTemplates.Where(x => x.Id == 1).SingleOrDefault();

            return View(simgleTemplateObject);
        }

        [HttpPost]
        public ActionResult SaveTemplate(EmailTemplate emailTemplate)
        {
            emailTemplate.CreatedBy = "System";
            
            marketingContext.Entry<EmailTemplate>(emailTemplate).State = System.Data.Entity.EntityState.Modified;

            marketingContext.SaveChanges();

            return View();
        }
    }
}