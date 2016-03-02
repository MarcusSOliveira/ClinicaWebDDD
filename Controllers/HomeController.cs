using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aula_08.Models;

namespace Aula_08.Controllers
{ 
    public class HomeController : Controller
    {
        private VeiculosEntities db = new VeiculosEntities();

        //
        // GET: /Home/

        public ViewResult Index()
        {
            return View(db.Carretas.ToList());
        }

        //
        // GET: /Home/Details/5

        public ViewResult Details(int id)
        {
            Carretas carretas = db.Carretas.Find(id);
            return View(carretas);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Carretas carretas)
        {
            if (ModelState.IsValid)
            {
                db.Carretas.Add(carretas);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(carretas);
        }
        
        //
        // GET: /Home/Edit/5
 
        public ActionResult Edit(int id)
        {
            Carretas carretas = db.Carretas.Find(id);
            return View(carretas);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(Carretas carretas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carretas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carretas);
        }

        //
        // GET: /Home/Delete/5
 
        public ActionResult Delete(int id)
        {
            Carretas carretas = db.Carretas.Find(id);
            return View(carretas);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Carretas carretas = db.Carretas.Find(id);
            db.Carretas.Remove(carretas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            try
            {
                this.View(actionName).ExecuteResult(this.ControllerContext);
            }
            catch (InvalidOperationException)
            {

                this.View("NotFound").ExecuteResult(this.ControllerContext);
            }
        }


    }
}