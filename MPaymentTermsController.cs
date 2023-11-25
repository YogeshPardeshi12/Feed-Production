using Feed_Production.Models;
using Feed_Production.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedProductionWebApp.Controllers
{
    public class MPaymentTermsController : Controller
    {
        // GET: MPaymentTerms
        public ActionResult MPaymentTermsView()
        {
            return View();
        }
        public ActionResult Post(MPaymentTerms_Models model)
        {
            int serverresponce;
            model.EntryType = "ADO";
            model.AcFlag = "Y";
            model.CreatedOn = DateTime.Now;
            model.CreatedBy = "";
            MPaymentTermsRepository repo = new MPaymentTermsRepository();
            serverresponce = repo.SaveOrUpdate(model);
            return RedirectToAction("MPaymentTermsView");
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