using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Feed_Production.Models;
using Feed_Production.Repository;

namespace FeedProductionWebApp.Controllers
{
    public class MOpningBalnceController : Controller
    {
        // GET: MOpningBalnce
        public ActionResult MOpningBalnceView()
        {
            return View();
        }
        public ActionResult Post(MOpningBalnce_Models model)
        {
            int serverresponce;
            model.EntryType = "ADO";
            model.AcFlag = "Y";
            model.CreatedOn = DateTime.Now;
            model.CreatedBy = 1;
            MOpeningBalanceRepository repo = new MOpeningBalanceRepository();
            serverresponce = repo.SaveOrUpdate(model);
            return RedirectToAction("MOpningBalnceView");
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