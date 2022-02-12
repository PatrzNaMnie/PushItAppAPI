using System;
using System.Collections.Generic;

#nullable disable

namespace PushItAppAPI.Models
{
    public partial class Historical
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PushUps { get; set; }
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
    }
}
