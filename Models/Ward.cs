using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Ward
{
    public int Id { get; set; }

    public string? WardName { get; set; }

    public int? IdStreet { get; set; }

    public virtual ICollection<Batdongsan> Batdongsans { get; set; } = new List<Batdongsan>();

    public virtual Street? IdStreetNavigation { get; set; }
}
