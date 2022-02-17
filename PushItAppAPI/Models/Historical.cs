using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PushItAppAPI.Models
{
    public partial class Historical
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "PushUps is required")]
        public int PushUps { get; set; }

        [Required(ErrorMessage = "PushUps is required"), DataType(DataType.DateTime, ErrorMessage = "Enter date in correct format")]
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
    }
}
