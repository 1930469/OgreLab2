using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Cuisine
{
    public class Contexte : DbContext
    {
        public virtual DbSet<Plat> Plats { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => 
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PlatBD;Trusted_Connection=True;");
    }
}
