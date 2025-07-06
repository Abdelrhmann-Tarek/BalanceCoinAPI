using BalanceCoinAPI.Application.Interfaces;
using BalanceCoinAPI.Application.Services;
using BalanceCoinAPI.Infrastructure.DAL;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICategoryService, CategoryService>();//Dependency injection
builder.Services.AddScoped<IIncomeService, IncomeService>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IBalanceService, BalanceService>();

//iii

//ننن


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseExceptionHandler(errorApp =>   //HAndling (without try .. catch )
{
    errorApp.Run(async context =>
    {
        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        var error = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (error != null)
        {
            logger.LogError(error, "Unhandled exception occurred");
        }

        context.Response.StatusCode = 500;
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("An unexpected error occurred.We will fix it..gitg");
    });
});
//HAndling (without try .. catch ) onl




app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();

