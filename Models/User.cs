using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? RoleId { get; set; }

    public int? AdvertisementId { get; set; }

    public bool? Status { get; set; }

    public string? SecurityCode { get; set; }

    public string? Avatar { get; set; }

    public bool? Statusupdate { get; set; }

    public virtual Advertisement? Advertisement { get; set; }

    public virtual ICollection<ImageRealestate> ImageRealestates { get; set; } = new List<ImageRealestate>();

    public virtual ICollection<Realestate> Realestates { get; set; } = new List<Realestate>();

    public virtual ICollection<Remain> Remains { get; set; } = new List<Remain>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
