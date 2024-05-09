using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class ImageBatdongsan
{
    public int Id { get; set; }

    public int? BatdongsanId { get; set; }

    public string? UrlImage { get; set; }

    public virtual Batdongsan? Batdongsan { get; set; }
}
