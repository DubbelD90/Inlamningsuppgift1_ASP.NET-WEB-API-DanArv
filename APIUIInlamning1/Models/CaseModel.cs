using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIUIInlamning1.Models
{
    public class CaseModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ClientId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }
        public string StatusId { get; set; }

        public virtual ClientModel Client { get; set; }
        public virtual UserModel User { get; set; }
    }
}
