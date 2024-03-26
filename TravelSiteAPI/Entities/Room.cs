using System;
using System.Collections.Generic;

namespace TravelSiteAPI.Entities;

public partial class Room
{
    public int RoomId { get; set; }

    public int HotelId { get; set; }

    public int NumBeds { get; set; }

    public string? RoomType { get; set; }

    public int? NumberNum { get; set; }

    public int? Floor { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual ICollection<RoomAvailiability> RoomAvailiabilities { get; set; } = new List<RoomAvailiability>();
}
