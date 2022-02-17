using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PushItAppAPI.Models
{
    public partial class User
    {
        public User()
        {
            Historicals = new HashSet<Historical>();
            Measurements = new HashSet<Measurement>();
            PushUps = new HashSet<PushUp>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "HashCode is required"), MaxLengthAttribute(8, ErrorMessage = "HashCode can be 8 digit long")]
        public string HashCode { get; set; }

        public virtual ICollection<Historical> Historicals { get; set; }
        public virtual ICollection<Measurement> Measurements { get; set; }
        public virtual ICollection<PushUp> PushUps { get; set; }
    }
}
