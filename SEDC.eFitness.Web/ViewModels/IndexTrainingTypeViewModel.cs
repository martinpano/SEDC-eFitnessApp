using SEDC.eFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEDC.eFitness.Web.ViewModels
{
    public class IndexTrainingTypeViewModel
    {

        public List<TrainingType> TrainingTypes { get; set; }

        public TrainingType TrainingType { get; set; }

        public Trainer Trainer { get; set; }
    }
}