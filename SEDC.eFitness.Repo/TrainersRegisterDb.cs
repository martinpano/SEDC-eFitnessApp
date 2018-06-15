using SEDC.eFitness.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.eFitness.Repo
{
    internal class TrainersRegisterDb : DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<TrainingType> TrainingTypes { get; set; }

        public DbSet<Schedule> Schedules { get; set; }
    }
}
