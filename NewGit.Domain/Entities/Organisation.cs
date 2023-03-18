using NewGit.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewGit.Domain.Entities
{
    public class Organisation : Auditable
    {
        public string Name { get; set; }
        public long CreatorId { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
