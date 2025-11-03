using System;
using System.Collections.Generic;

namespace TravelAgency.Data.Models;

public partial class Booking
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int DestinationId { get; set; }

    public DateTime? BookingDate { get; set; }

    public int NumberOfPeople { get; set; }

    public decimal TotalPrice { get; set; }

    public string? Status { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Destination Destination { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
