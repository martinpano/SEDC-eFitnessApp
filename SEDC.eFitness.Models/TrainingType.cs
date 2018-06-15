using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.eFitness.Models
{
    public class TrainingType
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "Please insert training type name")]
        [Display(Name = "Training type")]
        [StringLength(50)]
        public string Name { get; set; }


        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Short training description")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public byte[] TrainingTypeImagePath { get; set; }

        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }

        public Trainer Trainer { get; set; }
    }
}
