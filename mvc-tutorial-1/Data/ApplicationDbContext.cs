using Microsoft.EntityFrameworkCore;
using mvc_tutorial_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_tutorial_1.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Catergory { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }    
    }
}
