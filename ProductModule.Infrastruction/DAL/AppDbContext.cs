using Microsoft.EntityFrameworkCore;
using ProductModul.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModule.Infrastruction.DAL
{
    public class AppDbContext(DbContextOptions<AppDbContext> option) : DbContext (option)
    {
        public DbSet<Product> Products { get; set; }
    }
}
