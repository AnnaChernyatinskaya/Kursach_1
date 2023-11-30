using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_1.Migrations
{
    public partial class Role
    {
        public Role()
        {
            this.Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string name_role { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
