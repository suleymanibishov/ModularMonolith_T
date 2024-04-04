using Contract;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using StockModul.Shared;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


#region Mediatr
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddTransient<IRequestHandler<AddProductCommand>, AddProductCommandHandler>();
builder.Services.AddTransient<INotificationHandler<ProductCreatedEvent>, ProductCreatedEventHandler>();
#endregion

#region Shared Servisler
builder.Services.AddScoped<IShredStockServis, StockModul.Application.Servises.Servise>();
#endregion

#region add Controller

builder.Services.AddControllers()
    .AddApplicationPart(typeof(ProductModular.Presentation.Controller.ProductM_AssemblyRef).Assembly);
builder.Services.AddControllers()
    .AddApplicationPart(typeof(ProductModular.Presentation.Controller.OrderM_AssemblyRef).Assembly);

#endregion

#region Db
builder.Services.AddDbContext<ProductModule.Infrastruction.DAL.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddDbContext<StockModul.Infrastruction.DAL.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
#endregion

#region Others
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion