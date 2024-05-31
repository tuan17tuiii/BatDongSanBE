using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class TypeRealestate
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Realestate> Realestates { get; set; } = new List<Realestate>();
}
