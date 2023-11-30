using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Kursach_1.Migrations
{
    public partial class ApplicationContext : DbContext
    {
        public DbSet<Users> User { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<Tema> Tema { get; set; }
        public DbSet<Status> Status { get; set; }

        public ApplicationContext()
        {

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ConfigurationManager.AppSettings["ConnectionString"]);
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
    }
}
