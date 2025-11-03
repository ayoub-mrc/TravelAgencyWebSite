using TravelAgency.Data.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<TravelAgencyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Minimal API ãËÇá Úáì Destinations
app.MapGet("/destinations", async (TravelAgencyDbContext db) =>
{
    var destinations = await db.Destinations.ToListAsync();
    return Results.Ok(destinations);
})
.WithName("GetDestinations");

app.MapPost("/destinations", async (TravelAgencyDbContext db, Destination dest) =>
{
    db.Destinations.Add(dest);
    await db.SaveChangesAsync();
    return Results.Created($"/destinations/{dest.Id}", dest);
});
app.MapControllers();

app.Run();
