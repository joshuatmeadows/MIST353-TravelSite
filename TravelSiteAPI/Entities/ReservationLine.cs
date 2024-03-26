using System;
using System.Collections.Generic;

namespace TravelSiteAPI.Entities;

public partial class ReservationLine
{
    public Guid ReservationId { get; set; }

    public int RoomId { get; set; }

    public DateOnly AvDate { get; set; }

    public decimal Price { get; set; }

    public int? Adults { get; set; }

    public int? Children { get; set; }

    public string? Notes { get; set; }

    public string? ReservationStatus { get; set; }

    public virtual Reservation Reservation { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
