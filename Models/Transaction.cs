using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public int? IdUser { get; set; }

    public int? IdAdv { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? Price { get; set; }

    public virtual Advertisement? IdAdvNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
