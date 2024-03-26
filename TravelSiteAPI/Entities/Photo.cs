using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelSiteAPI.Entities;

public partial class Photo
{
    [Key]
    public int HotelPhotoId { get; set; }

    public int HotelId { get; set; }

    public byte[]? Photo1 { get; set; }

    public bool? IsPrimary { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
