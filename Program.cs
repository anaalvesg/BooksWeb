using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// middleware
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BookDatabase>(options => options.UseInMemoryDatabase("db"));

var app = builder.Build();

// app.MapControllerRoute("default", "/{controller}/{action}");
app.MapControllerRoute("default", "/{controller=Book}/{action=Read}/{id?}"); // o ? significa q pode ser null

app.Run();