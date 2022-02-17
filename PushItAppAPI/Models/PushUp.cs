using PushItAppAPI.ModelValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PushItAppAPI.Models
{
    public partial class PushUp
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }

        [Required]
        public int CompletedPushUps { get; set; }

        public virtual User User { get; set; }
    }
}
