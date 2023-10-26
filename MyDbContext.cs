using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using TechOilActive.Models;
using TechOilActive.Controllers;

namespace TechOilActive
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Proyecto> Proyecto { get; set; }

        public DbSet<Servicio> Servicio { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Trabajo> Trabajo { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=NOTEBOOK_VIR\\SQLEXPRESS01;Initial Catalog=TechOilActive; Persist Security Info=True;Integrated Security=True; Trusted_Connection=SSPI;MultipleActiveResultSets=true;Trust Server Certificate=true;");
        }
    }
}
