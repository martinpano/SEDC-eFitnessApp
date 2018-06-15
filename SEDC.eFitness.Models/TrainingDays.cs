using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.eFitness.Models
{
    public enum TrainingDays
    {
        [Display(Name = "Monday")]
        Mon,
        [Display(Name = "Tuesday")]
        Tue,
        [Display(Name = "Wednesday")]
        Wed,
        [Display(Name = "Thursday")]
        Thu,
        [Display(Name = "Friday")]
        Fri,
        [Display(Name = "Saturday")]
        Sat,
        [Display(Name = "Sunday")]
        Sun
    }
}
