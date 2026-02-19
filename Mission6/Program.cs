using Microsoft.EntityFrameworkCore;
using Mission6.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the SQLite DbContext
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlite(builder.Configuration["ConnectionStrings:MovieConnection"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Add my 3 favorite movies
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MovieDbContext>();
    db.Database.EnsureCreated();

    if (!db.Movies.Any())
    {
        db.Movies.AddRange(
            new Mission6.Models.Movie
            {
                Title = "Pride and Prejudice",
                Category = "Romance/Drama",
                Year = "2005",
                Director = "Joe Wright",
                Rating = "PG",
                Edited = false,
                Notes = "Plex"
            },
            new Mission6.Models.Movie
            {
                Title = "The Hunger Games",
                Category = "Action/Sci-Fi",
                Year = "2012",
                Director = "Gary Ross",
                Rating = "PG-13",
                Edited = false,
                Notes = "Plex"
            },
            new Mission6.Models.Movie
            {
                Title = "Les Misérables",
                Category = "Musical/Drama",
                Year = "2012",
                Director = "Tom Hooper",
                Rating = "PG-13",
                Edited = false,
                Notes = "Plex"
            }
        );
        db.SaveChanges();
    }
} 

app.Run();