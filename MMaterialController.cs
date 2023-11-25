using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Feed_Production.Models;
using Feed_Production.Repository;

namespace FeedProductionWebApp.Controllers
{
    public class MMaterialController : Controller
    {
        // GET: MMaterial
        public ActionResult MMaterialView()
        {
            return View();
        }
        public ActionResult Post(MMaterial_Models model)
        {
            int serverresponce;
            model.EntryType = "ADO";
            model.AcFlag = "Y";
            model.CreatedOn = DateTime.Now;
            model.CreatedBy = 1;
            MMaterialRepository repo = new MMaterialRepository();
            serverresponce = repo.SaveOrUpdate(model);
            return RedirectToAction("MMaterialView");
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