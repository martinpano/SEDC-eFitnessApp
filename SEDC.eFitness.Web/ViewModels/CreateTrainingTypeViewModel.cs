using SEDC.eFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEDC.eFitness.Web.ViewModels
{
    public class CreateTrainingTypeViewModel
    {
        public List<Trainer> Trainers { get; set; }

        public TrainingType TrainingType { get; set; }
    }
}