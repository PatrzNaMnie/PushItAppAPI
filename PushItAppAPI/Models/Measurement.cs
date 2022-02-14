using System;
using System.Collections.Generic;

#nullable disable

namespace PushItAppAPI.Models
{
    public partial class Measurement
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Bmi { get; set; }
        public decimal Bmr { get; set; }
        public decimal Chest { get; set; }
        public decimal Arms { get; set; }
        public decimal Waist { get; set; }

        public virtual User User { get; set; }
    }
}
