using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProjectContext : DbContext
    {

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocaldb;Database=TravelDemoProject;Trusted_Connection = true");
            }

            DbSet<About> Abouts { get; set; }
            DbSet<FAQ> FAQs { get; set; }
            DbSet<Travel> Travels { get; set; }
            DbSet<Category> Categories { get; set; }


    }
}
