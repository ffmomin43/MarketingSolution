using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MarketingSolution.Models
{
   public class EmailTemplate: BaseModel
    {
        [AllowHtml]
        public string TemplateHtml { get; set; }
    }
}
