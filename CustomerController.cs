using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Feed_Production.Models;
using Feed_Production.Repository;
using Feed_Production.Sql_Conection;

namespace FeedProductionWebApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult CustomerView()
        {
            return View();
        }
        public ActionResult ReportMCustomer()
        {
            List<Customer_Models> list = new List<Customer_Models>();
            CustomerRepository repo = new CustomerRepository();
            list = repo.ReportMCustomer();
            return View(list);
        }
        public ActionResult Post(Customer_Models model)
        {
            int serverresponce;
            model.AcFlag = "Y";
            model.CreatedOn = DateTime.Now;
            model.CreatedBy = 1;
            CustomerRepository repo = new CustomerRepository();
            serverresponce = repo.SaveOrUpdate(model);
            if(serverresponce == 1)
            {
                TempData["Message"] = "Data inserted Successfully";
            }
            if(serverresponce == 2)
            {
                TempData["Message"] = "Data Updated Successfully";
            }
            else
            {
                TempData["Message"] = "oops Something Went Wrong";
            }
            return RedirectToAction("CustomerView");

        }

    }
}