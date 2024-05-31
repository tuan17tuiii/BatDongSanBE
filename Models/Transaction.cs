using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public int? BuyerId { get; set; }

    public int? SellerId { get; set; }

<<<<<<< HEAD
    public DateOnly? TransactionDate { get; set; }
=======
    public DateTime? TransactionDate { get; set; }
>>>>>>> 37d2c917c23e31316f7663b181e188cf5e153c10

    public double? Amount { get; set; }

    public int? RealestateId { get; set; }

    public virtual User? Buyer { get; set; }

    public virtual Realestate? Realestate { get; set; }

    public virtual User? Seller { get; set; }
}
