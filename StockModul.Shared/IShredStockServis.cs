using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockModul.Shared
{
    //dto
    public record AddStock(int ProductId, int Count);

    public interface IShredStockServis
    {
        Task AddProductAsync(AddStock stock);
        Task<int> PrductStockCountAsync(int id);        
    }
}
