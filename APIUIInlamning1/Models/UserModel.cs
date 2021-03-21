using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIUIInlamning1.Models
{
    public class UserModel
    {
        public UserModel()
        {
            Cases = new HashSet<CaseModel>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<CaseModel> Cases { get; set; }
    }
}
