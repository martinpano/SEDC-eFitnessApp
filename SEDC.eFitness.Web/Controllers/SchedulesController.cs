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
    public class SchedulesController : Controller
    {

        TrainersManager manager = new TrainersManager();


        // GET: Schedules
        public ActionResult Index()
        {

            var viewModel = new IndexScheduleViewModel()
            {
                Schedules = manager.ReturnAllSchedules(),
                TrainingTypes = manager.ReturnAllTrainingTypes(),
                Trainers = manager.ReturnAll()
            };

            return View(viewModel);
        }

        // GET: Schedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = manager.ReturnSchedule(id.Value);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: Schedules/Create
        public ActionResult Create()
        {
            var listOfTrainingTypes = manager.ReturnTrainingTypesWithTrainers();
         


            var createViewModel = new CreateScheduleViewModel()
            {
                TrainingTypes = listOfTrainingTypes,
            };

            return View(createViewModel);
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TrainingDay,StartTime,EndTime,TrainingTypeId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                manager.CreateSchedule(schedule);
                return RedirectToAction("Index");
            }

            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public ActionResult Edit(int? id)
        {
            var listOfTrainingTypes = manager.ReturnTrainingTypesWithTrainers();
            
            Schedule schedule = manager.ReturnSchedule(id.Value);

            var createViewModel = new CreateScheduleViewModel()
            {
                TrainingTypes = listOfTrainingTypes,
                Schedule = schedule
            };


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(createViewModel);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrainingDay,StartTime,EndTime,TrainingTypeId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                manager.UpdateSchedule(schedule);
                return RedirectToAction("Index");
            }
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = manager.ReturnSchedule(id.Value);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            manager.DeleteSchedule(id);
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
