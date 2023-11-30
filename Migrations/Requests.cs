using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_1.Migrations
{
    public partial class Requests
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int TemaId { get; set; }
        public int StatusId { get; set; }
        public System.DateTime date_start { get; set; }
        public System.DateTime date_finish { get; set; }
        public string description { get; set; }

        public virtual Users Users { get; set; }
        public virtual Tema Tema { get; set; }
        public virtual Status Status { get; set; }
    }
}
