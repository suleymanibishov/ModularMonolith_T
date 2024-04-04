using Microsoft.EntityFrameworkCore;
using StockModul.Domain.Entity;

namespace StockModul.Infrastruction.DAL
{
    public class AppDbContext(DbContextOptions<AppDbContext> option) : DbContext (option)
    {
        public DbSet<Stock> Stocks { get; set; }
    }
}
