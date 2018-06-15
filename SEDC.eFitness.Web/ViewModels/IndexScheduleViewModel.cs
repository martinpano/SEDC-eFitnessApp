using SEDC.eFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEDC.eFitness.Web.ViewModels
{
    public class IndexScheduleViewModel
    {
        public List<Schedule> Schedules { get; set; }

        public List<TrainingType> TrainingTypes { get; set; }

        public List<Trainer> Trainers { get; set; }

        public TrainingType TrainingType { get; set; }

        public Schedule Schedule { get; set; }

        public Trainer Trainer { get; set; }



    }
}