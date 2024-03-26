﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelSiteAPI.Entities;

public partial class HotelRating
{
    [Key]
    public int HotelRatingsId { get; set; }

    public int HotelId { get; set; }

    public int Rating { get; set; }

    public string? UserId { get; set; }

    public string? Comments { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
