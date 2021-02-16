using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Cuisine
{
    class Contexte : DbContext
    {
        public DbSet<Plat> Plats { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => 
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PlatBD;Trusted_Connection=True;");
    }
}
