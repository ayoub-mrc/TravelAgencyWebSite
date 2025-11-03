using System;
using System.Collections.Generic;

namespace TravelAgency.Data.Models;

public partial class VwBookingDetail
{
    public int BookingId { get; set; }

    public string Customer { get; set; } = null!;

    public string Destination { get; set; } = null!;

    public int NumberOfPeople { get; set; }

    public decimal TotalPrice { get; set; }

    public string? Status { get; set; }

    public DateTime? BookingDate { get; set; }
}
