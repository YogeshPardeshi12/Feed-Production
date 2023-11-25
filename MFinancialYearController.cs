using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Feed_Production.Models;
using Feed_Production.Repository;

namespace FeedProductionWebApp.Controllers
{
    public class MFinancialYearController : Controller
    {
        // GET: MFinancialYear
        public ActionResult MFinancialYearView()
        {
            return View();
        }
        public ActionResult ReportMFinancialYear()
        {
            MFinancialYearRepository repo = new MFinancialYearRepository();
            List<MFinancialYear_Models> list = new List<MFinancialYear_Models>();
            list = repo.ReportMFinancialYear();
            return View(list);
        }
        public ActionResult Post(MFinancialYear_Models model)
        {
            int serverresponce;
            model.EntryType = "ADO";
            model.AcFlag = "Y";
            MFinancialYearRepository repo = new MFinancialYearRepository();
            serverresponce = repo.SaveOrUpdate(model);
            return RedirectToAction("MFinancialYearView");
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