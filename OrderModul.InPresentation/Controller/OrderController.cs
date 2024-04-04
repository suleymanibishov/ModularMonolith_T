using Microsoft.AspNetCore.Mvc;
using StockModul.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderModul.InPresentation.Controller
{

    public class OrderDto
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromServices] IShredStockServis stockService,OrderDto orderDto)
        {
            if (await stockService.PrductStockCountAsync(orderDto.ProductId) < orderDto.Count)
                 throw new Exception($"Stokda {orderDto.Count} qeder mehsul yoxdu");
            await stockService.AddProductAsync(new AddStock(
                    ProductId: orderDto.ProductId,
                    Count: (-1 * orderDto.Count)
                ));
            return Ok(await stockService.PrductStockCountAsync(orderDto.ProductId));
        }
    }
}
