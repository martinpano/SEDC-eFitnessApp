using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SEDC.eFitness.Models;
using SEDC.eFitness.Repo;
using SEDC.eFitness.Services;

namespace SEDC.eFitness.Web.Controllers
{
    public class TrainersController : Controller
    {
        private TrainersManager manager = new TrainersManager();


        public ActionResult Home()
        {
            return View();
        }
        // GET: Trainers
        public ActionResult Index()
        {
            //var listOfTrainers = manager.ReturnAll();
            //var listOfTrainingTypes = manager.ReturnAllTrainingTypes();

            //var query = from tList in listOfTrainers
            //            join ttList in listOfTrainingTypes on tList.TrainingTypeId equals ttList.TrainingTypeId
            //             select ttList.Name;

            ViewBag.TrainingTypes = manager.ReturnAllTrainingTypes();



            return View(manager.ReturnAll());
        }

        // GET: Trainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = manager.Return(id.Value);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainers/Create
        public ActionResult Create()
        {
            ViewBag.TrainingTypes = manager.ReturnAllTrainingTypes();
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainerId,FullName,Phone,Email,ShotrBiography,ImagePath")] Trainer trainer, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    trainer.ImagePath = new byte[image.ContentLength];
                    image.InputStream.Read(trainer.ImagePath, 0, image.ContentLength);
                }

                manager.Create(trainer);
                return RedirectToAction("Index");
            }

            
            return View(trainer);
        }

        // GET: Trainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = manager.Return(id.Value);
            if (trainer == null)
            {
                return HttpNotFound();
            }

            ViewBag.TrainingTypes = manager.ReturnAllTrainingTypes();
            return View(trainer);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Phone,Email,ShotrBiography,ImagePath")] Trainer trainer, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    trainer.ImagePath = new byte[image.ContentLength];
                    image.InputStream.Read(trainer.ImagePath, 0, image.ContentLength);
                }

                manager.Update(trainer);
                return RedirectToAction("Index");
            }
            
            return View(trainer);
        }

        // GET: Trainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = manager.Return(id.Value);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            manager.Delete(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
