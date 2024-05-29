using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? BatdongsanId { get; set; }

    public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
