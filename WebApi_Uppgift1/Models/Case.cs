using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi_Uppgift1.Models
{
    public partial class Case
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ClientId { get; set; }
        public DateTime Created { get; set; }
        public string StatusId { get; set; }

        public virtual Client Client { get; set; }
        public virtual User User { get; set; }
    }
}
