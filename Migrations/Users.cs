using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_1.Migrations
{
    public partial class Users
    {
        public Users()
        {
            this.Requests = new HashSet<Requests>();
        }

        public int Id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string middlename { get; set; }
        public string teltphone { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Requests> Requests { get; set; }
        //public virtual ICollection<Requests> Requests { get; set; }
        //public virtual Role Role { get; set; }
    }
}
