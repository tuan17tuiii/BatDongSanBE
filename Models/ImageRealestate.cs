using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class ImageRealestate
{
    public int Id { get; set; }

    public int? RealestateId { get; set; }

    public string UrlImage { get; set; } = null!;

    public int? Newid { get; set; }

    public virtual News? New { get; set; }

    public virtual Realestate? Realestate { get; set; }
}
