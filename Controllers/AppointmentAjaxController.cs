using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsertAppointment.Controllers
{
    public class AppointmentAjaxController : Controller
    {
        NewDBAppointmentEntities db = new NewDBAppointmentEntities();
        // GET: AppointmentAjax
        [HttpGet]
        public ActionResult Index()
        {

            return View(db.AppointmentTBLs.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AppointmentTBL appointment)
        {
            var app = db.AppointmentTBLs.SingleOrDefault(c => c.ConsumerName == appointment.ConsumerName);
            if (app == null)
            {
                db.AppointmentTBLs.Add(appointment);
                db.SaveChanges();
                //return RedirectToAction("index");
                return Content("Record Added Successfully");
            }
            //return View("index");
            return Content("Already Existed");
        }
    }
}