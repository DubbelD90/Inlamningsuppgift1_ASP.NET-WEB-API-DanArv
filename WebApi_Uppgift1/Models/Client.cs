using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi_Uppgift1.Models
{
    public partial class Client
    {
        public Client()
        {
            Cases = new HashSet<Case>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
    }
}
