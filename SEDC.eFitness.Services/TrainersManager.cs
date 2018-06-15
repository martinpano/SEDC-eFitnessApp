using SEDC.eFitness.Models;
using SEDC.eFitness.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.eFitness.Services
{
   public class TrainersManager
    {
        public static void InitializeDatabase()
        {
            TrainersRepo.InitializeDatabase();
        }

        public void Create(Trainer trainer)
        {
            using (var dataAccess = new TrainersRepo())
            {
                dataAccess.Add(trainer);
            }
        }

        public List<Trainer> ReturnAll()
        {
            using (var dataAccess = new TrainersRepo())
            {
               return dataAccess.GetAll();
            }
        }

        public List<TrainingType> ReturnTrainingTypesWithTrainers()
        {
            using (var dataAccess = new TrainersRepo())
            {
                return dataAccess.GetAllTrainingTypesWithTrainers();
            }
        }


        public Trainer Return(int trainerId)
        {
            using (var dataAccess = new TrainersRepo())
            {
                return dataAccess.Find(trainerId);
            }
        }

        public void Update(Trainer trainer)
        {
            using (var dataAccess = new TrainersRepo())
            {
                dataAccess.Edit(trainer);
            }
        }

        public void Delete(int trainerId)
        {
            using (var dataAccess = new TrainersRepo())
            {
                dataAccess.Remove(trainerId);
            }
        }

    //CRUD for Training Type Model 
        
        public void CreateTrainingType(TrainingType trainingType)
        {
            using (var dataAccess = new TrainersRepo())
            {
                dataAccess.AddTrainingType(trainingType);
            }
        }

        public List<TrainingType> ReturnAllTrainingTypes()
        {
            using (var dataAccess = new TrainersRepo())
            {
                return dataAccess.GetAllTrainingTypes();
            }
        }


        public TrainingType ReturnTrainingType(int trainingTypeId)
        {
            using (var dataAccess = new TrainersRepo())
            {
                return dataAccess.FindTp(trainingTypeId);
            }
        }

        public void UpdateTrainingType(TrainingType trainingType)
        {
            using (var dataAccess = new TrainersRepo())
            {
                dataAccess.EditTrainingType(trainingType);
            }
        }

        public void DeleteTrainingType(int trainingTypeId)
        {
            using (var dataAccess = new TrainersRepo())
            {
                dataAccess.RemoveTrainingType(trainingTypeId);
            }
        }


        //CRUD for Schedule Model 

        public void CreateSchedule(Schedule schedule)
        {
            using (var dataAccess = new TrainersRepo())
            {
                dataAccess.AddSchedule(schedule);
            }
        }

        public List<Schedule> ReturnAllSchedules()
        {
            using (var dataAccess = new TrainersRepo())
            {
                return dataAccess.GetAllSchedules();
            }
        }

        public Schedule ReturnSchedule(int scheduleId)
        {
            using (var dataAccess = new TrainersRepo())
            {
                return dataAccess.FindSchedule(scheduleId);
            }
        }


        public void UpdateSchedule(Schedule schedule)
        {
            using (var dataAccess = new TrainersRepo())
            {
                dataAccess.EditSchedule(schedule);
            }
        }

        public void DeleteSchedule(int scheduleId)
        {
            using (var dataAccess = new TrainersRepo())
            {
                dataAccess.RemoveSchedule(scheduleId);
            }
        }
    }
}
