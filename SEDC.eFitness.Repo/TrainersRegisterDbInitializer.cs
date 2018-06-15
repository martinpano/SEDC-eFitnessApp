using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.eFitness.Repo
{
    internal class TrainersRegisterDbInitializer : DropCreateDatabaseAlways<TrainersRegisterDb>
    {
        protected override void Seed(TrainersRegisterDb context)
        {
            var trainingType = new Models.TrainingType()
            {
                Name = "CrossFit",
                TrainerId = 1
            };
            context.TrainingTypes.Add(trainingType);
            context.TrainingTypes.Add(new Models.TrainingType()
            {
                Name = "Bodybuilding",
                TrainerId = 2
            });

            context.Trainers.Add(new Models.Trainer()
            {
                FullName = "Dejan Jovanov",
                Phone = "070/234-565",
                Email = "dejan@efitness.com",
            });
            context.Trainers.Add(new Models.Trainer()
            {
                FullName = "Martin Panovski",
                Phone = "070/222-346",
                Email = "martin@efitness.com",
            });
            context.Trainers.Add(new Models.Trainer()
            {
                FullName = "Ivo Kostovski",
                Phone = "075/233-626",
                Email = "ivo@efitness.com",
            });
            context.Trainers.Add(new Models.Trainer()
            {
                FullName = "Saso Damovski",
                Phone = "078/233-789",
                Email = "dejan@efitness.com",
            });


            base.Seed(context);
        }
    }
}
