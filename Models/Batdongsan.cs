using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Batdongsan
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Describe { get; set; }

    public double? Price { get; set; }

    public int? Type { get; set; }

    public double? Acreage { get; set; }

    public int? Bedrooms { get; set; }

    public int? Bathrooms { get; set; }

    public bool? Status { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public int? RegionId { get; set; }

    public int? CityIt { get; set; }

    public int? WardId { get; set; }

    public int? StreetId { get; set; }

    public int? UserbuyId { get; set; }

    public int? UsersellId { get; set; }

    public virtual ICollection<ImageBatdongsan> ImageBatdongsans { get; set; } = new List<ImageBatdongsan>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual TypeBatdongsan? TypeNavigation { get; set; }

    public virtual User? Userbuy { get; set; }

    public virtual User? Usersell { get; set; }

    public virtual Ward? Ward { get; set; }
}
