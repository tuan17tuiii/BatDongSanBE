using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Region
{
    public int Id { get; set; }

    public string? RegionName { get; set; }

    public int? IdCity { get; set; }

    public virtual City? IdCityNavigation { get; set; }

    public virtual ICollection<Street> Streets { get; set; } = new List<Street>();
}
