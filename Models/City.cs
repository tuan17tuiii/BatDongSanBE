using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class City
{
    public int Id { get; set; }

    public string? CityName { get; set; }

    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();
}
