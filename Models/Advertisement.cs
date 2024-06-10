using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Advertisement
{
    public int Id { get; set; }

    public string? AdvertisementName { get; set; }

    public int? Price { get; set; }

    public int? Quantitydate { get; set; }

    public DateTime? Time { get; set; }

    public bool? Status { get; set; }

    public int? Quantitynews { get; set; }

    public virtual ICollection<Remain> Remains { get; set; } = new List<Remain>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
