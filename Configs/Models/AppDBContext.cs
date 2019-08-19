using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configs.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Employees> DbSetEmployees{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>().HasData(
                new Employees
                {
                    Id=2,
                    Name="mwangi",
                    Department=Dept.IT,
                    Email="sa@gmail.com"
                }
                );
        }
    }
}

