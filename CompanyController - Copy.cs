using Feed_Production.Models;
using Feed_Production.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedProductionWebApp.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult CompanyView()
        {
            return View();
        }
        public ActionResult ReportMCompany()
        {
            List<Company_Models> list = new List<Company_Models>();
            CompanyRepository repo = new CompanyRepository();
            list = repo.ReportMCompany();
            return View(list);
        }

        public ActionResult Post(Company_Models model)
        {
            int serverresponce;
            //string Message;
            model.AcFlag = "Y";
            model.CreatedOn= DateTime.Now;
            model.CreatedBy = 1;
            CompanyRepository repo = new CompanyRepository();
            serverresponce = repo.SaveOrUpdate(model);
            model.EntryType = "ADO";
           //int serverresponce = repo.SaveOrUpdate(model);
            return RedirectToAction("CompanyView");
            if (serverresponce == 1)
            {
                TempData["Message"] = "Data inserted Successfully";
            }
            if (serverresponce == 2)
            {
                TempData["Message"] = "Data Updated Successfully";
            }
            else
            {
                 TempData["Message"] = " OOps Something went wrong";
            }
        }
    }
}