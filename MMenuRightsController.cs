using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Feed_Production.Models;
using Feed_Production.Repository;

namespace FeedProductionWebApp.Controllers
{
    public class MMenuRightsController : Controller
    {
        // GET: MMenuRights
        public ActionResult MMenuRightsView()
        {
            return View();
        }
        public ActionResult Post(MMenuRights_Models model)
        {
            int serverresponce;
            model.EntryType = "ADO";
            model.AcFlag = "Y";
            model.CreatedOn = DateTime.Now;
            model.CreatedBy = 1;
            MMenuRightsRepository repo = new MMenuRightsRepository();
            serverresponce = repo.SaveOrUpdate(model);
            return RedirectToAction("MMenuRightsView");
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