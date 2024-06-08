using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class ImageRealestate
{
    public int Id { get; set; }

    public int? RealestateId { get; set; }

    public string? UrlImage { get; set; }

    public int? Newsid { get; set; }

    public int? Userid { get; set; }

    public virtual News? News { get; set; }

    public virtual Realestate? Realestate { get; set; }

    public virtual User? User { get; set; }
}
