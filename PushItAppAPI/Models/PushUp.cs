using System;
using System.Collections.Generic;

#nullable disable

namespace PushItAppAPI.Models
{
    public partial class PushUp
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompletedPushUps { get; set; }

        public virtual User User { get; set; }
    }
}
