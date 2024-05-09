using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Street
{
    public int Id { get; set; }

    public string? StreetName { get; set; }

    public int? IdRegion { get; set; }

    public virtual Region? IdRegionNavigation { get; set; }

    public virtual ICollection<Ward> Wards { get; set; } = new List<Ward>();
}
