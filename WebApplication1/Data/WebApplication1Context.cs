using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context (DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.Area> Areas { get; set; } = default!;

        public DbSet<WebApplication1.Models.Unit>? Units { get; set; }

        public DbSet<WebApplication1.Models.Location>? Locations { get; set; }
    }
}
