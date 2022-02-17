using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PushItAppAPI.Models
{
    public partial class Measurement
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Height is required")]
        public decimal Height { get; set; }

        [Required(ErrorMessage = "Bmi is required")]
        public decimal Bmi { get; set; }

        [Required(ErrorMessage = "Bmr is required")]
        public decimal Bmr { get; set; }

        [Required(ErrorMessage = "Chest is required")]
        public decimal Chest { get; set; }

        [Required(ErrorMessage = "Arms is required")]
        public decimal Arms { get; set; }

        [Required(ErrorMessage = "Waist is required")]
        public decimal Waist { get; set; }

        public virtual User User { get; set; }
    }
}
