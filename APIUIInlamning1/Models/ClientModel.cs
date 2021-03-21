using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIUIInlamning1.Models
{
    public class ClientModel
    {
        public ClientModel()
        {
            Cases = new HashSet<CaseModel>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<CaseModel> Cases { get; set; }
    }
}
