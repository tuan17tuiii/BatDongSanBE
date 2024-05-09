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

    public virtual Advertisement? Advertisement { get; set; }

    public virtual ICollection<Batdongsan> BatdongsanUserbuys { get; set; } = new List<Batdongsan>();

    public virtual ICollection<Batdongsan> BatdongsanUsersells { get; set; } = new List<Batdongsan>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Transaction> TransactionBuyers { get; set; } = new List<Transaction>();

    public virtual ICollection<Transaction> TransactionSellers { get; set; } = new List<Transaction>();
}
