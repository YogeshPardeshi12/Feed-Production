using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Feed_Production.Models;
using Feed_Production.Repository;

namespace FeedProductionWebApp.Controllers
{
    public class MExpensesController : Controller
    {
        // GET: MExpenses
        public ActionResult MExpensesView()
        {
            return View();
        }
        public ActionResult ReportMExpenses()
        {
            MExpensesRpository repo = new MExpensesRpository();
            List<MExpenses_Models> list = new List<MExpenses_Models>();
            list = repo.ReportMExpenses();
            return View(list);
        }
        public ActionResult Post(MExpenses_Models model)
        {
            int serverresponce;
            model.EntryType = "ADO";
            model.AcFlag = "Y";
            model.CreatedOn = DateTime.Now;
            model.CreatedBy = 1;
            MExpensesRpository repo = new MExpensesRpository();
            serverresponce = repo.SaveOrUpdate(model);
            return RedirectToAction("MExpensesView");
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