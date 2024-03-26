using System;
using System.Collections.Generic;

namespace TravelSiteAPI.Entities;

public partial class Cart
{
    public Guid CartId { get; set; }

    public string? UserId { get; set; }

    public string? GuestId { get; set; }
}
