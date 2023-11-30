using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_1.Migrations
{
    public partial class Status
    {
        public Status()
        {
            this.Requests = new HashSet<Requests>();
        }

        public int ID { get; set; }
        public string name_status { get; set; }

        public virtual ICollection<Requests> Requests { get; set; }
    }
}
