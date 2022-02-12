﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PushItAppAPI.Models
{
    public partial class User
    {
        public User()
        {
            Historicals = new HashSet<Historical>();
            PushUps = new HashSet<PushUp>();
        }

        public int Id { get; set; }
        public string HashCode { get; set; }

        public virtual ICollection<Historical> Historicals { get; set; }
        public virtual ICollection<PushUp> PushUps { get; set; }
    }
}
