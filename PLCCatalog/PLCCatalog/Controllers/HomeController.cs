using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PLCCatalog.Models;

namespace PLCCatalog.Controllers
{
    public class HomeController : Controller
    {
        PLCContext db = new PLCContext();
        public ActionResult Index()
        {
            var plcs = db.PLCs;
            ViewBag.PLCs = plcs;
            return View();
        }

        [HttpGet]
        public ActionResult Add(int id)
        {       
            ViewBag.PLCId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Add(PLC PLC)
        {
            if (PLC.Sphere1 != null) PLC.Sphere1 += "; ";
            if (PLC.Sphere2 != null) PLC.Sphere2 += "; ";
            if (PLC.Sphere3 != null) PLC.Sphere3 += "; ";
            if (PLC.Sphere4 != null) PLC.Sphere4 += "; ";
            PLC.Sphere = PLC.Sphere1 + PLC.Sphere2 + PLC.Sphere3 + PLC.Sphere4;
            db.PLCs.Add(PLC);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.PLCId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Delete(PLC PLC)
        {
            string DeletePLC = PLC.Name;
            db.PLCs.Remove(db.PLCs.Find(PLC.Id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            PLC plc = db.PLCs.Find(id);
            return View(plc);
        }

        [HttpPost]
        public ActionResult Edit(PLC PLC)
        {
            if (PLC.Sphere1 != null) PLC.Sphere1 += "; ";
            if (PLC.Sphere2 != null) PLC.Sphere2 += "; ";
            if (PLC.Sphere3 != null) PLC.Sphere3 += "; ";
            if (PLC.Sphere4 != null) PLC.Sphere4 += "; ";
            PLC.Sphere = PLC.Sphere1 + PLC.Sphere2 + PLC.Sphere3 + PLC.Sphere4;
            db.Entry(PLC).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}