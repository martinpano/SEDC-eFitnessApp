using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.eFitness.Models
{
    public class Trainer
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide full name")]
        [Display(Name = "Full Name")]
        [StringLength(50)]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Please provide phone number")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please provide e-main address")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\S+@\S+$")]
        public string Email { get; set; }

        [Display(Name = "Short Biography")]
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string ShotrBiography { get; set; }

        [Display(Name = "Image")]
        public byte[] ImagePath { get; set; }
    }
}
