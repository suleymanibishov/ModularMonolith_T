using Microsoft.EntityFrameworkCore;
using StockModul.Domain.Entity;
using StockModul.Infrastruction.DAL;
using StockModul.Shared;

namespace StockModul.Application.Servises
{
    public class Servise(AppDbContext db):IShredStockServis
    {
        public async Task AddProductAsync(AddStock stock)
        {

            Stock? _stock = await db.Stocks.FirstOrDefaultAsync(s => s.ProductId == stock.ProductId);
            if (_stock == null)
            {
                _stock = new Stock()
                {
                    ProductId = stock.ProductId,
                    Count = stock.Count,
                };
                await db.Stocks.AddAsync(_stock);
            }
            else
                _stock.Count += stock.Count;
            
            await db.SaveChangesAsync();


        }

        public async Task A()
        {

        }

        public async Task<int> PrductStockCountAsync(int id)
        {
            var e = await db.Stocks.FirstOrDefaultAsync(x => x.ProductId == id);
            if (e == null) throw new Exception("Bu mehsul yoxdur");
            return e.Count;
        }
    }
}
