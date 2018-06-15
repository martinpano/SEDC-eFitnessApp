using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.eFitness.Models
{
    public class Schedule
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Training days")]
        public TrainingDays TrainingDay { get; set; }

        [Display(Name = "Start time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Display(Name = "End time")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }


        [ForeignKey("TrainingType")]
        public int TrainingTypeId { get; set; }

        public TrainingType TrainingType { get; set; }

    }
}
