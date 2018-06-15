using SEDC.eFitness.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.eFitness.Repo
{
    public class TrainersRepo : IDisposable
    {
        private TrainersRegisterDb db;

        public TrainersRepo()
        {
            db = new TrainersRegisterDb();
        }
        
        public static void InitializeDatabase()
        {
            Database.SetInitializer(new TrainersRegisterDbInitializer());
        }

        public void Add(Trainer trainer)
        {
            db.Trainers.Add(trainer);
            db.SaveChanges();
        }

        public List<Trainer> GetAll()
        {
            try
            {
                return db.Trainers.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    
        public Trainer Find(int id)
        {
            return db.Trainers.SingleOrDefault(t => t.Id == id);
        }

        public void Edit(Trainer trainer)
        {
            db.Entry(trainer).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            db.Trainers.Remove(trainer);
            db.SaveChanges();
        }


        //CRUD Methods for Training Type Model


        public void AddTrainingType(TrainingType tp)
        {
            db.TrainingTypes.Add(tp);
            db.SaveChanges();
        }


        public TrainingType FindTp(int id)
        {
            return db.TrainingTypes.SingleOrDefault(tp => tp.Id == id);
        }

        public void EditTrainingType(TrainingType tp)
        {
            db.Entry(tp).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveTrainingType(int id)
        {
            TrainingType tp = db.TrainingTypes.Find(id);
            db.TrainingTypes.Remove(tp);
            db.SaveChanges();
        }



        public List<TrainingType> GetAllTrainingTypes()
        {
            return db.TrainingTypes.ToList();
        }


        public List<TrainingType> GetAllTrainingTypesWithTrainers()
        {
            try
            {
                var query = db.TrainingTypes.Include(x => x.Trainer).ToList();
                return query;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //CRUD Methods for Schedule Model

        public void AddSchedule(Schedule sc)
        {
            db.Schedules.Add(sc);
            db.SaveChanges();
        }


        public Schedule FindSchedule(int id)
        {
            return db.Schedules.SingleOrDefault(s => s.Id == id);
        }


        public void EditSchedule(Schedule sc)
        {
            db.Entry(sc).State = EntityState.Modified;
            db.SaveChanges();
        }


        public void RemoveSchedule(int id)
        {
            Schedule sc = db.Schedules.Find(id);
            db.Schedules.Remove(sc);
            db.SaveChanges();
        }

        public List<Schedule> GetAllSchedules()
        {
            return db.Schedules.ToList();
        }
         

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
