using System;
using System.Collections.Generic;

namespace TravelSiteAPI.Entities;

public partial class Reservation
{
    public Guid ReservationId { get; set; }

    public string? UserId { get; set; }

    public string? GuestId { get; set; }

    public string? Notes { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Tax { get; set; }

    public decimal? Fees { get; set; }

    public decimal? Total { get; set; }
}
