using System;
using System.Collections.Generic;

namespace TravelSiteAPI.Entities;

public partial class RoomAvailiability
{
    public int RoomId { get; set; }

    public DateOnly AvDate { get; set; }

    public decimal Price { get; set; }

    public int RoomAvailiabilityId { get; set; }

    public virtual Room Room { get; set; } = null!;
}
