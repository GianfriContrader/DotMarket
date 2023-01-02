global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using  DotMarket.Context;
global using Microsoft.AspNetCore.Identity;
global using DotMarket.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//aggiungo db context e setto la stringa di connessione
builder.Services.AddDbContext<DotContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

// ignietto il servizio di identity
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DotContext>().AddDefaultTokenProviders();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

// middleware per autenticazione
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
