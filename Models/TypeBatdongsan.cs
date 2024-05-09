using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class TypeBatdongsan
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Batdongsan> Batdongsans { get; set; } = new List<Batdongsan>();
}
