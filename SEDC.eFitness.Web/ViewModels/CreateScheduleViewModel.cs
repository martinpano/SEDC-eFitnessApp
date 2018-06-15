using SEDC.eFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEDC.eFitness.Web.ViewModels
{
    public class CreateScheduleViewModel
    {

        public List<TrainingType> TrainingTypes { get; set; }

        public Schedule Schedule { get; set; }

    }
}