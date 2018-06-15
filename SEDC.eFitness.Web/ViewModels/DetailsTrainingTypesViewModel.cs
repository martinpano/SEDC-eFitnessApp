using SEDC.eFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEDC.eFitness.Web.ViewModels
{
    public class DetailsTrainingTypesViewModel
    {
        public TrainingType TrainingType { get; set; }

        public List<TrainingType> TrainingTypes { get; set; }

        public List<Trainer> Trainers { get; set; }


    }
}