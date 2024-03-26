using System;
using System.Collections.Generic;

namespace TravelSiteAPI.Entities;

public partial class CartLine
{
    public int CartLineId { get; set; }
    public Guid CartId { get; set; }

    public int RoomAvailiabilityId { get; set; }

    public decimal Price { get; set; }

    public int? Adults { get; set; }

    public int? Children { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual RoomAvailiability RoomAvailiability { get; set; } = null!;
}
