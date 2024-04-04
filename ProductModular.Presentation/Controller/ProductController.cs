using Contract;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductModul.Domain.Entity;
using ProductModule.Infrastruction.DAL;
using StockModul.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModular.Presentation.Controller
{
    public class ProductCreatDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int StockCount { get; set;}

    }
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(AppDbContext db) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] IShredStockServis stockService,ProductCreatDto productCreatDto)
        {
            var p = new Product
            {
                Title = productCreatDto.Title,
                Description = productCreatDto.Description,
                Price = productCreatDto.Price,
            };

            await db.Products.AddAsync(p);
            await db.SaveChangesAsync();

            //await mediator.Send(cmnd);

            await stockService.AddProductAsync(new AddStock(
                    ProductId: p.Id,
                    Count: productCreatDto.StockCount
                ));



            return Ok();
        }
    }
    
}
