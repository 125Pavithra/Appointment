using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InsertAppointment.Controllers
{
    public class AppointmentController : Controller
    {
        NewDBAppointmentEntities db = new NewDBAppointmentEntities();
        // GET: Appointment
        [HttpGet]
        public ActionResult Index()
        {
           
            return View(db.AppointmentTBLs.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentTBL appointmentTbl = db.AppointmentTBLs.Find(id);
            if (appointmentTbl == null)
            {
                return HttpNotFound();
            }
            return View(appointmentTbl);
        }
        [HttpGet]
        public ActionResult Get(int id)
        {
            AppointmentTBL appointment = db.AppointmentTBLs.Where(x => x.AppointmentId == id).SingleOrDefault();
            
            return View(appointment);
        }
        //Post Method
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
                return RedirectToAction("index");
            }
            return View("index");
        }
        //Editing(Update)
        public ActionResult Edit(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentTBL appointmentTbl = db.AppointmentTBLs.Find(id);
            if (appointmentTbl == null)
            {
                return HttpNotFound();
            }
            return View(appointmentTbl);
        }
        [HttpPost]
        public ActionResult Edit(AppointmentTBL appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }
        //Deleting
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentTBL appointmentTbl = db.AppointmentTBLs.Find(id);
            if (appointmentTbl == null)
            {
                return HttpNotFound();
            }
            return View(appointmentTbl);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            AppointmentTBL appointmentTBL = db.AppointmentTBLs.Find(id);
            db.AppointmentTBLs.Remove(appointmentTBL);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}