global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using DotMarket.Context;
global using Microsoft.AspNetCore.Identity;
global using DotMarket.Models;
global using DotMarket.DTO;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//aggiungo db context e setto la stringa di connessione.
builder.Services.AddDbContext<DotContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

// ignietto il servizio di identity.
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DotContext>().AddDefaultTokenProviders();

// gestisco il cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = ".AspNetCore.Identity.Application";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.SlidingExpiration = true;
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
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
