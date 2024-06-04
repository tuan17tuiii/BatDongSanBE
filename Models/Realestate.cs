using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Realestate
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Describe { get; set; }

    public double? Price { get; set; }

    public int? Type { get; set; }

    public double? Acreage { get; set; }

    public int? Bedrooms { get; set; }

    public int? Bathrooms { get; set; }

    public bool? Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Region { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int? UsersellId { get; set; }

    public string? TransactionType { get; set; }

    public bool? Sold { get; set; }

    public bool? Expired { get; set; }

    public DateTime CreatedEnd { get; set; }

    public virtual ICollection<ImageRealestate> ImageRealestates { get; set; } = new List<ImageRealestate>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual TypeRealestate? TypeNavigation { get; set; }

    public virtual User? Usersell { get; set; }
}
