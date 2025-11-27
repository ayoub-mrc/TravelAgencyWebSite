using System;
using System.Collections.Generic;

namespace TravelAgency.Data.Models;

public partial class Destination
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int AvailableSeats { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
