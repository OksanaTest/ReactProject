using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(
                DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<Region> Regions { get; set; }
        }
   }

