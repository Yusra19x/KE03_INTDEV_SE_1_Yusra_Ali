using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// DataAccess
builder.Services.AddDbContext<MatrixIncDbContext>(options =>
    options.UseSqlite("Data Source=MatrixInc.db"));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// ? Session support
builder.Services.AddDistributedMemoryCache(); // vereist voor session storage
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // sessie vervalt na 30 minuten
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// ? Initialiseer database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MatrixIncDbContext>();
    context.Database.EnsureCreated(); // Zorgt dat de tabellen bestaan
    MatrixIncDbInitializer.Initialize(context); // Vult de tabellen
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// ? Voeg session middleware toe vóór routing
app.UseSession();

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
