using MarketingSolution.Models;
using MarketingSolution.Repository.EF;
using MarketingSolution.WebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MarketingSolution.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        MarketingContext marketingContext;
        public DashboardController()
        {
            marketingContext = new MarketingContext();
        }
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public FileResult DownloadSample()
        {
            return File("/static/Sample.csv", "text/csv");
        }

        public ActionResult UploadCSV(HttpPostedFileBase fileBase)
        {

            var content = ReadFileContent(fileBase);
            var modelList = GetCSVModel(content);
            TempData["ModelList"] = modelList;
            return View(modelList);
        }


        public ActionResult ConfirmUpload()
        {
            List<CSVModel> modelList = (List<CSVModel>)TempData["ModelList"];
            List<Receiver> receivers = new List<Receiver>();

            foreach (var csv in modelList)
            {
                var rec = new Receiver()
                {
                    CreatedBy = "System",
                    CreatedOn = DateTime.Now,
                    Email = csv.Email,
                    FirstName = csv.FirstName,
                    IsActive = true,
                    LastName = csv.LastName,
                    IsProcessed=false
                };

                marketingContext.Receivers.Add(rec);
            }

            marketingContext.SaveChanges();

            return View("SuccessView");
        }
        private string ReadFileContent(HttpPostedFileBase fileBase)
        {
            string contents = string.Empty;
            if (fileBase.ContentLength == 0)
                return string.Empty;

            using (var ms = new System.IO.MemoryStream())
            {
                fileBase.InputStream.CopyTo(ms);
                ms.Position = 0;

                contents = new StreamReader(ms).ReadToEnd();
            }

            return contents;
        }


        private List<CSVModel> GetCSVModel(string content)
        {

            if (string.IsNullOrWhiteSpace(content))
                return null;



            var finalCSVModelList = new List<CSVModel>();
            var lines = content.Trim().Split('\n');

            if (lines.Count() <= 1)
                return null;

            for (int i = 1; i < lines.Length; i++)
            {
                var singleLine = lines[i];

                var fields = singleLine.Split(',');

                if (fields.Count() <= 3)
                {
                    continue;
                }

                var csvModel = new CSVModel()
                {
                    SrNo = fields[0].Trim(),
                    FirstName = fields[1].Trim(),
                    LastName = fields[2].Trim(),
                    Email = fields[3].Trim()
                };

                finalCSVModelList.Add(csvModel);
            }

            return finalCSVModelList;

        }
    }
}