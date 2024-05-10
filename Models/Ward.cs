using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Ward
{
    public int Id { get; set; }

    public string? WardName { get; set; }

    public int? IdStreet { get; set; }

    public virtual Street? IdStreetNavigation { get; set; }

    public virtual ICollection<Realestate> Realestates { get; set; } = new List<Realestate>();
}
