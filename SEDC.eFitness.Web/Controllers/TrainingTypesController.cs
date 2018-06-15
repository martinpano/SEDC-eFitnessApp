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
using SEDC.eFitness.Web.ViewModels;

namespace SEDC.eFitness.Web.Controllers
{
    public class TrainingTypesController : Controller
    {
        TrainersManager manager = new TrainersManager();
        
        // GET: TrainingTypes
        public ActionResult Index()
        {

           
            var listOfTrainingTypes = manager.ReturnTrainingTypesWithTrainers();


            var viewModel = new IndexTrainingTypeViewModel()
            {
                TrainingTypes = listOfTrainingTypes,
            };
                
            return View(viewModel);
        }

        // GET: TrainingTypes/Details/5
        public ActionResult Details(int? id)
        {

            var listTtWithTrainers = manager.ReturnTrainingTypesWithTrainers();
            TrainingType trainingType = manager.ReturnTrainingType(id.Value);

            var viewModel = new DetailsTrainingTypesViewModel()
            {
                TrainingType = trainingType,
                TrainingTypes = listTtWithTrainers,
                Trainers = manager.ReturnAll()
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (trainingType == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: TrainingTypes/Create
        public ActionResult Create()
        {
            var trainersList = manager.ReturnAll();

            var viewModel = new CreateTrainingTypeViewModel()
            {
                Trainers = trainersList
            };
            return View(viewModel);
        }

        // POST: TrainingTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainingTypeId,Name,Description,TrainingTypeImagePath,TrainerId")] TrainingType trainingType, HttpPostedFileBase imageTrainingType)
        {
            if (ModelState.IsValid)
            {
                if (imageTrainingType != null)
                {
                    trainingType.TrainingTypeImagePath = new byte[imageTrainingType.ContentLength];
                    imageTrainingType.InputStream.Read(trainingType.TrainingTypeImagePath, 0, imageTrainingType.ContentLength);
                }
                manager.CreateTrainingType(trainingType);
                return RedirectToAction("Index");
            }

            return View(trainingType);
        }

        // GET: TrainingTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TrainingType trainingType = manager.ReturnTrainingType(id.Value);

            var listTtWithTrainers = manager.ReturnTrainingTypesWithTrainers();

            //TrainingType trainingTypeT = manager.ReturnTrainingType(id.Value);

            var viewModel = new CreateTrainingTypeViewModel()
            {
                TrainingType = trainingType,
                Trainers = manager.ReturnAll()
            };
            if (trainingType == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: TrainingTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,TrainingTypeImagePath,TrainerId")] TrainingType trainingType,  HttpPostedFileBase imageTrainingType)
        {
            if (ModelState.IsValid)
            {
                if (imageTrainingType != null)
                {
                    trainingType.TrainingTypeImagePath = new byte[imageTrainingType.ContentLength];
                    imageTrainingType.InputStream.Read(trainingType.TrainingTypeImagePath, 0, imageTrainingType.ContentLength);
                }

                manager.UpdateTrainingType(trainingType);
                return RedirectToAction("Index");
            }
            return View(trainingType);
        }

        // GET: TrainingTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingType trainingType = manager.ReturnTrainingType(id.Value);
            if (trainingType == null)
            {
                return HttpNotFound();
            }
            return View(trainingType);
        }

        // POST: TrainingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            manager.DeleteTrainingType(id);
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
