using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_1.Migrations
{
    public partial class Tema
    {
        public Tema()
        {
            this.Requests = new HashSet<Requests>();
        }

        public int Id { get; set; }
        public string name_tema { get; set; }

        public virtual ICollection<Requests> Requests { get; set; }
    }
}
