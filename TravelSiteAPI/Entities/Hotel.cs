using System;
using System.Collections.Generic;

namespace TravelSiteAPI.Entities;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string Address { get; set; } = null!;

    public string Zipcode { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? HotelType { get; set; }

    public string? Email { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public virtual ICollection<HotelRating> HotelRatings { get; set; } = new List<HotelRating>();

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
